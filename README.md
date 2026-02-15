# 📋 FastShareYourLog

> 🚀 一键分享日志文件到 mclo.gs 的跨平台工具

[![C#](https://img.shields.io/badge/C%23-9.0-239120?logo=c-sharp)](https://docs.microsoft.com/dotnet/csharp/)
[![Avalonia UI](https://img.shields.io/badge/Avalonia%20UI-11.3-8E44AD?logo=dotnet)](https://avaloniaui.net/)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)
[![Release](https://img.shields.io/github/v/release/linfon18/FastShareYourLog?include_prereleases)](https://github.com/linfon18/FastShareYourLog/releases)

---

## ✨ 功能特性

| 功能 | 描述 |
|------|------|
| 📤 一键上传 | 右键点击 `.log` 文件即可上传到 mclo.gs |
| 🔗 自动复制 | 上传成功后自动复制分享链接到剪贴板 |
| ⏰ 有效期提醒 | 日志有效期 3 个月，到期自动失效 |
| 🖥️ 跨平台支持 | Windows / Linux / macOS 全平台兼容 |
| 🎨 现代 UI | 简洁美观的界面设计，支持窗口拖动 |
| 📢 实时公告 | 从远程地址动态加载公告信息 |

---

## 📥 下载安装

👉 **[前往 Releases 页面下载](https://github.com/linfon18/FastShareYourLog/releases)** 👈

### 🪟 Windows
- `win-x64` - 64位系统
- `win-x86` - 32位系统

### 🐧 Linux
- `linux-x64` - x64 架构
- `linux-arm` - ARM 架构
- `linux-arm64` - ARM64 架构

### 🍎 macOS
- `osx-x64` - Intel 芯片
- `osx-arm64` - Apple Silicon (M1/M2)

> ⚠️ **运行要求**：需要安装 [.NET 9.0 Runtime](https://dotnet.microsoft.com/download/dotnet/9.0)

---

## 🚀 快速开始

### 1️⃣ 启动程序

#### 🪟 Windows
```powershell
# 双击运行
FastShareYourLog.exe

# 或命令行
.\FastShareYourLog.exe

# 带日志文件参数启动（直接上传）
.\FastShareYourLog.exe "C:\path\to\your.log"
```

#### 🐧 Linux
```bash
# 添加执行权限
chmod +x FastShareYourLog

# 运行程序
./FastShareYourLog

# 带日志文件参数启动（直接上传）
./FastShareYourLog /path/to/your.log
```

#### 🍎 macOS
```bash
# 添加执行权限
chmod +x FastShareYourLog

# 运行程序（可能需要绕过安全验证）
./FastShareYourLog

# 或右键 → 打开
# 系统偏好设置 → 安全性与隐私 → 仍要打开

# 带日志文件参数启动（直接上传）
./FastShareYourLog /path/to/your.log
```

### 2️⃣ 开启右键菜单
点击 **"开启"** 按钮，注册右键菜单

> 📝 **注意**：macOS 和 Linux 不支持右键菜单功能

### 3️⃣ 分享日志
右键点击任意 `.log` 文件 → 选择 **"分享此日志"**

### 4️⃣ 获取链接
上传成功后，链接自动复制到剪贴板！📋

---

## 🖼️ 界面预览

```
┌─────────────────────────────┐
│  FastShareYourLog      ─ □ ✕ │
├─────────────────────────────┤
│                             │
│    ┌─────┐    ┌─────┐      │
│    │ 开启 │    │ 关闭 │      │
│    └─────┘    └─────┘      │
│                             │
│  ┌─────────────────────┐   │
│  │ 📢 公告内容...       │   │
│  │                     │   │
│  └─────────────────────┘   │
│                             │
└─────────────────────────────┘
```

---

## 🛠️ 技术栈

- **🎨 UI 框架**: [Avalonia UI](https://avaloniaui.net/) - 跨平台 .NET UI 框架
- **🏗️ 架构模式**: MVVM (Model-View-ViewModel)
- **📦 依赖注入**: CommunityToolkit.Mvvm
- **🌐 HTTP 客户端**: 原生 HttpClient
- **📋 剪贴板**: 平台原生 API

---

## 📂 项目结构

```
FastShareYourLog/
├── 📁 Assets/              # 图片资源
├── 📁 Models/              # 数据模型
├── 📁 ViewModels/          # 视图模型 (MVVM)
│   └── MainWindowViewModel.cs
├── 📁 Views/               # 视图界面
│   ├── MainWindow.axaml
│   └── MainWindow.axaml.cs
├── 📄 App.axaml            # 应用配置
├── 📄 FastShareYourLog.csproj
└── 📄 README.md            # 本文件
```

---

## ⚙️ 构建项目

### 🔧 环境要求
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Visual Studio 2022 或 VS Code / Rider

### 🏗️ 本地构建

```bash
# 克隆仓库
git clone https://github.com/linfon18/FastShareYourLog.git
cd FastShareYourLog

# 还原依赖
dotnet restore

# 构建项目
dotnet build

# 运行程序
dotnet run
```

### 📦 发布全平台（单文件 + 无框架）

```bash
# 清理并创建发布目录
rm -rf publish 2>/dev/null || true
mkdir -p publish

# 🪟 Windows x64
dotnet publish -c Release -f net9.0-windows -r win-x64 \
  --self-contained false -p:PublishSingleFile=true \
  -o ./publish/win-x64

# 🪟 Windows x86
dotnet publish -c Release -f net9.0-windows -r win-x86 \
  --self-contained false -p:PublishSingleFile=true \
  -o ./publish/win-x86

# 🐧 Linux x64
dotnet publish -c Release -f net9.0 -r linux-x64 \
  --self-contained false -p:PublishSingleFile=true \
  -o ./publish/linux-x64

# 🐧 Linux ARM
dotnet publish -c Release -f net9.0 -r linux-arm \
  --self-contained false -p:PublishSingleFile=true \
  -o ./publish/linux-arm

# 🐧 Linux ARM64
dotnet publish -c Release -f net9.0 -r linux-arm64 \
  --self-contained false -p:PublishSingleFile=true \
  -o ./publish/linux-arm64

# 🍎 macOS x64
dotnet publish -c Release -f net9.0 -r osx-x64 \
  --self-contained false -p:PublishSingleFile=true \
  -o ./publish/osx-x64

# 🍎 macOS ARM64 (Apple Silicon)
dotnet publish -c Release -f net9.0 -r osx-arm64 \
  --self-contained false -p:PublishSingleFile=true \
  -o ./publish/osx-arm64
```

### 🔥 发布自包含版本（带运行时）

如需发布包含 .NET 运行时的版本（用户无需安装运行时）：

```bash
# 自包含 + 单文件 + 裁剪
dotnet publish -c Release -f net9.0-windows -r win-x64 \
  --self-contained true -p:PublishSingleFile=true \
  -p:PublishTrimmed=true -p:TrimMode=partial \
  -o ./publish/win-x64-self-contained
```

---

## 🌟 支持的系统

| 系统 | 最低版本 | 架构 | 右键菜单 |
|------|---------|------|---------|
| Windows | 8 / 10 / Server 2016 | x64, x86 | ✅ 支持 |
| Linux | Ubuntu 20.04+ | x64, ARM, ARM64 | ❌ 不支持 |
| macOS | 10.15+ | x64, ARM64 | ❌ 不支持 |

---

## 🤝 贡献指南

欢迎提交 Issue 和 Pull Request！

1. 🍴 Fork 本仓库
2. 🌿 创建分支 (`git checkout -b feature/AmazingFeature`)
3. 💾 提交更改 (`git commit -m 'Add some AmazingFeature'`)
4. 📤 推送分支 (`git push origin feature/AmazingFeature`)
5. 🔃 创建 Pull Request

---

## 📝 开源协议

本项目采用 [MIT](LICENSE) 协议开源

---

## 🙏 致谢

- ☁️ [mclo.gs](https://mclo.gs/) - 提供日志托管服务
- 🎨 [Avalonia UI](https://avaloniaui.net/) - 跨平台 UI 框架
- 🛠️ [CommunityToolkit.Mvvm](https://learn.microsoft.com/dotnet/communitytoolkit/mvvm/) - MVVM 工具包

---

<div align="center">

**⭐ 如果这个项目对你有帮助，请给个 Star！** ⭐

Made with ❤️ by linfon18

💡 后续将视情况发布 .NET Framework 4.7.2 版本的 Windows 独立版本，真·小而美

</div>
