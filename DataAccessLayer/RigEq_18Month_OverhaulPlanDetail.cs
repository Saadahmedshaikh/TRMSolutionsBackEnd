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
    
    public partial class RigEq_18Month_OverhaulPlanDetail
    {
        public System.Guid RigEquipmentPlanID { get; set; }
        public Nullable<System.Guid> RigEquipmentID { get; set; }
        public Nullable<System.Guid> RigEqUnscheduledRepairsID { get; set; }
        public Nullable<System.Guid> OverHaulType { get; set; }
        public Nullable<int> AssetID { get; set; }
        public Nullable<decimal> EstimatedBudget { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public byte[] UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}
