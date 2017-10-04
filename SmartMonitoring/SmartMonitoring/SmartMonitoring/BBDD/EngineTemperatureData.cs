using System;
using SQLite;

namespace SmartMonitoring.BBDD
{
    public class EngineTemperatureData : Table
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int Temperature { get; set; }
        public DateTime CreatedOn { get; set; }

        public EngineTemperatureData() { }
    }
}
