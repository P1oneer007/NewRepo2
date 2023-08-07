using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Dicom_v1.ViewModels;
using System;

namespace Dicom_v1.Views
{
    public partial class MainWindow : Window
    {
        private ViewModels.MainWindowViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _viewModel = new ViewModels.MainWindowViewModel();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public static explicit operator MainWindow(string v)
        {
            throw new NotImplementedException();
        }
    }
}