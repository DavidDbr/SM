using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System.IO;
using SmartMonitoring.BBDD;
using SmartMonitoring.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLAndroid))]
namespace SmartMonitoring.Droid
{
    public class SQLAndroid : ISQLite
    {
        static SQLiteConnection connection = null;

        public SQLiteConnection GetConnection()
        {
            if (connection == null)
            {
                createConnection();
            }
            return connection;
        }

        public void createConnection()
        {
            var fileName = "SmartMonitoring.db3";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, fileName);
            connection = new SQLiteConnection(path);


        }
        //Estos métodos hay que ver en que clase deberían ir

        public void initBBDD()
        {

            connection.CreateTable<RPMData>();
            connection.CreateTable<DTCData>();
            connection.CreateTable<EngineTemperatureData>();
            connection.CreateTable<FuelPressure>();
            connection.CreateTable<SpeedData>();
            connection.CreateTable<ThrottlePosition>();
            connection.CreateTable<AbsoluteBarometricPressure>();
            connection.CreateTable<AbsoluteEvapSystemVaporPressure>();
            connection.CreateTable<AbsoluteLoadValue>();
            connection.CreateTable<AbsoluteThrottlePositionB>();
            connection.CreateTable<AbsoluteThrottlePositionC>();
            connection.CreateTable<AbsoluteThrottlePositionD>();
            connection.CreateTable<AbsoluteThrottlePositionE>();
            connection.CreateTable<AbsoluteThrottlePositionF>();
            connection.CreateTable<ActualEngine_PercentTorque>();
            connection.CreateTable<AmbientAirTemperature>();
            connection.CreateTable<CalculatedEngineLoadValuesData>();
            connection.CreateTable<CatalystTemperatureB1S1>();
            connection.CreateTable<CatalystTemperatureB1S2>();
            connection.CreateTable<CatalystTemperatureB2S1>();
            connection.CreateTable<CatalystTemperatureB2S2>();
            connection.CreateTable<CommandedEGR>();
            connection.CreateTable<CommandedEvaporativePurge>();
            connection.CreateTable<FuelSystemStatus>();
            //connection.CreateTable<secondaryairstatus>();
            connection.CreateTable<CommandedThrottleActuator>();
            connection.CreateTable<ControlModuleVoltage>();
            connection.CreateTable<DistanceTraveledSinceCodesCleared>();
            connection.CreateTable<DistanceTraveledWithMILo>();
            connection.CreateTable<DriverDemandEngine_PercentTorque>();
            connection.CreateTable<EGRError>();
            //connection.CreateTable<emissionrequirementstowhich...>();
            connection.CreateTable<EngineFuelRate>();
            connection.CreateTable<EngineOilTemperature>();
            connection.CreateTable<EnginePercentTorqueData>();
            connection.CreateTable<EngineReferenceTorque>();
            connection.CreateTable<EngineStartTime>();
            connection.CreateTable<TimeRunWithMILOn>();
            connection.CreateTable<EthanolFuelPercentage>();
            connection.CreateTable<EvapSystemVaporPressure>();
            connection.CreateTable<FuelAirCommandedEquivalenceRatio>();
            connection.CreateTable<FuelAirEquivalence_OxygenVoltage_OxygenSensorCurrent_IntakeManifoldAbsolutePressure>();
            connection.CreateTable<FuelInjectionTiming>();
            connection.CreateTable<FuelRailAbsolutePressure>();
            connection.CreateTable<FuelRailGaugePressure>();
            connection.CreateTable<FuelRailPressure>();
            connection.CreateTable<FuelTankLevel>();
            connection.CreateTable<FuelType>();
            connection.CreateTable<HybridBateryPackRemainingLife>();
            connection.CreateTable<IntakeManifoldAbsolutePressure>();
            connection.CreateTable<IntakeTemperature>();
            connection.CreateTable<LongTermFuelTrimB1>();
            connection.CreateTable<LongTermFuelTrimB2>();
            connection.CreateTable<LongTermSecondaryOxygenSensorTrim1_3>();
            connection.CreateTable<LongTermSecondaryOxygenSensorTrim2_4>();
            connection.CreateTable<MAFAirFlowRate>();
            connection.CreateTable<MaximunValueAirFlowRateFromMassAirFlowSensor>();
            connection.CreateTable<OxygenSensor1>();
            connection.CreateTable<OxygenSensor1B>();
            connection.CreateTable<OxygenSensor1C>();
            connection.CreateTable<OxygenSensor2>();
            connection.CreateTable<OxygenSensor2B>();
            connection.CreateTable<OxygenSensor2C>();
            connection.CreateTable<OxygenSensor3>();
            connection.CreateTable<OxygenSensor3B>();
            connection.CreateTable<OxygenSensor3C>();
            connection.CreateTable<OxygenSensor4>();
            connection.CreateTable<OxygenSensor4B>();
            connection.CreateTable<OxygenSensor4C>();
            connection.CreateTable<OxygenSensor5>();
            connection.CreateTable<OxygenSensor5B>();
            connection.CreateTable<OxygenSensor5C>();
            connection.CreateTable<OxygenSensor6>();
            connection.CreateTable<OxygenSensor6B>();
            connection.CreateTable<OxygenSensor6C>();
            connection.CreateTable<OxygenSensor7>();
            connection.CreateTable<OxygenSensor7B>();
            connection.CreateTable<OxygenSensor7C>();
            connection.CreateTable<OxygenSensor8>();
            connection.CreateTable<OxygenSensor8B>();
            connection.CreateTable<OxygenSensor8C>();
            connection.CreateTable<RelativeAcceleratorPedalPosition>();
            connection.CreateTable<RelativeThrottlePosition>();
            connection.CreateTable<RunTimeSinceEngineStart>();
            connection.CreateTable<ShortTermFuelTrimB1>();
            connection.CreateTable<ShortTermFuelTrimB2>();
            connection.CreateTable<ShortTermSecondaryOxygenSensorTrim1_3>();
            connection.CreateTable<ShortTermSecondaryOxygenSensorTrim2_4>();
            connection.CreateTable<TimingAdvance>();
            connection.CreateTable<WarmsUpsCodesCleared>();
            int VisibilidadCreada = connection.ExecuteScalar<int>("SELECT COUNT(*) FROM sqlite_master WHERE type='table' AND name='Visibilidad'");
            connection.CreateTable<Visibilidad>();
            if (VisibilidadCreada == 0)
            {

                connection.Insert(new Visibilidad()
                {
                    absoluteBarometricPressureVisible = 0,
                    absoluteEvapSystemVaporPressureVisible = 0,
                    absoluteLoadValueVisible = 0,
                    absoluteThrottlePositionBVisible = 0,
                    absoluteThrottlePositionCVisible = 0,
                    absoluteThrottlePositionDVisible = 0,
                    absoluteThrottlePositionEVisible = 0,
                    absoluteThrottlePositionFVisible = 0,
                    actualEngine_PercentTorqueVisible = 0,
                    ambientTemperatureVisible = 1,
                    calculatedEngineLoadValueVisible = 0,
                    catalystTemperatureB1S1Visible = 0,
                    catalystTemperatureB1S2Visible = 0,
                    catalystTemperatureB2S1Visible = 0,
                    catalystTemperatureB2S2Visible = 0,
                    commanddEvaporativePurgeVisible = 0,
                    commandedEGRVisible = 0,
                    commandedThrottleActuatorValueVisible = 0,
                    controlModuleVoltageVisible = 0,
                    distanceTraveledSinceCodesClearedVisible = 0,
                    distanceTraveledWithMILoVisible = 0,
                    driverDemandEngine_PercentTorqueVisible = 0,
                    EGRErrorVisible = 0,
                    emissionRequirementsToWhichVehicleIsDesignedVisible = 0,
                    engineFuelRateValueVisible = 0,
                    engineOilTemperatureVisible = 1,
                    enginePercentTorqueData_PercentageEnginePoint1Visible = 0,
                    enginePercentTorqueData_PercentageEnginePoint2Visible = 0,
                    enginePercentTorqueData_PercentageEnginePoint3Visible = 0,
                    enginePercentTorqueData_PercentageEnginePoint4Visible = 0,
                    enginePercentTorqueData_PercentageIdleVisible = 0,
                    engineReferenceTorqueVisible = 0,
                    engineTemperatureVisible = 1,
                    ethanolFuelPercentageVisible = 0,
                    evapSystemVaporPressureVisible = 0,
                    fuelAirCommandedEquivalenceRatioVisible = 0,
                    fuelInjectionTimingVisible = 0,
                    fuelPressureVisible = 0,
                    fuelRailAbsolutePressureVisible = 0,
                    fuelRailGaugePressureVisible = 0,
                    fuelSystemStatus_System1Visible = 0,
                    fuelSystemStatus_System2Visible = 0,
                    fuelTankLevelVisible = 1,
                    fuelTypeVisible = 0,
                    hybridBateryPackRemainingLifeVisible = 0,
                    intakeManifoldAbsolutePressureValueVisible = 0,
                    intakeTemperatureVisible = 0,
                    longTermFuelTrimB1Visible = 0,
                    longTermFuelTrimB2Visible = 0,
                    longTermSecondaryOxygenSensorTrim1_3_Visible = 0,

                    longTermSecondaryOxygenSensorTrim2_4_Visible = 0,
                    mAFAirFlowRateVisible = 0,
                    maximunValueAirFlowRateFromMassAirFlowSensorVisible = 0,
                    relativeAcceleratorPedalPositionVisible = 0,
                    relativeThrottlePositionVisible = 0,
                    rpmVisible = 1,
                    RunTimeSinceEngineStartVisible = 0,
                    shortTermFuelTrimB1Visible = 0,
                    shortTermFuelTrimB2Visible = 0,
                    shortTermSecondaryOxygenSensorTrim1_3_Visible = 0,
                    shortTermSecondaryOxygenSensorTrim2_4_Visible = 0,
                    speedVisible = 1,
                    throttlePositionVisible = 1,
                    timeEngineStartVisible = 0,
                    timeRunWithMILOnVisible = 0,
                    timeSinceTroubleCodesClearedVisible = 0,
                    timingAdvanceVisible = 0,
                    warmsUpsCodesClearedVisible = 0


                });
            }



        }

    }
}
