using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smart.Models
{
    public class ColorHeadModel
    {

        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public string UniqueName { get; set; }
        public Nullable<DateTime> ModifiedDateTime { get; set; }

    }
}