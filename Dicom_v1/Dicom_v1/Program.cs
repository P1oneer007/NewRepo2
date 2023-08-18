using Avalonia;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using Dicom_v1.ViewModels;
using Dicom_v1.Views;
using System;

namespace Dicom_v1
{
    internal class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [STAThread]
          public static void Main(string[] args) => BuildAvaloniaApp()
          .StartWithClassicDesktopLifetime(args);

       /* static void Main(string[] args)
        {
            var app = new Application();
            var mainWindow = new MainWindow();

            if (args.Length > 0)
            {
                string filePath = @"C:\Feet2011_05_03_10_09_54_ID00000000113_raw_A_LUT_SevkavrentgenExtremity.dcm";
                var mainWindowViewModel = (MainWindowViewModel)mainWindow.DataContext;
                mainWindowViewModel.LoadDcmFile(filePath).Wait();
            }

            app.Run(mainWindow);
        }*/
        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .WithInterFont()
                .LogToTrace()
                .UseReactiveUI();

    }
}