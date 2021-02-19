using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFirstApplication.ObjectsDto
{
    public class CourseDto
    {
        public Guid? Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime? CreatedAt { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public DateTime CoruseDate { get; set; }
        public string CoruseTime { get; set; }
    }
}
