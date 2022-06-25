﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApplication.DataObjects
{
    public class RelevantDocumentData
    {
        public String Title { get; set; }
        public String Description { get; set; }
        public String Url { get; set; }

        public override string ToString()
        {
            return String.Format("{0}-{1}-{2}", this.Title, this.Description, this.Url);
        }
    }
}
