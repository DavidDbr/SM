using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMonitoring.BBDD
{
    public class AbsoluteThrottlePositionC
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string ThrottlePositionC { get; set; }
        public DateTime CreatedOn { get; set; }

        public AbsoluteThrottlePositionC() { }
    }
}
