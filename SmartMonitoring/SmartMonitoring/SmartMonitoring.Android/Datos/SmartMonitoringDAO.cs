using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.Bluetooth;
using SQLite;
using SmartMonitoring.OBDII;
using System.Runtime.CompilerServices;
using System.IO;
using SmartMonitoring.BBDD;
using SmartMonitoring.OBDII.Excepciones;
using SmartMonitoring.Droid.Negocio.ConnectionProcess;

namespace SmartMonitoring.Droid.Datos
{
    public class SmartMonitoringDAO : ISmartMonitoringDAO
    {
        BluetoothSocket socket = null;
        DataBaseReader reader;
        SQLiteConnection dataBase = null;
        byte[] pids01_20;
        byte[] pids21_40;
        byte[] pids41_60;
        public SmartMonitoringDAO(BluetoothSocket socket)
        {
            SQLAndroid sql = new SQLAndroid();
            dataBase = sql.GetConnection();
            reader = new DataBaseReader(dataBase);
            this.socket = socket;
        }

        
        public void Initialize()
        {
           
            byte[] cmd = Encoding.ASCII.GetBytes("ATD" + "\r");

            Console.WriteLine("Enviando comando ATD");
            socket.OutputStream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(100);
            if (Read().Equals(""))
            {
                throw new System.Exception();
            }
            socket.OutputStream.Flush();
            Thread.Sleep(100);


            cmd = Encoding.ASCII.GetBytes("ATZ" + "\r");
            Console.WriteLine("Enviando comando ATZ");
            socket.OutputStream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(100);
            if (Read().Equals(""))
            {
                throw new System.Exception();
            }
            socket.OutputStream.Flush();
            Thread.Sleep(100);

            cmd = Encoding.ASCII.GetBytes("AT E0" + "\r");
            Console.WriteLine("Enviando comando AT E0");
            socket.OutputStream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(100);
            if (Read().Equals(""))
            {
                return;
            }
            socket.OutputStream.Flush();
            Thread.Sleep(100);

            cmd = Encoding.ASCII.GetBytes("AT L0" + "\r");
            Console.WriteLine("Enviando comando AT L0");

            socket.OutputStream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(100);
            if (Read().Equals(""))
            {
                return;
            }
            socket.OutputStream.Flush();
            Thread.Sleep(100);

            Console.WriteLine("Enviando comando AT S0");
            cmd = Encoding.ASCII.GetBytes("AT S0" + "\r");
            socket.OutputStream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(100);
            if (Read().Equals(""))
            {
                return;
            }
            socket.OutputStream.Flush();
            Thread.Sleep(100);
            Console.WriteLine("Enviando comando AT H0");
            cmd = Encoding.ASCII.GetBytes("AT H0" + "\r");
            socket.OutputStream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(100);
            socket.OutputStream.Flush();
            if (Read().Equals(""))
            {
                return;
            }


            socket.OutputStream.Flush();
            Thread.Sleep(100);
            cmd = Encoding.ASCII.GetBytes("0100" + "\r");
            socket.OutputStream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(100);
            string firstpids = Read();
            if (firstpids.Contains("UNABLE TO CONNECT"))
            {
                throw new UnableToConnectException();
            }

            firstpids = firstpids.Substring(firstpids.Length - 10);
            string result = "";
            foreach (char c in firstpids)
            {
                byte a = (byte)c;
                if (a == 13)
                {
                    break;
                }
                result = result + c;
            }
            pids01_20 = new byte[32];
            for (int i = 0; i < result.Length; i++)
            {

                string binaryData = "";
                binaryData = Convert.ToString(Convert.ToInt32(result[i].ToString(), 16), 2).PadLeft(4, '0');
                pids01_20[i * 4] = (byte)binaryData[0];
                pids01_20[4*i + 1] = (byte)binaryData[1];
                pids01_20[4*i + 2] = (byte)binaryData[2];
                pids01_20[4*i + 3] = (byte)binaryData[3];
            }


            /*firstpids = firstpids.Substring(8);
            byte[] pids01_20 = Encoding.ASCII.GetBytes(firstpids);*/

            cmd = Encoding.ASCII.GetBytes("0120" + "\r");
            socket.OutputStream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(200);
            string secondpids = Read();
            if (secondpids.Contains("UNABLE TO CONNECT"))
            {
                throw new UnableToConnectException();
            }
            secondpids = secondpids.Substring(secondpids.Length - 10);
            result = "";
            foreach (char c in secondpids)
            {
                byte a = (byte)c;
                if (a == 13)
                {
                    break;
                }
                result = result + c;
            }
            pids21_40 = new byte[32];
            for (int i = 0; i < result.Length; i++)
            {

                string binaryData = "";
                binaryData = Convert.ToString(Convert.ToInt32(result[i].ToString(), 16), 2).PadLeft(4, '0');
                pids21_40[4 * i] = (byte)binaryData[0];
                pids21_40[4 * i + 1] = (byte)binaryData[1];
                pids21_40[4 * i + 2] = (byte)binaryData[2];
                pids21_40[4 * i + 3] = (byte)binaryData[3];
            }

            cmd = Encoding.ASCII.GetBytes("0140" + "\r");
            socket.OutputStream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(206);
            string thirdpids = Read();
            if (thirdpids.Contains("UNABLE TO CONNECT"))
            {
                throw new UnableToConnectException();
            }
            thirdpids = thirdpids.Substring(thirdpids.Length - 10);
            result = "";
            foreach (char c in thirdpids)
            {
                byte a = (byte)c;
                if (a == 13)
                {
                    break;
                }
                result = result + c;
            }
            pids41_60 = new byte[32];
            for (int i = 0; i < result.Length; i++)
            {

                string binaryData = "";
                binaryData = Convert.ToString(Convert.ToInt32(result[i].ToString(), 16), 2).PadLeft(4, '0');
                pids41_60[i * 4] = (byte)binaryData[0];
                pids41_60[4 * i + 1] = (byte)binaryData[1];
                pids41_60[4 * i + 2] = (byte)binaryData[2];
                pids41_60[4 * i + 3] = (byte)binaryData[3];

                
            }
            for (int i = 0; i < pids01_20.Length; i++)
            {
                Console.WriteLine("Valor de " + i + "=" + pids01_20[i]);
            }

        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public string Read()
        {
            //También probado con BufferedReader.ready() para comprobar si el stream está listo para leer; mismo resultado.

            string data = "";

            try

            {

                System.Text.StringBuilder builder = new System.Text.StringBuilder();
                char c;
                byte a;

                //Este tipo de socket no soporta Timeouts

                if (socket.InputStream.IsDataAvailable())
                {
                    char[] chr = new char[100];
                    byte[] bytes = new byte[20];

                    // socket.InputStream.Read(bytes,0,0);
                    //   if (!socket.InputStream.CanRead || !socket.InputStream.IsDataAvailable()) continue;
                    while (true)
                    //  for (int i = 0; i < bytes.Length; i++)
                    {
                        a = (byte)socket.InputStream.ReadByte();

                        // a = buffer[i];
                        Console.WriteLine(a);
                        if (a < -1)
                        {
                            break;
                        }

                        c = (char)a;
                        if (c.Equals('>'))
                        {

                            break;

                        }
                        builder.Append(c);
                    }
                   

                    data = builder.ToString();
                    Console.WriteLine("Información: " + data);

                    socket.InputStream.Flush();
                }

                else
                {
                    Console.WriteLine("Input Stream no disponible");
                }

            }
            catch (System.Exception e)
            {
                Console.WriteLine("Error de lectura :" + e.Message);

            }

            return data;

        }

        public void ConsultParameters()
        {
            //DataResponse result=
            //ConsultParameters(Parameters.PID.RPM);
            //new Thread(ConsultParametersThread).Start();

             Thread t = new Thread(ConsultParametersThread);
             t.Start();
           
        }

        public void ConsultParametersThread()
        {
            if (pids41_60[16] == 1)
            {
                ConsultParameters(Parameters.PID.FuelType);
            }

            while (true)
            {
                if (pids01_20[12] == 49)
                {
                    ConsultParameters(Parameters.PID.Speed);
                }
                if (pids01_20[11] == 49)
                {
                    ConsultParameters(Parameters.PID.RPM);
                }
                if (pids01_20[16] == 49)
                {
                    ConsultParameters(Parameters.PID.ThrottlePosition);
                }
                if (pids01_20[4] == 49)
                {
                    ConsultParameters(Parameters.PID.EngineTemperature);
                }
                if (pids01_20[9] == 49)
                {
                    ConsultParameters(Parameters.PID.FuelPressure);
                }
                if (pids01_20[3] == 49)
                {
                    ConsultParameters(Parameters.PID.CalculatedEngineLoadValue);
                }
                if (pids21_40[18] == 49)
                {
                    ConsultParameters(Parameters.PID.AbsolutBarometricPressure);
                }
                if (pids41_60[18] == 49)
                {
                    ConsultParameters(Parameters.PID.AbsoluteEvapSystemVaporPressure);
                }

                if (pids01_20[12] == 49)
                {
                    ConsultParameters(Parameters.PID.Speed);
                }
                if (pids01_20[11] == 49)
                {
                    ConsultParameters(Parameters.PID.RPM);
                }
                if (pids01_20[16] == 49)
                {
                    ConsultParameters(Parameters.PID.ThrottlePosition);
                }
                if (pids01_20[4] == 49)
                {
                    ConsultParameters(Parameters.PID.EngineTemperature);
                }
                if (pids01_20[9] == 49)
                {
                    ConsultParameters(Parameters.PID.FuelPressure);
                }
                if (pids41_60[2] == 49)
                {
                    ConsultParameters(Parameters.PID.AbsoluteLoadValue);
                }
                if (pids41_60[6] == 49)
                {
                    ConsultParameters(Parameters.PID.AbsoluteThrottlePositionB);
                }
                if (pids41_60[7] == 49)
                {
                    ConsultParameters(Parameters.PID.AbsoluteThrottlePositionC);
                }
                if (pids41_60[8] == 49)
                {
                    ConsultParameters(Parameters.PID.AbsoluteThrottlePositionD);
                }
                if (pids41_60[9] == 49)
                {
                    ConsultParameters(Parameters.PID.AbsoluteThrottlePositionE);
                }
                if (pids01_20[12] == 49)
                {
                    ConsultParameters(Parameters.PID.Speed);
                }
                if (pids01_20[11] == 49)
                {
                    ConsultParameters(Parameters.PID.RPM);
                }
                if (pids01_20[16] == 49)
                {
                    ConsultParameters(Parameters.PID.ThrottlePosition);
                }
                if (pids01_20[4] == 49)
                {
                    ConsultParameters(Parameters.PID.EngineTemperature);
                }
                if (pids01_20[9] == 49)
                {
                    ConsultParameters(Parameters.PID.FuelPressure);
                }

                if (pids41_60[10] == 49)
                {
                    ConsultParameters(Parameters.PID.AbsoluteThrottlePositionF);
                }
                /*if (pids01_20[12] == 49)//FALTA 61-80
                {
                    ConsultParameters(Parameters.PID.ActualEngine_PercentTorque);
                }*/
                if (pids01_20[12] == 49)
                {
                    ConsultParameters(Parameters.PID.Speed);
                }
                if (pids01_20[11] == 49)
                {
                    ConsultParameters(Parameters.PID.RPM);
                }
                if (pids01_20[16] == 49)
                {
                    ConsultParameters(Parameters.PID.ThrottlePosition);
                }
                if (pids01_20[4] == 49)
                {
                    ConsultParameters(Parameters.PID.EngineTemperature);
                }
                if (pids01_20[9] == 49)
                {
                    ConsultParameters(Parameters.PID.FuelPressure);
                }

                if (pids21_40[27] == 49)
                {
                    ConsultParameters(Parameters.PID.CatalystTemperature_Bank1_Sensor1);
                }
                if (pids21_40[28] == 49)
                {
                    ConsultParameters(Parameters.PID.CatalystTemperature_Bank1_Sensor2);
                }
                if (pids01_20[12] == 49)
                {
                    ConsultParameters(Parameters.PID.Speed);
                }
                if (pids01_20[11] == 49)
                {
                    ConsultParameters(Parameters.PID.RPM);
                }
                if (pids01_20[16] == 49)
                {
                    ConsultParameters(Parameters.PID.ThrottlePosition);
                }
                if (pids01_20[4] == 49)
                {
                    ConsultParameters(Parameters.PID.EngineTemperature);
                }
                if (pids01_20[9] == 49)
                {
                    ConsultParameters(Parameters.PID.FuelPressure);
                }
                if (pids21_40[29] == 49)
                {
                    ConsultParameters(Parameters.PID.CatalystTemperature_Bank2_Sensor1);
                }
                if (pids21_40[30] == 49)
                {
                    ConsultParameters(Parameters.PID.CatalystTemperature_Bank2_Sensor2);
                }
                if (pids41_60[15] == 49)
                {
                    ConsultParameters(Parameters.PID.AmbientAirTemperature);
                }
                if (pids21_40[11] == 49)
                {
                    ConsultParameters(Parameters.PID.CommandedEGR);
                }
                if (pids21_40[13] == 49)
                {
                    ConsultParameters(Parameters.PID.CommandedEvaporatiVePurge);
                }
                if (pids41_60[11] == 49)
                {
                    ConsultParameters(Parameters.PID.CommandedThrottleActuator);
                }
                if (pids01_20[12] == 49)
                {
                    ConsultParameters(Parameters.PID.Speed);
                }
                if (pids01_20[11] == 49)
                {
                    ConsultParameters(Parameters.PID.RPM);
                }
                if (pids01_20[16] == 49)
                {
                    ConsultParameters(Parameters.PID.ThrottlePosition);
                }
                if (pids01_20[4] == 49)
                {
                    ConsultParameters(Parameters.PID.EngineTemperature);
                }
                if (pids01_20[9] == 49)
                {
                    ConsultParameters(Parameters.PID.FuelPressure);
                }
                if (pids21_40[16] == 49)
                {
                    ConsultParameters(Parameters.PID.DistanceTraveledSinceCodesCleared);
                }
                if (pids21_40[0] == 49)
                {
                    ConsultParameters(Parameters.PID.DistanceTraveledWithMILon);
                }

                /*if (pids01_20[12] == 49)
                {
                    ConsultParameters(Parameters.PID.DriverDemandEngine_PercentTorque); //FALTA PIDS61-80
                }*/
                if (pids21_40[12] == 49)
                {
                    ConsultParameters(Parameters.PID.EGRError);
                }
                if (pids41_60[17] == 49)
                {
                    ConsultParameters(Parameters.PID.EhtanolFuelPercen);
                }
                if (pids41_60[29] == 49)
                {
                    ConsultParameters(Parameters.PID.EngineFuelRate);
                }
                if (pids01_20[12] == 49)
                {
                    ConsultParameters(Parameters.PID.Speed);
                }
                if (pids01_20[11] == 49)
                {
                    ConsultParameters(Parameters.PID.RPM);
                }
                if (pids01_20[16] == 49)
                {
                    ConsultParameters(Parameters.PID.ThrottlePosition);
                }
                if (pids01_20[4] == 49)
                {
                    ConsultParameters(Parameters.PID.EngineTemperature);
                }
                if (pids01_20[9] == 49)
                {
                    ConsultParameters(Parameters.PID.FuelPressure);
                }
                if (pids41_60[17] == 49)
                {
                    ConsultParameters(Parameters.PID.EngineOilTemperature);
                }
               /* if (pids01_20[12] == 1)//FALTA PIDS 61-80
                {
                    ConsultParameters(Parameters.PID.EnginePercentTorqueData);
                }*/

                /*if (pids01_20[12] == 49) //FALTA PIDS 61-80
                {
                    ConsultParameters(Parameters.PID.EngineReferenceTorque);
                }*/
                if (pids01_20[30] == 49)
                {
                    ConsultParameters(Parameters.PID.EngineStartTime);
                }
                if (pids01_20[4] == 49)
                {
                    ConsultParameters(Parameters.PID.EngineTemperature);
                }
                if (pids41_60[18] == 49)
                {
                    ConsultParameters(Parameters.PID.EvapSystemVaporPressure);
                }
                if (pids41_60[28] == 49)
                {
                    ConsultParameters(Parameters.PID.FuelInjectionTiming);
                }
                if (pids01_20[12] == 49)
                {
                    ConsultParameters(Parameters.PID.Speed);
                }
                if (pids01_20[11] == 49)
                {
                    ConsultParameters(Parameters.PID.RPM);
                }
                if (pids01_20[16] == 49)
                {
                    ConsultParameters(Parameters.PID.ThrottlePosition);
                }
                if (pids01_20[4] == 49)
                {
                    ConsultParameters(Parameters.PID.EngineTemperature);
                }
                if (pids01_20[9] == 49)
                {
                    ConsultParameters(Parameters.PID.FuelPressure);
                }
                if (pids41_60[24] == 49)
                {
                    ConsultParameters(Parameters.PID.FuelRailAbsolutePressure);
                }
                if (pids21_40[2] == 49)
                {
                    ConsultParameters(Parameters.PID.FuelRailGaugePressure);
                }
                if (pids21_40[1] == 49)
                {
                    ConsultParameters(Parameters.PID.FuelRailPressure);
                }
                if (pids21_40[14] == 49)
                {
                    ConsultParameters(Parameters.PID.FuelTankLevel);
                }
                if (pids01_20[6] == 49)
                {
                    ConsultParameters(Parameters.PID.FuelTrim_Bank1_Long);
                }
                if (pids01_20[5] == 49)
                {
                    ConsultParameters(Parameters.PID.FuelTrim_Bank1_Short);
                }
                if (pids01_20[8] == 49)
                {
                    ConsultParameters(Parameters.PID.FuelTrim_Bank2_Long);
                }
                if (pids01_20[7] == 49)
                {
                    ConsultParameters(Parameters.PID.FuelTrim_Bank2_Short);
                }
                if (pids01_20[12] == 49)
                {
                    ConsultParameters(Parameters.PID.Speed);
                }
                if (pids01_20[11] == 49)
                {
                    ConsultParameters(Parameters.PID.RPM);
                }
                if (pids01_20[16] == 49)
                {
                    ConsultParameters(Parameters.PID.ThrottlePosition);
                }
                if (pids01_20[4] == 49)
                {
                    ConsultParameters(Parameters.PID.EngineTemperature);
                }
                if (pids01_20[9] == 49)
                {
                    ConsultParameters(Parameters.PID.FuelPressure);
                }
                if (pids41_60[3] == 49)
                {
                    ConsultParameters(Parameters.PID.Fuel_AirCommandedEquivalenceRatio);
                }
                if (pids41_60[26] == 49)
                {
                    ConsultParameters(Parameters.PID.HybridBatteryPackRemainingLife);
                }
                if (pids01_20[10] == 49)
                {
                    ConsultParameters(Parameters.PID.IntakeManifoldAbsolutePressure);
                }
                if (pids01_20[14] == 49)
                {
                    ConsultParameters(Parameters.PID.IntakeTemperature);
                }
                if (pids01_20[15] == 49)
                {
                    ConsultParameters(Parameters.PID.MAFAirFlowRate);
                }
                if (pids41_60[15] == 49)
                {
                    ConsultParameters(Parameters.PID.MaximunValueFlowRateFromMassAirFlowSensor);
                }
                if (pids01_20[12] == 49)
                {
                    ConsultParameters(Parameters.PID.Speed);
                }
                if (pids01_20[11] == 49)
                {
                    ConsultParameters(Parameters.PID.RPM);
                }
                if (pids01_20[19] == 49)
                {
                    ConsultParameters(Parameters.PID.OxygenSensor1);
                }
                if (pids01_20[20] == 49)
                {
                    ConsultParameters(Parameters.PID.OxygenSensor2);
                }
                if (pids01_20[21] == 49)
                {
                    ConsultParameters(Parameters.PID.OxygenSensor3);
                }
                if (pids01_20[22] == 49)
                {
                    ConsultParameters(Parameters.PID.OxygenSensor4);
                }
                if (pids01_20[23] == 49)
                {
                    ConsultParameters(Parameters.PID.OxygenSensor5);
                }
                if (pids01_20[24] == 49)
                {
                    ConsultParameters(Parameters.PID.OxygenSensor6);
                }
                if (pids01_20[25] == 49)
                {
                    ConsultParameters(Parameters.PID.OxygenSensor7);
                }
                if (pids01_20[26] == 49)
                {
                    ConsultParameters(Parameters.PID.OxygenSensor8);
                }
                if (pids21_40[3] == 49)
                {
                    ConsultParameters(Parameters.PID.OxygenSensor1b);
                }
                if (pids21_40[4] == 49)
                {
                    ConsultParameters(Parameters.PID.OxygenSensor2b);
                }
                if (pids21_40[5] == 49)
                {
                    ConsultParameters(Parameters.PID.OxygenSensor3b);
                }
                if (pids21_40[6] == 49)
                {
                    ConsultParameters(Parameters.PID.OxygenSensor4b);
                }
                if (pids21_40[7] == 49)
                {
                    ConsultParameters(Parameters.PID.OxygenSensor5b);
                }
                if (pids21_40[8] == 49)
                {
                    ConsultParameters(Parameters.PID.OxygenSensor6b);
                }
                if (pids21_40[9] == 49)
                {
                    ConsultParameters(Parameters.PID.OxygenSensor7b);
                }
                if (pids21_40[10] == 49)
                {
                    ConsultParameters(Parameters.PID.OxygenSensor8b);
                }
                if (pids21_40[19] == 49)
                {
                    ConsultParameters(Parameters.PID.OxygenSensor1c);
                }
                if (pids21_40[20] == 49)
                {
                    ConsultParameters(Parameters.PID.OxygenSensor2c);
                }
                if (pids21_40[21] == 49)
                {
                    ConsultParameters(Parameters.PID.OxygenSensor3c);
                }
                if (pids21_40[22] == 49)
                {
                    ConsultParameters(Parameters.PID.OxygenSensor4c);
                }
                if (pids21_40[23] == 49)
                {
                    ConsultParameters(Parameters.PID.OxygenSensor5c);
                }
                if (pids21_40[24] == 49)
                {
                    ConsultParameters(Parameters.PID.OxygenSensor6c);
                }
                if (pids21_40[25] == 49)
                {
                    ConsultParameters(Parameters.PID.OxygenSensor7c);
                }
                if (pids21_40[26] == 49)
                {
                    ConsultParameters(Parameters.PID.OxygenSensor8c);
                }
                if (pids01_20[16] == 49)
                {
                    ConsultParameters(Parameters.PID.ThrottlePosition);
                }
                if (pids01_20[4] == 49)
                {
                    ConsultParameters(Parameters.PID.EngineTemperature);
                }
                if (pids01_20[9] == 49)
                {
                    ConsultParameters(Parameters.PID.FuelPressure);
                }
                if (pids41_60[25] == 49)
                {
                    ConsultParameters(Parameters.PID.RelativeAcceleratorPedalPosition);
                }
                if (pids01_20[12] == 49)
                {
                    ConsultParameters(Parameters.PID.RelativeThrottlePosition);
                }
                if (pids01_20[11] == 49)
                {
                    ConsultParameters(Parameters.PID.RPM);
                }
                if (pids01_20[16] == 49)
                {
                    ConsultParameters(Parameters.PID.ThrottlePosition);
                }
                if (pids01_20[13] == 49)
                {
                    ConsultParameters(Parameters.PID.TimingAdvance);
                }
                if (pids41_60[13] == 49)
                {
                    ConsultParameters(Parameters.PID.TimeSinceTroubleCodesCleared);
                }
                if (pids21_40[15] == 49)
                {
                    ConsultParameters(Parameters.PID.WarmsUpsCodesCleared);
                }
                if (pids01_20[12] == 49)
                {
                    ConsultParameters(Parameters.PID.Speed);
                }
                if (pids01_20[11] == 49)
                {
                    ConsultParameters(Parameters.PID.RPM);
                }
                if (pids01_20[16] == 49)
                {
                    ConsultParameters(Parameters.PID.ThrottlePosition);
                }
                if (pids01_20[4] == 49)
                {
                    ConsultParameters(Parameters.PID.EngineTemperature);
                }
                if (pids01_20[9] == 49)
                {
                    ConsultParameters(Parameters.PID.FuelPressure);
                }

            }
        }


        // public DataResponse ConsultParameters(BluetoothSocket socket, Parameters.PID pid)
        public void ConsultParameters(Parameters.PID pid)
        {

       
            string send = (Convert.ToUInt32(Parameters.ConsultMode.CurrentData).ToString("X2") + Convert.ToUInt32(pid).ToString("X2") + "\r");
            byte[] cmd = Encoding.ASCII.GetBytes(send);
            socket.OutputStream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(201);
            string data = Read();
            string dataFilter = "";
            for (int i = 0; i < data.Length; i++)
            {
                byte a = (byte)data[i];
                if (a == 13)
                {
                    break;
                }
                dataFilter = dataFilter + data[i];
            }

            if(dataFilter.Equals("UNABLE TO CONNECT"))
            {
                throw new UnableToConnectException();
            }
            if (dataFilter.Equals("NO DATA"))
            {
                throw new NoDataException();
            }
            if (dataFilter.Equals("STOPPED"))
            {
                throw new StoppedException();
            }


            DataTransferSchema dr = new DataTransferSchema(dataFilter, pid, Parameters.ConsultMode.CurrentData);

            switch (pid)
            {
                case Parameters.PID.FuelSystemStatus:

                    break;

                case Parameters.PID.CalculatedEngineLoadValue:
                    readCalculatedEngineLoad(dr);
                    break;

                case Parameters.PID.EngineTemperature:

                    readEngineTemperature(dr);
                    break;

                case Parameters.PID.FuelTrim_Bank1_Short:
                    readTermFuelTrim(dr);
                    break;

                case Parameters.PID.FuelTrim_Bank1_Long:
                    readTermFuelTrim(dr);
                    break;

                case Parameters.PID.FuelTrim_Bank2_Short:
                    readTermFuelTrim(dr);
                    break;

                case Parameters.PID.FuelTrim_Bank2_Long:
                    readTermFuelTrim(dr);
                    break;

                case Parameters.PID.MAFAirFlowRate:
                    readMAFAirFlowRate(dr);
                    break;

                case Parameters.PID.FuelPressure:

                    readFuelPressure(dr);
                    break;

                case Parameters.PID.IntakeManifoldAbsolutePressure:
                    readIntakeManifoldAbsolutePressure(dr);
                    break;

                case Parameters.PID.RPM:

                    readRMP(dr);
                    break;

                case Parameters.PID.Speed:

                    readSpeed(dr);
                    break;


                case Parameters.PID.TimingAdvance:
                    readTimingAdvance(dr);
                    break;


                case Parameters.PID.IntakeTemperature:
                    readIntakeAirTemperature(dr);
                    break;


                case Parameters.PID.ThrottlePosition:
                    readThrottlePosition(dr);
                    break;

                case Parameters.PID.CommandedSecondaryAirStatus:

                    break;

                case Parameters.PID.OxygenSensorsPresent:

                    break;

                case Parameters.PID.OxygenSensor1:
                    readOxygenSensor(dr);
                    break;

                case Parameters.PID.OxygenSensor2:
                    readOxygenSensor(dr);
                    break;

                case Parameters.PID.OxygenSensor3:
                    readOxygenSensor(dr);
                    break;

                case Parameters.PID.OxygenSensor4:
                    readOxygenSensor(dr);
                    break;

                case Parameters.PID.OxygenSensor5:
                    readOxygenSensor(dr);
                    break;

                case Parameters.PID.OxygenSensor6:
                    readOxygenSensor(dr);
                    break;

                case Parameters.PID.OxygenSensor7:
                    readOxygenSensor(dr);
                    break;

                case Parameters.PID.OxygenSensor8:
                    readOxygenSensor(dr);
                    break;

                case Parameters.PID.OBDStandarsPermit:

                    break;

                case Parameters.PID.OxygenSensorPresent_4Banks:

                    break;

                case Parameters.PID.AuxiliaryInputStatus:

                    break;

                case Parameters.PID.EngineStartTime:
                    readEngineStartTime(dr);
                    break;

                case Parameters.PID.DistanceTraveledWithMILon:
                    readDistanceWithMILLamp(dr);
                    break;

                case Parameters.PID.FuelRailPressure:
                    readFuelRailPressure(dr);
                    break;

                case Parameters.PID.FuelRailGaugePressure:
                    readFuelRailGaugePressure(dr);
                    break;

                case Parameters.PID.OxygenSensor1b:
                    readOxygenSensorB(dr);
                    break;

                case Parameters.PID.OxygenSensor2b:
                    readOxygenSensorB(dr);
                    break;

                case Parameters.PID.OxygenSensor3b:
                    readOxygenSensorB(dr);
                    break;

                case Parameters.PID.OxygenSensor4b:
                    readOxygenSensorB(dr);
                    break;

                case Parameters.PID.OxygenSensor5b:
                    readOxygenSensorB(dr);
                    break;

                case Parameters.PID.OxygenSensor6b:
                    readOxygenSensorB(dr);
                    break;

                case Parameters.PID.OxygenSensor7b:
                    readOxygenSensorB(dr);
                    break;

                case Parameters.PID.OxygenSensor8b:
                    readOxygenSensorB(dr);
                    break;

                case Parameters.PID.CommandedEGR:
                    readCommandedEGR(dr);
                    break;

                case Parameters.PID.EGRError:
                    readEGRError(dr);
                    break;

                case Parameters.PID.CommandedEvaporatiVePurge:
                    readCommandedEvaporativePurge(dr);
                    break;

                case Parameters.PID.FuelTankLevel:
                    readFuelTankLevelInput(dr);
                    break;

                case Parameters.PID.WarmsUpsCodesCleared:

                    break;

                case Parameters.PID.DistanceTraveledSinceCodesCleared:
                    
                    break;

                case Parameters.PID.AbsolutBarometricPressure:
                    readAbsoluteBarometricPressure(dr);
                    break;

                case Parameters.PID.OxygenSensor1c:
                    readOxygenSensorC(dr);
                    break;

                case Parameters.PID.OxygenSensor2c:
                    readOxygenSensorC(dr);
                    break;

                case Parameters.PID.OxygenSensor3c:
                    readOxygenSensorC(dr);
                    break;

                case Parameters.PID.OxygenSensor4c:
                    readOxygenSensorC(dr);
                    break;

                case Parameters.PID.OxygenSensor5c:
                    readOxygenSensorC(dr);
                    break;

                case Parameters.PID.OxygenSensor6c:
                    readOxygenSensorC(dr);
                    break;

                case Parameters.PID.OxygenSensor7c:
                    readOxygenSensorC(dr);
                    break;

                case Parameters.PID.OxygenSensor8c:
                    readOxygenSensorC(dr);
                    break;

                case Parameters.PID.CatalystTemperature_Bank1_Sensor1:
                    readCatalystTemperature(dr);
                    break;

                case Parameters.PID.CatalystTemperature_Bank1_Sensor2:
                    readCatalystTemperature(dr);
                    break;

                case Parameters.PID.CatalystTemperature_Bank2_Sensor1:
                    readCatalystTemperature(dr);
                    break;

                case Parameters.PID.CatalystTemperature_Bank2_Sensor2:
                    readCatalystTemperature(dr);
                    break;

                case Parameters.PID.MonitorStatusDriveCycle:

                    break;

                case Parameters.PID.ControlModuleVoltage:
                    readControlModuleVoltage(dr);
                    break;

                case Parameters.PID.AbsoluteLoadValue:
                    readAbsoluteLoadValue(dr);
                    break;

                case Parameters.PID.Fuel_AirCommandedEquivalenceRatio:
                    readFuelAirCommandedEquivalenceRatio(dr);
                    break;

                case Parameters.PID.RelativeThrottlePosition:
                    readRelativeThrottlePosition(dr);
                    break;

                case Parameters.PID.AmbientAirTemperature:
                    readAmbientTemperatureAir(dr);
                    break;

                case Parameters.PID.AbsoluteThrottlePositionB:
                    readAbsoluteThrottlePosition(dr);
                    break;

                case Parameters.PID.AbsoluteThrottlePositionC:
                    readAbsoluteThrottlePosition(dr);
                    break;

                case Parameters.PID.AbsoluteThrottlePositionD:
                    readAbsoluteThrottlePosition(dr);
                    break;

                case Parameters.PID.AbsoluteThrottlePositionE:
                    readAbsoluteThrottlePosition(dr);
                    break;

                case Parameters.PID.AbsoluteThrottlePositionF:
                    readAbsoluteThrottlePosition(dr);
                    break;

                case Parameters.PID.CommandedThrottleActuator:
                    readCommandedThrottleActuator(dr);
                    break;

                case Parameters.PID.TimeRunWithMILOn:
                    
                    break;

                case Parameters.PID.TimeSinceTroubleCodesCleared:

                    break;

                case Parameters.PID.FuelAirEquivalence_OxygenVoltage_OxygenSensorCurrent_IntakeManifoldAbsolutePressure:
                    readFuelAirEquivalence_OxygenVoltage_OxygenSensorCurrent_IntakeManifoldPressure(dr);
                    break;

                case Parameters.PID.MaximunValueFlowRateFromMassAirFlowSensor:
                    readMaximunValueFlowRateFromMassAirFlowSensor(dr);
                    break;

                case Parameters.PID.FuelType:
                    readFuelType(dr);
                    break;

                case Parameters.PID.EhtanolFuelPercen:
                    readEthanolPercentage(dr);
                    break;

                case Parameters.PID.AbsoluteEvapSystemVaporPressure:
                    readAbsoluteEvapSystemVaporPressure(dr);
                    break;

                case Parameters.PID.EvapSystemVaporPressure:
                    readEvapSystemVaporPressure(dr);
                    break;

                case Parameters.PID.ShortTermSecondaryOxygenSensorTrim1_3:
                    readSecondaryOxygenSensorTrim(dr);
                    break;

                case Parameters.PID.LongTermSecondaryOxygenSensorTrim1_3:
                    readSecondaryOxygenSensorTrim(dr);
                    break;

                case Parameters.PID.ShortTermSecondaryOxygenSensorTrim2_4:
                    readSecondaryOxygenSensorTrim(dr);
                    break;

                case Parameters.PID.LongTermSecondaryOxygenSensorTrim2_4:
                    readSecondaryOxygenSensorTrim(dr);
                    break;

                case Parameters.PID.FuelRailAbsolutePressure:
                    readFuelRailAbsolutePressure(dr);
                    break;

                case Parameters.PID.RelativeAcceleratorPedalPosition:
                    readRelativeAcceleratorPosition(dr);
                    break;

                case Parameters.PID.HybridBatteryPackRemainingLife:
                    readHybridBatteryPackRemainingLife(dr);
                    break;

                case Parameters.PID.EngineOilTemperature:
                    readEngineOilTemperature(dr);
                    break;

                case Parameters.PID.FuelInjectionTiming:
                    readFuelInjectionTiming(dr);
                    break;

                case Parameters.PID.EngineFuelRate:
                    readEngineFuelRate(dr);
                    break;

                case Parameters.PID.EmissionRequirementsToWhichVehicleIsDesigned:

                    break;
//Falla en prueba real con el coche, ya incluidos los filtros de pid
              /*  case Parameters.PID.DriverDemandEngine_PercentTorque:
                    readDriverDemandEngine_PercentTorque(dr);
                    break;*/

                case Parameters.PID.ActualEngine_PercentTorque:
                    readActualEngine_PercentTorque(dr);
                    break;

                case Parameters.PID.EngineReferenceTorque:
                    readEngineReferenceTorque(dr);
                    break;

                case Parameters.PID.EnginePercentTorqueData:
                    readEnginePercentTorqueData(dr);
                    break;



                default:
                    break;

            }





            //Thread.Sleep(151);
            // return new DataResponse(result, pid, Parameters.ConsultMode.CurrentData);            
        }



        // public DataResponse DiagnosticCar(BluetoothSocket socket)
        public string DiagnosticCar()
        {
            DataTransferSchema response = null;
            string send = (Convert.ToUInt32(Parameters.ConsultMode.DiagnosticTroubleCodes).ToString("X2"));
            byte[] cmd = Encoding.ASCII.GetBytes(send);
            socket.OutputStream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(100);
            string result = "";
            string data = Read();
            
            if (data != null)
            {
                socket.OutputStream.Flush();
                DataTransferSchema dr = new DataTransferSchema(data, Parameters.ConsultMode.CurrentData);
                List<DiagnosticTroubleCode> list = DiagnosticTroubleCodes(dr);

                foreach (DiagnosticTroubleCode dtc in list)
                {
                    result = result + "\n" + dtc.ToString();
                }
                response = new DataTransferSchema(result, Parameters.ConsultMode.DiagnosticTroubleCodes);
            }
            return result;

        }

        /**
         * Serie de comandos de inicialización
         * */
        /* public  void Initialization(BluetoothSocket socket)
         {

         }*/

        /**
         * Método de lectura de la respuesta del dispositivo BT
         * */







        /**
         * 
         * 
         * 
         * 
         * MÉTODOS DE PROCESAMIENTO DE LOS DATOS
         * 
         * 
         * 
         * 
         * 
         * */

        public void readCalculatedEngineLoad(DataTransferSchema dr)
        {
            string data = dr.Response.Substring(dr.Response.Length - 2);

            double engineLoad = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
            engineLoad = engineLoad * 100 / 255;
            var rowAdded = dataBase.Insert(new CalculatedEngineLoadValuesData()
            {
                CreatedOn = DateTime.Now,
                CalculatedEngineLoadValue = engineLoad

            });
            Console.WriteLine("Velocidad añadida: " + engineLoad + " rowAdded: " + rowAdded);

        }


        public void readEngineCoolantTemperature(DataTransferSchema dr)
        {
            string data = dr.Response.Substring(dr.Response.Length - 2);

            int temperature = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
            temperature = temperature - 40;
            var rowAdded = dataBase.Insert(new EngineTemperatureData()
            {
                CreatedOn = DateTime.Now,
                Temperature = temperature

            });
            Console.WriteLine("Velocidad añadida: " + temperature + " rowAdded: " + rowAdded);

        }

        public void readFuelSystemStatus(DataTransferSchema dr)
        {
            string data = dr.Response.Substring(dr.Response.Length - 4);
            string a = "";
            string b = "";
            for (int i = 0; i < data.Length; i++)
            {
                if (i <= 1)
                {
                    a = a + data.ElementAt(i);
                }
                else
                {
                    b = b + data.ElementAt(i);
                }
            }

            int value1 = Int32.Parse(a, System.Globalization.NumberStyles.HexNumber);
            int value2 = Int32.Parse(b, System.Globalization.NumberStyles.HexNumber);

            var rowAdded = dataBase.Insert(new FuelSystemStatus()
            {
                CreatedOn = DateTime.Now,
                System1 = value1,
                System2=value2

            });
       

        }



        public void readTermFuelTrim(DataTransferSchema dr)
        {
            string data = dr.Response.Substring(dr.Response.Length - 2);

            double value = System.Double.Parse(data, System.Globalization.NumberStyles.HexNumber);
            value = value * 100 / 128 - 100;
            var rowAdded = 0;
            switch (dr.Pid)
            {

                case Parameters.PID.FuelTrim_Bank1_Short:
                    rowAdded = dataBase.Insert(new ShortTermFuelTrimB1()
                    {
                        CreatedOn = DateTime.Now,
                        ShortTermFuelTrimBank1 = value

                    });

                    break;

                case Parameters.PID.FuelTrim_Bank1_Long:

                    rowAdded = dataBase.Insert(new LongTermFuelTrimB1()
                    {
                        CreatedOn = DateTime.Now,
                        LongTermFuelTrimBank1 = value

                    });



                    break;

                case Parameters.PID.FuelTrim_Bank2_Short:
                    rowAdded = dataBase.Insert(new ShortTermFuelTrimB2()
                    {
                        CreatedOn = DateTime.Now,
                        ShortTermFuelTrimBank2 = value

                    });
                    break;

                case Parameters.PID.FuelTrim_Bank2_Long:
                    rowAdded = dataBase.Insert(new LongTermFuelTrimB2()
                    {
                        CreatedOn = DateTime.Now,
                        LongTermFuelTrimBank2 = value

                    });
                    break;

            }
            Console.WriteLine("Velocidad añadida: " + value + " rowAdded: " + rowAdded);

        }

        public void readMAFAirFlowRate(DataTransferSchema dr)
        {
            // throw new NotImplementedException();
            string data = dr.Response.Substring(dr.Response.Length - 4);
            string a = "";
            string b = "";


            for (int i = 0; i < data.Length; i++)
            {
                if (i <= 1)
                {
                    a = a + data.ElementAt(i);
                }
                else
                {
                    b = b + data.ElementAt(i);
                }
            }

            int value1 = Int32.Parse(a, System.Globalization.NumberStyles.HexNumber);
            int value2 = Int32.Parse(b, System.Globalization.NumberStyles.HexNumber);

            double value = (256 * value1 + value2) / 100;

            var rowAdded = dataBase.Insert(new MAFAirFlowRate()
            {
                CreatedOn = DateTime.Now,
                MAFAirFlowRateValue = value

            });
            Console.WriteLine("FuelPressure añadida: " + value + " rowAdded: " + rowAdded);


            //return (dr.Value.Length >= 1) ? Convert.ToUInt32(dr.Value.First()) * 3 : 0;
        }

        public void readFuelPressure(DataTransferSchema dr)
        {
            // throw new NotImplementedException();
            string data = dr.Response.Substring(dr.Response.Length - 2);

            int fuelPressure = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
            fuelPressure = fuelPressure * 3;


            var rowAdded = dataBase.Insert(new FuelPressure()
            {
                CreatedOn = DateTime.Now,
                FuelPressureValue = fuelPressure

            });
            Console.WriteLine("FuelPressure añadida: " + fuelPressure + " rowAdded: " + rowAdded);


            //return (dr.Value.Length >= 1) ? Convert.ToUInt32(dr.Value.First()) * 3 : 0;
        }

        public void readIntakeManifoldAbsolutePressure(DataTransferSchema dr)
        {
            string data = dr.Response.Substring(dr.Response.Length - 2);

            int value = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);

            var rowAdded = dataBase.Insert(new IntakeManifoldAbsolutePressure()
            {
                CreatedOn = DateTime.Now,
                IntakeManifoldAbsolutePressureValue = value

            });
            Console.WriteLine("FuelPressure añadida: " + value + " rowAdded: " + rowAdded);


            //return (dr.Value.Length >= 1) ? Convert.ToUInt32(dr.Value.First()) * 3 : 0;
        }

