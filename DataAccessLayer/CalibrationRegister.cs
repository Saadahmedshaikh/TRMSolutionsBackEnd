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
    
    public partial class CalibrationRegister
    {
        public System.Guid CalibrationRegisterID { get; set; }
        public string NameOfTheInstrument { get; set; }
        public string WDIAssetNo { get; set; }
        public string Location { get; set; }
        public string MeasurementRange { get; set; }
        public System.DateTime LastCalibrationDate { get; set; }
        public System.DateTime CalibrationExpiryDate { get; set; }
        public bool IsDefective { get; set; }
        public string Remarks { get; set; }
        public System.Guid OrgUnitID { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime UpdatedOnDate { get; set; }
        public string UpdatedBy { get; set; }
        public byte[] UpdatedOn { get; set; }
        public bool IsTableDeleted { get; set; }
        public string Deletedby { get; set; }
        public string DeletedOn { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string SerialNo { get; set; }
        public string DrawingNo { get; set; }
        public string CalibrationSource { get; set; }
    
        public virtual OrgUnit OrgUnit { get; set; }
    }
}