using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace SmartMonitoring.BBDD
{
    
    public class Visibilidad
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        
        public int speedVisible{ get; set; }
        public int rpmVisible{ get; set; }
        public int engineTemperatureVisible{ get; set; }
        public int timeEngineStartVisible{ get; set; }

        public int absoluteBarometricPressureVisible{ get; set; }
        public int absoluteEvapSystemVaporPressureVisible{ get; set; }
        public int absoluteLoadValueVisible{ get; set; }
        public int absoluteThrottlePositionBVisible{ get; set; }
        public int absoluteThrottlePositionCVisible{ get; set; }
        public int absoluteThrottlePositionDVisible{ get; set; }
        public int absoluteThrottlePositionEVisible{ get; set; }
        public int absoluteThrottlePositionFVisible{ get; set; }
        public int actualEngine_PercentTorqueVisible{ get; set; }
        public int ambientTemperatureVisible{ get; set; }
        public int calculatedEngineLoadValueVisible{ get; set; }
        public int catalystTemperatureB1S1Visible{ get; set; }
        public int catalystTemperatureB1S2Visible{ get; set; }
        public int catalystTemperatureB2S1Visible{ get; set; }
        public int catalystTemperatureB2S2Visible{ get; set; }
        public int commandedEGRVisible{ get; set; }
        public int commanddEvaporativePurgeVisible{ get; set; }
        public int commandedThrottleActuatorValueVisible{ get; set; }
        public int controlModuleVoltageVisible{ get; set; }
        public int distanceTraveledSinceCodesClearedVisible{ get; set; }
        public int distanceTraveledWithMILoVisible{ get; set; }
        public int driverDemandEngine_PercentTorqueVisible{ get; set; }
        public int EGRErrorVisible{ get; set; }
        public int emissionRequirementsToWhichVehicleIsDesignedVisible{ get; set; }
        public int engineFuelRateValueVisible{ get; set; }
        public int engineOilTemperatureVisible{ get; set; }
        public int enginePercentTorqueData_PercentageIdleVisible{ get; set; }
        public int enginePercentTorqueData_PercentageEnginePoint1Visible{ get; set; }
        public int enginePercentTorqueData_PercentageEnginePoint2Visible{ get; set; }
        public int enginePercentTorqueData_PercentageEnginePoint3Visible{ get; set; }
        public int enginePercentTorqueData_PercentageEnginePoint4Visible{ get; set; }
        public int engineReferenceTorqueVisible{ get; set; }
        public int ethanolFuelPercentageVisible{ get; set; }
        public int evapSystemVaporPressureVisible{ get; set; }
        public int fuelAirCommandedEquivalenceRatioVisible{ get; set; }
        //--
        public int fuelInjectionTimingVisible{ get; set; }
        public int fuelPressureVisible{ get; set; }
        public int fuelRailAbsolutePressureVisible{ get; set; }
        public int fuelRailGaugePressureVisible{ get; set; }
        public int fuelSystemStatus_System1Visible{ get; set; }
        public int fuelSystemStatus_System2Visible{ get; set; }
        public int fuelTankLevelVisible{ get; set; }
        public int fuelTypeVisible{ get; set; }
        public int hybridBateryPackRemainingLifeVisible{ get; set; }
        public int intakeManifoldAbsolutePressureValueVisible{ get; set; }
        public int intakeTemperatureVisible{ get; set; }
        public int longTermFuelTrimB1Visible{ get; set; }
        public int longTermFuelTrimB2Visible{ get; set; }
        public int shortTermFuelTrimB1Visible{ get; set; }
        public int shortTermFuelTrimB2Visible{ get; set; }
        public int longTermSecondaryOxygenSensorTrim1_3_Visible{ get; set; }
        public int longTermSecondaryOxygenSensorTrim2_4_Visible{ get; set; }
        public int shortTermSecondaryOxygenSensorTrim1_3_Visible{ get; set; }
        public int shortTermSecondaryOxygenSensorTrim2_4_Visible{ get; set; }
        public int mAFAirFlowRateVisible{ get; set; }
        public int maximunValueAirFlowRateFromMassAirFlowSensorVisible{ get; set; }
        
        //SENSORES OXIGENO
        public int relativeAcceleratorPedalPositionVisible{ get; set; }
        public int relativeThrottlePositionVisible{ get; set; }
        public int RunTimeSinceEngineStartVisible{ get; set; }
        public int throttlePositionVisible{ get; set; }
        public int timeRunWithMILOnVisible{ get; set; }
        public int timeSinceTroubleCodesClearedVisible{ get; set; }
        public int timingAdvanceVisible{ get; set; }
        public int warmsUpsCodesClearedVisible{ get; set; } 

        public Visibilidad() { }

    }
}
