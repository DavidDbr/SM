using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMonitoring.BBDD
{
    public class MaximunValueAirFlowRateFromMassAirFlowSensor
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string MaximunValueA { get; set; }

        public string MaximunValueB { get; set; }

        public string MaximunValueC { get; set; }
        public string MaximunValueD { get; set; }
        public DateTime CreatedOn { get; set; }

        public MaximunValueAirFlowRateFromMassAirFlowSensor() { }
    }
}
