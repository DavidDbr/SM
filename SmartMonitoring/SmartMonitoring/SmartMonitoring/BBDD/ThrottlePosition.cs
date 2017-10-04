using System;
using SQLite;

namespace SmartMonitoring.BBDD
{
    public class ThrottlePosition : Table
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public double ThrottlePositionValue { get; set; }
        public DateTime CreatedOn { get; set; }

        public ThrottlePosition(){}
    }
}
