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
    
    public partial class WebJobs
    {
        public int JobID { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsProcessing { get; set; }
        public System.DateTime StartAt { get; set; }
        public Nullable<System.DateTime> LastRunAt { get; set; }
        public string Interval { get; set; }
        public int ErrorFlag { get; set; }
        public string WarningRecipients { get; set; }
    }
}
