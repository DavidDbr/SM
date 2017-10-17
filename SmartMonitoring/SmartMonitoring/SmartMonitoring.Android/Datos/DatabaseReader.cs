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
        public List<int> getFuelSystemStatus()
        {

            List<int> value = new List<int>(2);
            value[0] = dataBase.ExecuteScalar<int>("SELECT System1 FROM FuelSystemStatus ORDER BY ID DESC LIMIT 1");
            value[1] = dataBase.ExecuteScalar<int>("SELECT System2 FROM FuelSystemStatus ORDER BY ID DESC LIMIT 1");
            return value;

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

        public int getLastActualEnginePercentTorque()
        {
            return dataBase.ExecuteScalar<int>("SELECT PercentageTorque FROM ActualEngine_PercentTorque ORDER BY ID DESC LIMIT 1");

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


        public double getLastMAFAirFlowRate()
        {
            return dataBase.ExecuteScalar<double>("SELECT MAFAirFlowRateValue FROM MAFAirFlowRate ORDER BY ID DESC LIMIT 1");

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
            return dataBase.ExecuteScalar<double>("SELECT CommandedThrottleActuatorValue FROM CommandedThrottleActuator ORDER BY ID DESC LIMIT 1");
        }

        public double getLastControlModuleVoltage()
        {
            return dataBase.ExecuteScalar<double>("SELECT Voltage FROM ControlModuleVoltage ORDER BY ID DESC LIMIT 1");
        }

        public int getLastDistanceTraveledSinseCodesCleared()
        {
            return dataBase.ExecuteScalar<int>("SELECT distance FROM DistanceTraveledSinceCodesCleared ORDER BY ID DESC LIMIT 1");
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
        public List<int> getLastEnginePercentTorqueData()
        {
            List<int> value = new List<int>(5);
            value[0] = dataBase.ExecuteScalar<int>("SELECT PercentageIdle FROM EnginePercentTorqueData ORDER BY ID DESC LIMIT 1");
            value[1] = dataBase.ExecuteScalar<int>("SELECT PercentageEnginePoint1 FROM EnginePercentTorqueData ORDER BY ID DESC LIMIT 1");
            value[2] = dataBase.ExecuteScalar<int>("SELECT PercentageEnginePoint2 FROM EnginePercentTorqueData ORDER BY ID DESC LIMIT 1");
            value[3] = dataBase.ExecuteScalar<int>("SELECT PercentageEnginePoint3 FROM EnginePercentTorqueData ORDER BY ID DESC LIMIT 1");
            value[4] = dataBase.ExecuteScalar<int>("SELECT PercentageEnginePoint4 FROM EnginePercentTorqueData ORDER BY ID DESC LIMIT 1");
            return value;
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
        public List<int> FuelAirEquivalence_OxygenVoltage_OxygenSensorCurrent_IntakeManifoldAbsolutePressure()
        {
            List<int> value = new List<int>(4);
            value[0] = dataBase.ExecuteScalar<int>("SELECT MaximunValue_Fuel_Air_EquivalenceRatio FROM FuelAirEquivalence_OxygenVoltage_OxygenSensorCurrent_IntakeManifoldAbsolutePressure ORDER BY ID DESC LIMIT 1");
            value[1] = dataBase.ExecuteScalar<int>("SELECT OxygenSensorVoltage FROM FuelAirEquivalence_OxygenVoltage_OxygenSensorCurrent_IntakeManifoldAbsolutePressure ORDER BY ID DESC LIMIT 1");
            value[2] = dataBase.ExecuteScalar<int>("SELECT OxygenSensorCurrent FROM FuelAirEquivalence_OxygenVoltage_OxygenSensorCurrent_IntakeManifoldAbsolutePressure ORDER BY ID DESC LIMIT 1");
            value[3] = dataBase.ExecuteScalar<int>("SELECT IntakeManifoldAbsolutePressure FROM FuelAirEquivalence_OxygenVoltage_OxygenSensorCurrent_IntakeManifoldAbsolutePressure ORDER BY ID DESC LIMIT 1");
           
            return value;
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
        public int getLastIntakeManifoldAbsolutePressure()
        {
            return dataBase.ExecuteScalar<int>("SELECT IntakeManifoldAbsolutePressureValue FROM IntakeManifoldAbsolutePressure ORDER BY ID DESC LIMIT 1");
        }
        public List<int> MaximunValueAirFlowRateFromMassAirFlowSensor()
        {
            List<int> value = new List<int>(4);
            value[0] = dataBase.ExecuteScalar<int>("SELECT MaximunValueA FROM MaximunValueAirFlowRateFromMassAirFlowSensor ORDER BY ID DESC LIMIT 1");
            value[1] = dataBase.ExecuteScalar<int>("SELECT MaximunValueB FROM MaximunValueAirFlowRateFromMassAirFlowSensor ORDER BY ID DESC LIMIT 1");
            value[2] = dataBase.ExecuteScalar<int>("SELECT MaximunValueC FROM MaximunValueAirFlowRateFromMassAirFlowSensor ORDER BY ID DESC LIMIT 1");
            value[3] = dataBase.ExecuteScalar<int>("SELECT MaximunValueD FROM MaximunValueAirFlowRateFromMassAirFlowSensor ORDER BY ID DESC LIMIT 1");

            return value;
        }

        public List<double> OxygenSensor1()
        {
            List<double> value = new List<double>(2);
            value[0] = dataBase.ExecuteScalar<double>("SELECT Voltage FROM OxygenSensor1 ORDER BY ID DESC LIMIT 1");
            value[1] = dataBase.ExecuteScalar<double>("SELECT ShortTermFuelTrim FROM OxygenSensor1 ORDER BY ID DESC LIMIT 1");
            return value;
        }
        public List<double> OxygenSensor1B()
        {
            List<double> value = new List<double>(2);
            value[0] = dataBase.ExecuteScalar<double>("SELECT Fuel_AirEquivalenceRatio FROM OxygenSensor1B ORDER BY ID DESC LIMIT 1");
            value[1] = dataBase.ExecuteScalar<double>("SELECT Voltage FROM OxygenSensor1B ORDER BY ID DESC LIMIT 1");            
            return value;
        }
        public List<double> OxygenSensor1C()
        {
            List<double> value = new List<double>(2);
            value[0] = dataBase.ExecuteScalar<double>("SELECT Fuel_AirEquivalenceRatio FROM OxygenSensor1C ORDER BY ID DESC LIMIT 1");
            value[1] = dataBase.ExecuteScalar<double>("SELECT Current FROM OxygenSensor1C ORDER BY ID DESC LIMIT 1");
            return value;
        }
        public List<double> OxygenSensor2()
        {
            List<double> value = new List<double>(2);
            value[0] = dataBase.ExecuteScalar<double>("SELECT Voltage FROM OxygenSensor2 ORDER BY ID DESC LIMIT 1");
            value[1] = dataBase.ExecuteScalar<double>("SELECT ShortTermFuelTrim FROM OxygenSensor2 ORDER BY ID DESC LIMIT 1");
            return value;
        }
        public List<double> OxygenSensor2B()
        {
            List<double> value = new List<double>(2);
            value[0] = dataBase.ExecuteScalar<double>("SELECT Fuel_AirEquivalenceRatio FROM OxygenSensor2B ORDER BY ID DESC LIMIT 1");
            value[1] = dataBase.ExecuteScalar<double>("SELECT Voltage FROM OxygenSensor2B ORDER BY ID DESC LIMIT 1");
            return value;
        }
        public List<double> OxygenSensor2C()
        {
            List<double> value = new List<double>(2);
            value[0] = dataBase.ExecuteScalar<double>("SELECT Fuel_AirEquivalenceRatio FROM OxygenSensor2C ORDER BY ID DESC LIMIT 1");
            value[1] = dataBase.ExecuteScalar<double>("SELECT Current FROM OxygenSensor2C ORDER BY ID DESC LIMIT 1");
            return value;

        }
        public List<double> OxygenSensor3()
        {
            List<double> value = new List<double>(2);
            value[0] = dataBase.ExecuteScalar<double>("SELECT Voltage FROM OxygenSensor3 ORDER BY ID DESC LIMIT 1");
            value[1] = dataBase.ExecuteScalar<double>("SELECT ShortTermFuelTrim FROM OxygenSensor3 ORDER BY ID DESC LIMIT 1");
            return value;
        }
        public List<double> OxygenSensor3B()
        {
            List<double> value = new List<double>(2);
            value[0] = dataBase.ExecuteScalar<double>("SELECT Fuel_AirEquivalenceRatio FROM OxygenSensor3B ORDER BY ID DESC LIMIT 1");
            value[1] = dataBase.ExecuteScalar<double>("SELECT Voltage FROM OxygenSensor3B ORDER BY ID DESC LIMIT 1");
            return value;
        }
        public List<double> OxygenSensor3C()
        {
            List<double> value = new List<double>(2);
            value[0] = dataBase.ExecuteScalar<double>("SELECT Fuel_AirEquivalenceRatio FROM OxygenSensor3C ORDER BY ID DESC LIMIT 1");
            value[1] = dataBase.ExecuteScalar<double>("SELECT Current FROM OxygenSensor3C ORDER BY ID DESC LIMIT 1");
            return value;
        }
        public List<double> OxygenSensor4()
        {
            List<double> value = new List<double>(2);
            value[0] = dataBase.ExecuteScalar<double>("SELECT Voltage FROM OxygenSensor4 ORDER BY ID DESC LIMIT 1");
            value[1] = dataBase.ExecuteScalar<double>("SELECT ShortTermFuelTrim FROM OxygenSensor4 ORDER BY ID DESC LIMIT 1");
            return value;
        }
        public List<double> OxygenSensor4B()
        {
            List<double> value = new List<double>(2);
            value[0] = dataBase.ExecuteScalar<double>("SELECT Fuel_AirEquivalenceRatio FROM OxygenSensor4B ORDER BY ID DESC LIMIT 1");
            value[1] = dataBase.ExecuteScalar<double>("SELECT Voltage FROM OxygenSensor4B ORDER BY ID DESC LIMIT 1");
            return value;

        }
        public List<double> OxygenSensor4C()
        {
            List<double> value = new List<double>(2);
            value[0] = dataBase.ExecuteScalar<double>("SELECT Fuel_AirEquivalenceRatio FROM OxygenSensor4C ORDER BY ID DESC LIMIT 1");
            value[1] = dataBase.ExecuteScalar<double>("SELECT Current FROM OxygenSensor4C ORDER BY ID DESC LIMIT 1");
            return value;
        }
        public List<double> OxygenSensor5()
        {
            List<double> value = new List<double>(2);
            value[0] = dataBase.ExecuteScalar<double>("SELECT Voltage FROM OxygenSensor5 ORDER BY ID DESC LIMIT 1");
            value[1] = dataBase.ExecuteScalar<double>("SELECT ShortTermFuelTrim FROM OxygenSensor5 ORDER BY ID DESC LIMIT 1");
            return value;
        }
        public List<double> OxygenSensor5B()
        {
            List<double> value = new List<double>(2);
            value[0] = dataBase.ExecuteScalar<double>("SELECT Fuel_AirEquivalenceRatio FROM OxygenSensor5B ORDER BY ID DESC LIMIT 1");
            value[1] = dataBase.ExecuteScalar<double>("SELECT Voltage FROM OxygenSensor5B ORDER BY ID DESC LIMIT 1");
            return value;
        }
        public List<double> OxygenSensor5C()
        {
            List<double> value = new List<double>(2);
            value[0] = dataBase.ExecuteScalar<double>("SELECT Fuel_AirEquivalenceRatio FROM OxygenSensor5C ORDER BY ID DESC LIMIT 1");
            value[1] = dataBase.ExecuteScalar<double>("SELECT Current FROM OxygenSensor5C ORDER BY ID DESC LIMIT 1");
            return value;
        }
        public List<double> OxygenSensor6()
        {
            List<double> value = new List<double>(2);
            value[0] = dataBase.ExecuteScalar<double>("SELECT Voltage FROM OxygenSensor6 ORDER BY ID DESC LIMIT 1");
            value[1] = dataBase.ExecuteScalar<double>("SELECT ShortTermFuelTrim FROM OxygenSensor6 ORDER BY ID DESC LIMIT 1");
            return value;
        }
        public List<double> OxygenSensor6C()
        {
            List<double> value = new List<double>(2);
            value[0] = dataBase.ExecuteScalar<double>("SELECT Fuel_AirEquivalenceRatio FROM OxygenSensor6C ORDER BY ID DESC LIMIT 1");
            value[1] = dataBase.ExecuteScalar<double>("SELECT Current FROM OxygenSensor6C ORDER BY ID DESC LIMIT 1");
            return value;
        }
        public List<double> OxygenSensor6B()
        {
            List<double> value = new List<double>(2);
            value[0] = dataBase.ExecuteScalar<double>("SELECT Fuel_AirEquivalenceRatio FROM OxygenSensor6B ORDER BY ID DESC LIMIT 1");
            value[1] = dataBase.ExecuteScalar<double>("SELECT Voltage FROM OxygenSensor6B ORDER BY ID DESC LIMIT 1");
            return value;
        }
        public List<double> OxygenSensor7()
        {
            List<double> value = new List<double>(2);
            value[0] = dataBase.ExecuteScalar<double>("SELECT Voltage FROM OxygenSensor7 ORDER BY ID DESC LIMIT 1");
            value[1] = dataBase.ExecuteScalar<double>("SELECT ShortTermFuelTrim FROM OxygenSensor7 ORDER BY ID DESC LIMIT 1");
            return value;
        }
        public List<double> OxygenSensor7B()
        {
            List<double> value = new List<double>(2);
            value[0] = dataBase.ExecuteScalar<double>("SELECT Fuel_AirEquivalenceRatio FROM OxygenSensor7B ORDER BY ID DESC LIMIT 1");
            value[1] = dataBase.ExecuteScalar<double>("SELECT Voltage FROM OxygenSensor7B ORDER BY ID DESC LIMIT 1");
            return value;
        }
        public List<double> OxygenSensor7C()
        {
            List<double> value = new List<double>(2);
            value[0] = dataBase.ExecuteScalar<double>("SELECT Fuel_AirEquivalenceRatio FROM OxygenSensor7C ORDER BY ID DESC LIMIT 1");
            value[1] = dataBase.ExecuteScalar<double>("SELECT Current FROM OxygenSensor7C ORDER BY ID DESC LIMIT 1");
            return value;
        }
        public List<double> OxygenSensor8()
        {
            List<double> value = new List<double>(2);
            value[0] = dataBase.ExecuteScalar<double>("SELECT Voltage FROM OxygenSensor8 ORDER BY ID DESC LIMIT 1");
            value[1] = dataBase.ExecuteScalar<double>("SELECT ShortTermFuelTrim FROM OxygenSensor8 ORDER BY ID DESC LIMIT 1");
            return value;
        }
        public List<double> OxygenSensor8B()
        {
            List<double> value = new List<double>(2);
            value[0] = dataBase.ExecuteScalar<double>("SELECT Fuel_AirEquivalenceRatio FROM OxygenSensor8B ORDER BY ID DESC LIMIT 1");
            value[1] = dataBase.ExecuteScalar<double>("SELECT Voltage FROM OxygenSensor8B ORDER BY ID DESC LIMIT 1");
            return value;

        }
        public List<double> OxygenSensor8C()
        {
            List<double> value = new List<double>(2);
            value[0] = dataBase.ExecuteScalar<double>("SELECT Fuel_AirEquivalenceRatio FROM OxygenSensor8C ORDER BY ID DESC LIMIT 1");
            value[1] = dataBase.ExecuteScalar<double>("SELECT Current FROM OxygenSensor8C ORDER BY ID DESC LIMIT 1");
            return value;
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
        public double getLastShortTermFuelTrimB2()
        {
            return dataBase.ExecuteScalar<double>("SELECT ShortTermFuelTrimBank1 FROM ShortTermFuelTrimB2 ORDER BY ID DESC LIMIT 1");
        }

        public double getLastLongTermFuelTrimB1()
        {
            return dataBase.ExecuteScalar<int>("SELECT LongTermFuelTrimBank1 FROM LongTermFuelTrimB2 ORDER BY ID DESC LIMIT 1");
        }

        public int getLastLongTermFuelTrimB2()
        {
            return dataBase.ExecuteScalar<int>("SELECT LongTermFuelTrimBank1 FROM LongTermFuelTrimB2 ORDER BY ID DESC LIMIT 1");
        }

        public List<double> ShortTermSecondaryOxygenSensorTrim1_3() {
            List<double> value = new List<double>(2);
            value[0] = dataBase.ExecuteScalar<double>("SELECT valueBankA FROM ShortTermSecondaryOxygenSensorTrim1_3 ORDER BY ID DESC LIMIT 1");
            value[1] = dataBase.ExecuteScalar<double>("SELECT valueBankB FROM ShortTermSecondaryOxygenSensorTrim1_3 ORDER BY ID DESC LIMIT 1");
            return value;
        }
        public List<double> ShortTermSecondaryOxygenSensorTrim2_4() {
            List<double> value = new List<double>(2);
            value[0] = dataBase.ExecuteScalar<double>("SELECT valueBankA FROM ShortTermSecondaryOxygenSensorTrim2_3 ORDER BY ID DESC LIMIT 1");
            value[1] = dataBase.ExecuteScalar<double>("SELECT valueBankB FROM ShortTermSecondaryOxygenSensorTrim2_4 ORDER BY ID DESC LIMIT 1");
            return value;
        }

        public List<double> LongTermSecondaryOxygenSensorTrim1_3()
        {
            List<double> value = new List<double>(2);
            value[0] = dataBase.ExecuteScalar<double>("SELECT valueBankA FROM LongTermSecondaryOxygenSensorTrim1_3 ORDER BY ID DESC LIMIT 1");
            value[1] = dataBase.ExecuteScalar<double>("SELECT valueBankB FROM LongTermSecondaryOxygenSensorTrim1_3 ORDER BY ID DESC LIMIT 1");
            return value;
        }
        public List<double> LongTermSecondaryOxygenSensorTrim2_4()
        {
            List<double> value = new List<double>(2);
            value[0] = dataBase.ExecuteScalar<double>("SELECT valueBankA FROM LongTermSecondaryOxygenSensorTrim2_3 ORDER BY ID DESC LIMIT 1");
            value[1] = dataBase.ExecuteScalar<double>("SELECT valueBankB FROM LongTermSecondaryOxygenSensorTrim2_4 ORDER BY ID DESC LIMIT 1");
            return value;
        }


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