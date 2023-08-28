using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Dicom_viewer.ViewModels;
using Dicom_viewer.Views;
using System;

namespace Dicom_viewer
{
    public partial class App : Application
    {
        public static AppSettings Settings { get; } = new AppSettings();
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
           if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
           {
             desktop.MainWindow = new MainWindow(new DicomInfoViewModel());                
           }
           base.OnFrameworkInitializationCompleted();
        }
    }
}