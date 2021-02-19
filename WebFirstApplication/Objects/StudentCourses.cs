using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebFirstApplication.objects;

namespace WebFirstApplication.Objects
{
    public class StudentCourses: ObjectBase
    {

        public Guid StudentGuid{ get; set; }

        [ForeignKey("StudentGuid")]
        public virtual Student Student { get; set; }


        public Guid CourseGuid { get; set; }

        [ForeignKey("CourseGuid")]
        public virtual Course Course { get; set; }

        public virtual ICollection<DailyNote> DailyNotes { get; set; }



    }
}
