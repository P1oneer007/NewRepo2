using ReactiveUI;
using Dicom;

namespace Dicom_v3.ViewModels
{
    public class DicomInfoViewModel : ReactiveObject
    {
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

        public void LoadDicomInfo(string filePath)
        {
            var dicomFile = DicomFile.Open(filePath);
            var dicomDataset = dicomFile.Dataset;

            PatientName = dicomDataset.GetSingleValueOrDefault(DicomTag.PatientName, string.Empty);
            StudyDate = dicomDataset.GetSingleValueOrDefault(DicomTag.StudyDate, string.Empty);

        // Другие свойства DICOM
        }
    }
}
