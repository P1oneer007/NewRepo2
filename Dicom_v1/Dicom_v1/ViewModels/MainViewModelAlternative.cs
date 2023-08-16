using Avalonia.Media.Imaging;
using Avalonia.Controls;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using OpenFileDialog = Avalonia.Controls.OpenFileDialog;
using System.Runtime.CompilerServices;

namespace Dicom_v1.ViewModels
{
    internal class MainViewModelAlternative
    {
        private Bitmap? _image;
        private Avalonia.Controls.Window window;

        public Bitmap? Image
        {
            get => _image;
             set => SetProperty(ref _image, value);
        }
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged(string propertyName)
        {
           // PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async void OpenFileCommand()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filters.Add(new FileDialogFilter() { Name = "DICOM files", Extensions = { "dcm" } });
            //var window = ((IClassicDesktopStyleApplicationLifetime)Application.Current.ApplicationLifetime)?.MainWindow;
            var result = await openFileDialog.ShowAsync(window);
            if (result != null && result.Length > 0)
            {
                var filePath = result[0];

                DumpDicom(filePath, GetImage());
            }
        }
        private Bitmap GetImage()
        {
            return Image;
        }

        async Task DumpDicom(string filePath, Bitmap image)
        {

            await Task.Delay(1000);

            var fileName = Path.GetFileName(filePath);
            var fileInfo = new FileInfo(filePath);

            var dicomImage = await ParseDicomAndGetImage(filePath);
            image = dicomImage;
        }

        async Task<Bitmap?> ParseDicomAndGetImage(string filePath)
        {
            await Task.Delay(1000);
            return await Task.Run(() => new Bitmap(filePath));
        }
    }
}
