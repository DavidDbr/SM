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
        public int PercentageIdle { get; set; }

        public int PercentageEnginePoint1 { get; set; }

        public int PercentageEnginePoint2 { get; set; }

        public int PercentageEnginePoint3 { get; set; }

        public int PercentageEnginePoint4 { get; set; }

        public EnginePercentTorqueData() { }
    }
}
