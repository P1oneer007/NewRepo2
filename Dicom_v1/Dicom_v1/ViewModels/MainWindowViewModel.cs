using ReactiveUI;

namespace Dicom_v1.ViewModels
{
    internal class DicomFileViewModel : ReactiveObject
    {
        private DicomFileViewModel _dicomFileViewModel;

        public DicomFileViewModel GetDicomFileViewModel()
        {
            return _dicomFileViewModel;
        }

        public void SetDicomFileViewModel(DicomFileViewModel value)
        {
            this.RaiseAndSetIfChanged(ref _dicomFileViewModel, value);
        }

        public DicomFileViewModel()
        {
            SetDicomFileViewModel(this);
        }   

    }
}
