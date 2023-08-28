using System.Collections.ObjectModel;
using Avalonia.Media.Imaging;
using Dicom.Imaging;
using ReactiveUI;
using Dicom_viewer.Services;

namespace Dicom_viewer.ViewModels
{
    public class DicomInfoViewModel : ReactiveObject
    {
        private string _fileName;
        public string FileName
        {
            get => _fileName;
            set => this.RaiseAndSetIfChanged(ref _fileName, value);
        }

        public class TagData
        {
            public string? Tag { get; set; }
            public string? VR { get; set; }
            public int Length { get; set; }
            public string? Value { get; set; }
            // Другие свойства DICOM
        }
        
        private ObservableCollection<TagData> _tags;
        public ObservableCollection<TagData> Tags
        {
            get => _tags;
            set => this.RaiseAndSetIfChanged(ref _tags, value);
        }
        
        private Bitmap _imageSource;
        public Bitmap ImageSource
        {
            get => _imageSource;
            set => this.RaiseAndSetIfChanged(ref _imageSource, value);
        }

        public void LoadDicomInfo()
        {
            var dicomFile = Dicom.DicomFile.Open(FileName);
            Tags = new ObservableCollection<TagData>();

            foreach (var tag in dicomFile.Dataset)
            {
                var tagData = new TagData
                {
                    Tag = tag.ToString(),
                    VR = tag.ValueRepresentation.ToString(),
                    Length = (int)tag.ValueRepresentation.MaximumLength,
                    Value = dicomFile.Dataset.GetValueOrDefault(tag.Tag, 0, string.Empty)
                };
                Tags.Add(tagData);

                if (tagData.VR == "SQ")
                {
                    var sequence = dicomFile.Dataset.GetSequence(tag.Tag);
                    foreach (var item in sequence)
                    {
                        if (item != null)
                        {
                            var itemS = new TagData
                            {
                                Tag = "--(FFFE,E000) Item--"
                            };
                            Tags.Add(itemS);

                            var itemA = new TagData
                            {
                                Tag = item.ToString(),
                                VR = "--",
                                Length = (int)tag.ValueRepresentation.MaximumLength,
                                Value = dicomFile.Dataset.GetValueOrDefault(tag.Tag, 0, string.Empty)
                            };
                            Tags.Add(itemA);
                        }
                        
                        foreach (var it in item)
                        {
                            if (it != null)
                            {
                                var itemC = new TagData
                                {
                                    Tag = it.ToString(),
                                    VR = it.ValueRepresentation.ToString(),
                                    Length = (int)it.ValueRepresentation.MaximumLength,
                                    Value = dicomFile.Dataset.GetValueOrDefault(it.Tag, 0, string.Empty)
                                };
                                Tags.Add(itemC);
                            }
                        }
                    }
                }
            }
          var dcmFile = Dicom.DicomFile.Open(FileName);
          var pixelData = Dicom.Imaging.Render.PixelDataFactory.Create(DicomPixelData.Create(dcmFile.Dataset), 0);
          ImageSource = ImageService.MakeImage(pixelData);
        }
    }
}
