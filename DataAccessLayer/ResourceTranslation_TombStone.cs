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
    
    public partial class ResourceTranslation_TombStone
    {
        public System.Guid ResourceTranslationID { get; set; }
        public System.Guid LocalizedResourceID { get; set; }
        public System.Guid LanguageID { get; set; }
        public string TranslatedValue { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public byte[] UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}
