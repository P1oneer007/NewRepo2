using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Dicom_v1.ViewModels;
using Dicom_v1.Views;

namespace Dicom_v1
{
    public partial class App : Application
    {
        public static object MainWindow { get; internal set; }

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new ViewModels.MainWindowViewModel(desktop.MainWindow),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}