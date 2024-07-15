using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smart.Models
{
    public class FabricHeadModel
    {
        public int FabricId { get; set; }
        public string FabricName { get; set; }
        public string UniqueName { get; set; }
        public Nullable<DateTime> ModifiedDateTime { get; set; }

    }
}