        public void readRMP(DataTransferSchema dr)
        {
       
            string data = dr.Response.Substring(dr.Response.Length - 4);
            string a = "";
            string b = "";


            for (int i = 0; i < data.Length; i++)
            {
                if (i <= 1)
                {
                    a = a + data.ElementAt(i);
                }
                else
                {
                    b = b + data.ElementAt(i);
                }
            }

            int value1 = Int32.Parse(a, System.Globalization.NumberStyles.HexNumber);
            int value2 = Int32.Parse(b, System.Globalization.NumberStyles.HexNumber);

            int res = (256 * value1 + value2) / 4;

            var rowAdded = dataBase.Insert(new RPMData()
            {
                CreatedOn = DateTime.Now,
                RPM = res

            });
            Console.WriteLine("RMP añadida: " + res + " rowAdded: " + rowAdded);


        }

        public void readSpeed(DataTransferSchema dr)
        {
            // throw new NotImplementedException();
            string data = dr.Response.Substring(dr.Response.Length - 2);

            int numSpeed = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
            var rowAdded = dataBase.Insert(new SpeedData()
            {
                CreatedOn = DateTime.Now,
                Speed = numSpeed

            });
            Console.WriteLine("Velocidad añadida: " + numSpeed + " rowAdded: " + rowAdded);

            // return (dr.Value.Length >= 1) ? Convert.ToUInt32(dr.Value.First()) : 0;
        }

