using ReactiveUI;
using Dicom;
using Dicom_viewer.Views;
using Avalonia.Interactivity;
//using Microsoft.Windows.PowerShell.Gui.Internal;

namespace Dicom_viewer.ViewModels
{
    public class DicomInfoViewModel : ReactiveObject
    {
        string filePath = App.Settings.FilePath;

        private string _fileName;
        public string FileName
        { 
            get => _fileName;
            set => this.RaiseAndSetIfChanged(ref _fileName, value);
        }

        private string _patientName;
        public string PatientName
        {
            get => _patientName;
            set => this.RaiseAndSetIfChanged(ref _patientName, value);
        }

        private string _studyDate;

        public string StudyDate
        {
            get => _studyDate;
            set => this.RaiseAndSetIfChanged(ref _studyDate, value);
        }
        // Другие свойства DICOM

        public void LoadDicomInfo()
        {
            var dicomFile = DicomFile.Open(FileName);
            var dicomDataset = dicomFile.Dataset;

            PatientName = dicomDataset.GetSingleValueOrDefault(DicomTag.PatientName, string.Empty);
            StudyDate = dicomDataset.GetSingleValueOrDefault(DicomTag.StudyDate, string.Empty);
        }

    }
}
