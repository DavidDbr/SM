using SmartMonitoring.OBDII;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMonitoring
{
    public interface IConnectionManagement
    {
        void ConsultParameters();

        List<DiagnosticTroubleCode> DiagnosticCar();

        void InitializedOBD2();

        List<byte[]> getPids();

        double getLastCalculatedEngineValue();

        int getLastEngineTemperature();

        int getLastAbsoluteBarometricPressure();

        int getLastAbsoluteEvapSystemVaporPressure();

        double getLastAbsoluteLoadValue();

        double getLastAbsoluteThrottlePositionB();

        List<string> getFuelSystemStatus();

        double getLastAbsoluteThrottlePositionC();


        double getLastAbsoluteThrottlePositionD();

        double getLastAbsoluteThrottlePositionE();

        double getLastAbsoluteThrottlePositionF();

        int getLastActualEnginePercentTorque();

        int getLastAmbientAirTemperature();


        double getLastCalculatedEngineLoadValueData();


        double getLastCatalystTemperatureB1S1();


        double getLastCatalystTemperatureB1S2();

        double getLastCatalystTemperatureB2S2();

        double getLastCatalystTemperatureB2S1();


        double getLastCommandedEGR();

        double getLastCommandedEvaporativePurge();

        void getLastCommandedSecondaryAirStatus();

        double getLastCommandedThrottleActuator();

        double getLastControlModuleVoltage();

        int getLastDistanceTraveledSinseCodesCleared();

        int getLastDistanceTraveledWithMILo();

        int getLastDriverDemandEngine_PercentTorque();
        double getLastEGRError();

        double getLastEngineFuelRate();

        double getLastEngineOilTemperature();

        List<int> getLastEnginePercentTorqueData();

        int getLastEngineReferenceTorque();

        string getLastEngineStartTime();

        int getLastEngineTemperatureData();

        double getLastEthanolFuelPercentage();

        double getLastEvapSystemVaporPressure();

        double getLastFuelAirCommandedEquivalenceRatio();

        List<int> FuelAirEquivalence_OxygenVoltage_OxygenSensorCurrent_IntakeManifoldAbsolutePressure();

        double getLastFuelInjectionTimingValue();

        int getLastFuelPressure();

        double getLastFuelRailAbsolutePressure();

        int getLastFuelRailGaugeAbsolutePressure();

        double getLastFuelRailPressure();

        double getLastFuelTankLevel();

        string getFuelType();

        double getLastHybridBateryPackRemainingLife();

        int getLastIntakeManifoldAbsolutePressure();

        double getLastLongTermFuelTrimB1();

        double getLastLongTermFuelTrimB2();

        List<int> MaximunValueAirFlowRateFromMassAirFlowSensor();

        double MAFAirFlowRate();

        List<double> OxygenSensor1();

        List<double> OxygenSensor1B();

        List<double> OxygenSensor1C();

        List<double> OxygenSensor2();

        List<double> OxygenSensor2B();

        List<double> OxygenSensor2C();

        List<double> OxygenSensor3();

        List<double> OxygenSensor3B();

        List<double> OxygenSensor3C();

        List<double> OxygenSensor4();

        List<double> OxygenSensor4B();

        List<double> OxygenSensor4C();

        List<double> OxygenSensor5();

        List<double> OxygenSensor5B();

        List<double> OxygenSensor5C();

        List<double> OxygenSensor6();

        List<double> OxygenSensor6B();

        List<double> OxygenSensor6C();

        List<double> OxygenSensor7();

        List<double> OxygenSensor7B();

        List<double> OxygenSensor7C();

        List<double> OxygenSensor8();

        List<double> OxygenSensor8B();

        List<double> OxygenSensor8C();

        double getLastRelativeAcceleratorPedalPosition();

        double getLastRelativeThrottlePosition();

        int getLastRPM();

        int getRunTimeSinceEngineStart();

        double getLastShortTermFuelTrimB1();

        double getLastShortTermFuelTrimB2();

        List<double> LongTermSecondaryOxygenSensorTrim1_3();
        List<double> LongTermSecondaryOxygenSensorTrim2_4();
        List<double> ShortTermSecondaryOxygenSensorTrim1_3();
        List<double> ShortTermSecondaryOxygenSensorTrim2_4();

        int getLastSpeed();

        double getLastThrottlePosition();

        int getRunTimeRunWithMILOn();

        int getRunTimeSinceTroubleCodesCleares();

        int getLastTimingAdvance();


        int getLastWarmsUpsCodesCleared();
    }
}