        public void readTimingAdvance(DataTransferSchema dr)
        {
            // throw new NotImplementedException();
            string data = dr.Response.Substring(dr.Response.Length - 2);

            double time = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
            time = time / 2 - 64;


            var rowAdded = dataBase.Insert(new TimingAdvance()
            {
                CreatedOn = DateTime.Now,
                Time = time

            });
            Console.WriteLine("FuelPressure añadida: " + time + " rowAdded: " + rowAdded);


            //return (dr.Value.Length >= 1) ? Convert.ToUInt32(dr.Value.First()) * 3 : 0;
        }

        public void readIntakeAirTemperature(DataTransferSchema dr)
        {
            // throw new NotImplementedException();
            string data = dr.Response.Substring(dr.Response.Length - 2);

            int value = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
            value = value - 40;


            var rowAdded = dataBase.Insert(new TimingAdvance()
            {
                CreatedOn = DateTime.Now,
                Time = value

            });
            Console.WriteLine("FuelPressure añadida: " + value + " rowAdded: " + rowAdded);


            //return (dr.Value.Length >= 1) ? Convert.ToUInt32(dr.Value.First()) * 3 : 0;
        }



        public void readThrottlePosition(DataTransferSchema dr)
        {
            string data = dr.Response.Substring(dr.Response.Length - 2);

            int throttlePosition = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
            double throttlePositionRes = throttlePosition * 100 / 255;


            var rowAdded = dataBase.Insert(new ThrottlePosition()
            {
                CreatedOn = DateTime.Now,
                ThrottlePositionValue = throttlePositionRes

            });
            Console.WriteLine("ThrottlePosition añadida: " + throttlePositionRes + " rowAdded: " + rowAdded);

            // return (dr.Value.Length>=1) ? (Convert.ToUInt32(dr.Value.First()) * 100) / 255 : 0;
        }


