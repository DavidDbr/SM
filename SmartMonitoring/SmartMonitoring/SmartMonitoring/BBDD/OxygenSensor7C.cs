using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMonitoring.BBDD
{
    public class OxygenSensor7C
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public double Fuel_airEquivalenceRatio { get; set; }

        public double Current { get; set; }
        public DateTime CreatedOn { get; set; }

        public OxygenSensor7C() { }
    }
}
