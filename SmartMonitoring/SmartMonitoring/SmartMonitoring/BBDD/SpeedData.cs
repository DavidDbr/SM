using System;
using SQLite;

namespace SmartMonitoring.BBDD
{
    public class SpeedData 
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set;}
        public string Speed { get; set; }
        public DateTime CreatedOn { get; set; }

        public SpeedData() { }
    }
}