        public void readEngineTemperature(DataTransferSchema dr)
        {
            //throw new NotImplementedException();
            string data = dr.Response.Substring(dr.Response.Length - 2);

            int engineTemperature = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
            engineTemperature = engineTemperature - 40;
            var rowAdded = dataBase.Insert(new EngineTemperatureData()
            {
                CreatedOn = DateTime.Now,
                Temperature = engineTemperature

            });
            Console.WriteLine("Temperatura añadida: " + engineTemperature + " rowAdded: " + rowAdded);

            //return (dr.Value.Length >= 1) ? Convert.ToInt32(dr.Value.First()) - 40 : 0;
        }

        public void readEngineStartTime(DataTransferSchema dr)
        {
            string data = dr.Response.Substring(dr.Response.Length - 4);
            string a = "";
            string b = "";


            for (int i = 0; i < data.Length; i++)
            {
                if (i <= 1)
                {
                    a = a + data.ElementAt(i);
                }
                else
                {
                    b = b + data.ElementAt(i);
                }
            }

            int value1 = Int32.Parse(a, System.Globalization.NumberStyles.HexNumber);
            int value2 = Int32.Parse(b, System.Globalization.NumberStyles.HexNumber);

            int value = 256 * value1 + value2;

            var rowAdded = dataBase.Insert(new RunTimeSinceEngineStart
            {
                CreatedOn = DateTime.Now,
                Time = value

            });
            Console.WriteLine("RMP añadida: " + value + " rowAdded: " + rowAdded);

        }

