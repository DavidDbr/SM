using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMonitoring.BBDD
{
    public class OxygenSensor6C
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Fuel_airEquivalenceRatio { get; set; }

        public string Current { get; set; }
        public DateTime CreatedOn { get; set; }

        public OxygenSensor6C() { }
    }
}
