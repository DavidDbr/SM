using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMonitoring.BBDD
{
    public class EvapSystemVaporPressure
    {
        public int ID { get; set; }
        public double EvapSystemVaporPressureValue { get; set; }
        public DateTime CreatedOn { get; set; }

        public EvapSystemVaporPressure() { }
    }
}
