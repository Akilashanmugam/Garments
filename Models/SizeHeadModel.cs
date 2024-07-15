using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smart.Models
{
    public class SizeHeadModel
    {
        public int SizeId { get; set; }
        public string SizeName { get; set; }
        public string UniqueName { get; set; }
        public Nullable<DateTime> ModifiedDateTime { get; set; }

    }
}