        public void readDistanceWithMILLamp(DataTransferSchema dr)
        {
            string data = dr.Response.Substring(dr.Response.Length - 4);
            string a = "";
            string b = "";


            for (int i = 0; i < data.Length; i++)
            {
                if (i <= 1)
                {
                    a = a + data.ElementAt(i);
                }
                else
                {
                    b = b + data.ElementAt(i);
                }
            }

            int value1 = Int32.Parse(a, System.Globalization.NumberStyles.HexNumber);
            int value2 = Int32.Parse(b, System.Globalization.NumberStyles.HexNumber);

            int value = 256 * value1 + value2;

            var rowAdded = dataBase.Insert(new DistanceTraveledWithMILo()
            {
                CreatedOn = DateTime.Now,
                Distance = value

            });
            Console.WriteLine("RMP añadida: " + value + " rowAdded: " + rowAdded);

        }

        public void readAbsoluteBarometricPressure(DataTransferSchema dr)
        {
            // throw new NotImplementedException();
            string data = dr.Response.Substring(dr.Response.Length - 2);

            int pressure = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
            var rowAdded = dataBase.Insert(new AbsoluteBarometricPressure()
            {
                CreatedOn = DateTime.Now,
                BarometricPressure = pressure

            });
            Console.WriteLine("Presión Barométrica añadida: " + pressure + " rowAdded: " + rowAdded);

            // return (dr.Value.Length >= 1) ? Convert.ToUInt32(dr.Value.First()) : 0;
        }



        public void readOxygenSensor(DataTransferSchema dr)
        {

            string data = dr.Response.Substring(dr.Response.Length - 4);
            string a = "";
            string b = "";


            for (int i = 0; i < data.Length; i++)
            {
                if (i <= 1)
                {
                    a = a + data.ElementAt(i);
                }
                else
                {
                    b = b + data.ElementAt(i);
                }
            }

            double value1 = Int32.Parse(a, System.Globalization.NumberStyles.HexNumber);
            double value2 = Int32.Parse(b, System.Globalization.NumberStyles.HexNumber);

            value1 = value1 / 200;
            value2 = value2 * 100 / 128 - 100;

            var rowAdded = 0;
            switch (dr.Pid)
            {

                case Parameters.PID.OxygenSensor1:

                    rowAdded = dataBase.Insert(new OxygenSensor1()
                    {
                        CreatedOn = DateTime.Now,
                        Voltage = value1,
                        ShortTermFuelTrim = value2

                    });
                    Console.WriteLine("RMP añadida: " + value1 + " rowAdded: " + rowAdded);
                    break;

                case Parameters.PID.OxygenSensor2:

                    rowAdded = dataBase.Insert(new OxygenSensor2()
                    {
                        CreatedOn = DateTime.Now,
                        Voltage = value1,
                        ShortTermFuelTrim = value2

                    });
                    Console.WriteLine("RMP añadida: " + value1 + " rowAdded: " + rowAdded);
                    break;

                case Parameters.PID.OxygenSensor3:

                    rowAdded = dataBase.Insert(new OxygenSensor3()
                    {
                        CreatedOn = DateTime.Now,
                        Voltage = value1,
                        ShortTermFuelTrim = value2

                    });
                    Console.WriteLine("RMP añadida: " + value1 + " rowAdded: " + rowAdded);
                    break;

                case Parameters.PID.OxygenSensor4:

                    rowAdded = dataBase.Insert(new OxygenSensor4()
                    {
                        CreatedOn = DateTime.Now,
                        Voltage = value1,
                        ShortTermFuelTrim = value2

                    });
                    Console.WriteLine("RMP añadida: " + value1 + " rowAdded: " + rowAdded);
                    break;

                case Parameters.PID.OxygenSensor5:

                    rowAdded = dataBase.Insert(new OxygenSensor5()
                    {
                        CreatedOn = DateTime.Now,
                        Voltage = value1,
                        ShortTermFuelTrim = value2

                    });
                    Console.WriteLine("RMP añadida: " + value1 + " rowAdded: " + rowAdded);
                    break;

                case Parameters.PID.OxygenSensor6:

                    rowAdded = dataBase.Insert(new OxygenSensor6()
                    {
                        CreatedOn = DateTime.Now,
                        Voltage = value1,
                        ShortTermFuelTrim = value2

                    });
                    Console.WriteLine("RMP añadida: " + value1 + " rowAdded: " + rowAdded);
                    break;

                case Parameters.PID.OxygenSensor7:

                    rowAdded = dataBase.Insert(new OxygenSensor7()
                    {
                        CreatedOn = DateTime.Now,
                        Voltage = value1,
                        ShortTermFuelTrim = value2

                    });
                    Console.WriteLine("RMP añadida: " + value1 + " rowAdded: " + rowAdded);
                    break;

                case Parameters.PID.OxygenSensor8:

                    rowAdded = dataBase.Insert(new OxygenSensor8()
                    {
                        CreatedOn = DateTime.Now,
                        Voltage = value1,
                        ShortTermFuelTrim = value2

                    });
                    Console.WriteLine("RMP añadida: " + value1 + " rowAdded: " + rowAdded);
                    break;
            }


        }


        public void readFuelRailPressure(DataTransferSchema dr)
        {
            string data = dr.Response.Substring(dr.Response.Length - 4);
            string a = "";
            string b = "";


            for (int i = 0; i < data.Length; i++)
            {
                if (i <= 1)
                {
                    a = a + data.ElementAt(i);
                }
                else
                {
                    b = b + data.ElementAt(i);
                }
            }

            int value1 = Int32.Parse(a, System.Globalization.NumberStyles.HexNumber);
            int value2 = Int32.Parse(b, System.Globalization.NumberStyles.HexNumber);

            double value = 0.079 * (256 * value1 + value2);

            var rowAdded = dataBase.Insert(new FuelRailPressure()
            {
                CreatedOn = DateTime.Now,
                Pressure = value

            });
            Console.WriteLine("RMP añadida: " + value + " rowAdded: " + rowAdded);

        }

        public void readFuelRailGaugePressure(DataTransferSchema dr)
        {
            string data = dr.Response.Substring(dr.Response.Length - 4);
            string a = "";
            string b = "";


            for (int i = 0; i < data.Length; i++)
            {
                if (i <= 1)
                {
                    a = a + data.ElementAt(i);
                }
                else
                {
                    b = b + data.ElementAt(i);
                }
            }

            int value1 = Int32.Parse(a, System.Globalization.NumberStyles.HexNumber);
            int value2 = Int32.Parse(b, System.Globalization.NumberStyles.HexNumber);

            int value = 10 * (256 * value1 + value2);

            var rowAdded = dataBase.Insert(new FuelRailGaugePressure()
            {
                CreatedOn = DateTime.Now,
                Pressure = value

            });
            Console.WriteLine("RMP añadida: " + value + " rowAdded: " + rowAdded);

        }

