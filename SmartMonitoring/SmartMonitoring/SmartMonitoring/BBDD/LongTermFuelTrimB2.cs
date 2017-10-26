using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMonitoring.BBDD
{
    public class LongTermFuelTrimB2
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string LongTermFuelTrimBank2 { get; set; }
        public DateTime CreatedOn { get; set; }

        public LongTermFuelTrimB2() { }
    }
}
