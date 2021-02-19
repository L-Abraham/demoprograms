using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFirstApplication.ObjectsDto
{
    public class StudentCoursesDto : ObjectBaseDto
    {

        public Guid StudentGuid { get; set; }

        public StudentDto Student { get; set; }
        public Guid CourseGuid { get; set; }

        public CourseDto Course { get; set; }
    public List<DailyNoteDto> DailyNotes { get; set; }
    }
}
