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
    
    public partial class ColorCode
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ColorCode()
        {
            this.PMDiagramFields = new HashSet<PMDiagramFields>();
        }
    
        public System.Guid ColorCodeID { get; set; }
        public System.Guid PMDiagramID { get; set; }
        public System.Guid ColorID { get; set; }
        public string Text { get; set; }
        public Nullable<int> Sequence { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public byte[] UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    
        public virtual Color Color { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PMDiagramFields> PMDiagramFields { get; set; }
        public virtual PMDiagram PMDiagram { get; set; }
    }
}