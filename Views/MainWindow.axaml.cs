using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using FastShareYourLog.ViewModels;
using System;
using System.Threading.Tasks;

namespace FastShareYourLog.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);

        // 检查命令行参数
        var args = Environment.GetCommandLineArgs();
        if (args.Length > 1)
        {
            // 有文件参数，执行上传
            _ = HandleFileUploadAsync(args[1]);
        }
    }

    private async Task HandleFileUploadAsync(string filePath)
    {
        await MainWindowViewModel.HandleCommandLineAsync(new[] { filePath });

        // 上传完成后关闭窗口
        await Task.Delay(2000);
        Close();
    }

    // 标题栏拖动
    private void OnTitleBarPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
        {
            BeginMoveDrag(e);
        }
    }
}
