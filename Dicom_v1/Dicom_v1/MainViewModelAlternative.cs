using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Media.Imaging;
using Avalonia.Controls;
using Avalonia.Input;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using ReactiveUI;
using System.Reactive;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using OpenFileDialog = Avalonia.Controls.OpenFileDialog;

namespace Dicom_v1
{
    internal class MainViewModelAlternative
    {
        private Bitmap? _image;
        private Avalonia.Controls.Window window;

        public Bitmap? Image
        {
            get => _image;
            // set => SetProperty(ref _image, value);
        }

        public async void OpenFileCommand()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filters.Add(new FileDialogFilter() { Name = "DICOM files", Extensions = { "dcm" } });
           // var window = ((IClassicDesktopStyleApplicationLifetime)Application.Current.ApplicationLifetime)?.MainWindow;
           var result = await openFileDialog.ShowAsync(window);
            if (result != null && result.Length > 0)
            {
                var filePath = result[0];

                DumpDicom(filePath);
            }
        }

            async Task DumpDicom(string filePath)
            {

                await Task.Delay(1000);

                var fileName = Path.GetFileName(filePath);
                var fileInfo = new FileInfo(filePath);

                var dicomImage = await ParseDicomAndGetImage(filePath);

                //Image = dicomImage;
            }

            async Task<Bitmap?> ParseDicomAndGetImage(string filePath)
            {
                await Task.Delay(1000);
                return await Task.Run(() => new Bitmap(filePath));
            }
        }
    }
