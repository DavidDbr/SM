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

namespace SmartMonitoring.Droid.Datos
{
   public class DataBaseReader
    {
        SQLiteConnection dataBase;

        public DataBaseReader(SQLiteConnection dataBase)
        {
            this.dataBase = dataBase;
        }
        public double getLastCalculatedEngineValue()
        {

            return dataBase.ExecuteScalar<double>("SELECT CalculatedEngineLoadValue FROM CalculatedEngineLoadValueData ORDER BY ID DESC LIMIT 1");

        }

        public int getLastEngineTemperature()
        {
            return dataBase.ExecuteScalar<int>("SELECT Temperature FROM EngineTemperatureData ORDER BY ID DESC LIMIT 1");

        }

        public int getLastAbsoluteBarometricPressure()
        {
            return dataBase.ExecuteScalar<int>("SELECT BarometricPressure FROM AbsoluteBarometricPressure ORDER BY ID DESC LIMIT 1");

        }

        public int getLastAbsoluteEvapSystemVaporPressure()
        {
            return dataBase.ExecuteScalar<int>("SELECT BarometricPressure FROM AbsoluteBarometricPressure ORDER BY ID DESC LIMIT 1");

        }

        public double getLastAbsoluteLoadValue()
        {
            return dataBase.ExecuteScalar<double>("SELECT Value FROM AbsoluteLoadValue ORDER BY ID DESC LIMIT 1");
        }

        public double getLastAbsoluteThrottlePositionB()
        {
            return dataBase.ExecuteScalar<double>("SELECT ThrottlePositionB FROM AbsoluteThrottlePositionB ORDER BY ID DESC LIMIT 1");

        }
        public double getLastAbsoluteThrottlePositionC()
        {
            return dataBase.ExecuteScalar<double>("SELECT ThrottlePositionC FROM AbsoluteThrottlePositionC ORDER BY ID DESC LIMIT 1");

        }
        public double getLastAbsoluteThrottlePositionD()
        {
            return dataBase.ExecuteScalar<double>("SELECT ThrottlePositionD FROM AbsoluteThrottlePositionD ORDER BY ID DESC LIMIT 1");

        }
        public double getLastAbsoluteThrottlePositionE()
        {
            return dataBase.ExecuteScalar<double>("SELECT ThrottlePositionE FROM AbsoluteThrottlePositionE ORDER BY ID DESC LIMIT 1");

        }
        public double getLastAbsoluteThrottlePositionF()
        {
            return dataBase.ExecuteScalar<double>("SELECT ThrottlePositionF FROM AbsoluteThrottlePositionF ORDER BY ID DESC LIMIT 1");

        }

        public double getLastActualEnginePercentTorque()
        {
            return dataBase.ExecuteScalar<double>("SELECT PercentageTorque FROM ActualEngine_PercentTorque ORDER BY ID DESC LIMIT 1");

        }

        public int getLastAmbientAirTemperature()
        {
            return dataBase.ExecuteScalar<int>("SELECT Temperature FROM AmbientAirTemperature ORDER BY ID DESC LIMIT 1");

        }

        public double getLastCalculatedEngineLoadValueData()
        {
            return dataBase.ExecuteScalar<double>("SELECT CalculatedEngineLoadValue FROM CalculatedEngineLoadValueData ORDER BY ID DESC LIMIT 1");

        }

        public double getLastCatalystTemperatureB1S1()
        {
            return dataBase.ExecuteScalar<double>("SELECT Temperature FROM CatalystTemperatureB1S1 ORDER BY ID DESC LIMIT 1");

        }

        public double getLastCatalystTemperatureB1S2()
        {
            return dataBase.ExecuteScalar<double>("SELECT Temperature FROM CatalystTemperatureB1S2 ORDER BY ID DESC LIMIT 1");

        }
        public double getLastCatalystTemperatureB2S2()
        {
            return dataBase.ExecuteScalar<double>("SELECT Temperature FROM CatalystTemperatureB2S2 ORDER BY ID DESC LIMIT 1");

        }
        public double getLastCatalystTemperatureB2S1()
        {
            return dataBase.ExecuteScalar<double>("SELECT Temperature FROM CatalystTemperatureB2S1 ORDER BY ID DESC LIMIT 1");

        }

        public double getLastCommandedEGR()
        {
            return dataBase.ExecuteScalar<double>("SELECT ValueEGR FROM CommandedEGR ORDER BY ID DESC LIMIT 1");

        }

        public double getLastCommandedEvaporativePurge()
        {
            return dataBase.ExecuteScalar<double>("SELECT Value FROM CommandedEvaporativePurge ORDER BY ID DESC LIMIT 1");

        }

