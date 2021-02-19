using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebFirstApplication.objects
{
    public class Course:ObjectBase
    {
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        [Column(TypeName = "date")]
        public DateTime CoruseDate { get; set; }

        public string CoruseTime { get; set; }

    

    }
}
