using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFirstApplication.ObjectsDto
{
    public class UserDto: ObjectBaseDto
    {
        public Guid StudentGuid { get; set; }

       public StudentDto Student { get; set; }
    }
}
