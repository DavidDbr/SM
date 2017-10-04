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
using Android.Bluetooth;
using SmartMonitoring.Droid.Datos;

namespace SmartMonitoring.Droid
{
    public class ConnectionManagement : IConnectionManagement
    {
        BluetoothSocket socket = null;
        DataBaseReader reader;
        ISmartMonitoringDAO dao;


        public ConnectionManagement(BluetoothSocket socket)
        {

            this.socket = socket;
            dao = new SmartMonitoringDAO(socket);
            dao.Initialize();
            reader = dao.getReader();


        }

        public void ConsultParameters()
        {
            dao.ConsultParameters();
        }

        public string DiagnosticCar()
        {
            return dao.DiagnosticCar();
        }

        public void InitializedOBD2()
        {
            dao.Initialize();
        }

        /*public <double> getResultados()
        {
            return dao.
        }*/

        public double getLastCalculatedEngineValue()
        {

            return reader.getLastCalculatedEngineValue();

        }

        public int getLastEngineTemperature()
        {
            return reader.getLastEngineTemperature();

        }

        public int getLastAbsoluteBarometricPressure()
        {
            return reader.getLastAbsoluteBarometricPressure();

        }

        public int getLastAbsoluteEvapSystemVaporPressure()
        {
            return reader.getLastAbsoluteEvapSystemVaporPressure();

        }

        public double getLastAbsoluteLoadValue()
        {
            return reader.getLastAbsoluteLoadValue();
        }

        public double getLastAbsoluteThrottlePositionB()
        {
            return reader.getLastAbsoluteThrottlePositionB();

        }
        public double getLastAbsoluteThrottlePositionC()
        {
            return reader.getLastAbsoluteThrottlePositionC();

        }
        public double getLastAbsoluteThrottlePositionD()
        {
            return reader.getLastAbsoluteThrottlePositionD();

        }
        public double getLastAbsoluteThrottlePositionE()
        {
            return reader.getLastAbsoluteThrottlePositionE();

        }
        public double getLastAbsoluteThrottlePositionF()
        {
            return reader.getLastAbsoluteThrottlePositionF();

        }

        public double getLastActualEnginePercentTorque()
        {
            return reader.getLastActualEnginePercentTorque();

        }

        public int getLastAmbientAirTemperature()
        {
            return reader.getLastAmbientAirTemperature();

        }

        public double getLastCalculatedEngineLoadValueData()
        {
            return reader.getLastCalculatedEngineLoadValueData();

        }

        public double getLastCatalystTemperatureB1S1()
        {
            return reader.getLastCatalystTemperatureB1S1();

        }

        public double getLastCatalystTemperatureB1S2()
        {
            return reader.getLastCatalystTemperatureB1S2();

        }
        public double getLastCatalystTemperatureB2S2()
        {
            return reader.getLastCatalystTemperatureB2S2();

        }
        public double getLastCatalystTemperatureB2S1()
        {
            return reader.getLastCatalystTemperatureB2S1();

        }

        public double getLastCommandedEGR()
        {
            return reader.getLastCommandedEGR();

        }

        public double getLastCommandedEvaporativePurge()
        {
            return reader.getLastCommandedEvaporativePurge();

        }

        public void getLastCommandedSecondaryAirStatus()
        {
            // dataBase.ExecuteScalar<double>("SELECT Value FROM CommandedEvaporativePurge ORDER BY ID DESC LIMIT 1");

        }

        public double getLastCommandedThrottleActuator()
        {
            return reader.getLastCommandedThrottleActuator();
        }

        public void getLastControlModuleVoltage()
        {

        }

        public int getLastDistanceTraveledSinseCodesCleared()
        {
            return reader.getLastDistanceTraveledSinseCodesCleared();
        }

        public int getLastDistanceTraveledWithMILo()
        {
            return reader.getLastDistanceTraveledWithMILo();
        }
        public int getLastDriverDemandEngine_PercentTorque()
        {
            return reader.getLastDriverDemandEngine_PercentTorque();
        }
        public double getLastEGRError()
        {
            return reader.getLastEGRError();
        }
        public double getLastEngineFuelRate()
        {
            return reader.getLastEngineFuelRate();
        }

        public double getLastEngineOilTemperature()
        {
            return reader.getLastEngineOilTemperature();
        }
        public void getLastEnginePercentTorqueData()
        {

        }
        public int getLastEngineReferenceTorque()
        {
            return reader.getLastEngineReferenceTorque();
        }
        public int getLastEngineStartTime()
        {
            return reader.getLastEngineStartTime();
        }
        public int getLastEngineTemperatureData()
        {
            return reader.getLastEngineTemperatureData();
        }

        public double getLastEthanolFuelPercentage()
        {
            return reader.getLastEthanolFuelPercentage();
        }
        public double getLastEvapSystemVaporPressure()
        {
            return reader.getLastEvapSystemVaporPressure();
        }
        public double getLastFuelAirCommandedEquivalenceRatio()
        {
            return reader.getLastFuelAirCommandedEquivalenceRatio();
        }
        public void FuelAirEquivalence_OxygenVoltage_OxygenSensorCurrent_IntakeManifoldAbsolutePressure()
        {

        }
        public double getLastFuelInjectionTimingValue()
        {
            return reader.getLastFuelInjectionTimingValue();
        }
        public int getLastFuelPressure()
        {
            return reader.getLastFuelPressure();
        }
        public double getLastFuelRailAbsolutePressure()
        {
            return reader.getLastFuelRailAbsolutePressure();
        }
        public int getLastFuelRailGaugeAbsolutePressure()
        {
            return reader.getLastFuelRailGaugeAbsolutePressure();
        }
        public double getLastFuelRailPressure()
        {
            return reader.getLastFuelRailPressure();
        }
        public double getLastFuelTankLevel()
        {
            return reader.getLastFuelTankLevel();
        }

        public string getFuelType()
        {
            return reader.getFuelType();
        }
        public double getLastHybridBateryPackRemainingLife()
        {
            return reader.getLastHybridBateryPackRemainingLife();
        }
        public double getLastIntakeManifoldAbsolutePressure()
        {
            return reader.getLastIntakeManifoldAbsolutePressure();
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
            return reader.getLastRelativeAcceleratorPedalPosition();
        }
        public double getLastRelativeThrottlePosition()
        {
            return reader.getLastRelativeThrottlePosition();
        }
        public int getLastRPM()
        {
            return reader.getLastRPM();
        }
        public int getRunTimeSinceEngineStart()
        {
            return reader.getRunTimeSinceEngineStart();
        }
        public double getLastShortTermFuelTrimB1()
        {
            return reader.getLastShortTermFuelTrimB1();
        }
        public int getLastShortTermFuelTrimB2()
        {
            return reader.getLastShortTermFuelTrimB2();
        }

        public void ShortTermSecondaryOxygenSensorTrim1_3() { }
        public void ShortTermSecondaryOxygenSensorTrim2_4() { }

        public int getLastSpeed()
        {
            return reader.getLastSpeed();
        }
        public double getLastThrottlePosition()
        {
            return reader.getLastThrottlePosition();
        }
        public int getRunTimeRunWithMILOn()
        {
            return reader.getRunTimeRunWithMILOn();
        }
        public int getRunTimeSinceTroubleCodesCleares()
        {
            return reader.getRunTimeSinceTroubleCodesCleares();
        }
        public int getLastTimingAdvance()
        {
            return reader.getLastTimingAdvance();
        }

        public int getLastWarmsUpsCodesCleared()
        {
            return reader.getLastWarmsUpsCodesCleared();
        }
    }
}