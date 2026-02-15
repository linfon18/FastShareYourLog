# 📋 FastShareYourLog

> 🚀 一键分享日志文件到 mclo.gs 的跨平台工具

[![C#](https://img.shields.io/badge/C%23-9.0-239120?logo=c-sharp)](https://docs.microsoft.com/dotnet/csharp/)
[![Avalonia UI](https://img.shields.io/badge/Avalonia%20UI-11.3-8E44AD?logo=dotnet)](https://avaloniaui.net/)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)

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

### 🪟 Windows
- [📦 win-x64](publish/win-x64/FastShareYourLog.exe) - 64位系统
- [📦 win-x86](publish/win-x86/FastShareYourLog.exe) - 32位系统

### 🐧 Linux
- [📦 linux-x64](publish/linux-x64/FastShareYourLog) - x64 架构
- [📦 linux-arm](publish/linux-arm/FastShareYourLog) - ARM 架构
- [📦 linux-arm64](publish/linux-arm64/FastShareYourLog) - ARM64 架构

### 🍎 macOS
- [📦 osx-x64](publish/osx-x64/FastShareYourLog) - Intel 芯片
- [📦 osx-arm64](publish/osx-arm64/FastShareYourLog) - Apple Silicon (M1/M2)

> ⚠️ **运行要求**：需要安装 [.NET 9.0 Runtime](https://dotnet.microsoft.com/download/dotnet/9.0)

---

## 🚀 快速开始

### 1️⃣ 启动程序
双击运行 `FastShareYourLog`（或 `.exe`）

### 2️⃣ 开启右键菜单
点击 **"开启"** 按钮，注册右键菜单

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
- Visual Studio 2022 或 VS Code

### 🏗️ 构建命令

```bash
# 还原依赖
dotnet restore

# 构建项目
dotnet build

# 运行程序
dotnet run
```

### 📦 发布单文件

```bash
# Windows x64
dotnet publish -c Release -f net9.0-windows -r win-x64 --self-contained false -p:PublishSingleFile=true

# Linux x64
dotnet publish -c Release -f net9.0 -r linux-x64 --self-contained false -p:PublishSingleFile=true

# macOS arm64
dotnet publish -c Release -f net9.0 -r osx-arm64 --self-contained false -p:PublishSingleFile=true
```

---

## 🌟 支持的系统

| 系统 | 最低版本 | 架构 |
|------|---------|------|
| Windows | 10 / Server 2016 | x64, x86 |
| Linux | Ubuntu 20.04+ | x64, ARM, ARM64 |
| macOS | 10.15+ | x64, ARM64 |

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

</div>
