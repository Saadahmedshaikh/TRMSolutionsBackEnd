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
    
    public partial class ReportFilesTab
    {
        public System.Guid ReportFilesTabID { get; set; }
        public System.Guid ReportTabID { get; set; }
        public System.Guid ReportFileID { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> UpdatedOnDate { get; set; }
    
        public virtual ReportTab ReportTab { get; set; }
    }
}
