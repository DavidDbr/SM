namespace SmartMonitoring.OBDII
{
    public class Parameters
    {
        public enum ConsultMode
        {
            Unknown = 0x00,
            CurrentData = 0x01,
            DiagnosticTroubleCodes = 0x03
        }

        //Incluir Datos de Interés
        public enum PID
        {
            PIDs_01_20 = 0x00,//
            MIL = 0x01,//
            DTCCount = 0x01,
            FuelSystemStatus = 0x03,
            CalculatedEngineLoadValue = 0x04, //--
            EngineTemperature = 0x05, //--
            FuelTrim_Bank1_Short = 0x06, //--
            FuelTrim_Bank1_Long = 0x07, //--
            FuelTrim_Bank2_Short = 0x08, //--
            FuelTrim_Bank2_Long = 0x09,//--
            MAFAirFlowRate = 0x10,//--
            FuelPressure = 0x0A, //--
            IntakeManifoldAbsolutePressure = 0x0B, //--
            RPM = 0x0C,//--
            Speed = 0x0D, //--
            TimingAdvance = 0x0E, //--
            IntakeTemperature = 0x0F, //--
            ThrottlePosition = 0x11, //--
            CommandedSecondaryAirStatus = 0x12,
            OxygenSensorsPresent = 0x13,
            OxygenSensor1 = 0x14,//--
            OxygenSensor2 = 0x15,//--
            OxygenSensor3 = 0x16,//--
            OxygenSensor4 = 0x17,//--
            OxygenSensor5 = 0x18,//--
            OxygenSensor6 = 0x19,//--
            OxygenSensor7 = 0x1A,//--
            OxygenSensor8 = 0x1B,//--
            OBDStandarsPermit = 0x1C,
            OxygenSensorPresent_4Banks = 0x1D,
            AuxiliaryInputStatus = 0x1E,
            EngineStartTime = 0x1F,//--
            PIDs_21_40 = 0x20, //
            DistanceTraveledWithMILon = 0x21, //--
            FuelRailPressure = 0x22, //--
            FuelRailGaugePressure = 0x23, //--
            OxygenSensor1b = 0x24,//--
            OxygenSensor2b = 0x25,//--
            OxygenSensor3b = 0x26,//--
            OxygenSensor4b = 0x27,//--
            OxygenSensor5b = 0x28,//--
            OxygenSensor6b = 0x29,//--
            OxygenSensor7b = 0x2A,//--
            OxygenSensor8b = 0x2B,//--
            CommandedEGR = 0x2C,//--
            EGRError = 0x2D,//--
            CommandedEvaporatiVePurge = 0x2E,  //    --   
            FuelTankLevel = 0x2F,//--
            WarmsUpsCodesCleared = 0x30,//
            DistanceTraveledSinceCodesCleared = 0x31,//

            AbsolutBarometricPressure = 0x33,//
            OxygenSensor1c = 0x34,//
            OxygenSensor2c = 0x35,//
            OxygenSensor3c = 0x36,//
            OxygenSensor4c = 0x37,//
            OxygenSensor5c = 0x38,//
            OxygenSensor6c = 0x39,//
            OxygenSensor7c = 0x3A,//
            OxygenSensor8c = 0x3B,//
            CatalystTemperature_Bank1_Sensor1 = 0x3C,//
            CatalystTemperature_Bank2_Sensor1 = 0x3D,//
            CatalystTemperature_Bank1_Sensor2 = 0x3E,//
            CatalystTemperature_Bank2_Sensor2 = 0x3F,//
            PIDs_41_60 = 0x40,
            MonitorStatusDriveCycle = 0x41,
            ControlModuleVoltage = 0x42,
            AbsoluteLoadValue = 0x43,
            Fuel_AirCommandedEquivalenceRatio = 0x44,//
            RelativeThrottlePosition = 0x45,//
            AmbientAirTemperature = 0x46,//
            AbsoluteThrottlePositionB = 0x47,//
            AbsoluteThrottlePositionC = 0x48,//
            AbsoluteThrottlePositionD = 0x49,//
            AbsoluteThrottlePositionE = 0x4A,//
            AbsoluteThrottlePositionF = 0x4B,//
            CommandedThrottleActuator = 0x4C, //
            TimeRunWithMILOn = 0x4D,//
            TimeSinceTroubleCodesCleared = 0x4E,//
            FuelAirEquivalence_OxygenVoltage_OxygenSensorCurrent_IntakeManifoldAbsolutePressure = 0x4F,//
            MaximunValueFlowRateFromMassAirFlowSensor = 0x50, //
            FuelType = 0x51, //--
            EhtanolFuelPercen = 0x52, //--
            AbsoluteEvapSystemVaporPressure = 0x53, //
            EvapSystemVaporPressure = 0x54,//
            ShortTermSecondaryOxygenSensorTrim1_3 = 0x55, //
            LongTermSecondaryOxygenSensorTrim1_3 = 0x56,//
            ShortTermSecondaryOxygenSensorTrim2_4 = 0x57,//
            LongTermSecondaryOxygenSensorTrim2_4 = 0x58,//
            FuelRailAbsolutePressure = 0x59,//
            RelativeAcceleratorPedalPosition = 0x5A, //
            HybridBatteryPackRemainingLife = 0x5B, //
            EngineOilTemperature = 0x5C, //
            FuelInjectionTiming = 0x5D, //
            EngineFuelRate = 0x5E, //
            EmissionRequirementsToWhichVehicleIsDesigned = 0x5F,
            PIDs_61_80 = 0x60,
            DriverDemandEngine_PercentTorque = 0x61, //
            ActualEngine_PercentTorque = 0x62,
            EngineReferenceTorque = 0x63,
            EnginePercentTorqueData = 0x64

        };

  

    }
}