        public double getLastCommandedSecondaryAirStatus()
        {
            return 0; // dataBase.ExecuteScalar<double>("SELECT Value FROM CommandedEvaporativePurge ORDER BY ID DESC LIMIT 1");

        }

        public double getLastCommandedThrottleActuator()
        {
            return dataBase.ExecuteScalar<double>("SELECT CommandedThrottleActuatorValue FROM CommandedThrottleAcuator ORDER BY ID DESC LIMIT 1");
        }

        public void getLastControlModuleVoltage()
        {

        }

        public int getLastDistanceTraveledSinseCodesCleared()
        {
            return dataBase.ExecuteScalar<int>("SELECT distance FROM DistanceTraveledSinseCodesCleared ORDER BY ID DESC LIMIT 1");
        }

        public int getLastDistanceTraveledWithMILo()
        {
            return dataBase.ExecuteScalar<int>("SELECT Distance FROM DistanceTraveledWithMILo ORDER BY ID DESC LIMIT 1");
        }
        public int getLastDriverDemandEngine_PercentTorque()
        {
            return dataBase.ExecuteScalar<int>("SELECT Percentage FROM DriverDemandEngine_PercentTorque ORDER BY ID DESC LIMIT 1");
        }
        public double getLastEGRError()
        {
            return dataBase.ExecuteScalar<double>("SELECT ValueEGR FROM EGRError ORDER BY ID DESC LIMIT 1");
        }
        public double getLastEngineFuelRate()
        {
            return dataBase.ExecuteScalar<double>("SELECT EngineFuelRateValue FROM EngineFuelRate ORDER BY ID DESC LIMIT 1");
        }

        public double getLastEngineOilTemperature()
        {
            return dataBase.ExecuteScalar<double>("SELECT Temperature FROM EngineOilTemperature ORDER BY ID DESC LIMIT 1");
        }
        public void getLastEnginePercentTorqueData()
        {

        }
        public int getLastEngineReferenceTorque()
        {
            return dataBase.ExecuteScalar<int>("SELECT ReferenceTorque FROM EngineReferenceTorque ORDER BY ID DESC LIMIT 1");
        }
        public int getLastEngineStartTime()
        {
            return dataBase.ExecuteScalar<int>("SELECT StartTime FROM EngineStartTime ORDER BY ID DESC LIMIT 1");
        }
        public int getLastEngineTemperatureData()
        {
            return dataBase.ExecuteScalar<int>("SELECT Temperature FROM EngineTemperatureData ORDER BY ID DESC LIMIT 1");
        }

        public double getLastEthanolFuelPercentage()
        {
            return dataBase.ExecuteScalar<double>("SELECT Percentage FROM EthanolFuelPercentage ORDER BY ID DESC LIMIT 1");
        }
        public double getLastEvapSystemVaporPressure()
        {
            return dataBase.ExecuteScalar<double>("SELECT EvapSystemVaporPressureValue FROM EvapSystemVaporPressure ORDER BY ID DESC LIMIT 1");
        }
        public double getLastFuelAirCommandedEquivalenceRatio()
        {
            return dataBase.ExecuteScalar<double>("SELECT Ratio FROM FuelAirCommandedEquivalenceRatio ORDER BY ID DESC LIMIT 1");
        }
        public void FuelAirEquivalence_OxygenVoltage_OxygenSensorCurrent_IntakeManifoldAbsolutePressure()
        {

        }
        public double getLastFuelInjectionTimingValue()
        {
            return dataBase.ExecuteScalar<double>("SELECT FuelInjectionTimingValue FROM FuelInjectionTiming ORDER BY ID DESC LIMIT 1");
        }
        public int getLastFuelPressure()
        {
            return dataBase.ExecuteScalar<int>("SELECT FuelPressureValue FROM FuelPressure ORDER BY ID DESC LIMIT 1");
        }
        public double getLastFuelRailAbsolutePressure()
        {
            return dataBase.ExecuteScalar<double>("SELECT Pressure FROM FuelRailAbsolutePressure ORDER BY ID DESC LIMIT 1");
        }
        public int getLastFuelRailGaugeAbsolutePressure()
        {
            return dataBase.ExecuteScalar<int>("SELECT Pressure FROM FuelRailGaugePressure ORDER BY ID DESC LIMIT 1");
        }
        public double getLastFuelRailPressure()
        {
            return dataBase.ExecuteScalar<double>("SELECT Pressure FROM FuelRailPressure ORDER BY ID DESC LIMIT 1");
        }
        public double getLastFuelTankLevel()
        {
            return dataBase.ExecuteScalar<double>("SELECT FuelTankLevelValue FROM FuelTankLevel ORDER BY ID DESC LIMIT 1");
        }

