using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMonitoring.BBDD
{
    public class ShortTermSecondaryOxygenSensorTrim2_4
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string valueBankA { get; set; }
        public string valueBankB { get; set; }
        public DateTime CreatedOn { get; set; }

        public ShortTermSecondaryOxygenSensorTrim2_4() { }
    }
}
