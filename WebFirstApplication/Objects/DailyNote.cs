using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebFirstApplication.Objects;

namespace WebFirstApplication.objects
{
    public class DailyNote: ObjectBase
    {
        public Guid UploadDocumentGuid { get; set; }
        public string FileName { get; set; }

        public string ContetntType { get; set; }

        public Guid StudentCoursesId { get; set; }
        public virtual StudentCourses StudentCourses { get; set; }

        [ForeignKey("UploadDocumentGuid")]
        public virtual UploadedDocuments Documents { get; set; }
    }
}
