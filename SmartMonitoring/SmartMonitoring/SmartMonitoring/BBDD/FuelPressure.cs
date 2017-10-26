using System;
using SQLite;

namespace SmartMonitoring.BBDD
{
    public class FuelPressure
    {

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string FuelPressureValue { get; set; }
        public DateTime CreatedOn { get; set; }

        public FuelPressure() { }
    }
}
