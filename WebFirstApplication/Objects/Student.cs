﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFirstApplication.objects
{
    public class Student:ObjectBase
    {   
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudentID { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }

      
    }
}
