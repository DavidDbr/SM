
using Android.Bluetooth;
using SmartMonitoring.BBDD;
using SmartMonitoring.Droid.Datos;
using SmartMonitoring.Droid.Negocio.ConnectionProcess;
using SmartMonitoring.Droid.Negocio.DataTransfer;
using SmartMonitoring.MVVM;
using SmartMonitoring.OBDII;
using SmartMonitoring.OBDII.Excepciones;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading;
using Xamarin.Forms;

[assembly: Dependency(typeof(ConnectionManagement))]
namespace SmartMonitoring.Droid.Negocio.DataTransfer
{

    public class ConnectionManagement : IConnectionManagement
    {
        BluetoothSocket socket = null;
        ISmartMonitoringDAO dao;
        public const string NO_DATA = "NO DATA";
        ViewModel vm = null;
        Thread t = null;
        bool consultar;
        Visibilidad actualVisibilidad;
       
        public bool Consultar
        {
            get
            {
                return consultar;
            }
            set
            {
                consultar = value;
            }
        }

        public ConnectionManagement()
        {
            Consultar = true;
            socket = BluetoothAndroidManagement.getSocket();
            dao = new SmartMonitoringDAO(socket);
            vm = new ViewModel();
        
        }

        public void setVisibilidad(Visibilidad visibilidad)
        {
            dao.setVisibilidad(visibilidad);
        }

        public Visibilidad getVisibilidad()
        {
            actualVisibilidad = dao.GetVisibilidad();
            return actualVisibilidad;
        }

        public SQLiteConnection getSQLConnection()
        {
            return dao.getSQLConnection();
        }
        public void setGuardarDatos(bool value)
        {
            dao.setGuardarDatos(value);
        }

        public bool getGuardarDatos()
        {
            return dao.getGuardarDatos();
        }

        public ViewModel getViewModel()
        {
            return vm;
        }

        public List<byte[]> getPids()
        {
            return dao.getPids();
        }


        public List<DiagnosticTroubleCode> DiagnosticCar()
        {
            return dao.DiagnosticCar();
        }

        public void InitializedOBD2()
        {
            try
            {
                dao.Initialize();
            }
            catch (UnableToConnectException u)
            {
                throw u;
            }
        }





