using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;
using ReactiveUI;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Avalonia;
using Avalonia.ReactiveUI;
using Dicom_v1.ViewModels;
using System.Reactive;
namespace Dicom_v1.Views
{
    public partial class MainWindow : Window
    {
        private ViewModels.MainWindowViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            
            DataContext = _viewModel = new ViewModels.MainWindowViewModel(this);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private string _filePath;
        public string FilePath
        {
            get => _filePath;
            set => this.RaiseAndSetIfChanged(ref _filePath, value);
        }

        private void RaiseAndSetIfChanged(ref string filePath, string value)
        {
            throw new NotImplementedException();
        }
        
        public string FileContent { get; private set; }

        public async Task LoadFileContent(string filePath)
        {
            filePath = @"С:\Feet2011_05_03_10_09_54_ID00000000113_raw_A_LUT_SevkavrentgenExtremity.dcm";
            // Чтение содержимого файла DCM
            string content = await File.ReadAllTextAsync(filePath);

            // Обновление свойства FileContent
            FileContent = content;
        }

        public async Task GetPath()
        {
           var dialog = new OpenFileDialog();
           // dialog.Filters.Add(new FileDialogFilter() { Name = "dcm", Extensions = { "DICOM Dump" } });
            dialog.AllowMultiple = true;
            var result = await dialog.ShowAsync(this);
            var filePath = result[0];
            string content = await File.ReadAllTextAsync(filePath);
            // Обновление свойства FileContent
            FileContent = content;
        }
       
        public void OnBrowseClicked(object sender, RoutedEventArgs args)
        {
            GetPath();
        }
    }
}