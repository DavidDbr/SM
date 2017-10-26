using System;
using SQLite;

namespace SmartMonitoring.BBDD
{
    public class EngineTemperatureData
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Temperature { get; set; }
        public DateTime CreatedOn { get; set; }

        public EngineTemperatureData() { }
    }
}
