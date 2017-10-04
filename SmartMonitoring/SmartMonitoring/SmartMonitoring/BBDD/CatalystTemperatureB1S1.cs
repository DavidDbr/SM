using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMonitoring.BBDD
{
    public class CatalystTemperatureB1S1
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public double Temperature { get; set; }
        public DateTime CreatedOn { get; set; }

        public CatalystTemperatureB1S1() { }
    }
}