        public void readOxygenSensorB(DataTransferSchema dr)
        {

            string data = dr.Response.Substring(dr.Response.Length - 8);
            string a = "";
            string b = "";
            string c = "";
            string d = "";


            for (int i = 0; i < data.Length; i++)
            {
                if (i <= 1)
                {
                    a = a + data.ElementAt(i);
                }
                else if (i <= 3)
                {
                    b = b + data.ElementAt(i);
                }
                else if (i <= 5)
                {
                    c = c + data.ElementAt(i);
                }
                else
                {
                    d = d + data.ElementAt(i);
                }
            }

            double value1 = Int32.Parse(a, System.Globalization.NumberStyles.HexNumber);
            double value2 = Int32.Parse(b, System.Globalization.NumberStyles.HexNumber);
            double value3 = Int32.Parse(c, System.Globalization.NumberStyles.HexNumber);
            double value4 = Int32.Parse(d, System.Globalization.NumberStyles.HexNumber);
            value1 = 2 / 65536 * (256 * value1 + value2);
            value3 = 8 / 65536 * (256 * value3 + value4);

            var rowAdded = 0;
            switch (dr.Pid)
            {

                case Parameters.PID.OxygenSensor1b:

                    rowAdded = dataBase.Insert(new OxygenSensor1B()
                    {
                        CreatedOn = DateTime.Now,
                        Fuel_AirEquivalenceRatio = value1,
                        Voltage = value3

                    });
                    Console.WriteLine("RMP añadida: " + value1 + " rowAdded: " + rowAdded);
                    break;

                case Parameters.PID.OxygenSensor2b:

                    rowAdded = dataBase.Insert(new OxygenSensor2B()
                    {
                        CreatedOn = DateTime.Now,
                        Fuel_AirEquivalenceRatio = value1,
                        Voltage = value3

                    });
                    Console.WriteLine("RMP añadida: " + value1 + " rowAdded: " + rowAdded);
                    break;

                case Parameters.PID.OxygenSensor3b:

                    rowAdded = dataBase.Insert(new OxygenSensor3B()
                    {
                        CreatedOn = DateTime.Now,
                        Fuel_AirEquivalenceRatio = value1,
                        Voltage = value3
                    });
                    Console.WriteLine("RMP añadida: " + value1 + " rowAdded: " + rowAdded);
                    break;

                case Parameters.PID.OxygenSensor4b:

                    rowAdded = dataBase.Insert(new OxygenSensor4B()
                    {
                        CreatedOn = DateTime.Now,
                        Fuel_AirEquivalenceRatio = value1,
                        Voltage = value3

                    });
                    Console.WriteLine("RMP añadida: " + value1 + " rowAdded: " + rowAdded);
                    break;

                case Parameters.PID.OxygenSensor5b:

                    rowAdded = dataBase.Insert(new OxygenSensor5B()
                    {
                        CreatedOn = DateTime.Now,
                        Fuel_AirEquivalenceRatio = value1,
                        Voltage = value3

                    });
                    Console.WriteLine("RMP añadida: " + value1 + " rowAdded: " + rowAdded);
                    break;

                case Parameters.PID.OxygenSensor6b:

                    rowAdded = dataBase.Insert(new OxygenSensor6B()
                    {
                        CreatedOn = DateTime.Now,
                        Fuel_AirEquivalenceRatio = value1,
                        Voltage = value3

                    });
                    Console.WriteLine("RMP añadida: " + value1 + " rowAdded: " + rowAdded);
                    break;

                case Parameters.PID.OxygenSensor7b:

                    rowAdded = dataBase.Insert(new OxygenSensor7B()
                    {
                        CreatedOn = DateTime.Now,
                        Fuel_AirEquivalenceRatio = value1,
                        Voltage = value3

                    });
                    Console.WriteLine("RMP añadida: " + value1 + " rowAdded: " + rowAdded);
                    break;

                case Parameters.PID.OxygenSensor8b:

                    rowAdded = dataBase.Insert(new OxygenSensor8B()
                    {
                        CreatedOn = DateTime.Now,
                        Fuel_AirEquivalenceRatio = value1,
                        Voltage = value3

                    });
                    Console.WriteLine("RMP añadida: " + value1 + " rowAdded: " + rowAdded);
                    break;
            }


        }

        public void readCommandedEGR(DataTransferSchema dr)
        {
            string data = dr.Response.Substring(dr.Response.Length - 2);

            double value = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
            value = 100 * value / 128 - 100;
            var rowAdded = dataBase.Insert(new CommandedEGR()
            {
                CreatedOn = DateTime.Now,
                ValueEGR = value

            });
            Console.WriteLine("EngineLoad añadida: " + value + " rowAdded: " + rowAdded);

        }

        public void readEGRError(DataTransferSchema dr)
        {
            string data = dr.Response.Substring(dr.Response.Length - 2);

            double value = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
            value = 100 * value / 128 - 100;
            var rowAdded = dataBase.Insert(new EGRError()
            {
                CreatedOn = DateTime.Now,
                ValueEGR = value

            });
            Console.WriteLine("EngineLoad añadida: " + value + " rowAdded: " + rowAdded);

        }

        public void readCommandedEvaporativePurge(DataTransferSchema dr)
        {
            string data = dr.Response.Substring(dr.Response.Length - 2);

            double value = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
            value = 100 * value / 128 - 100;
            var rowAdded = dataBase.Insert(new CommandedEvaporativePurge()
            {
                CreatedOn = DateTime.Now,
                Value = value

            });
            Console.WriteLine("EngineLoad añadida: " + value + " rowAdded: " + rowAdded);

        }

        public void readFuelTankLevelInput(DataTransferSchema dr)
        {
            string data = dr.Response.Substring(dr.Response.Length - 2);

            double value = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
            value = 100 * value / 128 - 100;
            var rowAdded = dataBase.Insert(new FuelTankLevel()
            {
                CreatedOn = DateTime.Now,
                FuelTankLevelValue = value

            });
            Console.WriteLine("EngineLoad añadida: " + value + " rowAdded: " + rowAdded);

        }

        public void readOxygenSensorC(DataTransferSchema dr)
        {

            string data = dr.Response.Substring(dr.Response.Length - 8);
            string a = "";
            string b = "";
            string c = "";
            string d = "";


            for (int i = 0; i < data.Length; i++)
            {
                if (i <= 1)
                {
                    a = a + data.ElementAt(i);
                }
                else if (i <= 3)
                {
                    b = b + data.ElementAt(i);
                }
                else if (i <= 5)
                {
                    c = c + data.ElementAt(i);
                }
                else
                {
                    d = d + data.ElementAt(i);
                }
            }

            double value1 = Int32.Parse(a, System.Globalization.NumberStyles.HexNumber);
            double value2 = Int32.Parse(b, System.Globalization.NumberStyles.HexNumber);
            double value3 = Int32.Parse(c, System.Globalization.NumberStyles.HexNumber);
            double value4 = Int32.Parse(d, System.Globalization.NumberStyles.HexNumber);
            value1 = 2 / 65536 * (256 * value1 + value2);
            value3 = value3 + value4 / 256 - 128;

            var rowAdded = 0;
            switch (dr.Pid)
            {

                case Parameters.PID.OxygenSensor1c:

                    rowAdded = dataBase.Insert(new OxygenSensor1C()
                    {
                        CreatedOn = DateTime.Now,
                        Fuel_AirEquivalenceRatio = value1,
                        Current = value3

                    });
                    Console.WriteLine("RMP añadida: " + value1 + " rowAdded: " + rowAdded);
                    break;

                case Parameters.PID.OxygenSensor2c:

                    rowAdded = dataBase.Insert(new OxygenSensor2C()
                    {
                        CreatedOn = DateTime.Now,
                        Fuel_airEquivalenceRatio = value1,
                        Current = value3

                    });
                    Console.WriteLine("RMP añadida: " + value1 + " rowAdded: " + rowAdded);
                    break;

                case Parameters.PID.OxygenSensor3c:

                    rowAdded = dataBase.Insert(new OxygenSensor3C()
                    {
                        CreatedOn = DateTime.Now,
                        Fuel_airEquivalenceRatio = value1,
                        Current = value3
                    });
                    Console.WriteLine("RMP añadida: " + value1 + " rowAdded: " + rowAdded);
                    break;

                case Parameters.PID.OxygenSensor4c:

                    rowAdded = dataBase.Insert(new OxygenSensor4C()
                    {
                        CreatedOn = DateTime.Now,
                        Fuel_airEquivalenceRatio = value1,
                        Current = value3

                    });
                    Console.WriteLine("RMP añadida: " + value1 + " rowAdded: " + rowAdded);
                    break;

                case Parameters.PID.OxygenSensor5c:

                    rowAdded = dataBase.Insert(new OxygenSensor5C()
                    {
                        CreatedOn = DateTime.Now,
                        Fuel_airEquivalenceRatio = value1,
                        Current = value3

                    });
                    Console.WriteLine("RMP añadida: " + value1 + " rowAdded: " + rowAdded);
                    break;

                case Parameters.PID.OxygenSensor6c:

                    rowAdded = dataBase.Insert(new OxygenSensor6C()
                    {
                        CreatedOn = DateTime.Now,
                        Fuel_airEquivalenceRatio = value1,
                        Current = value3

                    });
                    Console.WriteLine("RMP añadida: " + value1 + " rowAdded: " + rowAdded);
                    break;

                case Parameters.PID.OxygenSensor7c:

                    rowAdded = dataBase.Insert(new OxygenSensor7C()
                    {
                        CreatedOn = DateTime.Now,
                        Fuel_airEquivalenceRatio = value1,
                        Current = value3

                    });
                    Console.WriteLine("RMP añadida: " + value1 + " rowAdded: " + rowAdded);
                    break;

                case Parameters.PID.OxygenSensor8c:

                    rowAdded = dataBase.Insert(new OxygenSensor8C()
                    {
                        CreatedOn = DateTime.Now,
                        Fuel_airEquivalenceRatio = value1,
                        Current = value3

                    });
                    Console.WriteLine("RMP añadida: " + value1 + " rowAdded: " + rowAdded);
                    break;
            }


        }

        public void readCatalystTemperature(DataTransferSchema dr)
        {

            string data = dr.Response.Substring(dr.Response.Length - 4);
            string a = "";
            string b = "";


            for (int i = 0; i < data.Length; i++)
            {
                if (i <= 1)
                {
                    a = a + data.ElementAt(i);
                }
                else
                {
                    b = b + data.ElementAt(i);
                }
            }

            int numA = Int32.Parse(a, System.Globalization.NumberStyles.HexNumber);
            int numB = Int32.Parse(b, System.Globalization.NumberStyles.HexNumber);

            double res = ((256 * numA + numB) / 10) - 40;
            var rowAdded = 0;
            switch (dr.Pid)
            {
                case Parameters.PID.CatalystTemperature_Bank1_Sensor1:
                    rowAdded = dataBase.Insert(new CatalystTemperatureB1S1()
                    {
                        CreatedOn = DateTime.Now,
                        Temperature = res

                    });
                    break;

                case Parameters.PID.CatalystTemperature_Bank1_Sensor2:
                    rowAdded = dataBase.Insert(new CatalystTemperatureB1S2()
                    {
                        CreatedOn = DateTime.Now,
                        Temperature = res

                    });
                    break;

                case Parameters.PID.CatalystTemperature_Bank2_Sensor1:
                    rowAdded = dataBase.Insert(new CatalystTemperatureB2S1()
                    {
                        CreatedOn = DateTime.Now,
                        Temperature = res

                    });
                    break;

                case Parameters.PID.CatalystTemperature_Bank2_Sensor2:
                    rowAdded = dataBase.Insert(new CatalystTemperatureB2S2()
                    {
                        CreatedOn = DateTime.Now,
                        Temperature = res

                    });
                    break;

            }




        }

        public void readControlModuleVoltage(DataTransferSchema dr)
        {
            string data = dr.Response.Substring(dr.Response.Length - 4);
            string a = "";
            string b = "";


            for (int i = 0; i < data.Length; i++)
            {
                if (i <= 1)
                {
                    a = a + data.ElementAt(i);
                }
                else
                {
                    b = b + data.ElementAt(i);
                }
            }

            int value1 = Int32.Parse(a, System.Globalization.NumberStyles.HexNumber);
            int value2 = Int32.Parse(b, System.Globalization.NumberStyles.HexNumber);

            double value = (256 * value1 + value2) / 1000;

            var rowAdded = dataBase.Insert(new ControlModuleVoltage()
            {
                CreatedOn = DateTime.Now,
                Voltage = value

            });
            Console.WriteLine("RMP añadida: " + value + " rowAdded: " + rowAdded);

        }

