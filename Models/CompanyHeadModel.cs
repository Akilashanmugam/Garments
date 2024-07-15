using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smart.Models
{
    public class CompanyHeadModel
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string UniqueName { get; set; }
        public string CompanyPrintName { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyAddress1 { get; set; }
        public string CompanyAddress2 { get; set; }
        public string CompanyAddress3 { get; set; }
        public string CompanyAddress4 { get; set; }
        public string CompanyPhoneNo { get; set; }
        public string CompanyFaxNo { get; set; }
        public string CompanyEmailid { get; set; }
        public string companywebsite { get; set; }
        public string CompanyTinNo { get; set; }
        public string CompanyCstNo { get; set; }
        public string CompanyType { get; set; }
        public string CompanyPanNo { get; set; }
        public Nullable<DateTime> ModifiedDateTime { get; set; }
      
    }
}