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
    
    public partial class LiftingGearRegister
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LiftingGearRegister()
        {
            this.LiftingGearRegisterDetails = new HashSet<LiftingGearRegisterDetails>();
        }
    
        public System.Guid LiftingGearRegisterID { get; set; }
        public System.Guid OrgUnitID { get; set; }
        public Nullable<System.DateTime> LiftingGearRegisterDate { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public byte[] UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LiftingGearRegisterDetails> LiftingGearRegisterDetails { get; set; }
        public virtual OrgUnit OrgUnit { get; set; }
    }
}
