using System;
using SQLite;

namespace SmartMonitoring.BBDD
{
    public class FuelPressure : Table
    {

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int FuelPressureValue { get; set; }
        public DateTime CreatedOn { get; set; }

        public FuelPressure() { }
    }
}
