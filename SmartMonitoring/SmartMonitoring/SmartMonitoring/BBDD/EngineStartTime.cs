using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMonitoring.BBDD
{
    public class EngineStartTime
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int StartTime { get; set; }
        public DateTime CreatedOn { get; set; }

        public EngineStartTime() { }
    }
}
