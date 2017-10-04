using System;
using SQLite;

namespace SmartMonitoring.BBDD
{

    public class RPMData
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int RPM { get; set; }
        public DateTime CreatedOn { get; set; }

        public RPMData() { }
    }
}
