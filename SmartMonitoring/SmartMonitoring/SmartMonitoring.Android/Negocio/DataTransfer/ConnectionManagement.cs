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

namespace SmartMonitoring.Droid
{
    public class ConnectionManagement : IConnectionManagement
    {
        BluetoothSocket socket = null;
        
        ISmartMonitoringDAO dao;


        public ConnectionManagement(BluetoothSocket socket)
        {

            this.socket = socket;
            dao = new SmartMonitoringDAO(socket);
            dao.Initialize();
           


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

        public double getLastCalculatedEngineValue()
        {
            throw new NotImplementedException();
        }

        public int getLastEngineTemperature()
        {
            throw new NotImplementedException();
        }

        public int getLastAbsoluteBarometricPressure()
        {
            throw new NotImplementedException();
        }

        public int getLastAbsoluteEvapSystemVaporPressure()
        {
            throw new NotImplementedException();
        }

        public double getLastAbsoluteLoadValue()
        {
            throw new NotImplementedException();
        }

        public double getLastAbsoluteThrottlePositionB()
        {
            throw new NotImplementedException();
        }

        public double getLastAbsoluteThrottlePositionC()
        {
            throw new NotImplementedException();
        }

        public double getLastAbsoluteThrottlePositionD()
        {
            throw new NotImplementedException();
        }

        public double getLastAbsoluteThrottlePositionE()
        {
            throw new NotImplementedException();
        }

        public double getLastAbsoluteThrottlePositionF()
        {
            throw new NotImplementedException();
        }

        public double getLastActualEnginePercentTorque()
        {
            throw new NotImplementedException();
        }

        public int getLastAmbientAirTemperature()
        {
            throw new NotImplementedException();
        }

        public double getLastCalculatedEngineLoadValueData()
        {
            throw new NotImplementedException();
        }

        public double getLastCatalystTemperatureB1S1()
        {
            throw new NotImplementedException();
        }

        public double getLastCatalystTemperatureB1S2()
        {
            throw new NotImplementedException();
        }

        public double getLastCatalystTemperatureB2S2()
        {
            throw new NotImplementedException();
        }

        public double getLastCatalystTemperatureB2S1()
        {
            throw new NotImplementedException();
        }

        public double getLastCommandedEGR()
        {
            throw new NotImplementedException();
        }

        public double getLastCommandedEvaporativePurge()
        {
            throw new NotImplementedException();
        }

        public void getLastCommandedSecondaryAirStatus()
        {
            throw new NotImplementedException();
        }

        public double getLastCommandedThrottleActuator()
        {
            throw new NotImplementedException();
        }

        public void getLastControlModuleVoltage()
        {
            throw new NotImplementedException();
        }

        public int getLastDistanceTraveledSinseCodesCleared()
        {
            throw new NotImplementedException();
        }

        public int getLastDistanceTraveledWithMILo()
        {
            throw new NotImplementedException();
        }

        public int getLastDriverDemandEngine_PercentTorque()
        {
            throw new NotImplementedException();
        }

        public double getLastEGRError()
        {
            throw new NotImplementedException();
        }

        public double getLastEngineFuelRate()
        {
            throw new NotImplementedException();
        }

        public double getLastEngineOilTemperature()
        {
            throw new NotImplementedException();
        }

        public void getLastEnginePercentTorqueData()
        {
            throw new NotImplementedException();
        }

        public int getLastEngineReferenceTorque()
        {
            throw new NotImplementedException();
        }

        public int getLastEngineStartTime()
        {
            throw new NotImplementedException();
        }

        public int getLastEngineTemperatureData()
        {
            throw new NotImplementedException();
        }

        public double getLastEthanolFuelPercentage()
        {
            throw new NotImplementedException();
        }

        public double getLastEvapSystemVaporPressure()
        {
            throw new NotImplementedException();
        }

        public double getLastFuelAirCommandedEquivalenceRatio()
        {
            throw new NotImplementedException();
        }

        public void FuelAirEquivalence_OxygenVoltage_OxygenSensorCurrent_IntakeManifoldAbsolutePressure()
        {
            throw new NotImplementedException();
        }

        public double getLastFuelInjectionTimingValue()
        {
            throw new NotImplementedException();
        }

        public int getLastFuelPressure()
        {
            throw new NotImplementedException();
        }

        public double getLastFuelRailAbsolutePressure()
        {
            throw new NotImplementedException();
        }

        public int getLastFuelRailGaugeAbsolutePressure()
        {
            throw new NotImplementedException();
        }

        public double getLastFuelRailPressure()
        {
            throw new NotImplementedException();
        }

        public double getLastFuelTankLevel()
        {
            throw new NotImplementedException();
        }

        public string getFuelType()
        {
            throw new NotImplementedException();
        }

        public double getLastHybridBateryPackRemainingLife()
        {
            throw new NotImplementedException();
        }

        public double getLastIntakeManifoldAbsolutePressure()
        {
            throw new NotImplementedException();
        }

        public void MaximunValueAirFlowRateFromMassAirFlowSensor()
        {
            throw new NotImplementedException();
        }

        public void OxygenSensor1()
        {
            throw new NotImplementedException();
        }

        public void OxygenSensor1B()
        {
            throw new NotImplementedException();
        }

        public void OxygenSensor1C()
        {
            throw new NotImplementedException();
        }

        public void OxygenSensor2()
        {
            throw new NotImplementedException();
        }

        public void OxygenSensor2B()
        {
            throw new NotImplementedException();
        }

        public void OxygenSensor2C()
        {
            throw new NotImplementedException();
        }

        public void OxygenSensor3()
        {
            throw new NotImplementedException();
        }

        public void OxygenSensor3B()
        {
            throw new NotImplementedException();
        }

        public void OxygenSensor3C()
        {
            throw new NotImplementedException();
        }

        public void OxygenSensor4()
        {
            throw new NotImplementedException();
        }

        public void OxygenSensor4B()
        {
            throw new NotImplementedException();
        }

        public void OxygenSensor4C()
        {
            throw new NotImplementedException();
        }

        public void OxygenSensor5()
        {
            throw new NotImplementedException();
        }

        public void OxygenSensor5B()
        {
            throw new NotImplementedException();
        }

        public void OxygenSensor5C()
        {
            throw new NotImplementedException();
        }

        public void OxygenSensor6()
        {
            throw new NotImplementedException();
        }

        public void OxygenSensor6B()
        {
            throw new NotImplementedException();
        }

        public void OxygenSensor6C()
        {
            throw new NotImplementedException();
        }

        public void OxygenSensor7()
        {
            throw new NotImplementedException();
        }

        public void OxygenSensor7B()
        {
            throw new NotImplementedException();
        }

        public void OxygenSensor7C()
        {
            throw new NotImplementedException();
        }

        public void OxygenSensor8()
        {
            throw new NotImplementedException();
        }

        public void OxygenSensor8B()
        {
            throw new NotImplementedException();
        }

        public void OxygenSensor8C()
        {
            throw new NotImplementedException();
        }

        public double getLastRelativeAcceleratorPedalPosition()
        {
            throw new NotImplementedException();
        }

        public double getLastRelativeThrottlePosition()
        {
            throw new NotImplementedException();
        }

        public int getLastRPM()
        {
            throw new NotImplementedException();
        }

        public int getRunTimeSinceEngineStart()
        {
            throw new NotImplementedException();
        }

        public double getLastShortTermFuelTrimB1()
        {
            throw new NotImplementedException();
        }

        public int getLastShortTermFuelTrimB2()
        {
            throw new NotImplementedException();
        }

        public void ShortTermSecondaryOxygenSensorTrim1_3()
        {
            throw new NotImplementedException();
        }

        public void ShortTermSecondaryOxygenSensorTrim2_4()
        {
            throw new NotImplementedException();
        }

        public int getLastSpeed()
        {
            throw new NotImplementedException();
        }

        public double getLastThrottlePosition()
        {
            throw new NotImplementedException();
        }

        public int getRunTimeRunWithMILOn()
        {
            throw new NotImplementedException();
        }

        public int getRunTimeSinceTroubleCodesCleares()
        {
            throw new NotImplementedException();
        }

        public int getLastTimingAdvance()
        {
            throw new NotImplementedException();
        }

        public int getLastWarmsUpsCodesCleared()
        {
            throw new NotImplementedException();
        }
    }
}