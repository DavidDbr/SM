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
        public int MaximunValueA { get; set; }

        public int MaximunValueB { get; set; }

        public int MaximunValueC { get; set; }
        public int MaximunValueD { get; set; }
        public DateTime CreatedOn { get; set; }

        public MaximunValueAirFlowRateFromMassAirFlowSensor() { }
    }
}
