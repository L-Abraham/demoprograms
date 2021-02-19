using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFirstApplication.ObjectsDto
{
    public class DailyNoteDto: ObjectBaseDto
    {
        public Guid UploadDocumentGuid { get; set; }
        public string FileName { get; set; }

        public string ContetntType { get; set; }

        public UploadedDocumentsDto Documents { get; set; }
        public Guid StudentCoursesId { get; set; }

    }
}
