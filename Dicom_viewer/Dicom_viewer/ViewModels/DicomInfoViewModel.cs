using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

using Dicom_viewer.Views;
using Avalonia.Interactivity;

using Dicom;
using Dicom.Imaging;
using Dicom.Imaging.Codec;
using Dicom.IO.Buffer;
using ReactiveUI;
using FellowOakDicom;


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
/*
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

        private string _studyInstanceUid;

        public string studyInstanceUid
        {
            get => _studyInstanceUid;
            set => this.RaiseAndSetIfChanged(ref _studyInstanceUid, value);
        }

        private string _seriesInstanceUid;
        public string seriesInstanceUid
        {
            get => _seriesInstanceUid;
            set => this.RaiseAndSetIfChanged(ref _seriesInstanceUid, value);
        }

        private string _sopClassUid;
        public string sopClassUid
        {
            get => _sopClassUid;
            set => this.RaiseAndSetIfChanged(ref _sopClassUid, value);
        }

        private string _sopInstanceUid;
        public string sopInstanceUid
        {
            get => _sopInstanceUid;
            set => this.RaiseAndSetIfChanged(ref _sopInstanceUid, value);
        }
        */
        public class TagData
        {
            public string? Tag { get; set; }
            public string? VR { get; set; }
            public int Length { get; set; }
            public string? Value { get; set; }
        }
        // Другие свойства DICOM
        private ObservableCollection<TagData> _tags;
        public ObservableCollection<TagData> Tags
        {
            get => _tags;
            set => this.RaiseAndSetIfChanged(ref _tags, value);
        }
                
        public void LoadDicomInfo()
        {
          var dicomFile = FellowOakDicom.DicomFile.Open(FileName);
          Tags = new ObservableCollection<TagData>();
                
           foreach (var tag in dicomFile.Dataset)
           {
               Tags.Add(new TagData
               {
                  Tag = tag.Tag.ToString(),
                  VR = tag.ValueRepresentation.ToString(),
                //Length = tag.Length.ToString(),
                  Value = tag.ToString()
               });
           }
        }

        /* var dicomTags = dicomFile.Dataset.ToList();
         Tags = new ObservableCollection<DicomTagModel>(
             dicomTags.Select(tag => new DicomTagModel
             {
                 Tag = tag.Tag.ToString(),
                 VR = tag.ValueRepresentation.Code,
                 //Length = tag.Length,
                 Value = tag.ToString()
             }));*/

        //var dicomFile = DicomFile.Open(FileName);
        //var dicomDataset = dicomFile.Dataset;
        /*studyInstanceUid = dicomDataset.GetSingleValue<string>(DicomTag.StudyInstanceUID);
        seriesInstanceUid = dicomDataset.GetSingleValue<string>(DicomTag.SeriesInstanceUID);
        sopClassUid = dicomDataset.GetSingleValue<string>(DicomTag.SOPClassUID);
        sopInstanceUid = dicomDataset.GetSingleValue<string>(DicomTag.SOPInstanceUID);

        PatientName = dicomDataset.GetSingleValueOrDefault(DicomTag.PatientName, string.Empty);
        StudyDate = dicomDataset.GetSingleValueOrDefault(DicomTag.StudyDate, string.Empty);
        */
    }

}
