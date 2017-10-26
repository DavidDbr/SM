using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMonitoring.BBDD
{
    public class OxygenSensor8B
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Fuel_AirEquivalenceRatio { get; set; }

        public string Voltage { get; set; }
        public DateTime CreatedOn { get; set; }

        public OxygenSensor8B() { }
    }
}
