using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dicom_v1
{
    public class DicomFile
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Content { get; set; }

        internal static object Open(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
