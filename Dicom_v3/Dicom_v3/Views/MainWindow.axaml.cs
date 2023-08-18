using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Dicom_v3.ViewModels;
using ReactiveUI;
using System;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Dicom_v3
{
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
       // public object OpenDicomButton { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            /*  this.WhenActivated(disposables =>
   {
       ViewModel = new MainWindowViewModel();

       // Обработка команды открытия DICOM

          this.BindCommand(ViewModel, vm => vm.OpenDicomCommand, v => v.OpenDicomButton)
              .DisposeWith(disposables);

       //  this.BindCommand<MainWindow, MainWindowViewModel, Unit, Button>(ViewModel, vm => vm.OpenDicomCommand, v => v.OpenDicomButton, null)
       //     .DisposeWith(disposables);

       // this.BindCommand<MainWindow, MainWindowViewModel, Unit, Button>(this, viewModel => viewModel.OpenDicomCommand, button => button.OpenDicomButton, nameof(Button.Click))
       //     .DisposeWith(disposables);

      // this.BindCommand<MainWindow, MainWindowViewModel, Unit, Button>(this, viewModel => (ReactiveCommand<Unit, Unit>)viewModel.OpenDicomCommand, button => button.OpenDicomButton, nameof(Button.Click))
      //     .DisposeWith(disposables);

       // Обновление данных DICOM при открытии нового файла
       ViewModel.DicomInfoViewModel = new DicomInfoViewModel();
       this.WhenAnyValue(x => x.ViewModel.CurrentDicomPath)
           .Where(path => !string.IsNullOrEmpty(path))
           .Subscribe(path => ViewModel.DicomInfoViewModel.LoadDicomInfo(path))
           .DisposeWith(disposables);
   });    */
        }

        void OpenDicomButton(object sender, RoutedEventArgs e)
        {
            // открытие диалогового окна для выбора файла DICOM
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filters.Add(new FileDialogFilter() { Name = "DICOM Files", Extensions = { "dcm" } });
            var result = openFileDialog.ShowAsync(this);

            // Обновление свойства CurrentDicomPath во ViewMode
            ViewModel.CurrentDicomPath = result.Result.FirstOrDefault();
        }
       
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
       
        public string FileContent { get; private set; }
        public async Task GetPath()
        {
              var dialog = new OpenFileDialog();
              // dialog.Filters.Add(new FileDialogFilter() { Name = "dcm", Extensions = { "DICOM Dump" } });
              dialog.AllowMultiple = true;
             // var result = await dialog.ShowAsync(this);
             // var filePath = result[0];
             // string content = await File.ReadAllTextAsync(filePath);
              // Обновление свойства FileContent
             // FileContent = content;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filters.Add(new FileDialogFilter() { Name = "DICOM Files", Extensions = { "dcm" } });
            var result = openFileDialog.ShowAsync(this);

            // Обновление свойства CurrentDicomPath во ViewModel
            ViewModel.CurrentDicomPath = result.Result.FirstOrDefault();
        }

        public void OnBrowseClicked(object sender, RoutedEventArgs args)
        {
            GetPath();
        }/*
*/

    }
}