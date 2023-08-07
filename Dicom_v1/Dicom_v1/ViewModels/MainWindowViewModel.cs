using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Avalonia.Controls.ApplicationLifetimes;
using Microsoft.Extensions.Hosting;
using Avalonia.Input;
using Avalonia.Threading;
using Dicom_v1.Views;
using ReactiveUI;
using System.Reactive;
namespace Dicom_v1.ViewModels
{
    internal class MainWindowViewModel : ReactiveObject
    {
        private MainWindowViewModel _dicomFileViewModel;

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

        public ReactiveCommand<KeyEventArgs, Unit> OpenFileCommand { get; }

        public MainWindowViewModel()
        {
            OpenFileCommand = ReactiveCommand.Create<KeyEventArgs>(OpenFile);
            SetDicomFileViewModel(this);
        }

        private void OpenFile(KeyEventArgs args)
        {
            if (args.Key != Key.Enter)
                return;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filters.Add(new FileDialogFilter { Extensions = { "dcm" }, Name = "DICOM Dump" });

            var window = (MainWindow)args.Source;
            openFileDialog.ShowAsync(window).ContinueWith(t =>
            {
                foreach (var filePath in t.Result)
                {
                    Dispatcher.UIThread.InvokeAsync(() =>
                    {
                        FilePath = filePath;
                        // Здесь можно выполнить обработку DICOM-дампа
                    });
                }
            });
        }
    }
}
