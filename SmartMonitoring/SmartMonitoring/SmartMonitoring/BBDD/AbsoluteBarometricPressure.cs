using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMonitoring.BBDD
{
    public class AbsoluteBarometricPressure
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string BarometricPressure { get; set; }
        public DateTime CreatedOn { get; set; }

        public AbsoluteBarometricPressure() { }
    }
}
