using Android.Bluetooth;
using SmartMonitoring.BBDD;
using SmartMonitoring.OBDII;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartMonitoring.Droid.Datos
{
    public interface ISmartMonitoringDAO
    {
        void setGuardarDatos(bool value);

        bool getGuardarDatos();

        void Initialize();

        string Read();

        SQLiteConnection getSQLConnection();

        List<DiagnosticTroubleCode> DiagnosticCar();

        List<byte[]> getPids();

        string readCalculatedEngineLoad(DataTransferSchema dr);



        string readAbsoluteBarometricPressure(DataTransferSchema dr);

        string readAbsoluteEvapSystemVaporPressure(DataTransferSchema dr);

        string readAbsoluteLoadValue(DataTransferSchema dr);

        string readAbsoluteThrottlePosition(DataTransferSchema dr);


        List<string> readFuelSystemStatus(DataTransferSchema dr);



        string readActualEnginePercentTorque(DataTransferSchema dr);

        string readAmbientTemperatureAir(DataTransferSchema dr);


        string readCatalystTemperature(DataTransferSchema dr);


        string readCommandedEGR(DataTransferSchema dr);

        string readCommandedEvaporativePurge(DataTransferSchema dr);

        //void readCommandedSecondaryAirStatus(DataTransferSchema dr);

        string readCommandedThrottleActuator(DataTransferSchema dr);

        string readControlModuleVoltage(DataTransferSchema dr);

        // string readDistanceTraveledSinseCodesCleared(DataTransferSchema dr);

        string readDistanceWithMILLamp(DataTransferSchema dr);

        string readDriverDemandEngine_PercentTorque(DataTransferSchema dr);
        string readEGRError(DataTransferSchema dr);

        string readEngineFuelRate(DataTransferSchema dr);

        string readEngineOilTemperature(DataTransferSchema dr);

        List<string> readEnginePercentTorqueData(DataTransferSchema dr);

        string readEngineReferenceTorque(DataTransferSchema dr);

        string readEngineStartTime(DataTransferSchema dr);

        string readEngineTemperature(DataTransferSchema dr);

        string readEthanolFuelPercentage(DataTransferSchema dr);

        string readEvapSystemVaporPressure(DataTransferSchema dr);

        string readFuelAirCommandedEquivalenceRatio(DataTransferSchema dr);

        List<string> readFuelAirEquivalence_OxygenVoltage_OxygenSensorCurrent_IntakeManifoldAbsolutePressure(DataTransferSchema dr);

        string readIntakeAirTemperature(DataTransferSchema dr);

        string readFuelInjectionTiming(DataTransferSchema dr);

        string readFuelPressure(DataTransferSchema dr);

        string readFuelRailAbsolutePressure(DataTransferSchema dr);


        string readFuelRailGaugePressure(DataTransferSchema dr);

        string readFuelRailPressure(DataTransferSchema dr);

        string readFuelTankLevelInput(DataTransferSchema dr);

        string readFuelType(DataTransferSchema dr);

        string readHybridBatteryPackRemainingLife(DataTransferSchema dr);

        string readIntakeManifoldAbsolutePressure(DataTransferSchema dr);

        string readTermFuelTrim(DataTransferSchema dr);

        List<string> readMaximunValueFlowRateFromMassAirFlowSensor(DataTransferSchema dr);

        string readMAFAirFlowRate(DataTransferSchema dr);

        List<string> readOxygenSensor(DataTransferSchema dr);

        List<string> readOxygenSensorB(DataTransferSchema dr);

        List<string> readOxygenSensorC(DataTransferSchema dr);




        string readRelativeAcceleratorPedalPosition(DataTransferSchema dr);

        string readRelativeThrottlePosition(DataTransferSchema dr);

        string readRPM(DataTransferSchema dr);

        Task<DataTransferSchema> ConsultParametersAsync(Parameters.PID pid);

        List<string> readSecondaryOxygenSensorTrim(DataTransferSchema dr);

        string readSpeed(DataTransferSchema dr);

        string readThrottlePosition(DataTransferSchema dr);

        //string readRunTimeSinceTroubleCodesCleares(DataTransferSchema dr);

        string readTimingAdvance(DataTransferSchema dr);

        Visibilidad GetVisibilidad();

        void setVisibilidad(Visibilidad visibilidad);
    }
}

