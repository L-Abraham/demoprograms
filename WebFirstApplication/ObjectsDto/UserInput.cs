using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFirstApplication.ObjectsDto
{
    public class UserInput : ObjectBaseDto
    {
        public string EmailAddress { get; set; }

        public string Password { get; set; }
    }
}
