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
    
    public partial class MaterialTransferHistoryLog
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MaterialTransferHistoryLog()
        {
            this.MaterialTransferDetails = new HashSet<MaterialTransferDetails>();
        }
    
        public System.Guid MaterialTransferHistoryLogID { get; set; }
        public System.Guid OrgUnitID { get; set; }
        public System.Guid ToOrgUnitID { get; set; }
        public Nullable<System.DateTime> TransferDate { get; set; }
        public Nullable<System.DateTime> ReceivedOn { get; set; }
        public string ReceivedBy { get; set; }
        public Nullable<System.DateTime> NotReceivedOn { get; set; }
        public string NotReceivedBy { get; set; }
        public Nullable<System.DateTime> FinalTransferOn { get; set; }
        public string FinalTransferBy { get; set; }
        public int STATUS { get; set; }
        public bool IsTemporary { get; set; }
        public bool IsExpirayMailSent { get; set; }
        public bool IsInitiationMailSent { get; set; }
        public bool IsRecNotRecMailSent { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public byte[] UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime UpdatedOnDate { get; set; }
        public string Transferno { get; set; }
        public string DriverName { get; set; }
        public string Comments { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string Remarks { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialTransferDetails> MaterialTransferDetails { get; set; }
        public virtual OrgUnit OrgUnit { get; set; }
        public virtual OrgUnit OrgUnit1 { get; set; }
    }
}
