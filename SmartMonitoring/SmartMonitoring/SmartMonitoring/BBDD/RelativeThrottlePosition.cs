using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMonitoring.BBDD
{
    public class RelativeThrottlePosition
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public double ThrottlePosition { get; set; }
        public DateTime CreatedOn { get; set; }

        public RelativeThrottlePosition() { }
    }
}
