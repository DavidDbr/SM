using Java.Lang;
using SmartMonitoring.BBDD;
using SmartMonitoring.OBDII.Excepciones;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace SmartMonitoring.MVVM
{
    public class ViewModel : INotifyPropertyChanged
    {
        public const string SIN_DATOS = "NO HAY DATOS";
        bool guardarDatos;
        private string speed;
        private string rpm;
        private string engineTemperature;
        private string timeEngineStart;

        private string absoluteBarometricPressure;
        private string absoluteEvapSystemVaporPressure;
        private string absoluteLoadValue;
        private string absoluteThrottlePositionB;
        private string absoluteThrottlePositionC;
        private string absoluteThrottlePositionD;
        private string absoluteThrottlePositionE;
        private string absoluteThrottlePositionF;
        private string actualEngine_PercentTorque;
        private string ambientTemperature;
        private string calculatedEngineLoadValue;
        private string catalystTemperatureB1S1;
        private string catalystTemperatureB1S2;
        private string catalystTemperatureB2S1;
        private string catalystTemperatureB2S2;
        private string commandedEGR;
        private string commanddEvaporativePurge;
        private string commandedThrottleActuatorValue;
        private string controlModuleVoltage;
        private string distanceTraveledSinceCodesCleared;
        private string distanceTraveledWithMILo;
        private string driverDemandEngine_PercentTorque;
        private string EGRError;
        private string emissionRequirementsToWhichVehicleIsDesigned;
        private string engineFuelRateValue;
        private string engineOilTemperature;
        private string enginePercentTorqueData_PercentageIdle;
        private string enginePercentTorqueData_PercentageEnginePoint1;
        private string enginePercentTorqueData_PercentageEnginePoint2;
        private string enginePercentTorqueData_PercentageEnginePoint3;
        private string enginePercentTorqueData_PercentageEnginePoint4;
        private string engineReferenceTorque;
        private string ethanolFuelPercentage;
        private string evapSystemVaporPressure;
        private string fuelAirCommandedEquivalenceRatio;
        //--
        private string fuelInjectionTiming;
        private string fuelPressure;
        private string fuelRailAbsolutePressure;
        private string fuelRailGaugePressure;
        private string fuelSystemStatus_System1;
        private string fuelSystemStatus_System2;
        private string fuelTankLevel;
        private string fuelType;
        private string hybridBateryPackRemainingLife;
        private string intakeManifoldAbsolutePressureValue;
        private string intakeTemperature;
        private string longTermFuelTrimB1;
        private string longTermFuelTrimB2;
        private string shortTermFuelTrimB1;
        private string shortTermFuelTrimB2;
        private string longTermSecondaryOxygenSensorTrim1_3_ValueA;
        private string longTermSecondaryOxygenSensorTrim1_3_ValueB;
        private string longTermSecondaryOxygenSensorTrim2_4_ValueA;
        private string longTermSecondaryOxygenSensorTrim2_4_ValueB;
        private string shortTermSecondaryOxygenSensorTrim1_3_ValueA;
        private string shortTermSecondaryOxygenSensorTrim1_3_ValueB;
        private string shortTermSecondaryOxygenSensorTrim2_4_ValueA;
        private string shortTermSecondaryOxygenSensorTrim2_4_ValueB;
        private string mAFAirFlowRate;
        private string maximunValueAirFlowRateFromMassAirFlowSensor_ValueA;
        private string maximunValueAirFlowRateFromMassAirFlowSensor_ValueB;
        private string maximunValueAirFlowRateFromMassAirFlowSensor_ValueC;
        private string maximunValueAirFlowRateFromMassAirFlowSensor_ValueD;
        //SENSORES OXIGENO
        private string relativeAcceleratorPedalPosition;
        private string relativeThrottlePosition;
        private string RunTimeSinceEngineStart;
        private string throttlePosition;
        private string timeRunWithMILOn;
        private string timeSinceTroubleCodesCleared;
        private string timingAdvance;
        private string warmsUpsCodesCleared;
        private byte[] pids0120;
        private byte[] pids2140;
        private byte[] pids4160;
        private Thread t;
        private List<byte[]> pids;




        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string Speed
        {
            get
            {
                return speed;
            }

            set
            {
                speed = value;
                OnPropertyChanged("Speed");
            }
        }

        public string Rpm
        {
            get
            {
                return rpm;
            }

            set
            {
                rpm = value;
                OnPropertyChanged("Rpm");
            }
        }

        public Thread T
        {
            get
            {
                return T;
            }
            set
            {
                T = value;
            }
        }
        public string EngineTemperature
        {
            get
            {
                return engineTemperature;
            }
            set
            {
                engineTemperature = value;
                OnPropertyChanged("EngineTemperature");
            }
        }
        public string TimeEngineStart
        {
            get
            {
                return timeEngineStart;
            }
            set
            {
                timeEngineStart = value;
                OnPropertyChanged("TimeEngineStart");
            }
        }
        public List<byte[]> Pids
        {
            get
            {
                return pids;
            }
            set
            {
                pids = value;
            }
        }
        public string AbsoluteBarometricPressure
        {
            get
            {
                return absoluteBarometricPressure;
            }
            set
            {
                absoluteBarometricPressure = value;
                OnPropertyChanged("AbsoluteBarometricPressure");
            }
        }
        public string AbsoluteEvapSystemVaporPressure
        {
            get
            {
                return absoluteEvapSystemVaporPressure;
            }
            set
            {
                absoluteEvapSystemVaporPressure = value;
                OnPropertyChanged("AbsoluteEvapSystemVaportPressure");
            }
        }
        public string AbsoluteLoadValue
        {
            get
            {
                return absoluteLoadValue;
            }
            set
            {
                absoluteLoadValue = value;
                OnPropertyChanged("AbsoluteLoadValue");
            }
        }
        public string AbsoluteThrottlePositionB
        {
            get
            {
                return absoluteThrottlePositionB;
            }
            set
            {
                absoluteThrottlePositionB = value;
                OnPropertyChanged("AbsoluteThrottlePositionB");
            }
        }
        public string AbsoluteThrottlePositionC
        {
            get
            {
                return absoluteThrottlePositionC;
            }
            set
            {
                absoluteThrottlePositionC = value;
                OnPropertyChanged("AbsoluteThrottlePositionC");
            }
        }
        public string AbsoluteThrottlePositionD
        {
            get
            {
                return absoluteThrottlePositionD;
            }
            set
            {
                absoluteThrottlePositionD = value;
                OnPropertyChanged("AbsoluteThrottlePositionD");
            }
        }
        public string AbsoluteThrottlePositionE
        {
            get
            {
                return absoluteThrottlePositionE;
            }
            set
            {
                absoluteThrottlePositionE = value;
                OnPropertyChanged("AbsoluteThrottlePositionE");
            }
        }
        public string AbsoluteThrottlePositionF
        {
            get
            {
                return absoluteThrottlePositionF;
            }
            set
            {
                absoluteThrottlePositionF = value;
                OnPropertyChanged("AbsoluteThrottlePositionE");
            }
        }
        public string ActualEngine_PercentTorque
        {

            get
            {
                return actualEngine_PercentTorque;
            }
            set
            {
                actualEngine_PercentTorque = value;
                OnPropertyChanged("ActualEngine_PercentTorque");
            }
        }

        public string AmbientTemperature
        {
            get
            {
                return ambientTemperature;
            }
            set
            {
                ambientTemperature = value;
                OnPropertyChanged("AmbientTemperature");
            }
        }
        public string CalculatedEngineLoadValue
        {
            get
            {
                return calculatedEngineLoadValue;
            }
            set
            {
                calculatedEngineLoadValue = value;
                OnPropertyChanged("CalculatedEngineLoadValue");
            }
        }
        public string CatalystTemperatureB1S1
        {
            get
            {
                return catalystTemperatureB1S1;
            }
            set
            {
                catalystTemperatureB1S1 = value;
                OnPropertyChanged("CatalystTemperatureB1S1");
            }
        }
        public string CatalystTemperatureB1S2
        {
            get
            {
                return catalystTemperatureB1S2;
            }
            set
            {
                catalystTemperatureB1S2 = value;
                OnPropertyChanged("CatalystTemperatureB1S2");
            }
        }
        public string CatalystTemperatureB2S1
        {
            get
            {
                return catalystTemperatureB2S1;
            }
            set
            {
                catalystTemperatureB2S1 = value;
                OnPropertyChanged("CatalystTemperatureB2S1");
            }
        }
        public string CatalystTemperatureB2S2
        {
            get
            {
                return catalystTemperatureB2S2;
            }
            set
            {
                catalystTemperatureB2S2 = value;
                OnPropertyChanged("CatalystTemperatureB2S2");
            }
        }
        public string CommandedEGR
        {
            get
            {
                return commandedEGR;
            }
            set
            {
                commandedEGR = value;
                OnPropertyChanged("CommandedEGR");
            }
        }
        public string CommanddEvaporativePurge
        {
            get
            {
                return commanddEvaporativePurge;
            }
            set
            {
                commanddEvaporativePurge = value;
                OnPropertyChanged("CommanddEvaporativePurge");
            }
        }
        public string CommandedThrottleActuatorValue
        {
            get
            {
                return commandedThrottleActuatorValue;
            }
            set
            {
                commandedThrottleActuatorValue = value;
                OnPropertyChanged("CommandedThrottleActuatorValue");
            }
        }
        public string ControlModuleVoltage
        {
            get
            {
                return controlModuleVoltage;
            }
            set
            {
                controlModuleVoltage = value;
                OnPropertyChanged("ControlModuleVoltage");
            }
        }
        public string DistanceTraveledSinceCodesCleared
        {
            get
            {
                return distanceTraveledSinceCodesCleared;
            }
            set
            {
                distanceTraveledSinceCodesCleared = value;
                OnPropertyChanged("DistanceTraveledSinceCodesCleared");
            }
        }
        public string DistanceTraveledWithMILo
        {
            get
            {
                return distanceTraveledWithMILo;
            }
            set
            {
                distanceTraveledWithMILo = value;
                OnPropertyChanged("DistanceTraveledWithMILo");
            }
        }
        public string DriverDemandEngine_PercentTorque
        {
            get
            {
                return driverDemandEngine_PercentTorque;
            }
            set
            {
                driverDemandEngine_PercentTorque = value;
                OnPropertyChanged("DriverDemandEngine_PercentTorque");
            }
        }
        public string EGRError1
        {
            get
            {
                return EGRError;
            }
            set
            {
                EGRError = value;
                OnPropertyChanged("EGRError1");
            }
        }
        public string EmissionRequirementsToWhichVehicleIsDesigned
        {
            get
            {
                return emissionRequirementsToWhichVehicleIsDesigned;
            }
            set
            {
                emissionRequirementsToWhichVehicleIsDesigned = value;
                OnPropertyChanged("EmmisionRequirementsToWhichVehicleIsDesigned");
            }
        }
        public string EngineFuelRateValue
        {
            get
            {
                return engineFuelRateValue;
            }
            set
            {
                engineFuelRateValue = value;
                OnPropertyChanged("EngineFuelRateValue");
            }
        }
        public string EngineOilTemperature
        {
            get
            {
                return engineOilTemperature;
            }
            set
            {
                engineOilTemperature = value;
                OnPropertyChanged("EngineOilTemperature");
            }
        }
        public string EnginePercentTorqueData_PercentageIdle
        {
            get
            {
                return enginePercentTorqueData_PercentageIdle;
            }
            set
            {
                enginePercentTorqueData_PercentageIdle = value;
                OnPropertyChanged("EnginePercentTorqueData_PercentageIdle");
            }
        }
        public string EnginePercentTorqueData_PercentageEnginePoint1
        {
            get
            {
                return enginePercentTorqueData_PercentageEnginePoint1;
            }
            set
            {
                enginePercentTorqueData_PercentageEnginePoint1 = value;
                OnPropertyChanged("EnginePercentTorqueData_PercentageEnginePoint1");
            }
        }
        public string EnginePercentTorqueData_PercentageEnginePoint2
        {
            get
            {
                return enginePercentTorqueData_PercentageEnginePoint2;
            }
            set
            {
                enginePercentTorqueData_PercentageEnginePoint2 = value;
                OnPropertyChanged("EnginePercentTorqueData_PercentageEnginePoint2");
            }
        }
        public string EnginePercentTorqueData_PercentageEnginePoint3
        {
            get
            {
                return enginePercentTorqueData_PercentageEnginePoint3;
            }
            set
            {
                enginePercentTorqueData_PercentageEnginePoint3 = value;
                OnPropertyChanged("EnginePercentTorqueData_PercentageEnginePoint3");
            }
        }
        public string EnginePercentTorqueData_PercentageEnginePoint4
        {
            get
            {
                return enginePercentTorqueData_PercentageEnginePoint4;
            }
            set
            {
                enginePercentTorqueData_PercentageEnginePoint4 = value;
                OnPropertyChanged("EnginePercentTorqueData_PercentagePoint4");
            }
        }
        public string EngineReferenceTorque
        {
            get
            {
                return engineReferenceTorque;
            }
            set
            {
                engineReferenceTorque = value;
                OnPropertyChanged("EngineReferenceTorque");
            }
        }
        public string EthanolFuelPercentage
        {
            get
            {
                return ethanolFuelPercentage;
            }
            set
            {
                ethanolFuelPercentage = value;
                OnPropertyChanged("EthanolFuelPercentage");
            }
        }
        public string EvapSystemVaporPressure
        {
            get
            {
                return evapSystemVaporPressure;
            }
            set
            {
                evapSystemVaporPressure = value;
                OnPropertyChanged("EvapSystemVaporPressure");
            }
        }
        public string FuelAirCommandedEquivalenceRatio
        {
            get
            {
                return fuelAirCommandedEquivalenceRatio;
            }
            set
            {
                fuelAirCommandedEquivalenceRatio = value;
                OnPropertyChanged("FuelAirCommandedEquivalenceRatio");
            }
        }
        public string FuelInjectionTiming
        {
            get
            {
                return fuelInjectionTiming;
            }
            set
            {
                fuelInjectionTiming = value;
                OnPropertyChanged("FuelInjectionTiming");
            }
        }
        public string FuelPressure
        {
            get
            {
                return fuelPressure;
            }
            set
            {
                fuelPressure = value;
                OnPropertyChanged("FuelPressure");
            }
        }
        public string FuelRailAbsolutePressure
        {
            get
            {
                return fuelRailAbsolutePressure;
            }
            set
            {
                fuelRailAbsolutePressure = value;
                OnPropertyChanged("FuelRailAbsolutePressure");
            }
        }
        public string FuelRailGaugePressure
        {
            get
            {
                return fuelRailGaugePressure;
            }
            set
            {
                fuelRailGaugePressure = value;
                OnPropertyChanged("FuelRailGaugePressure");
            }
        }
        public string FuelSystemStatus_System1
        {
            get
            {
                return fuelSystemStatus_System1;
            }
            set
            {
                fuelSystemStatus_System1 = value;
                OnPropertyChanged("FuelSystemStatus_System1");
            }
        }
        public string FuelSystemStatus_System2
        {
            get
            {
                return fuelSystemStatus_System2;
            }
            set
            {
                fuelSystemStatus_System2 = value;
                OnPropertyChanged("FuelSystemStatus_System2");
            }
        }
        public string FuelTankLevel
        {
            get
            {
                return fuelTankLevel;
            }
            set
            {
                fuelTankLevel = value;
                OnPropertyChanged("FuelTankLevel");
            }
        }
        public string FuelType
        {
            get
            {
                return fuelType;
            }
            set
            {
                fuelType = value;
                OnPropertyChanged("FuelType");
            }
        }
        public string HybridBateryPackRemainingLife
        {
            get
            {
                return hybridBateryPackRemainingLife;
            }
            set
            {
                hybridBateryPackRemainingLife = value;
                OnPropertyChanged("HybridBateryPackRemainingLife");
            }
        }
        public string IntakeManifoldAbsolutePressureValue
        {
            get
            {
                return intakeManifoldAbsolutePressureValue;
            }
            set
            {
                intakeManifoldAbsolutePressureValue = value;
                OnPropertyChanged("IntakeManifoldAbsolutePressureValue");
            }
        }
        public string IntakeTemperature
        {
            get
            {
                return intakeTemperature;
            }
            set
            {
                intakeTemperature = value;
                OnPropertyChanged("IntakeTemperature");
            }
        }
        public string LongTermFuelTrimB1
        {
            get
            {
                return longTermFuelTrimB1;
            }
            set
            {
                longTermFuelTrimB1 = value;
                OnPropertyChanged("LongTermFuelTrimB1");
            }
        }
        public string LongTermFuelTrimB2
        {
            get
            {
                return longTermFuelTrimB2;
            }
            set
            {
                longTermFuelTrimB2 = value;
                OnPropertyChanged("LongTermFuelTrimB2");
            }
        }
        public string ShortTermFuelTrimB1
        {
            get
            {
                return shortTermFuelTrimB1;
            }
            set
            {
                shortTermFuelTrimB1 = value;
                OnPropertyChanged("ShortTermFuelTrimB1");
            }
        }
        public string ShortTermFuelTrimB2
        {
            get
            {
                return shortTermFuelTrimB2;
            }
            set
            {
                shortTermFuelTrimB2 = value;
                OnPropertyChanged("ShortTermFuelTrimB2");
            }
        }
        public string LongTermSecondaryOxygenSensorTrim1_3_ValueA
        {
            get
            {
                return longTermSecondaryOxygenSensorTrim1_3_ValueA;
            }
            set
            {
                longTermSecondaryOxygenSensorTrim1_3_ValueA = value;
                OnPropertyChanged("LongTermSecondaryOxygenSensorTrim1_3_ValueA");
            }
        }
        public string LongTermSecondaryOxygenSensorTrim1_3_ValueB
        {
            get
            {
                return longTermSecondaryOxygenSensorTrim1_3_ValueB;
            }
            set
            {
                longTermSecondaryOxygenSensorTrim1_3_ValueB = value;
                OnPropertyChanged("LongTermSecondaryOxygenSensorTrim1_3_ValueB");
            }
        }
        public string LongTermSecondaryOxygenSensorTrim2_4_ValueA
        {
            get
            {
                return longTermSecondaryOxygenSensorTrim2_4_ValueA;
            }
            set
            {
                longTermSecondaryOxygenSensorTrim2_4_ValueA = value;
                OnPropertyChanged("LongTermSecondaryOxygenSensorTrim2_4_ValueA");
            }
        }
        public string LongTermSecondaryOxygenSensorTrim2_4_ValueB
        {
            get
            {
                return longTermSecondaryOxygenSensorTrim2_4_ValueB;
            }
            set
            {
                longTermSecondaryOxygenSensorTrim2_4_ValueB = value;
                OnPropertyChanged("LongTermSecondaryOxygenSensorTrim2_B_ValueB");
            }
        }
        public string ShortTermSecondaryOxygenSensorTrim1_3_ValueA
        {
            get
            {
                return shortTermSecondaryOxygenSensorTrim1_3_ValueA;
            }
            set
            {
                shortTermSecondaryOxygenSensorTrim1_3_ValueA = value;
                OnPropertyChanged("ShortTermSecondaryOxygenSensorTrim1_3_ValueA");
            }
        }
        public string ShortTermSecondaryOxygenSensorTrim1_3_ValuB
        {
            get
            {
                return shortTermSecondaryOxygenSensorTrim1_3_ValueB;
            }
            set
            {
                shortTermSecondaryOxygenSensorTrim1_3_ValueB = value;
                OnPropertyChanged("ShortTermSecondaryOxygenSensorTrim1_3_ValuB");
            }
        }
        public string ShortTermSecondaryOxygenSensorTrim2_4_ValueA
        {
            get
            {
                return shortTermSecondaryOxygenSensorTrim2_4_ValueA;
            }
            set
            {
                shortTermSecondaryOxygenSensorTrim2_4_ValueA = value;
                OnPropertyChanged("ShortTermSecondaryOxygenSensorTrim2_4_ValueA");
            }
        }
        public string ShortTermSecondaryOxygenSensorTrim2_4_ValueB
        {
            get
            {
                return shortTermSecondaryOxygenSensorTrim2_4_ValueB;
            }
            set
            {
                shortTermSecondaryOxygenSensorTrim2_4_ValueB = value;
                OnPropertyChanged("ShortTermSecondaryOxygenSensorTrim2_4_ValueB");
            }
        }
        public string MAFAirFlowRate
        {
            get
            {
                return mAFAirFlowRate;
            }
            set
            {
                mAFAirFlowRate = value;
                OnPropertyChanged("MAFAirFlowRate");
            }
        }
        public string MaximunValueAirFlowRateFromMassAirFlowSensor_ValueA
        {
            get
            {
                return maximunValueAirFlowRateFromMassAirFlowSensor_ValueA;
            }
            set
            {
                maximunValueAirFlowRateFromMassAirFlowSensor_ValueA = value;
                OnPropertyChanged("MaxiumValueAirFlowRateFromMassAirFlowSensor_ValueA");
            }
        }
        public string MaximunValueAirFlowRateFromMassAirFlowSensor_ValueB
        {
            get
            {
                return maximunValueAirFlowRateFromMassAirFlowSensor_ValueB;
            }
            set
            {
                maximunValueAirFlowRateFromMassAirFlowSensor_ValueB = value;
                OnPropertyChanged("MaxiumValueAirFlowRateFromMassAirFlowSensor_ValueB");
            }
        }
        public string MaximunValueAirFlowRateFromMassAirFlowSensor_ValueC
        {
            get
            {
                return maximunValueAirFlowRateFromMassAirFlowSensor_ValueC;
            }
            set
            {
                maximunValueAirFlowRateFromMassAirFlowSensor_ValueC = value;
                OnPropertyChanged("MaxiumValueAirFlowRateFromMassAirFlowSensor_ValueC");
            }
        }
        public string MaximunValueAirFlowRateFromMassAirFlowSensor_ValueD
        {
            get
            {
                return maximunValueAirFlowRateFromMassAirFlowSensor_ValueD;
            }
            set
            {
                maximunValueAirFlowRateFromMassAirFlowSensor_ValueD = value;
                OnPropertyChanged("MaxiumValueAirFlowRateFromMassAirFlowSensor_ValueA");
            }
        }
        public string RelativeAcceleratorPedalPosition
        {
            get
            {
                return relativeAcceleratorPedalPosition;
            }
            set
            {
                relativeAcceleratorPedalPosition = value;
                OnPropertyChanged("RelativeAcceleratorPedalPosition");
            }
        }
        public string RelativeThrottlePosition
        {
            get
            {
                return relativeThrottlePosition;
            }
            set
            {
                relativeThrottlePosition = value;
                OnPropertyChanged("RelativeThrottlePosition");
            }
        }
        public string RunTimeSinceEngineStart1
        {
            get
            {
                return RunTimeSinceEngineStart;
            }
            set
            {
                RunTimeSinceEngineStart = value;
                OnPropertyChanged("RunTimeSinceEngineStart1");
            }
        }
        public string ThrottlePosition
        {
            get
            {
                return throttlePosition;
            }
            set
            {
                throttlePosition = value;
                OnPropertyChanged("ThrottlePosition");
            }
        }
        public string TimeRunWithMILOn
        {
            get
            {
                return timeRunWithMILOn;
            }
            set
            {
                timeRunWithMILOn = value;
                OnPropertyChanged("TimeRunWithMILOn");
            }
        }
        public string TimeSinceTroubleCodesCleared
        {
            get
            {
                return timeSinceTroubleCodesCleared;
            }
            set
            {
                timeSinceTroubleCodesCleared = value;
                OnPropertyChanged("TimeSinceTroubleCodesCleared");
            }
        }
        public string TimingAdvance
        {
            get
            {
                return timingAdvance;
            }
            set
            {
                timingAdvance = value;
                OnPropertyChanged("TimingAdvance");
            }
        }
        public string WarmsUpsCodesCleared
        {
            get
            {
                return warmsUpsCodesCleared;
            }
            set
            {
                warmsUpsCodesCleared = value;
                OnPropertyChanged("WarmsUpsCodesCleared");
            }
        }

        public byte[] Pids0120
        {
            get
            {
                return pids0120;
            }
            set
            {
                pids0120 = value;
            }
        }
        public byte[] Pids2140
        {
            get
            {
                return pids2140;
            }
            set
            {
                pids2140 = value;
            }
        }
        public byte[] Pids4160
        {
            get
            {
                return pids4160;
            }
            set
            {
                pids4160 = value;
            }
        }

        public ViewModel()
        {


        }

        public System.Windows.Input.ICommand AddCommand
        {
            protected set; get;
        }



    }

}

