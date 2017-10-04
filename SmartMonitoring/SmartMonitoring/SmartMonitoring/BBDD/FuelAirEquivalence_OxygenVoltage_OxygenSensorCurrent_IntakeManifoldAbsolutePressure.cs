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
        public int MaximunValue_Fuel_Air_EquivalenceRatio{ get; set; }

        public int OxygenSensorVoltage { get; set; }

        public int OxygenSensorCurrent { get; set; }

        public int IntakeManifoldAbsolutePressure { get; set; }
        public DateTime CreatedOn { get; set; }

        public FuelAirEquivalence_OxygenVoltage_OxygenSensorCurrent_IntakeManifoldAbsolutePressure() { }
    }
}
