using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Dicom_v1.ViewModels;

namespace Dicom_v1.Views
{
    public partial class MainWindow : Window
    {
        private ViewModels.DicomFileViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _viewModel = new ViewModels.DicomFileViewModel();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
   
    }
}