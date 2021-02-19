﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFirstApplication.objects;

namespace WebFirstApplication.Objects
{
    public class UploadedDocuments: ObjectBase
    {
        public string FileName { get; set; }
        public byte[] Content { get; set; }

        public string ContetntType { get; set; }
    }
}