        public void readAbsoluteLoadValue(DataTransferSchema dr)
        {
            string data = dr.Response.Substring(dr.Response.Length - 4);
            string a = "";
            string b = "";


            for (int i = 0; i < data.Length; i++)
            {
                if (i <= 1)
                {
                    a = a + data.ElementAt(i);
                }
                else
                {
                    b = b + data.ElementAt(i);
                }
            }

            int value1 = Int32.Parse(a, System.Globalization.NumberStyles.HexNumber);
            int value2 = Int32.Parse(b, System.Globalization.NumberStyles.HexNumber);

            double value = (100 / 255) * (256 * value1 + value2);

            var rowAdded = dataBase.Insert(new AbsoluteLoadValue()
            {
                CreatedOn = DateTime.Now,
                Value = value

            });
            Console.WriteLine("RMP añadida: " + value + " rowAdded: " + rowAdded);

        }

        public void readFuelAirCommandedEquivalenceRatio(DataTransferSchema dr)
        {
            string data = dr.Response.Substring(dr.Response.Length - 4);
            string a = "";
            string b = "";


            for (int i = 0; i < data.Length; i++)
            {
                if (i <= 1)
                {
                    a = a + data.ElementAt(i);
                }
                else
                {
                    b = b + data.ElementAt(i);
                }
            }

            int value1 = Int32.Parse(a, System.Globalization.NumberStyles.HexNumber);
            int value2 = Int32.Parse(b, System.Globalization.NumberStyles.HexNumber);

            double value = (2 / 65536) * (256 * value1 + value2);

            var rowAdded = dataBase.Insert(new FuelAirCommandedEquivalenceRatio()
            {
                CreatedOn = DateTime.Now,
                Ratio = value

            });
            Console.WriteLine("RMP añadida: " + value + " rowAdded: " + rowAdded);

        }

        public void readRelativeThrottlePosition(DataTransferSchema dr)
        {
            string data = dr.Response.Substring(dr.Response.Length - 2);

            double value = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
            value = value * 100 / 255;
            var rowAdded = dataBase.Insert(new RelativeThrottlePosition()
            {
                CreatedOn = DateTime.Now,
                ThrottlePosition = value

            });
            Console.WriteLine("Velocidad añadida: " + value + " rowAdded: " + rowAdded);

        }

        public void readAmbientTemperatureAir(DataTransferSchema dr)
        {
            string data = dr.Response.Substring(dr.Response.Length - 2);

            int value = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
            value = value - 40;
            var rowAdded = dataBase.Insert(new AmbientAirTemperature()
            {
                CreatedOn = DateTime.Now,
                Temperature = value

            });
            Console.WriteLine("Velocidad añadida: " + value + " rowAdded: " + rowAdded);

        }

        public void readAbsoluteThrottlePosition(DataTransferSchema dr)
        {
            string data = dr.Response.Substring(dr.Response.Length - 2);

            double value = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
            value = 100 * value / 255;
            var rowAdded = 0;
            switch (dr.Pid)
            {
                case Parameters.PID.AbsoluteThrottlePositionB:
                    rowAdded = dataBase.Insert(new AbsoluteThrottlePositionB()
                    {
                        CreatedOn = DateTime.Now,
                        ThrottlePositionB = value

                    });
                    break;
                case Parameters.PID.AbsoluteThrottlePositionC:
                    rowAdded = dataBase.Insert(new AbsoluteThrottlePositionC()
                    {
                        CreatedOn = DateTime.Now,
                        ThrottlePositionC = value

                    });
                    break;
                case Parameters.PID.AbsoluteThrottlePositionD:
                    rowAdded = dataBase.Insert(new AbsoluteThrottlePositionD()
                    {
                        CreatedOn = DateTime.Now,
                        ThrottlePositionD = value

                    });
                    break;
                case Parameters.PID.AbsoluteThrottlePositionE:
                    rowAdded = dataBase.Insert(new AbsoluteThrottlePositionE()
                    {
                        CreatedOn = DateTime.Now,
                        ThrottlePositionE = value

                    });
                    break;
                case Parameters.PID.AbsoluteThrottlePositionF:
                    rowAdded = dataBase.Insert(new AbsoluteThrottlePositionF()
                    {
                        CreatedOn = DateTime.Now,
                        ThrottlePositionF = value

                    });
                    break;

            }

        }

        public void readCommandedThrottleActuator(DataTransferSchema dr)
        {
            string data = dr.Response.Substring(dr.Response.Length - 2);

            double value = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
            value = 100 * value / 255;
            var rowAdded = dataBase.Insert(new CommandedThrottleActuator()
            {
                CreatedOn = DateTime.Now,
                CommandedThrottleActuatorValue = value

            });
        }

        public void readTimeEventTroubleCodes(DataTransferSchema dr)
        {
            string data = dr.Response.Substring(dr.Response.Length - 4);
            string a = "";
            string b = "";


            for (int i = 0; i < data.Length; i++)
            {
                if (i <= 1)
                {
                    a = a + data.ElementAt(i);
                }
                else
                {
                    b = b + data.ElementAt(i);
                }
            }

            int value1 = Int32.Parse(a, System.Globalization.NumberStyles.HexNumber);
            int value2 = Int32.Parse(b, System.Globalization.NumberStyles.HexNumber);

            int value = 256 * value1 + value2;

            var rowAdded = 0;
            switch (dr.Pid)
            {
                case Parameters.PID.TimeRunWithMILOn:

                    rowAdded = dataBase.Insert(new TimeRunWithMILOn()
                    {
                        CreatedOn = DateTime.Now,
                        Time = value

                    });
                    break;

                case Parameters.PID.TimeSinceTroubleCodesCleared:
                    rowAdded = dataBase.Insert(new TimeSinceTroubleCodesCleared()
                    {
                        CreatedOn = DateTime.Now,
                        Time = value

                    });
                    break;


            }

        }

        public void readFuelAirEquivalence_OxygenVoltage_OxygenSensorCurrent_IntakeManifoldPressure(DataTransferSchema dr)
        {
            string data = dr.Response.Substring(dr.Response.Length - 8);
            string a = "";
            string b = "";
            string c = "";
            string d = "";


            for (int i = 0; i < data.Length; i++)
            {
                if (i <= 1)
                {
                    a = a + data.ElementAt(i);
                }
                else if (i <= 3)
                {
                    b = b + data.ElementAt(i);
                }
                else if (i <= 5)
                {
                    c = c + data.ElementAt(i);
                }
                else if (i <= 7)
                {
                    d = d + data.ElementAt(i);
                }
            }

            int value1 = Int32.Parse(a, System.Globalization.NumberStyles.HexNumber);
            int value2 = Int32.Parse(b, System.Globalization.NumberStyles.HexNumber);
            int value3 = Int32.Parse(c, System.Globalization.NumberStyles.HexNumber);
            int value4 = Int32.Parse(d, System.Globalization.NumberStyles.HexNumber);
            value4 = value4 * 10;

            var rowAdded = dataBase.Insert(new FuelAirEquivalence_OxygenVoltage_OxygenSensorCurrent_IntakeManifoldAbsolutePressure()
            {
                CreatedOn = DateTime.Now,
                MaximunValue_Fuel_Air_EquivalenceRatio = value1,
                OxygenSensorVoltage = value2,
                OxygenSensorCurrent = value3,
                IntakeManifoldAbsolutePressure = value4


            });



        }

        public void readMaximunValueFlowRateFromMassAirFlowSensor(DataTransferSchema dr)
        {
            string data = dr.Response.Substring(dr.Response.Length - 8);
            string a = "";
            string b = "";
            string c = "";
            string d = "";


            for (int i = 0; i < data.Length; i++)
            {
                if (i <= 1)
                {
                    a = a + data.ElementAt(i);
                }
                else if (i <= 3)
                {
                    b = b + data.ElementAt(i);
                }
                else if (i <= 5)
                {
                    c = c + data.ElementAt(i);
                }
                else if (i <= 7)
                {
                    d = d + data.ElementAt(i);
                }
            }

            int value1 = Int32.Parse(a, System.Globalization.NumberStyles.HexNumber);
            int value2 = Int32.Parse(b, System.Globalization.NumberStyles.HexNumber);
            int value3 = Int32.Parse(c, System.Globalization.NumberStyles.HexNumber);
            int value4 = Int32.Parse(d, System.Globalization.NumberStyles.HexNumber);
            value1 = value1 * 10;

            var rowAdded = dataBase.Insert(new MaximunValueAirFlowRateFromMassAirFlowSensor()
            {
                CreatedOn = DateTime.Now,
                MaximunValueA = value1,
                MaximunValueB = value2,
                MaximunValueC = value3,
                MaximunValueD = value4


            });
        }

        public void readFuelType(DataTransferSchema dr)
        {
            string data = dr.Response.Substring(dr.Response.Length - 2);
            int value = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
            string type = "";
            switch (value)
            {
                case 0:
                    type = "Not available";
                    break;
                case 1:
                    type = "Gasoline";
                    break;
                case 2:
                    type = "Methanol";
                    break;
                case 3:
                    type = "Ethanol";
                    break;
                case 4:
                    type = "Diesel";
                    break;
                case 5:
                    type = "LPG";
                    break;
                case 6:
                    type = "CNG";
                    break;
                case 7:
                    type = "Propane";
                    break;
                case 8:
                    type = "Electric";
                    break;
                case 9:
                    type = "Bifuel running Gasoline";
                    break;
                case 10:
                    type = "Bifuel running Methanol";
                    break;
                case 11:
                    type = "Bifuel running Ethanol";
                    break;
                case 12:
                    type = "Bifuel running LPG";
                    break;
                case 13:
                    type = "Bifuel running CNG";
                    break;
                case 14:
                    type = "Bifuel running Propane";
                    break;
                case 15:
                    type = "Bifuel running Electricity";
                    break;
                case 16:
                    type = "Bifuel running electric and combustion engine";
                    break;
                case 17:
                    type = "Hybrid Gasoline";
                    break;
                case 18:
                    type = "Hybrid Ethanol";
                    break;
                case 19:
                    type = "Hybrid Gasoline";
                    break;
                case 20:
                    type = "Hybrid Electric";
                    break;
                case 21:
                    type = "Hybrid running enectric and combustion engine";
                    break;
                case 22:
                    type = "Hybrid Regenerative";
                    break;
                case 23:
                    type = "Bifuel running diesel";
                    break;

            }
            var rowAdded = dataBase.Insert(new FuelType()
            {
                CreatedOn = DateTime.Now,
                FuelTypeValue = type



            });

        }


        public void readEthanolPercentage(DataTransferSchema dr)
        {

            string data = dr.Response.Substring(dr.Response.Length - 2);
            double value = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
            value = value * 100 / 255;
            var rowAdded = dataBase.Insert(new EthanolFuelPercentage()
            {
                CreatedOn = DateTime.Now,
                Percentage = value



            });


        }

