using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMonitoring.BBDD
{
    public class OxygenSensor5
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public double Voltage { get; set; }

        public double ShortTermFuelTrim { get; set; }
        public DateTime CreatedOn { get; set; }

        public OxygenSensor5() { }
    }
}
