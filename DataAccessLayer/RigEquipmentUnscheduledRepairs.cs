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
    
    public partial class RigEquipmentUnscheduledRepairs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RigEquipmentUnscheduledRepairs()
        {
            this.RigEquipmentUnscheduledRepairDetails = new HashSet<RigEquipmentUnscheduledRepairDetails>();
        }
    
        public System.Guid RigEquipmentUnscheduledRepairsID { get; set; }
        public System.Guid RigEquipmentID { get; set; }
        public Nullable<System.DateTime> RepairDate { get; set; }
        public string WONumber { get; set; }
        public string HourMeter { get; set; }
        public string LabourHours { get; set; }
        public string Comments { get; set; }
        public string OtherReason { get; set; }
        public string RepairReason { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public byte[] UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.Guid> OrgUnitID { get; set; }
        public byte[] Attachment { get; set; }
        public string AttachmentExtension { get; set; }
    
        public virtual RigEquipment RigEquipment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RigEquipmentUnscheduledRepairDetails> RigEquipmentUnscheduledRepairDetails { get; set; }
    }
}