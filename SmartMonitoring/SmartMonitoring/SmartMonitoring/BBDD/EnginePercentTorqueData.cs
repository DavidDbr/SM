using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMonitoring.BBDD
{
    public class EnginePercentTorqueData
    {
        public DateTime CreatedOn { get; set; }
        public string PercentageIdle { get; set; }

        public string PercentageEnginePoint1 { get; set; }

        public string PercentageEnginePoint2 { get; set; }

        public string PercentageEnginePoint3 { get; set; }

        public string PercentageEnginePoint4 { get; set; }

        public EnginePercentTorqueData() { }
    }
}
