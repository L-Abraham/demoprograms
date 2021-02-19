using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebFirstApplication.objects;

namespace WebFirstApplication.Objects
{
    public class User : ObjectBase
    {
        public Guid StudentGuid { get; set; }

        [ForeignKey("StudentGuid")]
        public virtual Student Student { get; set; }

        public string Password { get; set; }
    }
}
