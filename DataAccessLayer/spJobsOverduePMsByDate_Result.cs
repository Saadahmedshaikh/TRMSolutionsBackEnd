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
    
    public partial class spJobsOverduePMsByDate_Result
    {
        public string Countries { get; set; }
        public string RigNames { get; set; }
        public Nullable<System.DateTime> Months { get; set; }
        public Nullable<int> MoringReports { get; set; }
        public Nullable<int> ICRs { get; set; }
        public int CompletedJobs { get; set; }
        public int OverdueOnMonthEnd { get; set; }
        public Nullable<decimal> MonthEndPercent { get; set; }
        public string RigStatus { get; set; }
    }
}
