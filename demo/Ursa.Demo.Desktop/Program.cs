using System;
using System.Runtime.InteropServices;
using Avalonia;
using Avalonia.Dialogs;
using Avalonia.Media;

namespace Ursa.Demo.Desktop;

class Program
{

    static string MacOS_Default_Font = "STHeiti";
    static string Windows_Default_Font = "Microsoft YaHei";
    static string Linux_Default_Font = "Noto Sans CJK SC";

    static string DefaultFontName()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) return Linux_Default_Font;
        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) return MacOS_Default_Font;
        return Windows_Default_Font;
    }

    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .With(new FontManagerOptions
        {
            FontFallbacks = new[]
            {
                new FontFallback
                {
                    FontFamily = new FontFamily(DefaultFontName())
                }
            }
        })
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UseManagedSystemDialogs()
            .UsePlatformDetect()
            .With(new Win32PlatformOptions())
            .LogToTrace();
}