using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFirstApplication.ObjectsDto
{
    public class ObjectBaseDto
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
