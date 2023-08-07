using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Media.Imaging;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Dicom_v1
{
    internal class MainViewModel
    {
        private Bitmap? _image;
        private object window;

        public Bitmap? Image
        {
            get => _image;
           
        }


        public async void OpenFileCommand()
        {
            var openFileDialog = new OpenFileDialog();
            // object value = openFileDialog.Filter.Add(new FileDialogFilter() { Name = "DICOM files", Extensions = { "dcm" } });

            // var window = (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow;
            //var result = await openFileDialog.ShowAsync(window);

            //if (result != null && result.Length > 0)
           // {
           //     var filePath = result[0];

                // Call your DICOM dump method passing the filePath
                // Replace the below line with your DICOM dump method call
           //     DumpDicom(filePath);
           // }

        }

        private async Task DumpDicom(string filePath)
        {
            // Call your DICOM parsing method to extract image data from the DICOM file
            // Replace the below code with your DICOM parsing logic

            await Task.Delay(1000); // Simulating DICOM parsing delay

            var fileName = Path.GetFileName(filePath);
            var fileInfo = new FileInfo(filePath);

            // Assuming you have a method that returns a Bitmap from the DICOM image data
            var dicomImage = await ParseDicomAndGetImage(filePath);

            //Image = dicomImage;
        }

        private async Task<Bitmap?> ParseDicomAndGetImage(string filePath)
        {
            // Implement your DICOM parsing logic here
            // This method should extract the image data from the DICOM file
            // and return it as a Bitmap

            await Task.Delay(1000); // Simulating DICOM parsing delay

            // Replace the below line with your actual DICOM parsing logic
            return await Task.Run(() => new Bitmap(filePath));
        }

        private class FileDialogFilter
        {
            public FileDialogFilter()
            {
            }

            public string Name { get; set; }
            public object Extensions { get; set; }
        }
    }
}