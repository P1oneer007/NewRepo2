using Avalonia.Controls;
using Avalonia.Interactivity;
using System.IO;
using System.Threading.Tasks;
using Dicom;
using System;
using Dicom_viewer.ViewModels;

namespace Dicom_viewer.Views
{
    
    public partial class MainWindow : Window
    {
        string filePath = App.Settings.FilePath;
        DicomInfoViewModel viewModel;

        public MainWindow(DicomInfoViewModel _viewModel)
        {
            this.viewModel = _viewModel;
            this.DataContext = viewModel;
            InitializeComponent();
        }
        public string FileContent { get; private set; }
        public async Task LoadFileContent(string filePath)
        {
            // Чтение содержимого файла DCM
            string content = await File.ReadAllTextAsync(filePath);
            // Обновление свойства FileContent
            FileContent = content;
        }
        public async Task GetPath()
        {
            var dialog = new OpenFileDialog();
            dialog.Filters.Add(new FileDialogFilter() { Name = "DICOM Files", Extensions = { "dcm" } });
            dialog.AllowMultiple = false;
            var result = await dialog.ShowAsync(this);
            if (result.Length > 0)
            {
                filePath = result[0];
                viewModel.FileName = filePath;
                viewModel.LoadDicomInfo();
            }

        }
        public async Task studyInst()
        {
            var file = DicomFile.Open(filePath, readOption: FileReadOption.ReadAll);
            var dicomDataset = file.Dataset;
            var studyInstanceUid = dicomDataset.GetSingleValue<string>(DicomTag.StudyInstanceUID);

        }
        public void OnBrowseClicked(object sender, RoutedEventArgs args)
        {
            GetPath();
        }
    }
}