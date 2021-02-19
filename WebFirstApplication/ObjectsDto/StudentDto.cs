using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFirstApplication.ObjectsDto
{
    public class StudentDto
    {
        public Guid? Id { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; }

        public DateTime? CreatedAt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudentID { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
    }
}
