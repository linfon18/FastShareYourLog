using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;

namespace FastShareYourLog.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private bool _isEnabled;

    [ObservableProperty]
    private string _statusText = "就绪 - 点击开启按钮注册右键菜单";

    [ObservableProperty]
    private string _customWord = "加载中...";

    private const string ApiUrl = "https://api.mclo.gs/1/log";
    private const string AlertUrl = "https://gitee.com/linfon18/minecraft-connect-tool-api/raw/master/fastshareyourlogalert";
    private const string RegistryKeyPath = @"Software\Classes\SystemFileAssociations\.log\shell\ShareLog";
    private const string RegistryCommandPath = @"Software\Classes\SystemFileAssociations\.log\shell\ShareLog\command";

    public MainWindowViewModel()
    {
        CheckRegistryStatus();
        _ = LoadCustomWordAsync();
    }

    private async Task LoadCustomWordAsync()
    {
        try
        {
            using var client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(10);
            var content = await client.GetStringAsync(AlertUrl);
            CustomWord = content.Trim();
        }
        catch (Exception ex)
        {
            CustomWord = $"加载失败: {ex.Message}";
        }
    }

    private void CheckRegistryStatus()
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            IsEnabled = false;
            StatusText = "非Windows系统 - 右键菜单功能不可用";
            return;
        }

        try
        {
            using var key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(RegistryKeyPath);
            IsEnabled = key != null;
            StatusText = IsEnabled ? "右键菜单已启用" : "就绪 - 点击开启按钮注册右键菜单";
        }
        catch (Exception ex)
        {
            IsEnabled = false;
            StatusText = $"检测状态失败: {ex.Message}";
        }
    }

    [RelayCommand]
    private void Enable()
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            StatusText = "非Windows系统 - 无法注册右键菜单";
            return;
        }

        try
        {
            // 创建右键菜单项
            using var shellKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(RegistryKeyPath);
            shellKey?.SetValue("", "分享此日志");
            shellKey?.SetValue("Icon", Process.GetCurrentProcess().MainModule?.FileName ?? "");

            // 创建命令
            using var commandKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(RegistryCommandPath);
            var exePath = Process.GetCurrentProcess().MainModule?.FileName ?? "";
            commandKey?.SetValue("", $"\"{exePath}\" \"%1\"");

            IsEnabled = true;
            StatusText = "右键菜单已启用 - 可以右键.log文件分享";
        }
        catch (Exception ex)
        {
            StatusText = $"启用失败: {ex.Message}";
        }
    }

    [RelayCommand]
    private void Disable()
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            StatusText = "非Windows系统 - 无需操作";
            return;
        }

        try
        {
            // 删除注册表项
            Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree(RegistryKeyPath, false);
            IsEnabled = false;
            StatusText = "右键菜单已禁用";
        }
        catch (Exception ex)
        {
            StatusText = $"禁用失败: {ex.Message}";
        }
    }

    [RelayCommand]
    private void Close()
    {
        if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime lifetime)
        {
            lifetime.Shutdown();
        }
    }

    // 显示消息框（跨平台）
    private static void ShowMessageBox(string title, string message)
    {
#if WINDOWS
        // 使用现代Windows消息框样式
        var result = MessageBoxW(IntPtr.Zero, message, title, 0x40 | 0x0); // MB_ICONINFORMATION | MB_OK
#else
        Console.WriteLine($"[{title}] {message}");
#endif
    }

#if WINDOWS
    [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
    private static extern int MessageBoxW(IntPtr hWnd, string text, string caption, uint type);
#endif

    // 处理命令行参数上传日志
    public static async Task HandleCommandLineAsync(string[] args)
    {
        if (args.Length < 1) return;

        var filePath = args[0];
        if (!File.Exists(filePath) || !filePath.EndsWith(".log", StringComparison.OrdinalIgnoreCase))
        {
            ShowMessageBox("错误", "无效的文件路径或不是.log文件");
            return;
        }

        try
        {
            var logContent = await File.ReadAllTextAsync(filePath, Encoding.UTF8);
            var fileName = Path.GetFileName(filePath);

            using var client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(30);

            var requestBody = new
            {
                content = logContent,
                source = "FastShareYourLog"
            };

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(ApiUrl, content);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                ShowMessageBox("上传失败", $"上传失败: HTTP {(int)response.StatusCode}");
                return;
            }

            var result = JsonNode.Parse(responseBody);
            if (result?["success"]?.GetValue<bool>() == true)
            {
                var url = result["url"]?.GetValue<string>() ?? "";
                
                // 复制到剪贴板
#if WINDOWS
                try
                {
                    System.Windows.Forms.Clipboard.SetText(url);
                }
                catch { }
#endif

                // 显示成功消息框
                var message = $"日志文件已成功分享\n访问地址: {url}\n已自动复制入剪切板，日志有效期3个月";
                ShowMessageBox("云日志分享", message);

                // 打开浏览器
                try
                {
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                }
                catch { }
            }
            else
            {
                var error = result?["error"]?.GetValue<string>() ?? "未知错误";
                ShowMessageBox("上传失败", $"上传失败: {error}");
            }
        }
        catch (Exception ex)
        {
            ShowMessageBox("上传失败", $"上传失败: {ex.Message}");
        }
    }
}
