using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ReactiveUI;
using System.Reactive;

namespace Dicom_v1.ViewModels
{
    internal class MainWindowViewModel : ReactiveObject
    {
        private MainWindowViewModel _dicomFileViewModel;
        private Window _localWindow;

        public MainWindowViewModel GetDicomFileViewModel()
        {
            return _dicomFileViewModel;
        }

        public void SetDicomFileViewModel(MainWindowViewModel value)
        {
            this.RaiseAndSetIfChanged(ref _dicomFileViewModel, value);
        }

        private string _filePath;
        public string FilePath
        {
            get => _filePath;
            set => this.RaiseAndSetIfChanged(ref _filePath, value);
        }

        private DcmFileViewModel _dcmFileViewModel;

        public DcmFileViewModel DcmFileViewModel
        {
            get => _dcmFileViewModel;
            set => SetProperty(ref _dcmFileViewModel, value);
        }
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            //OnPropertyChanged(propertyName);
            return true;
        }
        public MainWindowViewModel()
        {
            DcmFileViewModel = new DcmFileViewModel();
        }
        public async Task LoadDcmFile(string filePath)
        {
            await DcmFileViewModel.LoadFileContent(filePath);
        }
        
        public ReactiveCommand<System.Reactive.Unit, System.Threading.Tasks.Task> OpenFileCommand { get; }
        public MainWindowViewModel(Window localWindow)
        {
            OpenFileCommand = ReactiveCommand.Create(OpenFileAsync);
            OpenFileCommand.ThrownExceptions.Subscribe(ex => Console.WriteLine(ex));
            SetDicomFileViewModel(this);
            _localWindow = localWindow;
        }

         private async Task OpenFileAsync()
          {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filters.Add(new FileDialogFilter { Extensions = { "dcm" }, Name = "DICOM Dump" });
            var window = _localWindow;
            var result = await openFileDialog.ShowAsync(window);
            foreach (var filePath in result)
            {
                FilePath = filePath;
            }
         }
    }
}