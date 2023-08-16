using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Dicom_v3.ViewModels;
using ReactiveUI;
using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Windows;

namespace Dicom_v3
{
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        //private object OpenDicomButton;
        public object OpenDicomButton { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            this.WhenActivated(disposables =>
            {
                ViewModel = new MainWindowViewModel();

                // Обработка команды открытия DICOM
                  this.BindCommand(ViewModel, vm => vm.OpenDicomCommand, v => v.OpenDicomButton)
                     .DisposeWith(disposables);
                
                
                /*this.BindCommand<MainWindow, MainWindowViewModel, Unit, Button>(this, viewModel => viewModel.OpenDicomCommand, button => button.OpenDicomButton, nameof(Button.Click))
     .DisposeWith(disposables);
                // Обновление данных DICOM при открытии нового файла
                ViewModel.DicomInfoViewModel = new DicomInfoViewModel();
                this.WhenAnyValue(x => x.ViewModel.CurrentDicomPath)
                    .Where(path => !string.IsNullOrEmpty(path))
                    .Subscribe(path => ViewModel.DicomInfoViewModel.LoadDicomInfo(path))
                    .DisposeWith(disposables);
            */
                });
        }

       /* private void OpenDicomButton(object sender, RoutedEventArgs e)
        {
            // Ваш код для обработки команды открытия DICOM
            // Например, открытие диалогового окна для выбора файла DICOM
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filters.Add(new FileDialogFilter() { Name = "DICOM Files", Extensions = { "dcm" } });
            var result = openFileDialog.ShowAsync(this);

            // Обновление свойства CurrentDicomPath во ViewModel
            ViewModel.CurrentDicomPath = result.Result.FirstOrDefault();
        }
       
       */
        

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

    }
}