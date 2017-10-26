using System;
using SQLite;

namespace SmartMonitoring.BBDD
{
    public class ThrottlePosition
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string ThrottlePositionValue { get; set; }
        public DateTime CreatedOn { get; set; }

        public ThrottlePosition(){}
    }
}