        public void readAbsoluteEvapSystemVaporPressure(DataTransferSchema dr)
        {

            string data = dr.Response.Substring(dr.Response.Length - 4);
            string a = "";
            string b = "";



            for (int i = 0; i < data.Length; i++)
            {
                if (i <= 1)
                {
                    a = a + data.ElementAt(i);
                }
                else if (i <= 3)
                {
                    b = b + data.ElementAt(i);
                }
            }


            int value1 = Int32.Parse(a, System.Globalization.NumberStyles.HexNumber);
            int value2 = Int32.Parse(b, System.Globalization.NumberStyles.HexNumber);
            double value = (256 * value1 + value2) / 200;
            var rowAdded = dataBase.Insert(new AbsoluteEvapSystemVaporPressure()
            {
                CreatedOn = DateTime.Now,
                Pressure = value



            });


        }

        public void readEvapSystemVaporPressure(DataTransferSchema dr)
        {
            string data = dr.Response.Substring(dr.Response.Length - 4);
            string a = "";
            string b = "";



            for (int i = 0; i < data.Length; i++)
            {
                if (i <= 1)
                {
                    a = a + data.ElementAt(i);
                }
                else if (i <= 3)
                {
                    b = b + data.ElementAt(i);
                }
            }


            int value1 = Int32.Parse(a, System.Globalization.NumberStyles.HexNumber);
            int value2 = Int32.Parse(b, System.Globalization.NumberStyles.HexNumber);
            int value = (256 * value1 + value2) - 32767;
            var rowAdded = dataBase.Insert(new EvapSystemVaporPressure()
            {
                CreatedOn = DateTime.Now,
                EvapSystemVaporPressureValue = value



            });
        }

        public void readSecondaryOxygenSensorTrim(DataTransferSchema dr)
        {
            string data = dr.Response.Substring(dr.Response.Length - 4);
            string a = "";
            string b = "";



            for (int i = 0; i < data.Length; i++)
            {
                if (i <= 1)
                {
                    a = a + data.ElementAt(i);
                }
                else if (i <= 3)
                {
                    b = b + data.ElementAt(i);
                }
            }


            double value1 = Int32.Parse(a, System.Globalization.NumberStyles.HexNumber);
            double value2 = Int32.Parse(b, System.Globalization.NumberStyles.HexNumber);
            value1 = value1 * 100 / 128 - 100;
            value2 = value2 * 100 / 128 - 100;
            var rowAdded = 0;
            switch (dr.Pid)
            {
                case Parameters.PID.ShortTermSecondaryOxygenSensorTrim1_3:
                    rowAdded = dataBase.Insert(new ShortTermSecondaryOxygenSensorTrim1_3()
                    {
                        CreatedOn = DateTime.Now,
                        valueBankA = value1,
                        valueBankB = value2

                    });

                    break;

                case Parameters.PID.LongTermSecondaryOxygenSensorTrim1_3:
                    rowAdded = dataBase.Insert(new LongTermSecondaryOxygenSensorTrim1_3()
                    {
                        CreatedOn = DateTime.Now,
                        ValueBankA = value1,
                        ValueBankB = value2

                    });

                    break;

                case Parameters.PID.ShortTermSecondaryOxygenSensorTrim2_4:
                    rowAdded = dataBase.Insert(new ShortTermSecondaryOxygenSensorTrim2_4()
                    {
                        CreatedOn = DateTime.Now,
                        valueBankA = value1,
                        valueBankB = value2

                    });
                    break;

                case Parameters.PID.LongTermSecondaryOxygenSensorTrim2_4:
                    rowAdded = dataBase.Insert(new LongTermSecondaryOxygenSensorTrim2_4()
                    {
                        CreatedOn = DateTime.Now,
                        ValueBankA = value1,
                        ValueBankB = value2

                    });
                    break;

            }

        }

        public void readFuelRailAbsolutePressure(DataTransferSchema dr)
        {
            string data = dr.Response.Substring(dr.Response.Length - 4);
            string a = "";
            string b = "";



            for (int i = 0; i < data.Length; i++)
            {
                if (i <= 1)
                {
                    a = a + data.ElementAt(i);
                }
                else if (i <= 3)
                {
                    b = b + data.ElementAt(i);
                }
            }


            int value1 = Int32.Parse(a, System.Globalization.NumberStyles.HexNumber);
            int value2 = Int32.Parse(b, System.Globalization.NumberStyles.HexNumber);
            double value = 10 * (256 * value1 + value2);
            var rowAdded = dataBase.Insert(new FuelRailAbsolutePressure()
            {
                CreatedOn = DateTime.Now,
                Pressure = value

            });


        }

        public void readRelativeAcceleratorPosition(DataTransferSchema dr)
        {
            string data = dr.Response.Substring(dr.Response.Length - 2);
            double value = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
            value = value * 100 / 255;
            var rowAdded = dataBase.Insert(new RelativeAcceleratorPedalPosition()
            {
                CreatedOn = DateTime.Now,
                Position = value



            });
        }

        public void readHybridBatteryPackRemainingLife(DataTransferSchema dr)
        {
            string data = dr.Response.Substring(dr.Response.Length - 2);
            double value = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
            value = value * 100 / 255;
            var rowAdded = dataBase.Insert(new HybridBateryPackRemainingLife()
            {
                CreatedOn = DateTime.Now,
                RemainingLife = value



            });
        }

        public void readEngineOilTemperature(DataTransferSchema dr)
        {
            string data = dr.Response.Substring(dr.Response.Length - 2);
            int value = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
            value = value - 40;
            var rowAdded = dataBase.Insert(new EngineOilTemperature()
            {
                CreatedOn = DateTime.Now,
                Temperature = value



            });
        }

        public void readFuelInjectionTiming(DataTransferSchema dr)
        {
            string data = dr.Response.Substring(dr.Response.Length - 4);
            string a = "";
            string b = "";



            for (int i = 0; i < data.Length; i++)
            {
                if (i <= 1)
                {
                    a = a + data.ElementAt(i);
                }
                else if (i <= 3)
                {
                    b = b + data.ElementAt(i);
                }
            }


            int value1 = Int32.Parse(a, System.Globalization.NumberStyles.HexNumber);
            int value2 = Int32.Parse(b, System.Globalization.NumberStyles.HexNumber);
            double value = (256 * value1 + value2) / 128 - 210;
            var rowAdded = dataBase.Insert(new FuelInjectionTiming()
            {
                CreatedOn = DateTime.Now,
                FuelInjectionTimingValue = value

            });

        }
        public void readEngineFuelRate(DataTransferSchema dr)
        {
            string data = dr.Response.Substring(dr.Response.Length - 4);
            string a = "";
            string b = "";



            for (int i = 0; i < data.Length; i++)
            {
                if (i <= 1)
                {
                    a = a + data.ElementAt(i);
                }
                else if (i <= 3)
                {
                    b = b + data.ElementAt(i);
                }
            }


            int value1 = Int32.Parse(a, System.Globalization.NumberStyles.HexNumber);
            int value2 = Int32.Parse(b, System.Globalization.NumberStyles.HexNumber);
            double value = (256 * value1 + value2) / 20;
            var rowAdded = dataBase.Insert(new EngineFuelRate()
            {
                CreatedOn = DateTime.Now,
                EngineFuelRateValue = value

            });

        }

        public void readDriverDemandEngine_PercentTorque(DataTransferSchema dr)
        {
            string data = dr.Response.Substring(dr.Response.Length - 2);

            int value = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);

            value = value - 125;
            var rowAdded = dataBase.Insert(new DriverDemandEngine_PercentTorque()
            {
                CreatedOn = DateTime.Now,
                Percentage = value

            });

        }

        public void readActualEngine_PercentTorque(DataTransferSchema dr)
        {
            string data = dr.Response.Substring(dr.Response.Length - 2);

            int value = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);

            value = value - 125;
            var rowAdded = dataBase.Insert(new ActualEngine_PercentTorque()
            {
                CreatedOn = DateTime.Now,
                PercentageTorque = value

            });

        }

        public void readEngineReferenceTorque(DataTransferSchema dr)
        {
            string data = dr.Response.Substring(dr.Response.Length - 4);
            string a = "";
            string b = "";



            for (int i = 0; i < data.Length; i++)
            {
                if (i <= 1)
                {
                    a = a + data.ElementAt(i);
                }
                else if (i <= 3)
                {
                    b = b + data.ElementAt(i);
                }
            }


            int value1 = Int32.Parse(a, System.Globalization.NumberStyles.HexNumber);
            int value2 = Int32.Parse(b, System.Globalization.NumberStyles.HexNumber);
            int value = 256 * value1 + value2;
            var rowAdded = dataBase.Insert(new EngineReferenceTorque()
            {
                CreatedOn = DateTime.Now,
                ReferenceTorque = value

            });

        }

        public void readEnginePercentTorqueData(DataTransferSchema dr)
        {
            string data = dr.Response.Substring(dr.Response.Length - 10);
            string a = "";
            string b = "";
            string c = "";
            string d = "";
            string e = "";

            for (int i = 0; i < data.Length; i++)
            {
                if (i <= 1)
                {
                    a = a + data.ElementAt(i);
                }
                else if (i <= 3)
                {
                    b = b + data.ElementAt(i);
                }
                else if (i <= 5)
                {
                    c = c + data.ElementAt(i);
                }
                else if (i <= 7)
                {
                    d = d + data.ElementAt(i);
                }
                else if (i <= 9)
                {
                    e = e + data.ElementAt(i);
                }
            }

            int value1 = Int32.Parse(a, System.Globalization.NumberStyles.HexNumber);
            int value2 = Int32.Parse(b, System.Globalization.NumberStyles.HexNumber);
            int value3 = Int32.Parse(c, System.Globalization.NumberStyles.HexNumber);
            int value4 = Int32.Parse(d, System.Globalization.NumberStyles.HexNumber);
            int value5 = Int32.Parse(d, System.Globalization.NumberStyles.HexNumber);

            value1 = value1 - 125;
            value2 = value2 - 125;
            value3 = value3 - 125;
            value4 = value4 - 125;
            value5 = value5 - 125;
            var rowAdded = dataBase.Insert(new EnginePercentTorqueData()
            {
                CreatedOn = DateTime.Now,
                PercentageIdle = value1,
                PercentageEnginePoint1 = value2,
                PercentageEnginePoint2 = value3,
                PercentageEnginePoint3 = value4,
                PercentageEnginePoint4 = value5,


            });
        }





        //La siguiente es maximun value for fuel-air blablablaaaaaaaaa
        public List<DiagnosticTroubleCode> DiagnosticTroubleCodes(DataTransferSchema dr)
        {
            throw new NotImplementedException();
            // issue the request for the actual DTCs

            /* var fetchedCodes = new List<DiagnosticTroubleCode>();
             for (int i = 1; i < dr.Value.Length; i += 3) // each error code got a size of 3 bytes
             {
                 byte[] troubleCode = new byte[3];
                 Array.Copy(dr.Value, i, troubleCode, 0, 3);

                 if (!troubleCode.All(b => b == default(System.Byte))) 
                     fetchedCodes.Add(new DiagnosticTroubleCode(troubleCode));
             }

             return fetchedCodes;*/
        }
        public DataBaseReader getReader()
        {
            return reader;
        }
    }
}