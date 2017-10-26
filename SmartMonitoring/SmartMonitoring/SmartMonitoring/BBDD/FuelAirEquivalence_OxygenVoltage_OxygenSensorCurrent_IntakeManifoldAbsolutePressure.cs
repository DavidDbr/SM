using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMonitoring.BBDD
{
    public class FuelAirEquivalence_OxygenVoltage_OxygenSensorCurrent_IntakeManifoldAbsolutePressure
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string MaximunValue_Fuel_Air_EquivalenceRatio { get; set; }

        public string OxygenSensorVoltage { get; set; }

        public string OxygenSensorCurrent { get; set; }

        public string IntakeManifoldAbsolutePressure { get; set; }
        public DateTime CreatedOn { get; set; }

        public FuelAirEquivalence_OxygenVoltage_OxygenSensorCurrent_IntakeManifoldAbsolutePressure() { }
    }
}
