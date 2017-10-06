using Android.Bluetooth;
using SmartMonitoring.Droid.Datos;
using Xamarin.Forms;
using SmartMonitoring.Droid.Negocio.DataTransfer;
using SmartMonitoring.Droid.Negocio.ConnectionProcess;
using SmartMonitoring.OBDII.Excepciones;
using System.Collections.Generic;
using System;

[assembly: Dependency(typeof(ConnectionManagement))]
namespace SmartMonitoring.Droid.Negocio.DataTransfer
{

    public class ConnectionManagement : IConnectionManagement
    {
        BluetoothSocket socket = null;
        DataBaseReader reader;
        ISmartMonitoringDAO dao;
       
       
        public ConnectionManagement()
        {
            socket = BluetoothAndroidManagement.getSocket();
            dao = new SmartMonitoringDAO(socket);
            reader = dao.getReader();
        }

        public void ConsultParameters()
        {
            try
            {
                dao.ConsultParameters();
            }
            catch(UnableToConnectException u)
            {
                throw u;
            }
            catch (NoDataException u)
            {
                throw u;
            }
            catch (StoppedException u)
            {
                throw u;
            }
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

        public List<string> getFuelSystemStatus()
        {
            List<int> value = reader.getFuelSystemStatus();
            List<string> status = new List<string>(2);
            switch (value[0])
            {
                case 1:
                    status[0] = "Bucle abierto debido a temperatura baja del motor";
                    break;
                case 2:
                    status[0] = "Bucle cerrado; uso de sensor de oxígeno para determinar la mezcla de combustible";
                    break;
                case 4:
                    status[0] = "Bucle abierto debido a carga del motor o corte de combustible por desaceleración";
                    break;
                case 8:
                    status[0] = "Bucle abierto debido a falla del sistema";
                    break;
                case 16:
                    status[0] = "Bucle cerrado usando por lo menos un sensor de oxígeno; pero hay una falla en el sistema de retroalimentación";
                    break;
                default:
                    status[0] = "Valor inválido";
                    break;

            }
            switch (value[1])
            {
                case 1:
                    status[0] = "Bucle abierto debido a temperatura baja del motor";
                    break;
                case 2:
                    status[0] = "Bucle cerrado; uso de sensor de oxígeno para determinar la mezcla de combustible";
                    break;
                case 4:
                    status[0] = "Bucle abierto debido a carga del motor o corte de combustible por desaceleración";
                    break;
                case 8:
                    status[0] = "Bucle abierto debido a falla del sistema";
                    break;
                case 16:
                    status[0] = "Bucle cerrado usando por lo menos un sensor de oxígeno; pero hay una falla en el sistema de retroalimentación";
                    break;
            }
            return status;


        }

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

        public double getLastControlModuleVoltage()
        {
            return reader.getLastControlModuleVoltage();
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
        public List<int> getLastEnginePercentTorqueData()
        {
            return reader.getLastEnginePercentTorqueData();
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
        public List<int> FuelAirEquivalence_OxygenVoltage_OxygenSensorCurrent_IntakeManifoldAbsolutePressure()
        {
            return reader.FuelAirEquivalence_OxygenVoltage_OxygenSensorCurrent_IntakeManifoldAbsolutePressure();
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
        public List<int> MaximunValueAirFlowRateFromMassAirFlowSensor()
        {
            return reader.MaximunValueAirFlowRateFromMassAirFlowSensor();
        }

        public List<double> OxygenSensor1()
        {
            return reader.OxygenSensor1();
        }
        public List<double> OxygenSensor1B()
        {
            return reader.OxygenSensor1B();
        }
        public List<double> OxygenSensor1C()
        {
            return reader.OxygenSensor1C();
        }
        public List<double> OxygenSensor2()
        {
            return reader.OxygenSensor2();
        }
        public List<double> OxygenSensor2B()
        {
            return reader.OxygenSensor2B();
        }
        public List<double> OxygenSensor2C()
        {
            return reader.OxygenSensor2C();
        }
        public List<double> OxygenSensor3()
        {
            return reader.OxygenSensor3();
        }
        public List<double> OxygenSensor3B()
        {
            return reader.OxygenSensor3B();
        }
        public List<double> OxygenSensor3C()
        {
            return reader.OxygenSensor3C();
        }
        public List<double> OxygenSensor4()
        {
            return reader.OxygenSensor4();
        }
        public List<double> OxygenSensor4B()
        {
            return reader.OxygenSensor4B();
        }
        public List<double> OxygenSensor4C()
        {
            return reader.OxygenSensor4C();
        }
        public List<double> OxygenSensor5()
        {
            return reader.OxygenSensor5();
        }
        public List<double> OxygenSensor5B()
        {
            return reader.OxygenSensor5B();
        }
        public List<double> OxygenSensor5C()
        {
            return reader.OxygenSensor5C();
        }
        public List<double> OxygenSensor6()
        {
            return reader.OxygenSensor6();
        }
        public List<double> OxygenSensor6B()
        {
            return reader.OxygenSensor6B();
        }
        public List<double> OxygenSensor6C()
        {
            return reader.OxygenSensor6C();
        }
        public List<double> OxygenSensor7()
        {
            return reader.OxygenSensor7();
        }
        public List<double> OxygenSensor7B()
        {
            return reader.OxygenSensor7B();
        }
        public List<double> OxygenSensor7C()
        {
            return reader.OxygenSensor7C();
        }
        public List<double> OxygenSensor8()
        {
            return reader.OxygenSensor8();
        }
        public List<double> OxygenSensor8B()
        {
            return reader.OxygenSensor6B();
        }
        public List<double> OxygenSensor8C()
        {
            return reader.OxygenSensor8C();
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

        public List<double> LongTermSecondaryOxygenSensorTrim1_3()
        {
            return reader.LongTermSecondaryOxygenSensorTrim1_3();
        }

        public List<double> LongTermSecondaryOxygenSensorTrim2_4()
        {
            return reader.LongTermSecondaryOxygenSensorTrim2_4();
        }

        public List<double> ShortTermSecondaryOxygenSensorTrim1_3()
        {
           return reader.ShortTermSecondaryOxygenSensorTrim1_3();
        }

        public List<double> ShortTermSecondaryOxygenSensorTrim2_4()
        {
            return reader.ShortTermSecondaryOxygenSensorTrim2_4();
        }
    }
}