        public async void getFuelSystemStatusAsync()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.FuelSystemStatus);
            List<string> value = dao.readFuelSystemStatus(dr);
            List<string> status = new List<string>(2);
            switch (value[0])
            {
                case "1":
                    status[0] = "Bucle abierto debido a temperatura baja del motor";
                    break;
                case "2":
                    status[0] = "Bucle cerrado; uso de sensor de oxígeno para determinar la mezcla de combustible";
                    break;
                case "4":
                    status[0] = "Bucle abierto debido a carga del motor o corte de combustible por desaceleración";
                    break;
                case "8":
                    status[0] = "Bucle abierto debido a falla del sistema";
                    break;
                case "16":
                    status[0] = "Bucle cerrado usando por lo menos un sensor de oxígeno; pero hay una falla en el sistema de retroalimentación";
                    break;
                default:
                    status[0] = "Valor inválido";
                    break;

            }
            switch (value[1])
            {
                case "1":
                    status[0] = "Bucle abierto debido a temperatura baja del motor";
                    break;
                case "2":
                    status[0] = "Bucle cerrado; uso de sensor de oxígeno para determinar la mezcla de combustible";
                    break;
                case "4":
                    status[0] = "Bucle abierto debido a carga del motor o corte de combustible por desaceleración";
                    break;
                case "8":
                    status[0] = "Bucle abierto debido a falla del sistema";
                    break;
                case "16":
                    status[0] = "Bucle cerrado usando por lo menos un sensor de oxígeno; pero hay una falla en el sistema de retroalimentación";
                    break;
                default:
                    status[0] = "Valor inválido";
                    break;
            }
            vm.FuelSystemStatus_System1 = status[0];
            vm.FuelSystemStatus_System2 = status[1];
        }

        public async void getLastCalculatedEngineValue()
        {

            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.CalculatedEngineLoadValue);
            string value = dao.readCalculatedEngineLoad(dr);

            if (!value.Equals(NO_DATA))
            {
                double res = Double.Parse(value);
                Math.Round(res, 3);
                value = res.ToString();

            }
            vm.CalculatedEngineLoadValue = value;

        }

        public async void getLastEngineTemperatureAsync()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.EngineTemperature);
            string value = dao.readEngineTemperature(dr);
            vm.EngineTemperature = value;

        }

        public async void MAFAirFlowRateAsync()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.MAFAirFlowRate);
            string value = dao.readMAFAirFlowRate(dr);

            if (!value.Equals(NO_DATA))
            {
                double res = Double.Parse(value);
                Math.Round(res, 3);
                value = res.ToString();

            }
            vm.MAFAirFlowRate = value;
        }

        public async void getLastAbsoluteBarometricPressureAsync()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.AbsolutBarometricPressure);
            string value = dao.readAbsoluteBarometricPressure(dr);
            vm.AbsoluteBarometricPressure = value;

        }

        public async void getLastAbsoluteEvapSystemVaporPressureAsync()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.AbsoluteEvapSystemVaporPressure);
            string value = dao.readAbsoluteEvapSystemVaporPressure(dr);
            vm.AbsoluteEvapSystemVaporPressure = value;

        }

        public async void getLastAbsoluteLoadValueAsync()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.CalculatedEngineLoadValue);
            string value = dao.readAbsoluteLoadValue(dr);

            if (!value.Equals(NO_DATA))
            {
                double res = Double.Parse(value);
                Math.Round(res, 3);
                value = res.ToString();

            }
            vm.AbsoluteLoadValue = value;
        }

        public async void getLastAbsoluteThrottlePositionBAsync()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.AbsoluteThrottlePositionB);
            string value = dao.readAbsoluteThrottlePosition(dr);

            if (!value.Equals(NO_DATA))
            {
                double res = Double.Parse(value);
                Math.Round(res, 3);
                value = res.ToString();

            }
            vm.AbsoluteThrottlePositionB = value;
        }
        public async void getLastAbsoluteThrottlePositionCAsync()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.AbsoluteThrottlePositionC);
            string value = dao.readAbsoluteThrottlePosition(dr);

            if (!value.Equals(NO_DATA))
            {
                double res = Double.Parse(value);
                Math.Round(res, 3);
                value = res.ToString();

            }
            vm.AbsoluteThrottlePositionC = value;
        }
        public async void getLastAbsoluteThrottlePositionDAsync()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.AbsoluteThrottlePositionD);
            string value = dao.readAbsoluteThrottlePosition(dr);

            if (!value.Equals(NO_DATA))
            {
                double res = Double.Parse(value);
                Math.Round(res, 3);
                value = res.ToString();

            }
            vm.AbsoluteThrottlePositionD = value;
        }
        public async void getLastAbsoluteThrottlePositionEAsync()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.AbsoluteThrottlePositionE);
            string value = dao.readAbsoluteThrottlePosition(dr);

            if (!value.Equals(NO_DATA))
            {
                double res = Double.Parse(value);
                Math.Round(res, 3);
                value = res.ToString();

            }
            vm.AbsoluteThrottlePositionE = value;
        }
        public async void getLastAbsoluteThrottlePositionFAsync()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.AbsoluteThrottlePositionF);
            string value = dao.readAbsoluteThrottlePosition(dr);

            if (!value.Equals(NO_DATA))
            {
                double res = Double.Parse(value);
                Math.Round(res, 3);
                value = res.ToString();

            }
            vm.AbsoluteThrottlePositionF = value;
        }

        /* public async void getLastActualEnginePercentTorqueAsync()
         {
             DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.ActualEngine_PercentTorque);
             string value = dao.percent(dr);
             vm.ActualEngine_PercentTorque = value;

         }*/

        public async void getLastAmbientAirTemperatureAsync()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.AmbientAirTemperature);
            string value = dao.readAmbientTemperatureAir(dr);
            vm.AmbientTemperature = value;

        }



        public async void getLastCatalystTemperatureB1S1Async()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.CatalystTemperature_Bank1_Sensor1);
            string value = dao.readCatalystTemperature(dr);


            if (!value.Equals(NO_DATA))
            {
                double res = Double.Parse(value);
                Math.Round(res, 3);
                value = res.ToString();

            }
            vm.CatalystTemperatureB1S1 = value;

        }

        public async void getLastCatalystTemperatureB1S2Async()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.CatalystTemperature_Bank1_Sensor2);
            string value = dao.readCatalystTemperature(dr);


            if (!value.Equals(NO_DATA))
            {
                double res = Double.Parse(value);
                Math.Round(res, 3);
                value = res.ToString();

            }
            vm.CatalystTemperatureB1S2 = value;

        }
        public async void getLastCatalystTemperatureB2S2Async()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.CatalystTemperature_Bank2_Sensor2);
            string value = dao.readCatalystTemperature(dr);


            if (!value.Equals(NO_DATA))
            {
                double res = Double.Parse(value);
                Math.Round(res, 3);
                value = res.ToString();

            }
            vm.CatalystTemperatureB2S2 = value;

        }
        public async void getLastCatalystTemperatureB2S1Async()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.CatalystTemperature_Bank2_Sensor1);
            string value = dao.readCatalystTemperature(dr);


            if (!value.Equals(NO_DATA))
            {
                double res = Double.Parse(value);
                Math.Round(res, 3);
                value = res.ToString();

            }
            vm.CatalystTemperatureB2S1 = value;

        }

        public async void getLastCommandedEGRAsync()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.CommandedEGR);
            string value = dao.readCommandedEGR(dr);


            if (!value.Equals(NO_DATA))
            {
                double res = Double.Parse(value);
                Math.Round(res, 3);
                value = res.ToString();

            }
            vm.CommandedEGR = value;

        }

        public async void getLastCommandedEvaporativePurgeAsync()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.CommandedEvaporatiVePurge);
            string value = dao.readCommandedEvaporativePurge(dr);


            if (!value.Equals(NO_DATA))
            {
                double res = Double.Parse(value);
                Math.Round(res, 3);
                value = res.ToString();

            }
            vm.CommanddEvaporativePurge = value;

        }

        public void getLastCommandedSecondaryAirStatus()
        {
            // dataBase.ExecuteScalar<string >("SELECT Value FROM CommandedEvaporativePurge ORDER BY ID DESC LIMIT 1");

        }

        public async void getLastCommandedThrottleActuatorAsync()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.CommandedThrottleActuator);
            string value = dao.readCommandedThrottleActuator(dr);


            if (!value.Equals(NO_DATA))
            {
                double res = Double.Parse(value);
                Math.Round(res, 3);
                value = res.ToString();

            }
            vm.CommandedThrottleActuatorValue = value;
        }

        public async void getLastControlModuleVoltageAsync()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.ControlModuleVoltage);
            string value = dao.readControlModuleVoltage(dr);


            if (!value.Equals(NO_DATA))
            {
                double res = Double.Parse(value);
                Math.Round(res, 3);
                value = res.ToString();

            }
            vm.ControlModuleVoltage = value;
        }

        /*  public async void getLastDistanceTraveledSinseCodesClearedAsync()
          {
              DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.DistanceTraveledSinceCodesCleared);
              string value = dao.distance(dr);
              vm.DistanceTraveledSinceCodesCleared = value;

          }*/

        public async void getLastDistanceTraveledWithMILoAsync()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.DistanceTraveledWithMILon);
            string value = dao.readDistanceWithMILLamp(dr);
            vm.DistanceTraveledSinceCodesCleared = value;
        }
        /*  public async void getLastDriverDemandEngine_PercentTorqueAsync()
          {
              DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.DriverDemandEngine_PercentTorque);
              string value = dao.lastdriver(dr);
              vm.DriverDemandEngine_PercentTorque = value;

          }*/
        public async void getLastEGRErrorAsync()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.EGRError);
            string value = dao.readEGRError(dr);


            if (!value.Equals(NO_DATA))
            {
                double res = Double.Parse(value);
                Math.Round(res, 3);
                value = res.ToString();

            }
            vm.EGRError1 = value;
        }
        public async void getLastEngineFuelRateAsync()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.EngineFuelRate);
            string value = dao.readEngineFuelRate(dr);


            if (!value.Equals(NO_DATA))
            {
                double res = Double.Parse(value);
                Math.Round(res, 3);
                value = res.ToString();

            }
            vm.EngineFuelRateValue = value;
        }

        public async void getLastEngineOilTemperatureAsync()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.CatalystTemperature_Bank2_Sensor1);
            string value = dao.readEngineOilTemperature(dr);


            if (!value.Equals(NO_DATA))
            {
                double res = Double.Parse(value);
                Math.Round(res, 3);
                value = res.ToString();

            }
            vm.EngineOilTemperature = value;
        }
        public async void getLastEnginePercentTorqueDataAsync()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.EnginePercentTorqueData);
            List<string> values = dao.readEnginePercentTorqueData(dr);
            vm.EnginePercentTorqueData_PercentageIdle = values[0];
            vm.EnginePercentTorqueData_PercentageEnginePoint1 = values[1];
            vm.EnginePercentTorqueData_PercentageEnginePoint2 = values[2];
            vm.EnginePercentTorqueData_PercentageEnginePoint3 = values[3];
            vm.EnginePercentTorqueData_PercentageEnginePoint4 = values[4];

        }
        public async void getLastEngineReferenceTorqueAsync()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.EngineReferenceTorque);
            string value = dao.readEngineReferenceTorque(dr);

        }
        public async void getLastEngineStartTimeAsync()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.EngineStartTime);
            string value = dao.readEngineStartTime(dr);
            vm.TimeEngineStart = value;

        }

        /*public async void getLastEthanolFuelPercentageAsync()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.EhtanolFuelPercen);
            string value = dao.eht(dr);


            if (!value.Equals(NO_DATA))
            {
                double res = Double.Parse(value);
                Math.Round(res, 3);
                value = res.ToString();

            }
            vm.EthanolFuelPercentage = value;
        }*/
        public async void getLastEvapSystemVaporPressureAsync()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.EvapSystemVaporPressure);
            string value = dao.readEvapSystemVaporPressure(dr);


            if (!value.Equals(NO_DATA))
            {
                double res = Double.Parse(value);
                Math.Round(res, 3);
                value = res.ToString();

            }
            vm.EvapSystemVaporPressure = value;
        }
        public async void getLastFuelAirCommandedEquivalenceRatioAsync()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.Fuel_AirCommandedEquivalenceRatio);
            string value = dao.readCalculatedEngineLoad(dr);


            if (!value.Equals(NO_DATA))
            {
                double res = Double.Parse(value);
                Math.Round(res, 3);
                value = res.ToString();

            }
            vm.FuelAirCommandedEquivalenceRatio = value;
        }
        /* public async void FuelAirEquivalence_OxygenVoltage_OxygenSensorCurrent_IntakeManifoldAbsolutePressureAsync()
         {
             DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.CatalystTemperature_Bank2_Sensor1);
             List<string> values = dao.readFuelAirEquivalence_OxygenVoltage_OxygenSensorCurrent_IntakeManifoldAbsolutePressure(dr);
             vm.Max
         }*/
        public async void getLastFuelInjectionTimingValueAsync()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.FuelInjectionTiming);
            string value = dao.readFuelInjectionTiming(dr);


            if (!value.Equals(NO_DATA))
            {
                double res = Double.Parse(value);
                Math.Round(res, 3);
                value = res.ToString();

            }
            vm.FuelInjectionTiming = value;
        }
        public async void getLastFuelPressureAsync()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.FuelPressure);
            string value = dao.readFuelPressure(dr);
            vm.FuelPressure = value;

        }
        public async void getLastFuelRailAbsolutePressureAsync()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.FuelRailAbsolutePressure);
            string value = dao.readCalculatedEngineLoad(dr);


            if (!value.Equals(NO_DATA))
            {
                double res = Double.Parse(value);
                Math.Round(res, 3);
                value = res.ToString();

            }
            vm.FuelRailAbsolutePressure = value;
        }
        public async void getLastFuelRailGaugeAbsolutePressure()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.FuelRailGaugePressure);
            string value = dao.readCalculatedEngineLoad(dr);
            vm.FuelRailGaugePressure = value;

        }

        /**
         * REVISAR
         * */
        public async void getLastFuelRailPressureAsync()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.FuelRailPressure);
            string value = dao.readFuelRailPressure(dr);


            if (!value.Equals(NO_DATA))
            {
                double res = Double.Parse(value);
                Math.Round(res, 3);
                value = res.ToString();

            }
            vm.FuelRailAbsolutePressure = value;
        }
        public async void getLastFuelTankLevelAsync()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.FuelTankLevel);
            string value = dao.readFuelTankLevelInput(dr);


            if (!value.Equals(NO_DATA))
            {
                double res = Double.Parse(value);
                Math.Round(res, 3);
                value = res.ToString();

            }
            vm.FuelTankLevel = value;
        }

        public async void getFuelTypeAsync()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.FuelType);
            string value = dao.readFuelType(dr);
            vm.FuelType = value;

        }
        public async void getLastHybridBateryPackRemainingLifeAsync()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.HybridBatteryPackRemainingLife);
            string value = dao.readCalculatedEngineLoad(dr);


            if (!value.Equals(NO_DATA))
            {
                double res = Double.Parse(value);
                Math.Round(res, 3);
                value = res.ToString();

            }
            vm.HybridBateryPackRemainingLife = value;
        }
        public async void getLastIntakeManifoldAbsolutePressureAsync()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.IntakeManifoldAbsolutePressure);
            string value = dao.readIntakeManifoldAbsolutePressure(dr);

            vm.IntakeManifoldAbsolutePressureValue = value;

        }

        public async void getLastIntakeAirTemperatureAsync()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.IntakeTemperature);
            string value = dao.readIntakeAirTemperature(dr);

            vm.IntakeTemperature = value;

        }


        public async void MaximunValueAirFlowRateFromMassAirFlowSensorAsync()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.MaximunValueFlowRateFromMassAirFlowSensor);
            List<string> values = dao.readMaximunValueFlowRateFromMassAirFlowSensor(dr);
            vm.MaximunValueAirFlowRateFromMassAirFlowSensor_ValueA = values[0];
            vm.MaximunValueAirFlowRateFromMassAirFlowSensor_ValueB = values[1];
            vm.MaximunValueAirFlowRateFromMassAirFlowSensor_ValueC = values[2];
            vm.MaximunValueAirFlowRateFromMassAirFlowSensor_ValueD = values[3];
        }

        /*public async void OxygenSensor1Async()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.OxygenSensor1);
            string value = dao.readOxygenSensor(dr);

      */
        public async void getLastRelativeAcceleratorPedalPosition()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.RelativeAcceleratorPedalPosition);
            string value = dao.readRelativeAcceleratorPedalPosition(dr);


            if (!value.Equals(NO_DATA))
            {
                double res = Double.Parse(value);
                Math.Round(res, 3);
                value = res.ToString();

            }
            vm.RelativeAcceleratorPedalPosition = value;
        }
        public async void getLastRelativeThrottlePositionAsync()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.RelativeThrottlePosition);
            string value = dao.readRelativeThrottlePosition(dr);


            if (!value.Equals(NO_DATA))
            {
                double res = Double.Parse(value);
                Math.Round(res, 3);
                value = res.ToString();

            }
            vm.RelativeThrottlePosition = value;
        }
        public async void getLastRPMAsync()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.RPM);
            string value = dao.readRPM(dr);
            vm.Rpm = value;

        }

        public async void getLastShortTermFuelTrimB1Async()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.FuelTrim_Bank1_Short);
            string value = dao.readTermFuelTrim(dr);


            if (!value.Equals(NO_DATA))
            {
                double res = Double.Parse(value);
                Math.Round(res, 3);
                value = res.ToString();

            }
            vm.ShortTermFuelTrimB1 = value;
        }
        public async void getLastShortTermFuelTrimB2()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.FuelTrim_Bank2_Short);
            string value = dao.readTermFuelTrim(dr);


            if (!value.Equals(NO_DATA))
            {
                double res = Double.Parse(value);
                Math.Round(res, 3);
                value = res.ToString();

            }
            vm.ShortTermFuelTrimB2 = value;
        }
        public async void getLastLongTermFuelTrimB2()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.FuelTrim_Bank2_Long);
            string value = dao.readTermFuelTrim(dr);
            if (!value.Equals(NO_DATA))
            {
                double res = Double.Parse(value);
                Math.Round(res, 3);
                value = res.ToString();

            }
            vm.LongTermFuelTrimB2 = value;
        }

        public async void getLastLongTermFuelTrimB1()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.FuelTrim_Bank1_Long);
            string value = dao.readTermFuelTrim(dr);

            if (!value.Equals(NO_DATA))
            {
                double res = Double.Parse(value);
                Math.Round(res, 3);
                value = res.ToString();

            }
            vm.LongTermFuelTrimB1 = value;
        }

        public async void getLastSpeedAsync()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.Speed);
            string value = dao.readSpeed(dr);
            vm.Speed = value;
        }
        public async void getLastThrottlePositionAsync()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.ThrottlePosition);
            string value = dao.readThrottlePosition(dr);


            if (!value.Equals(NO_DATA))
            {
                double res = Double.Parse(value);
                Math.Round(res, 3);
                value = res.ToString();

            }
            vm.ThrottlePosition = value;
        }

        public async void getLastTimingAdvance()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.TimingAdvance);
            string value = dao.readTimingAdvance(dr);
            vm.TimingAdvance = value;


        }
        public async void getRunTimeRunWithMILOn()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.TimeRunWithMILOn);
            string value = dao.readDistanceWithMILLamp(dr);
            vm.DistanceTraveledWithMILo = value;

        }
        /*
        public string  getRunTimeSinceTroubleCodesCleares()
        {
            return reader.getRunTimeSinceTroubleCodesCleares();
        }
        

        public async void  getLastWarmsUpsCodesCleared()
        {
            return reader.getLastWarmsUpsCodesCleared();
        }*/

        public async void LongTermSecondaryOxygenSensorTrim1_3()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.LongTermSecondaryOxygenSensorTrim1_3);
            List<string> values = dao.readSecondaryOxygenSensorTrim(dr);
            vm.LongTermSecondaryOxygenSensorTrim1_3_ValueA = values[0];
            vm.LongTermSecondaryOxygenSensorTrim1_3_ValueB = values[1];

        }

        public async void LongTermSecondaryOxygenSensorTrim2_4()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.LongTermSecondaryOxygenSensorTrim2_4);
            List<string> values = dao.readSecondaryOxygenSensorTrim(dr);
            vm.LongTermSecondaryOxygenSensorTrim2_4_ValueA = values[0];
            vm.LongTermSecondaryOxygenSensorTrim2_4_ValueB = values[1];
        }

        public async void ShortTermSecondaryOxygenSensorTrim1_3()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.ShortTermSecondaryOxygenSensorTrim1_3);
            List<string> values = dao.readSecondaryOxygenSensorTrim(dr);
            vm.ShortTermSecondaryOxygenSensorTrim1_3_ValueA = values[0];
            vm.ShortTermSecondaryOxygenSensorTrim1_3_ValuB = values[1];
        }

        public async void ShortTermSecondaryOxygenSensorTrim2_4()
        {
            DataTransferSchema dr = await dao.ConsultParametersAsync(Parameters.PID.ShortTermSecondaryOxygenSensorTrim2_4);
            List<string> values = dao.readSecondaryOxygenSensorTrim(dr);
            vm.ShortTermSecondaryOxygenSensorTrim2_4_ValueA = values[0];
            vm.ShortTermSecondaryOxygenSensorTrim2_4_ValueB = values[1];
        }


        public void ConsultParameters()
        {
            t= new Thread(ConsultParametersThread);
            
            t.Start();

        }
        public void ConsultParametersThread()
        {
            getFuelTypeAsync();
            while (true)
            {
                if (Consultar)
                {

                    if (actualVisibilidad.rpmVisible == 1)
                    {
                        getLastRPMAsync();
                    }
                    if (actualVisibilidad.speedVisible == 1)
                    {
                        getLastSpeedAsync();
                    }
                    if (actualVisibilidad.engineOilTemperatureVisible == 1)
                    {
                        getLastEngineOilTemperatureAsync();
                    }
                    if (actualVisibilidad.engineTemperatureVisible == 1)
                    {
                        getLastEngineTemperatureAsync();
                    }
                    if (actualVisibilidad.fuelTankLevelVisible == 1)
                    {
                        getLastFuelTankLevelAsync();
                    }

                    if (actualVisibilidad.rpmVisible == 1)
                    {
                        getLastRPMAsync();
                    }
                    if (actualVisibilidad.speedVisible == 1)
                    {
                        getLastSpeedAsync();
                    }
                    if (actualVisibilidad.absoluteLoadValueVisible == 1)
                    {
                        getLastAbsoluteLoadValueAsync();
                    }
                    if (actualVisibilidad.ambientTemperatureVisible == 1)
                    {
                        getLastAmbientAirTemperatureAsync();
                    }
                    if (actualVisibilidad.controlModuleVoltageVisible == 1)
                    {
                        getLastControlModuleVoltageAsync();
                    }
                    if (actualVisibilidad.timeEngineStartVisible == 1)
                    {
                        getLastEngineStartTimeAsync();
                    }
                    if (actualVisibilidad.absoluteBarometricPressureVisible == 1)
                    {
                        getLastAbsoluteBarometricPressureAsync();
                    }
                    if (actualVisibilidad.absoluteThrottlePositionBVisible == 1)
                    {
                        getLastAbsoluteThrottlePositionBAsync();
                    }
                    if (actualVisibilidad.rpmVisible == 1)
                    {
                        getLastRPMAsync();
                    }
                    if (actualVisibilidad.speedVisible == 1)
                    {
                        getLastSpeedAsync();
                    }
                    if (actualVisibilidad.absoluteThrottlePositionCVisible == 1)
                    {
                        getLastAbsoluteThrottlePositionCAsync();
                    }
                    if (actualVisibilidad.absoluteThrottlePositionDVisible == 1)
                    {
                        getLastAbsoluteThrottlePositionDAsync();
                    }
                    if (actualVisibilidad.engineFuelRateValueVisible == 1)
                    {
                        getLastEngineFuelRateAsync();
                    }
                    if (actualVisibilidad.fuelAirCommandedEquivalenceRatioVisible == 1)
                    {
                        getLastFuelAirCommandedEquivalenceRatioAsync();
                    }
                    if (actualVisibilidad.timeRunWithMILOnVisible == 1)
                    {
                        getRunTimeRunWithMILOn();
                    }
                    ShortTermSecondaryOxygenSensorTrim1_3();
                    ShortTermSecondaryOxygenSensorTrim2_4();
                    LongTermSecondaryOxygenSensorTrim1_3();
                    LongTermSecondaryOxygenSensorTrim2_4();

                    if (actualVisibilidad.rpmVisible == 1)
                    {
                        getLastRPMAsync();
                    }
                    if (actualVisibilidad.speedVisible == 1)
                    {
                        getLastSpeedAsync();
                    }
                    if (actualVisibilidad.absoluteThrottlePositionEVisible == 1)
                    {
                        getLastAbsoluteThrottlePositionEAsync();
                    }
                    if (actualVisibilidad.absoluteThrottlePositionFVisible == 1)
                    {
                        getLastAbsoluteThrottlePositionFAsync();
                    }
                    if (actualVisibilidad.rpmVisible == 1)
                    {
                        getLastRPMAsync();
                    }
                    if (actualVisibilidad.speedVisible == 1)
                    {
                        getLastSpeedAsync();
                    }
                    if (actualVisibilidad.calculatedEngineLoadValueVisible == 1)
                    {
                        getLastCalculatedEngineValue();
                    }
                    if (actualVisibilidad.catalystTemperatureB2S1Visible == 1)
                    {
                        getLastCatalystTemperatureB2S1Async();
                    }
                    if (actualVisibilidad.rpmVisible == 1)
                    {
                        getLastRPMAsync();
                    }
                    if (actualVisibilidad.speedVisible == 1)
                    {
                        getLastSpeedAsync();
                    }
                    if (actualVisibilidad.catalystTemperatureB1S1Visible == 1)
                    {
                        getLastCatalystTemperatureB1S1Async();
                    }
                    if (actualVisibilidad.catalystTemperatureB2S2Visible == 1)
                    {
                        getLastCatalystTemperatureB2S2Async();
                    }
                    if (actualVisibilidad.rpmVisible == 1)
                    {
                        getLastRPMAsync();
                    }
                    if (actualVisibilidad.speedVisible == 1)
                    {
                        getLastSpeedAsync();
                    }
                    if (actualVisibilidad.catalystTemperatureB1S2Visible == 1)
                    {
                        getLastCatalystTemperatureB1S2Async();
                    }
                    if (actualVisibilidad.commandedEGRVisible == 1)
                    {
                        getLastCommandedEGRAsync();
                    }
                    if (actualVisibilidad.rpmVisible == 1)
                    {
                        getLastRPMAsync();
                    }
                    if (actualVisibilidad.speedVisible == 1)
                    {
                        getLastSpeedAsync();
                    }
                    if (actualVisibilidad.commanddEvaporativePurgeVisible == 1)
                    {
                        getLastCommandedEvaporativePurgeAsync();
                    }
                    if (actualVisibilidad.commandedThrottleActuatorValueVisible == 1)
                    {
                        getLastCommandedThrottleActuatorAsync();
                    }
                    if (actualVisibilidad.rpmVisible == 1)
                    {
                        getLastRPMAsync();
                    }
                    if (actualVisibilidad.speedVisible == 1)
                    {
                        getLastSpeedAsync();
                    }
                    if (actualVisibilidad.controlModuleVoltageVisible == 1)
                    {
                        getLastControlModuleVoltageAsync();
                    }
                    if (actualVisibilidad.EGRErrorVisible == 1)
                    {
                        getLastEGRErrorAsync();
                    }
                    if (actualVisibilidad.rpmVisible == 1)
                    {
                        getLastRPMAsync();
                    }
                    if (actualVisibilidad.speedVisible == 1)
                    {
                        getLastSpeedAsync();
                    }
                    if (actualVisibilidad.evapSystemVaporPressureVisible == 1)
                    {
                        getLastEvapSystemVaporPressureAsync();
                    }
                    if (actualVisibilidad.mAFAirFlowRateVisible == 1)
                    {
                        MAFAirFlowRateAsync();
                    }



                    MaximunValueAirFlowRateFromMassAirFlowSensorAsync();





                    if (actualVisibilidad.fuelAirCommandedEquivalenceRatioVisible == 1)
                    {
                        getLastFuelAirCommandedEquivalenceRatioAsync();
                    }
                    if (actualVisibilidad.rpmVisible == 1)
                    {
                        getLastRPMAsync();
                    }
                    if (actualVisibilidad.speedVisible == 1)
                    {
                        getLastSpeedAsync();
                    }
                    if (actualVisibilidad.fuelInjectionTimingVisible == 1)
                    {
                        getLastFuelInjectionTimingValueAsync();
                    }
                    if (actualVisibilidad.fuelPressureVisible == 1)
                    {
                        getLastFuelPressureAsync();
                    }
                    if (actualVisibilidad.rpmVisible == 1)
                    {
                        getLastRPMAsync();
                    }
                    if (actualVisibilidad.speedVisible == 1)
                    {
                        getLastSpeedAsync();
                    }
                    if (actualVisibilidad.fuelRailAbsolutePressureVisible == 1)
                    {
                        getLastFuelRailAbsolutePressureAsync();
                    }

                    getLastFuelRailPressureAsync();
                    if (actualVisibilidad.rpmVisible == 1)
                    {
                        getLastRPMAsync();
                    }
                    if (actualVisibilidad.speedVisible == 1)
                    {
                        getLastSpeedAsync();
                    }
                    if (actualVisibilidad.hybridBateryPackRemainingLifeVisible == 1)
                    {
                        getLastHybridBateryPackRemainingLifeAsync();
                    }
                    if (actualVisibilidad.intakeManifoldAbsolutePressureValueVisible == 1)
                    {
                        getLastIntakeManifoldAbsolutePressureAsync();
                    }
                    if (actualVisibilidad.rpmVisible == 1)
                    {
                        getLastRPMAsync();
                    }
                    if (actualVisibilidad.speedVisible == 1)
                    {
                        getLastSpeedAsync();
                    }
                    if (actualVisibilidad.throttlePositionVisible == 1)
                    {
                        getLastThrottlePositionAsync();
                    }
                    if (actualVisibilidad.relativeAcceleratorPedalPositionVisible == 1)
                    {
                        getLastRelativeAcceleratorPedalPosition();
                    }
                }


            }
        }

        public bool getEstadoConsultar()
        {
            return Consultar;
        }

        public void setEstadoConsultar(bool value)
        {
            Consultar = value;
        }


    }
}