using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMonitoring.BBDD
{
    public class FuelSystemStatus
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int System1 { get; set; }
        public int System2 { get; set; }
        public DateTime CreatedOn { get; set; }
        public FuelSystemStatus() { }
    }
}
