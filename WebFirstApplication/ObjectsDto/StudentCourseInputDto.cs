using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFirstApplication.ObjectsDto
{
    public class StudentCourseInputDto
    {
        public Guid StudentGuid { get; set; }
        public List<CourseDto> Courses { get; set; }
    }
}
