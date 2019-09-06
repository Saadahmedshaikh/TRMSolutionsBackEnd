using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class EquipDetails
    {
        public string EquipmentName { get; set; }
        public string EquipmentType { get; set; }
        public string EquipmentModel { get; set; }
        public string EquipmentMake { get; set; }
        public string EquipmentRange { get; set; }
        public string EquipmentAccuracy { get; set; }
        public string EquipmentOthers { get; set; }
        public string EquipmentCustodian { get; set; }
        public string EquipmentLocation { get; set; }
        public string EquipmentFamilyName { get; set; }
        public Guid AssetID { get; set; }
        public Guid EquipmentCategoryID { get; set; }
        public string EquipmentCategoryName { get; set; }
        public Guid CompanyID { get; set; }
        public string CompanyName { get; set; }

    }
}
