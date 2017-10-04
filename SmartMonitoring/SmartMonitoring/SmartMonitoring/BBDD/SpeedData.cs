using System;
using SQLite;

namespace SmartMonitoring.BBDD
{
    public class SpeedData : Table
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set;}
        public int Speed { get; set; }
        public DateTime CreatedOn { get; set; }

        public SpeedData() { }
    }
}
