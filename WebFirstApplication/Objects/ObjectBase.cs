using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFirstApplication.objects
{
    public class ObjectBase
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; }

        public DateTime? CreatedAt { get; set; }

    }
}
