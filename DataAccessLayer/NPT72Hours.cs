//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class NPT72Hours
    {
        public string CountryName { get; set; }
        public System.Guid OrgunitID { get; set; }
        public string rigNAme { get; set; }
        public System.Guid MorningReportID { get; set; }
        public Nullable<System.DateTime> MorningReportDate { get; set; }
        public int IACDCode { get; set; }
        public string IACDCodeDescription { get; set; }
        public Nullable<decimal> OperationHours { get; set; }
        public string OperationDetails { get; set; }
        public Nullable<bool> IS6HrOperation { get; set; }
        public string operationFrom { get; set; }
        public string NPT { get; set; }
    }
}