using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class EquipSchedule
    {
        public string EquipmentScheduleName { get; set; }
        public string EquipmentScheduleType { get; set; }
        public string EquipmentScheduleBasis { get; set; }
        public int Interval { get; set; }
        public int Margin { get; set; }
        public int Leverage { get; set; }

    }
}
