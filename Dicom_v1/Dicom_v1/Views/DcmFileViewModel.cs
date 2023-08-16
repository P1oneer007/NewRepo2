using Dicom_v1.ViewModels;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Dicom_v1
{
    public class DcmFileViewModel : ViewModelBase
    {
        private string _fileContent;

        public string FileContent
        {
            get => _fileContent;
            set => SetProperty(ref _fileContent, value);
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
        public async Task LoadFileContent(string filePath)
        {
            filePath = @"C:\Feet2011_05_03_10_09_54_ID00000000113_raw_A_LUT_SevkavrentgenExtremity.dcm";
            // Чтение содержимого файла DCM
            string content = await File.ReadAllTextAsync(filePath);

            // Обновление свойства FileContent
            FileContent = content;
        }
    }
}
