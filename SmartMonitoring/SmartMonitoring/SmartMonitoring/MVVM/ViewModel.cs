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
        private string speed;
        private string rpm;
        private string engineTemperature;
        private string timeEngineStart;

        private int absoluteBarometricPressure;
        private double absoluteEvapSystemVaporPressure;
        private double absoluteLoadValue;
        private double absoluteThrottlePositionB;
        private double absoluteThrottlePositionC;
        private double absoluteThrottlePositionD;
        private double absoluteThrottlePositionE;
        private double absoluteThrottlePositionF;
        private int actualEngine_PercentTorque;
        private int ambientTemperature;
        private double calculatedEngineLoadValue;
        private double catalystTemperatureB1S1;
        private double catalystTemperatureB1S2;
        private double catalystTemperatureB2S1;
        private double catalystTemperatureB2S2;
        private double commandedEGR;
        private double commanddEvaporativePurge;
        private double commandedThrottleActuatorValue;
        private double controlModuleVoltage;
        private int distanceTraveledSinceCodesCleared;
        private int distanceTraveledWithMILo;
        private int driverDemandEngine_PercentTorque;
        private double EGRError;
        private double emissionRequirementsToWhichVehicleIsDesigned;
        private double engineFuelRateValue;
        private double engineOilTemperature;
        private int enginePercentTorqueData_PercentageIdle;
        private int enginePercentTorqueData_PercentageEnginePoint1;
        private int enginePercentTorqueData_PercentageEnginePoint2;
        private int enginePercentTorqueData_PercentageEnginePoint3;
        private int enginePercentTorqueData_PercentageEnginePoint4;
        private int engineReferenceTorque;
        private double ethanolFuelPercentage;
        private double evapSystemVaporPressure;
        private double fuelAirCommandedEquivalenceRatio;
        //--
        private double fuelInjectionTiming;
        private int fuelPressure;
        private double fuelRailAbsolutePressure;
        private double fuelRailGaugePressure;
        private string fuelSystemStatus_System1;
        private string fuelSystemStatus_System2;
        private double fuelTankLevel;
        private string fuelType;
        private double hybridBateryPackRemainingLife;
        private int intakeManifoldAbsolutePressureValue;
        private int intakeTemperature;
        private double longTermFuelTrimB1;
        private double longTermFuelTrimB2;
        private double shortTermFuelTrimB1;
        private double shortTermFuelTrimB2;
        private double longTermSecondaryOxygenSensorTrim1_3_ValueA;
        private double longTermSecondaryOxygenSensorTrim1_3_ValueB;
        private double longTermSecondaryOxygenSensorTrim2_4_ValueA;
        private double longTermSecondaryOxygenSensorTrim2_4_ValueB;
        private double shortTermSecondaryOxygenSensorTrim1_3_ValueA;
        private double shortTermSecondaryOxygenSensorTrim1_3_ValueB;
        private double shortTermSecondaryOxygenSensorTrim2_4_ValueA;
        private double shortTermSecondaryOxygenSensorTrim2_4_ValueB;
        private double mAFAirFlowRate;
        private int maximunValueAirFlowRateFromMassAirFlowSensor_ValueA;
        private int maximunValueAirFlowRateFromMassAirFlowSensor_ValueB;
        private int maximunValueAirFlowRateFromMassAirFlowSensor_ValueC;
        private int maximunValueAirFlowRateFromMassAirFlowSensor_ValueD;
        //SENSORES OXIGENO
        private double relativeAcceleratorPedalPosition;
        private double relativeThrottlePosition;
        private int RunTimeSinceEngineStart;
        private double throttlePosition;
        private int timeRunWithMILOn;
        private int timeSinceTroubleCodesCleared;
        private int timingAdvance;
        private int warmsUpsCodesCleared;

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

        public Thread T { get => t; set => t = value; }
        public string EngineTemperature {
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
        public List<byte[]> Pids { get => pids; set => pids = value; }
        public int AbsoluteBarometricPressure
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
        public double AbsoluteEvapSystemVaporPressure {
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
        public double AbsoluteLoadValue
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
        public double AbsoluteThrottlePositionB
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
        public double AbsoluteThrottlePositionC
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
        public double AbsoluteThrottlePositionD
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
        public double AbsoluteThrottlePositionE
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
        public double AbsoluteThrottlePositionF
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
        public int ActualEngine_PercentTorque {  
        
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
    
        public int AmbientTemperature
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
        public double CalculatedEngineLoadValue
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
        public double CatalystTemperatureB1S1
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
        public double CatalystTemperatureB1S2
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
        public double CatalystTemperatureB2S1
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
        public double CatalystTemperatureB2S2
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
        public double CommandedEGR
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
        public double CommanddEvaporativePurge
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
        public double CommandedThrottleActuatorValue
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
        public double ControlModuleVoltage
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
        public int DistanceTraveledSinceCodesCleared
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
        public int DistanceTraveledWithMILo
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
        public int DriverDemandEngine_PercentTorque
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
        public double EGRError1
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
        public double EmissionRequirementsToWhichVehicleIsDesigned {
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
        public double EngineFuelRateValue
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
        public double EngineOilTemperature
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
        public int EnginePercentTorqueData_PercentageIdle {
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
        public int EnginePercentTorqueData_PercentageEnginePoint1 {
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
        public int EnginePercentTorqueData_PercentageEnginePoint2
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
        public int EnginePercentTorqueData_PercentageEnginePoint3 {
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
        public int EnginePercentTorqueData_PercentageEnginePoint4
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
        public int EngineReferenceTorque
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
        public double EthanolFuelPercentage
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
        public double EvapSystemVaporPressure
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
        public double FuelAirCommandedEquivalenceRatio
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
        public double FuelInjectionTiming
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
        public int FuelPressure
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
        public double FuelRailAbsolutePressure
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
        public double FuelRailGaugePressure
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
        public string FuelSystemStatus_System1 {
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
        public double FuelTankLevel
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
        public double HybridBateryPackRemainingLife {
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
        public int IntakeManifoldAbsolutePressureValue {
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
        public int IntakeTemperature
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
        public double LongTermFuelTrimB1
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
        public double LongTermFuelTrimB2
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
        public double ShortTermFuelTrimB1
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
        public double ShortTermFuelTrimB2
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
        public double LongTermSecondaryOxygenSensorTrim1_3_ValueA {
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
        public double LongTermSecondaryOxygenSensorTrim1_3_ValueB {
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
        public double LongTermSecondaryOxygenSensorTrim2_4_ValueA
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
        public double LongTermSecondaryOxygenSensorTrim2_4_ValueB {
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
        public double ShortTermSecondaryOxygenSensorTrim1_3_ValueA
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
        public double ShortTermSecondaryOxygenSensorTrim1_3_ValuB
        {
            get
            {
                return shortTermSecondaryOxygenSensorTrim1_3_ValueB;
            }
            set
            {
                shortTermSecondaryOxygenSensorTrim1_3_ValueB = value;
                OnPropertyChanged("ShortTermSecondaryOxygenSensorTrim1_3_ValueB");
            }
        }
        public double ShortTermSecondaryOxygenSensorTrim2_4_ValueA {
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
        public double ShortTermSecondaryOxygenSensorTrim2_4_ValueB
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
        public double MAFAirFlowRate {
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
        public int MaximunValueAirFlowRateFromMassAirFlowSensor_ValueA {
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
        public int MaximunValueAirFlowRateFromMassAirFlowSensor_ValueB {   get
            {
                return maximunValueAirFlowRateFromMassAirFlowSensor_ValueB;
            }
            set
            {
                maximunValueAirFlowRateFromMassAirFlowSensor_ValueB = value;
                OnPropertyChanged("MaxiumValueAirFlowRateFromMassAirFlowSensor_ValueB");
            } }
        public int MaximunValueAirFlowRateFromMassAirFlowSensor_ValueC
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
        public int MaximunValueAirFlowRateFromMassAirFlowSensor_ValueD
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
        public double RelativeAcceleratorPedalPosition
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
        public double RelativeThrottlePosition {
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
        public int RunTimeSinceEngineStart1
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
        public double ThrottlePosition
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
        public int TimeRunWithMILOn
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
        public int TimeSinceTroubleCodesCleared
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
        public int TimingAdvance
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
        public int WarmsUpsCodesCleared
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

        public ViewModel()
        {

            T = new Thread(consultParameters);
            T.Start();
        }

        public void consultParameters()
        {
            var scan = DependencyService.Get<IConnectionManagement>();
            // string parameter = scan.consultParameters();
            Pids=scan.getPids();
            var database = DependencyService.Get<ISQLite>();
            var connection = database.GetConnection();

            try
            {
                scan.ConsultParameters();
            }
            catch (UnableToConnectException u)
            {
                //  DisplayAlert("Title", "No se puede conectar a la ECU", "OK");
            }
            catch (NoDataException u)
            {
                //  DisplayAlert("Title", "No hay datos disponibles", "OK");
            }
            catch (StoppedException u)
            {
                //  DisplayAlert("Title", "El dispositivo OBDII se ha detenido", "OK");
            }

            int contador = 0;
            while (contador < 50)
            {
                contador = contador + 1;
            }

            while (true)
            {

                Speed = scan.getLastSpeed().ToString();
                Rpm = scan.getLastRPM().ToString();
                EngineTemperature = scan.getLastEngineTemperature().ToString();
                TimeEngineStart = scan.getLastEngineStartTime();
                AbsoluteBarometricPressure = scan.getLastAbsoluteBarometricPressure();
                AbsoluteEvapSystemVaporPressure = scan.getLastAbsoluteEvapSystemVaporPressure();
                AbsoluteLoadValue = scan.getLastAbsoluteLoadValue();
                AbsoluteThrottlePositionB = scan.getLastAbsoluteThrottlePositionB();
                AbsoluteThrottlePositionC = scan.getLastAbsoluteThrottlePositionC();
                AbsoluteThrottlePositionD = scan.getLastAbsoluteThrottlePositionD();
                AbsoluteThrottlePositionE = scan.getLastAbsoluteThrottlePositionE();
                AbsoluteThrottlePositionF = scan.getLastAbsoluteThrottlePositionF();
                ActualEngine_PercentTorque = scan.getLastActualEnginePercentTorque();
                AmbientTemperature = scan.getLastAmbientAirTemperature();
                CalculatedEngineLoadValue = scan.getLastCalculatedEngineLoadValueData();
                CatalystTemperatureB1S1 = scan.getLastCatalystTemperatureB1S1();
                CatalystTemperatureB1S2 = scan.getLastCatalystTemperatureB1S2();
                CatalystTemperatureB2S1 = scan.getLastCatalystTemperatureB2S1();
                CatalystTemperatureB2S2 = scan.getLastCatalystTemperatureB2S2();
                CommanddEvaporativePurge = scan.getLastCommandedEvaporativePurge();
                CommandedEGR = scan.getLastCommandedEGR();
                CommandedThrottleActuatorValue = scan.getLastCommandedThrottleActuator();
                ControlModuleVoltage = scan.getLastControlModuleVoltage();
                DistanceTraveledSinceCodesCleared = scan.getLastDistanceTraveledSinseCodesCleared();
                DistanceTraveledWithMILo = scan.getLastDistanceTraveledWithMILo();
                DriverDemandEngine_PercentTorque = scan.getLastDriverDemandEngine_PercentTorque();
                EGRError1 = scan.getLastEGRError();
                //EmissionRequirementsToWhichVehicleIsDesigned=
                EngineFuelRateValue = scan.getLastEngineFuelRate();
                EngineOilTemperature = scan.getLastEngineOilTemperature();
                //percent data points
                EngineReferenceTorque = scan.getLastEngineReferenceTorque();
                EthanolFuelPercentage = scan.getLastEthanolFuelPercentage();
                EvapSystemVaporPressure = scan.getLastEvapSystemVaporPressure();
                FuelAirCommandedEquivalenceRatio = scan.getLastFuelAirCommandedEquivalenceRatio();
                FuelInjectionTiming = scan.getLastFuelInjectionTimingValue();
                FuelPressure = scan.getLastFuelPressure();
                FuelRailAbsolutePressure = scan.getLastFuelRailAbsolutePressure();
                FuelRailGaugePressure = scan.getLastFuelRailGaugeAbsolutePressure();
                List<string> fuelSystem= scan.getFuelSystemStatus();
                FuelSystemStatus_System1 = fuelSystem[0];
                FuelSystemStatus_System2 = fuelSystem[1];
                FuelTankLevel = scan.getLastFuelTankLevel();
                FuelType = scan.getFuelType();
                HybridBateryPackRemainingLife = scan.getLastHybridBateryPackRemainingLife();
                IntakeManifoldAbsolutePressureValue = scan.getLastIntakeManifoldAbsolutePressure();
                LongTermFuelTrimB1 = scan.getLastLongTermFuelTrimB1();
                LongTermFuelTrimB2 = scan.getLastLongTermFuelTrimB2();
                // LongTermSecondaryOxygenSensorTrim1_3_ValueA=scan.get
                MAFAirFlowRate = scan.MAFAirFlowRate();
                //  MaximunValueAirFlowRateFromMassAirFlowSensor_ValueA=scan.valueA
                RelativeAcceleratorPedalPosition = scan.getLastRelativeAcceleratorPedalPosition();
                RelativeThrottlePosition = scan.getLastRelativeThrottlePosition();
                RunTimeSinceEngineStart1 = scan.getRunTimeSinceEngineStart();
                ShortTermFuelTrimB1 = scan.getLastShortTermFuelTrimB1();
                ShortTermFuelTrimB2 = scan.getLastShortTermFuelTrimB2();
                //shorttrimvaluea
                ThrottlePosition = scan.getLastThrottlePosition();
                //TimeEngineStart
                TimeRunWithMILOn = scan.getRunTimeRunWithMILOn();
                TimeSinceTroubleCodesCleared = scan.getRunTimeSinceTroubleCodesCleares();
                TimingAdvance = scan.getLastTimingAdvance();
               WarmsUpsCodesCleared = scan.getLastWarmsUpsCodesCleared();
            }


        }

    }
}
