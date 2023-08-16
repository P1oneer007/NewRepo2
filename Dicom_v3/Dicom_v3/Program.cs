using Avalonia;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using Dicom_v3.ViewModels;
using Dicom_v3;
using System;
using System.Xml;
namespace Dicom_v3
{
    internal class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        /* [STAThread]
         public static void Main(string[] args) => BuildAvaloniaApp()
         .StartWithClassicDesktopLifetime(args);

         // Avalonia configuration, don't remove; also used by visual designer.
         public static AppBuilder BuildAvaloniaApp()
             => AppBuilder.Configure<App>()
                 .UsePlatformDetect()
                 .WithInterFont()
                 .LogToTrace()
                 .UseReactiveUI();*/
        public static void Main(string[] args)
        {
            BuildAvaloniaApp()
                .StartWithClassicDesktopLifetime(args);
        }

        public static AppBuilder BuildAvaloniaApp()
        {
            return AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .With(new X11PlatformOptions { EnableMultiTouch = true })
                .UseReactiveUI();

        }
    }
}