using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smart.Models
{
    public class MillHeadModel
    {
        public int MillId { get; set; }
        public string MillName { get; set; }
        public string UniqueName { get; set; }
        public Nullable<DateTime> ModifiedDateTime { get; set; }

    }
}