        public string getFuelType()
        {
            return dataBase.ExecuteScalar<string>("SELECT FuelTypeValue FROM FuelType ORDER BY ID DESC LIMIT 1");
        }
        public double getLastHybridBateryPackRemainingLife()
        {
            return dataBase.ExecuteScalar<double>("SELECT RemainingLife FROM HybridBateryPackRemainingLife ORDER BY ID DESC LIMIT 1");
        }
        public double getLastIntakeManifoldAbsolutePressure()
        {
            return dataBase.ExecuteScalar<double>("SELECT IntakeManifoldAbsolutePressureValue FROM HybridBateryPackRemainingLife ORDER BY ID DESC LIMIT 1");
        }
        public void MaximunValueAirFlowRateFromMassAirFlowSensor()
        {

        }

        public void OxygenSensor1()
        {

        }
        public void OxygenSensor1B()
        {

        }
        public void OxygenSensor1C()
        {

        }
        public void OxygenSensor2()
        {

        }
        public void OxygenSensor2B()
        {

        }
        public void OxygenSensor2C()
        {

        }
        public void OxygenSensor3()
        {

        }
        public void OxygenSensor3B()
        {

        }
        public void OxygenSensor3C()
        {

        }
        public void OxygenSensor4()
        {

        }
        public void OxygenSensor4B()
        {

        }
        public void OxygenSensor4C()
        {

        }
        public void OxygenSensor5()
        {

        }
        public void OxygenSensor5B()
        {

        }
        public void OxygenSensor5C()
        {

        }
        public void OxygenSensor6()
        {

        }
        public void OxygenSensor6B()
        {

        }
        public void OxygenSensor6C()
        {

        }
        public void OxygenSensor7()
        {

        }
        public void OxygenSensor7B()
        {

        }
        public void OxygenSensor7C()
        {

        }
        public void OxygenSensor8()
        {

        }
        public void OxygenSensor8B()
        {

        }
        public void OxygenSensor8C()
        {

        }
        public double getLastRelativeAcceleratorPedalPosition()
        {
            return dataBase.ExecuteScalar<double>("SELECT Position FROM RelativeAcceleratorPedalPosition ORDER BY ID DESC LIMIT 1");
        }
        public double getLastRelativeThrottlePosition()
        {
            return dataBase.ExecuteScalar<double>("SELECT ThrottlePosition FROM RelativeThrottlePosition ORDER BY ID DESC LIMIT 1");
        }
        public int getLastRPM()
        {
            return dataBase.ExecuteScalar<int>("SELECT RPM FROM RPMData ORDER BY ID DESC LIMIT 1");
        }
        public int getRunTimeSinceEngineStart()
        {
            return dataBase.ExecuteScalar<int>("SELECT Time FROM RunTimeSinceEngineStart ORDER BY ID DESC LIMIT 1");
        }
        public double getLastShortTermFuelTrimB1()
        {
            return dataBase.ExecuteScalar<double>("SELECT ShortTermFuelTrimBank1 FROM ShortTermFuelTrimB1 ORDER BY ID DESC LIMIT 1");
        }
        public int getLastShortTermFuelTrimB2()
        {
            return dataBase.ExecuteScalar<int>("SELECT ShortTermFuelTrimBank1 FROM ShortTermFuelTrimB2 ORDER BY ID DESC LIMIT 1");
        }

        public void ShortTermSecondaryOxygenSensorTrim1_3() { }
        public void ShortTermSecondaryOxygenSensorTrim2_4() { }

        public int getLastSpeed()
        {
            return dataBase.ExecuteScalar<int>("SELECT Speed FROM SpeedData ORDER BY ID DESC LIMIT 1");
        }
        public double getLastThrottlePosition()
        {
            return dataBase.ExecuteScalar<double>("SELECT ThrottlePositionValue FROM ThrottlePosition ORDER BY ID DESC LIMIT 1");
        }
        public int getRunTimeRunWithMILOn()
        {
            return dataBase.ExecuteScalar<int>("SELECT Time FROM TimeRunWithMILOn ORDER BY ID DESC LIMIT 1");
        }
        public int getRunTimeSinceTroubleCodesCleares()
        {
            return dataBase.ExecuteScalar<int>("SELECT Time FROM TimeRunWithMILOn ORDER BY ID DESC LIMIT 1");
        }
        public int getLastTimingAdvance()
        {
            return dataBase.ExecuteScalar<int>("SELECT Time FROM TimingAdvance ORDER BY ID DESC LIMIT 1");
        }

        public int getLastWarmsUpsCodesCleared()
        {
            return dataBase.ExecuteScalar<int>("SELECT Value FROM WarmsUpsCodesCleared ORDER BY ID DESC LIMIT 1");
        }
    }
}