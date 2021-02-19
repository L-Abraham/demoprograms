using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFirstApplication.ObjectsDto
{
    public class UploadedDocumentsDto:ObjectBaseDto
    {
        public string FileName { get; set; }
        public byte[] Content { get; set; }

        public string ContetntType { get; set; }

    }
}
