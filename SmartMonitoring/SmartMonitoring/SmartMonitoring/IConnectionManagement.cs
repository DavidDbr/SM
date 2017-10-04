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

        string DiagnosticCar();

        void InitializedOBD2();



        /* <double> getResultados()
        {
            return dao.
        }*/

        double getLastCalculatedEngineValue();

        int getLastEngineTemperature();

        int getLastAbsoluteBarometricPressure();

        int getLastAbsoluteEvapSystemVaporPressure();

        double getLastAbsoluteLoadValue();

        double getLastAbsoluteThrottlePositionB();


        double getLastAbsoluteThrottlePositionC();


        double getLastAbsoluteThrottlePositionD();

        double getLastAbsoluteThrottlePositionE();

        double getLastAbsoluteThrottlePositionF();

        double getLastActualEnginePercentTorque();

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

        void getLastControlModuleVoltage();

        int getLastDistanceTraveledSinseCodesCleared();

        int getLastDistanceTraveledWithMILo();

        int getLastDriverDemandEngine_PercentTorque();
        double getLastEGRError();

        double getLastEngineFuelRate();

        double getLastEngineOilTemperature();

        void getLastEnginePercentTorqueData();

        int getLastEngineReferenceTorque();

        int getLastEngineStartTime();

        int getLastEngineTemperatureData();

        double getLastEthanolFuelPercentage();

        double getLastEvapSystemVaporPressure();

        double getLastFuelAirCommandedEquivalenceRatio();

        void FuelAirEquivalence_OxygenVoltage_OxygenSensorCurrent_IntakeManifoldAbsolutePressure();

        double getLastFuelInjectionTimingValue();

        int getLastFuelPressure();

        double getLastFuelRailAbsolutePressure();

        int getLastFuelRailGaugeAbsolutePressure();

        double getLastFuelRailPressure();

        double getLastFuelTankLevel();

        string getFuelType();

        double getLastHybridBateryPackRemainingLife();

        double getLastIntakeManifoldAbsolutePressure();

        void MaximunValueAirFlowRateFromMassAirFlowSensor();

        void OxygenSensor1();

        void OxygenSensor1B();

        void OxygenSensor1C();

        void OxygenSensor2();

        void OxygenSensor2B();

        void OxygenSensor2C();

        void OxygenSensor3();

        void OxygenSensor3B();

        void OxygenSensor3C();

        void OxygenSensor4();

        void OxygenSensor4B();

        void OxygenSensor4C();

        void OxygenSensor5();

        void OxygenSensor5B();

        void OxygenSensor5C();

        void OxygenSensor6();

        void OxygenSensor6B();

        void OxygenSensor6C();

        void OxygenSensor7();

        void OxygenSensor7B();

        void OxygenSensor7C();

        void OxygenSensor8();

        void OxygenSensor8B();

        void OxygenSensor8C();

        double getLastRelativeAcceleratorPedalPosition();

        double getLastRelativeThrottlePosition();

        int getLastRPM();

        int getRunTimeSinceEngineStart();

        double getLastShortTermFuelTrimB1();

        int getLastShortTermFuelTrimB2();


        void ShortTermSecondaryOxygenSensorTrim1_3();
        void ShortTermSecondaryOxygenSensorTrim2_4();

        int getLastSpeed();

        double getLastThrottlePosition();

        int getRunTimeRunWithMILOn();

        int getRunTimeSinceTroubleCodesCleares();

        int getLastTimingAdvance();


        int getLastWarmsUpsCodesCleared();
    }
}
