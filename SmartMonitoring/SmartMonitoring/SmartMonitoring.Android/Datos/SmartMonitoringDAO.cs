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
using System.Threading.Tasks;

namespace SmartMonitoring.Droid.Datos
{
    public class SmartMonitoringDAO : ISmartMonitoringDAO
    {

        public const string NO_DATA = "NO DATA";

        BluetoothSocket socket = null;

        SQLiteConnection dataBase = null;
        byte[] pids01_20;
        byte[] pids21_40;
        byte[] pids41_60;
        byte[] pids61_80;
        string obdiiProtocol;
        bool guardar = false;

        public byte[] Pids01_20 { get { return pids01_20; } set { pids01_20 = value; } }
        public byte[] Pids21_40 { get { return pids21_40; } set { pids21_40 = value; } }
        public byte[] Pids41_60 { get { return pids21_40; } set { pids21_40 = value; } }

        public byte[] Pids61_80
        {
            get
            {
                return pids61_80;
            }
            set
            {
                pids61_80 = value;
            }
        }

        public void setGuardarDatos(bool value)
        {
            guardar = value;
        }

        public bool getGuardarDatos()
        {
            return guardar;
        }

        public SQLiteConnection getSQLConnection()
        {
            return dataBase;
        }

        public List<byte[]> getPids()
        {
            List<byte[]> pids = new List<byte[]>();
            pids.Add(Pids01_20);
            pids.Add(Pids21_40);
            pids.Add(Pids41_60);
            return pids;
        }
        public SmartMonitoringDAO(BluetoothSocket socket)
        {
            SQLAndroid sql = new SQLAndroid();
            dataBase = sql.GetConnection();
            this.socket = socket;
            obdiiProtocol = "";
        }


        public void Initialize()
        {

            byte[] cmd = Encoding.ASCII.GetBytes("ATD" + "\r");

            Console.WriteLine("Enviando comando ATD");
            socket.OutputStream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(500);
            if (Read().Equals(""))
            {
                throw new System.Exception();
            }
            socket.OutputStream.Flush();
            Thread.Sleep(500);


            cmd = Encoding.ASCII.GetBytes("ATZ" + "\r");
            Console.WriteLine("Enviando comando ATZ");
            socket.OutputStream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(500);
            if (Read().Equals(""))
            {
                throw new System.Exception();
            }
            socket.OutputStream.Flush();
            Thread.Sleep(500);

            cmd = Encoding.ASCII.GetBytes("AT E0" + "\r");
            Console.WriteLine("Enviando comando AT E0");
            socket.OutputStream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(500);
            if (Read().Equals(""))
            {
                return;
            }
            socket.OutputStream.Flush();
            Thread.Sleep(500);

            cmd = Encoding.ASCII.GetBytes("AT L0" + "\r");
            Console.WriteLine("Enviando comando AT L0");

            socket.OutputStream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(500);
            if (Read().Equals(""))
            {
                return;
            }
            socket.OutputStream.Flush();
            Thread.Sleep(500);

            Console.WriteLine("Enviando comando AT S0");
            cmd = Encoding.ASCII.GetBytes("AT S0" + "\r");
            socket.OutputStream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(500);
            if (Read().Equals(""))
            {
                return;
            }
            socket.OutputStream.Flush();
            Thread.Sleep(500);
            Console.WriteLine("Enviando comando AT H0");
            cmd = Encoding.ASCII.GetBytes("AT H0" + "\r");
            socket.OutputStream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(500);
            socket.OutputStream.Flush();
            if (Read().Equals(""))
            {
                return;
            }

            socket.OutputStream.Flush();
            Thread.Sleep(500);
            Console.WriteLine("Enviando comando AT ST");
            cmd = Encoding.ASCII.GetBytes("AT H0" + "\r");
            socket.OutputStream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(500);
            socket.OutputStream.Flush();
            if (Read().Equals(""))
            {
                return;
            }


            socket.OutputStream.Flush();
            Thread.Sleep(500);
            cmd = Encoding.ASCII.GetBytes("0100" + "\r");
            socket.OutputStream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(500);
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
            Pids01_20 = new byte[32];
            for (int i = 0; i < result.Length; i++)
            {

                string binaryData = "";
                binaryData = Convert.ToString(Convert.ToInt32(result[i].ToString(), 16), 2).PadLeft(4, '0');
                Pids01_20[i * 4] = (byte)binaryData[0];
                Pids01_20[4 * i + 1] = (byte)binaryData[1];
                Pids01_20[4 * i + 2] = (byte)binaryData[2];
                Pids01_20[4 * i + 3] = (byte)binaryData[3];
            }

            Console.WriteLine("PIDS_0120 \n");
            for (int i = 0; i < pids01_20.Length; i++)
            {
                Console.WriteLine(i + "= " + Pids01_20[i]);
            }

            cmd = Encoding.ASCII.GetBytes("0120" + "\r");
            socket.OutputStream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(500);
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
            Pids21_40 = new byte[32];
            for (int i = 0; i < result.Length; i++)
            {

                string binaryData = "";
                binaryData = Convert.ToString(Convert.ToInt32(result[i].ToString(), 16), 2).PadLeft(4, '0');
                Pids21_40[4 * i] = (byte)binaryData[0];
                Pids21_40[4 * i + 1] = (byte)binaryData[1];
                Pids21_40[4 * i + 2] = (byte)binaryData[2];
                Pids21_40[4 * i + 3] = (byte)binaryData[3];
            }
            Console.WriteLine("PIDS_2140 \n");
            for (int i = 0; i < pids21_40.Length; i++)
            {
                Console.WriteLine(i + "= " + Pids21_40[i]);
            }

            cmd = Encoding.ASCII.GetBytes("0140" + "\r");
            socket.OutputStream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(500);
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
            Pids41_60 = new byte[32];
            for (int i = 0; i < result.Length; i++)
            {

                string binaryData = "";
                binaryData = Convert.ToString(Convert.ToInt32(result[i].ToString(), 16), 2).PadLeft(4, '0');
                Pids41_60[i * 4] = (byte)binaryData[0];
                Pids41_60[4 * i + 1] = (byte)binaryData[1];
                Pids41_60[4 * i + 2] = (byte)binaryData[2];
                Pids41_60[4 * i + 3] = (byte)binaryData[3];
            }

            Console.WriteLine("PIDS_4160 \n");
            for (int i = 0; i < Pids41_60.Length; i++)
            {
                Console.WriteLine(i + "= " + Pids41_60[i]);
            }



            cmd = Encoding.ASCII.GetBytes("0160" + "\r");
            socket.OutputStream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(500);
            string fourthpids = Read();
            if (fourthpids.Contains("UNABLE TO CONNECT"))
            {
                throw new UnableToConnectException();
            }
            /* if (!fourthpids.Contains("NO DATA"))
            {
                            
            fourthpids = fourthpids.Substring(fourthpids.Length - 10);
            result = "";
            foreach (char c in fourthpids)
            {
                byte a = (byte)c;
                if (a == 13)
                {
                    break;
                }
                result = result + c;
            }
            Pids61_80 = new byte[32];
            for (int i = 0; i < result.Length; i++)
            {

                string binaryData = "";
                binaryData = Convert.ToString(Convert.ToInt32(result[i].ToString(), 16), 2).PadLeft(4, '0');
                Pids61_80[i * 4] = (byte)binaryData[0];
                Pids61_80[4 * i + 1] = (byte)binaryData[1];
                Pids61_80[4 * i + 2] = (byte)binaryData[2];
                Pids61_80[4 * i + 3] = (byte)binaryData[3];
            }

            Console.WriteLine("PIDS_6180 \n");
            for (int i = 0; i < Pids61_80.Length; i++)
            {
                Console.WriteLine(i + "= " + Pids61_80[i]);
            }

           }*/


            socket.OutputStream.Flush();
            Thread.Sleep(500);
            Console.WriteLine("Enviando comando DPN");
            cmd = Encoding.ASCII.GetBytes("AT DPN" + "\r");
            socket.OutputStream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(500);
            socket.OutputStream.Flush();
            obdiiProtocol = Read();
            if (obdiiProtocol.Equals(""))
            {
                return;
            }
            socket.OutputStream.Flush();
            Thread.Sleep(500);


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
                    Thread.Sleep(50);
                }

            }
            catch (System.Exception e)
            {
                Console.WriteLine("Error de lectura :" + e.Message);

            }

            return data;

        }




        // public DataResponse ConsultParameters(BluetoothSocket socket, Parameters.PID pid)
        public async Task<DataTransferSchema> ConsultParametersAsync(Parameters.PID pid)
        {


            string send = (Convert.ToUInt32(Parameters.ConsultMode.CurrentData).ToString("X2") + Convert.ToUInt32(pid).ToString("X2") + "\r");
            byte[] cmd = Encoding.ASCII.GetBytes(send);
            socket.OutputStream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(300);
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

            if (dataFilter.Equals("UNABLE TO CONNECT"))
            {
                throw new UnableToConnectException();
            }

            if (dataFilter.Equals("STOPPED"))
            {
                throw new StoppedException();
            }
            if (dataFilter.Equals("BUS ERROR"))
            {
                throw new BusErrorException();
            }
            if (dataFilter.Equals("BUFFER FULL"))
            {
                throw new BufferFullException();
            }
            if (dataFilter.Equals("NO DATA"))
            {
                socket.InputStream.Flush();
                await Task.Delay(20);
                socket.OutputStream.Flush();
                await Task.Delay(20);

            }
            if (dataFilter.Equals("CAN ERROR"))
            {
                throw new CanErrorException();
            }
            if (dataFilter.Equals("BUS BUSY"))
            {
                throw new BusBusyException();
            }


            DataTransferSchema dr = new DataTransferSchema(dataFilter, pid, Parameters.ConsultMode.CurrentData);
            return dr;

        }



        // public DataResponse DiagnosticCar(BluetoothSocket socket)
        public List<DiagnosticTroubleCode> DiagnosticCar()
        {
            List<DiagnosticTroubleCode> diagnostic = new List<DiagnosticTroubleCode>();
            DataTransferSchema response = null;
            string send = (Convert.ToUInt32(Parameters.ConsultMode.DiagnosticTroubleCodes).ToString("X2") + "\r");
            byte[] cmd = Encoding.ASCII.GetBytes(send);
            socket.OutputStream.Write(cmd, 0, cmd.Length);
            Thread.Sleep(500);
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
            return diagnostic;

        }


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

        public string readCalculatedEngineLoad(DataTransferSchema dr)
        {
            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
            {
                string data = dr.Response.Substring(dr.Response.Length - 2);

                double engineLoad = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
                engineLoad = engineLoad * 100 / 255;
                res = engineLoad.ToString();
            }
            if (guardar == true)
            {
                var rowAdded = dataBase.Insert(new CalculatedEngineLoadValuesData()
                {
                    CreatedOn = DateTime.Now,
                    CalculatedEngineLoadValue = res

                });
            }
            return res;

        }


        public List<string> readFuelSystemStatus(DataTransferSchema dr)
        {
            string res1;
            string res2;
            List<string> res = new List<String>();

            if (dr.Response.Equals(NO_DATA))
            {
                res1 = NO_DATA;
                res2 = NO_DATA;
            }
            else
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
                res1 = value1.ToString();
                res2 = value2.ToString();
            }

            if (guardar == true)
            {
                var rowAdded = dataBase.Insert(new FuelSystemStatus()
                {
                    CreatedOn = DateTime.Now,
                    System1 = res1,
                    System2 = res2

                });
                res.Add(res1);
                res.Add(res2);
            }
            return res;



        }



        public string readTermFuelTrim(DataTransferSchema dr)
        {
            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
            {
                string data = dr.Response.Substring(dr.Response.Length - 2);

                double value = System.Double.Parse(data, System.Globalization.NumberStyles.HexNumber);
                value = value * 100 / 128 - 100;
                res = value.ToString();
            }
            var rowAdded = 0;
            switch (dr.Pid)
            {

                case Parameters.PID.FuelTrim_Bank1_Short:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new ShortTermFuelTrimB1()
                        {
                            CreatedOn = DateTime.Now,
                            ShortTermFuelTrimBank1 = res

                        });
                    }
                    break;

                case Parameters.PID.FuelTrim_Bank1_Long:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new LongTermFuelTrimB1()
                        {
                            CreatedOn = DateTime.Now,
                            LongTermFuelTrimBank1 = res

                        });
                    }

                    break;

                case Parameters.PID.FuelTrim_Bank2_Short:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new ShortTermFuelTrimB2()
                        {
                            CreatedOn = DateTime.Now,
                            ShortTermFuelTrimBank2 = res

                        });
                    }
                    break;

                case Parameters.PID.FuelTrim_Bank2_Long:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new LongTermFuelTrimB2()
                        {
                            CreatedOn = DateTime.Now,
                            LongTermFuelTrimBank2 = res

                        });
                    }
                    break;

            }
            return res;

        }

        public string readMAFAirFlowRate(DataTransferSchema dr)
        {

            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
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

                double value = (256 * value1 + value2) / 100;
                res = value.ToString();
            }
            if (guardar == true)
            {
                var rowAdded = dataBase.Insert(new MAFAirFlowRate()
                {
                    CreatedOn = DateTime.Now,
                    MAFAirFlowRateValue = res

                });
            }

            return res;

        }

        public string readFuelPressure(DataTransferSchema dr)
        {
            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
            {
                string data = dr.Response.Substring(dr.Response.Length - 2);

                int fuelPressure = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
                fuelPressure = fuelPressure * 3;
                res = fuelPressure.ToString();

            }
            if (guardar == true)
            {
                var rowAdded = dataBase.Insert(new FuelPressure()
                {
                    CreatedOn = DateTime.Now,
                    FuelPressureValue = res

                });
            }
            return res;
        }

        public string readIntakeManifoldAbsolutePressure(DataTransferSchema dr)
        {
            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
            {
                string data = dr.Response.Substring(dr.Response.Length - 2);

                int value = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
                res = value.ToString();
            }
            if (guardar == true)
            {
                var rowAdded = dataBase.Insert(new IntakeManifoldAbsolutePressure()
                {
                    CreatedOn = DateTime.Now,
                    IntakeManifoldAbsolutePressureValue = res.ToString()

                });
            }
            return res;
        }

        public string readRPM(DataTransferSchema dr)
        {
            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
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

                int value = (256 * value1 + value2) / 4;
                res = value.ToString();
            }
            if (guardar == true)
            {
                var rowAdded = dataBase.Insert(new RPMData()
                {
                    CreatedOn = DateTime.Now,
                    RPM = res

                });

                Console.WriteLine("RMP añadida: " + res + " rowAdded: " + rowAdded);
            }
            return res;

        }

        public string readSpeed(DataTransferSchema dr)
        {
            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
            {
                string data = dr.Response.Substring(dr.Response.Length - 2);

                int numSpeed = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
                res = numSpeed.ToString();
            }
            if (guardar == true)
            {
                var rowAdded = dataBase.Insert(new SpeedData()
                {
                    CreatedOn = DateTime.Now,
                    Speed = res

                });
                Console.WriteLine("Velocidad añadida: " + res + " rowAdded: " + rowAdded);
            }

            return res;
        }

        public string readTimingAdvance(DataTransferSchema dr)
        {
            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
            {
                string data = dr.Response.Substring(dr.Response.Length - 2);

                double time = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
                time = time / 2 - 64;
                res = time.ToString();
            }
            if (guardar == true)
            {
                var rowAdded = dataBase.Insert(new TimingAdvance()
                {
                    CreatedOn = DateTime.Now,
                    Time = res

                });
            }
            return res;
        }

        public string readIntakeAirTemperature(DataTransferSchema dr)
        {
            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
            {
                string data = dr.Response.Substring(dr.Response.Length - 2);

                int value = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
                value = value - 40;
                res = value.ToString();

            }
            if (guardar == true)
            {
                var rowAdded = dataBase.Insert(new TimingAdvance()
                {
                    CreatedOn = DateTime.Now,
                    Time = res

                });
            }
            return res;

        }



        public string readThrottlePosition(DataTransferSchema dr)
        {
            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
            {
                string data = dr.Response.Substring(dr.Response.Length - 2);

                int throttlePosition = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
                double throttlePositionRes = throttlePosition * 100 / 255;
                res = throttlePositionRes.ToString();
            }

            if (guardar == true)
            {
                var rowAdded = dataBase.Insert(new ThrottlePosition()
                {
                    CreatedOn = DateTime.Now,
                    ThrottlePositionValue = res

                });
                Console.WriteLine("ThrottlePosition añadida: " + res + " rowAdded: " + rowAdded);
            }

            return res;
        }


        public string readEngineTemperature(DataTransferSchema dr)
        {
            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
            {
                string data = dr.Response.Substring(dr.Response.Length - 2);

                int engineTemperature = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
                engineTemperature = engineTemperature - 40;
                res = engineTemperature.ToString();
            }
            if (guardar == true)
            {
                var rowAdded = dataBase.Insert(new EngineTemperatureData()
                {
                    CreatedOn = DateTime.Now,
                    Temperature = res

                });

                Console.WriteLine("Temperatura añadida: " + res + " rowAdded: " + rowAdded);
            }
            return res;
        }

        public string readEngineStartTime(DataTransferSchema dr)
        {
            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
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
                res = value.ToString();
            }
            if (guardar == true)
            {
                var rowAdded = dataBase.Insert(new RunTimeSinceEngineStart
                {
                    CreatedOn = DateTime.Now,
                    Time = res

                });
            }
            return res;
        }

        public string readDistanceWithMILLamp(DataTransferSchema dr)
        {
            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
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
                res = value.ToString();

            }
            if (guardar == true)
            {
                var rowAdded = dataBase.Insert(new DistanceTraveledWithMILo()
                {
                    CreatedOn = DateTime.Now,
                    Distance = res,

                });
            }
            return res;
        }

        public string readAbsoluteBarometricPressure(DataTransferSchema dr)
        {
            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
            {
                string data = dr.Response.Substring(dr.Response.Length - 2);

                int pressure = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
                res = pressure.ToString();
            }
            if (guardar == true)
            {
                var rowAdded = dataBase.Insert(new AbsoluteBarometricPressure()
                {
                    CreatedOn = DateTime.Now,
                    BarometricPressure = res

                });
            }
            return res;
        }



        public List<string> readOxygenSensor(DataTransferSchema dr)
        {
            List<string> res = new List<string>();
            string res1;
            string res2;
            if (dr.Response.Equals(NO_DATA))
            {
                res1 = NO_DATA;
                res2 = NO_DATA;
            }
            else
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
                res1 = value1.ToString();
                res2 = value2.ToString();
            }
            var rowAdded = 0;
            switch (dr.Pid)
            {

                case Parameters.PID.OxygenSensor1:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new OxygenSensor1()
                        {
                            CreatedOn = DateTime.Now,
                            Voltage = res1,
                            ShortTermFuelTrim = res2

                        });
                    }

                    break;

                case Parameters.PID.OxygenSensor2:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new OxygenSensor2()
                        {
                            CreatedOn = DateTime.Now,
                            Voltage = res1,
                            ShortTermFuelTrim = res2

                        });
                    }
                    break;

                case Parameters.PID.OxygenSensor3:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new OxygenSensor3()
                        {
                            CreatedOn = DateTime.Now,
                            Voltage = res1,
                            ShortTermFuelTrim = res2

                        });
                    }

                    break;

                case Parameters.PID.OxygenSensor4:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new OxygenSensor4()
                        {
                            CreatedOn = DateTime.Now,
                            Voltage = res1,
                            ShortTermFuelTrim = res2

                        });
                    }

                    break;

                case Parameters.PID.OxygenSensor5:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new OxygenSensor5()
                        {
                            CreatedOn = DateTime.Now,
                            Voltage = res1,
                            ShortTermFuelTrim = res2

                        });
                    }

                    break;

                case Parameters.PID.OxygenSensor6:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new OxygenSensor6()
                        {
                            CreatedOn = DateTime.Now,
                            Voltage = res1,
                            ShortTermFuelTrim = res2

                        });
                    }
                    break;

                case Parameters.PID.OxygenSensor7:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new OxygenSensor7()
                        {
                            CreatedOn = DateTime.Now,
                            Voltage = res1,
                            ShortTermFuelTrim = res2

                        });
                    }
                    break;

                case Parameters.PID.OxygenSensor8:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new OxygenSensor8()
                        {
                            CreatedOn = DateTime.Now,
                            Voltage = res1,
                            ShortTermFuelTrim = res2

                        });
                    }
                    break;
            }
            res.Add(res1);
            res.Add(res2);
            return res;


        }


        public string readFuelRailPressure(DataTransferSchema dr)
        {
            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
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
                res = value.ToString();
            }

            var rowAdded = dataBase.Insert(new FuelRailPressure()
            {
                CreatedOn = DateTime.Now,
                Pressure = res

            });

            return res;

        }

        public string readFuelRailGaugePressure(DataTransferSchema dr)
        {
            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
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
                res = value.ToString();
            }
            if (guardar == true)
            {
                var rowAdded = dataBase.Insert(new FuelRailGaugePressure()
                {
                    CreatedOn = DateTime.Now,
                    Pressure = res

                });
            }
            return res;

        }

        public List<string> readOxygenSensorB(DataTransferSchema dr)
        {
            List<string> res = new List<string>();
            string res1;
            string res2;
            if (dr.Response.Equals(NO_DATA))
            {
                res1 = NO_DATA;
                res2 = NO_DATA;
            }
            else
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

                res1 = value1.ToString();
                res2 = value3.ToString();

            }


            var rowAdded = 0;
            switch (dr.Pid)
            {

                case Parameters.PID.OxygenSensor1b:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new OxygenSensor1B()
                        {
                            CreatedOn = DateTime.Now,
                            Fuel_AirEquivalenceRatio = res1,
                            Voltage = res2

                        });
                    }

                    break;

                case Parameters.PID.OxygenSensor2b:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new OxygenSensor2B()
                        {
                            CreatedOn = DateTime.Now,
                            Fuel_AirEquivalenceRatio = res1,
                            Voltage = res2

                        });
                    }

                    break;

                case Parameters.PID.OxygenSensor3b:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new OxygenSensor3B()
                        {
                            CreatedOn = DateTime.Now,
                            Fuel_AirEquivalenceRatio = res1,
                            Voltage = res2
                        });
                    }

                    break;

                case Parameters.PID.OxygenSensor4b:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new OxygenSensor4B()
                        {
                            CreatedOn = DateTime.Now,
                            Fuel_AirEquivalenceRatio = res1,
                            Voltage = res2

                        });
                    }

                    break;

                case Parameters.PID.OxygenSensor5b:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new OxygenSensor5B()
                        {
                            CreatedOn = DateTime.Now,
                            Fuel_AirEquivalenceRatio = res1,
                            Voltage = res2

                        });
                    }
                    break;

                case Parameters.PID.OxygenSensor6b:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new OxygenSensor6B()
                        {
                            CreatedOn = DateTime.Now,
                            Fuel_AirEquivalenceRatio = res1,
                            Voltage = res2

                        });
                    }
                    break;

                case Parameters.PID.OxygenSensor7b:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new OxygenSensor7B()
                        {
                            CreatedOn = DateTime.Now,
                            Fuel_AirEquivalenceRatio = res1,
                            Voltage = res2

                        });
                    }
                    break;

                case Parameters.PID.OxygenSensor8b:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new OxygenSensor8B()
                        {
                            CreatedOn = DateTime.Now,
                            Fuel_AirEquivalenceRatio = res1,
                            Voltage = res2

                        });
                    }
                    break;
            }
            res.Add(res1);
            res.Add(res2);
            return res;


        }

        public string readCommandedEGR(DataTransferSchema dr)
        {
            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
            {
                string data = dr.Response.Substring(dr.Response.Length - 2);

                double value = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
                value = 100 * value / 255;
                res = value.ToString();
            }
            if (guardar == true)
            {
                var rowAdded = dataBase.Insert(new CommandedEGR()
                {
                    CreatedOn = DateTime.Now,
                    ValueEGR = res

                });
            }

            return res;

        }

        public string readEGRError(DataTransferSchema dr)
        {
            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
            {
                string data = dr.Response.Substring(dr.Response.Length - 2);

                double value = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
                value = 100 * value / 128 - 100;
                res = value.ToString();
            }
            if (guardar == true)
            {
                var rowAdded = dataBase.Insert(new EGRError()
                {
                    CreatedOn = DateTime.Now,
                    ValueEGR = res

                });
            }

            return res;

        }

        public string readCommandedEvaporativePurge(DataTransferSchema dr)
        {
            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
            {
                string data = dr.Response.Substring(dr.Response.Length - 2);

                double value = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
                value = 100 * value / 255;
                res = value.ToString();
            }
            if (guardar == true)
            {
                var rowAdded = dataBase.Insert(new CommandedEvaporativePurge()
                {
                    CreatedOn = DateTime.Now,
                    Value = res

                });
            }

            return res;


        }

        public string readFuelTankLevelInput(DataTransferSchema dr)
        {
            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
            {
                string data = dr.Response.Substring(dr.Response.Length - 2);

                double value = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
                value = 100 * value / 255;
                res = value.ToString();
            }
            if (guardar == true)
            {
                var rowAdded = dataBase.Insert(new FuelTankLevel()
                {
                    CreatedOn = DateTime.Now,
                    FuelTankLevelValue = res

                });
            }

            return res;


        }

        public List<string> readOxygenSensorC(DataTransferSchema dr)
        {
            List<string> res = new List<string>();
            string res1;
            string res2;
            if (dr.Response.Equals(NO_DATA))
            {
                res1 = NO_DATA;
                res2 = NO_DATA;
            }
            else
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

                res1 = value1.ToString();
                res2 = value3.ToString();
            }
            var rowAdded = 0;
            switch (dr.Pid)
            {

                case Parameters.PID.OxygenSensor1c:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new OxygenSensor1C()
                        {
                            CreatedOn = DateTime.Now,
                            Fuel_AirEquivalenceRatio = res1,
                            Current = res2

                        });
                    }
                    break;

                case Parameters.PID.OxygenSensor2c:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new OxygenSensor2C()
                        {
                            CreatedOn = DateTime.Now,
                            Fuel_airEquivalenceRatio = res1,
                            Current = res2

                        });
                    }
                    break;

                case Parameters.PID.OxygenSensor3c:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new OxygenSensor3C()
                        {
                            CreatedOn = DateTime.Now,
                            Fuel_airEquivalenceRatio = res1,
                            Current = res2
                        });
                    }
                    break;

                case Parameters.PID.OxygenSensor4c:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new OxygenSensor4C()
                        {
                            CreatedOn = DateTime.Now,
                            Fuel_airEquivalenceRatio = res1,
                            Current = res2

                        });
                    }
                    break;

                case Parameters.PID.OxygenSensor5c:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new OxygenSensor5C()
                        {
                            CreatedOn = DateTime.Now,
                            Fuel_airEquivalenceRatio = res1,
                            Current = res2

                        });
                    }
                    break;

                case Parameters.PID.OxygenSensor6c:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new OxygenSensor6C()
                        {
                            CreatedOn = DateTime.Now,
                            Fuel_airEquivalenceRatio = res1,
                            Current = res2

                        });
                    }
                    break;

                case Parameters.PID.OxygenSensor7c:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new OxygenSensor7C()
                        {
                            CreatedOn = DateTime.Now,
                            Fuel_airEquivalenceRatio = res1,
                            Current = res2

                        });
                    }
                    break;

                case Parameters.PID.OxygenSensor8c:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new OxygenSensor8C()
                        {
                            CreatedOn = DateTime.Now,
                            Fuel_airEquivalenceRatio = res1,
                            Current = res2

                        });
                    }
                    break;
            }

            res.Add(res1);
            res.Add(res2);
            return res;


        }

        public string readCatalystTemperature(DataTransferSchema dr)
        {
            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
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

                double value = ((256 * numA + numB) / 10) - 40;
                res = value.ToString();
            }

            var rowAdded = 0;
            switch (dr.Pid)
            {
                case Parameters.PID.CatalystTemperature_Bank1_Sensor1:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new CatalystTemperatureB1S1()
                        {
                            CreatedOn = DateTime.Now,
                            Temperature = res

                        });
                    }
                    break;

                case Parameters.PID.CatalystTemperature_Bank1_Sensor2:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new CatalystTemperatureB1S2()
                        {
                            CreatedOn = DateTime.Now,
                            Temperature = res

                        });
                    }
                    break;

                case Parameters.PID.CatalystTemperature_Bank2_Sensor1:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new CatalystTemperatureB2S1()
                        {
                            CreatedOn = DateTime.Now,
                            Temperature = res

                        });
                    }
                    break;

                case Parameters.PID.CatalystTemperature_Bank2_Sensor2:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new CatalystTemperatureB2S2()
                        {
                            CreatedOn = DateTime.Now,
                            Temperature = res

                        });
                    }
                    break;

            }

            return res;


        }

        public string readControlModuleVoltage(DataTransferSchema dr)
        {
            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
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
                res = value.ToString();
            }
            if (guardar == true)
            {
                var rowAdded = dataBase.Insert(new ControlModuleVoltage()
                {
                    CreatedOn = DateTime.Now,
                    Voltage = res

                });
            }
            return res;
        }

        public string readAbsoluteLoadValue(DataTransferSchema dr)
        {
            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
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
                res = value.ToString();
            }
            if (guardar == true)
            {
                var rowAdded = dataBase.Insert(new AbsoluteLoadValue()
                {
                    CreatedOn = DateTime.Now,
                    Value = res

                });
            }

            return res;

        }

        public string readFuelAirCommandedEquivalenceRatio(DataTransferSchema dr)
        {
            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
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
                res = value.ToString();
            }
            if (guardar == true)
            {
                var rowAdded = dataBase.Insert(new FuelAirCommandedEquivalenceRatio()
                {
                    CreatedOn = DateTime.Now,
                    Ratio = res

                });
            }

            return res;
        }

        public string readRelativeThrottlePosition(DataTransferSchema dr)
        {
            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
            {
                string data = dr.Response.Substring(dr.Response.Length - 2);

                double value = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
                value = value * 100 / 255;

                res = value.ToString();
            }
            if (guardar == true)
            {
                var rowAdded = dataBase.Insert(new RelativeThrottlePosition()
                {
                    CreatedOn = DateTime.Now,
                    ThrottlePosition = res

                });
            }
            return res;

        }



        public string readAmbientTemperatureAir(DataTransferSchema dr)
        {
            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
            {
                string data = dr.Response.Substring(dr.Response.Length - 2);

                int value = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
                value = value - 40;
                res = value.ToString();
            }

            if (guardar == true)
            {
                var rowAdded = dataBase.Insert(new AmbientAirTemperature()
                {
                    CreatedOn = DateTime.Now,
                    Temperature = res

                });
            }

            return res;

        }

        public string readAbsoluteThrottlePosition(DataTransferSchema dr)
        {
            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
            {
                string data = dr.Response.Substring(dr.Response.Length - 2);

                double value = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
                value = 100 * value / 255;
                res = value.ToString();
            }

            var rowAdded = 0;
            switch (dr.Pid)
            {
                case Parameters.PID.AbsoluteThrottlePositionB:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new AbsoluteThrottlePositionB()
                        {
                            CreatedOn = DateTime.Now,
                            ThrottlePositionB = res

                        });
                    }
                    break;
                case Parameters.PID.AbsoluteThrottlePositionC:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new AbsoluteThrottlePositionC()
                        {
                            CreatedOn = DateTime.Now,
                            ThrottlePositionC = res

                        });
                    }
                    break;
                case Parameters.PID.AbsoluteThrottlePositionD:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new AbsoluteThrottlePositionD()
                        {
                            CreatedOn = DateTime.Now,
                            ThrottlePositionD = res

                        });
                    }
                    break;
                case Parameters.PID.AbsoluteThrottlePositionE:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new AbsoluteThrottlePositionE()
                        {
                            CreatedOn = DateTime.Now,
                            ThrottlePositionE = res

                        });
                    }
                    break;
                case Parameters.PID.AbsoluteThrottlePositionF:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new AbsoluteThrottlePositionF()
                        {
                            CreatedOn = DateTime.Now,
                            ThrottlePositionF = res

                        });
                    }
                    break;

            }

            return res;

        }

        public string readCommandedThrottleActuator(DataTransferSchema dr)
        {
            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
            {
                string data = dr.Response.Substring(dr.Response.Length - 2);

                double value = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
                value = 100 * value / 255;
                res = value.ToString();
            }
            if (guardar == true)
            {
                var rowAdded = dataBase.Insert(new CommandedThrottleActuator()
                {
                    CreatedOn = DateTime.Now,
                    CommandedThrottleActuatorValue = res

                });
            }

            return res;
        }

        public string readTimeEventTroubleCodes(DataTransferSchema dr)
        {
            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
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
                res = value.ToString();
            }

            var rowAdded = 0;
            switch (dr.Pid)
            {
                case Parameters.PID.TimeRunWithMILOn:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new TimeRunWithMILOn()
                        {
                            CreatedOn = DateTime.Now,
                            Time = res

                        });
                    }
                    break;

                case Parameters.PID.TimeSinceTroubleCodesCleared:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new TimeSinceTroubleCodesCleared()
                        {
                            CreatedOn = DateTime.Now,
                            Time = res

                        });
                    }
                    break;

            }
            return res;
        }

        public List<string> readFuelAirEquivalence_OxygenVoltage_OxygenSensorCurrent_IntakeManifoldAbsolutePressure(DataTransferSchema dr)
        {
            List<string> res = new List<string>();
            string res1;
            string res2;
            string res3;
            string res4;
            if (dr.Response.Equals(NO_DATA))
            {
                res1 = NO_DATA;
                res2 = NO_DATA;
                res3 = NO_DATA;
                res4 = NO_DATA;
            }
            else
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

                res1 = value1.ToString();
                res2 = value2.ToString();
                res3 = value3.ToString();
                res4 = value4.ToString();
            }
            if (guardar == true)
            {
                var rowAdded = dataBase.Insert(new FuelAirEquivalence_OxygenVoltage_OxygenSensorCurrent_IntakeManifoldAbsolutePressure()
                {
                    CreatedOn = DateTime.Now,
                    MaximunValue_Fuel_Air_EquivalenceRatio = res1,
                    OxygenSensorVoltage = res2,
                    OxygenSensorCurrent = res3,
                    IntakeManifoldAbsolutePressure = res4,
                });
            }

            res.Add(res1);
            res.Add(res2);
            res.Add(res3);
            res.Add(res4);
            return res;

        }

        public List<string> readMaximunValueFlowRateFromMassAirFlowSensor(DataTransferSchema dr)
        {
            List<string> res = new List<string>();
            string res1;
            string res2;
            string res3;
            string res4;
            if (dr.Response.Equals(NO_DATA))
            {
                res1 = NO_DATA;
                res2 = NO_DATA;
                res3 = NO_DATA;
                res4 = NO_DATA;
            }
            else
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

                res1 = value1.ToString();
                res2 = value2.ToString();
                res3 = value3.ToString();
                res4 = value4.ToString();
            }
            if (guardar == true)
            {
                var rowAdded = dataBase.Insert(new MaximunValueAirFlowRateFromMassAirFlowSensor()
                {
                    CreatedOn = DateTime.Now,
                    MaximunValueA = res1,
                    MaximunValueB = res2,
                    MaximunValueC = res3,
                    MaximunValueD = res4


                });
            }
            res.Add(res1);
            res.Add(res2);
            res.Add(res3);
            res.Add(res4);
            return res;
        }

        public string readFuelType(DataTransferSchema dr)
        {
            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
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
                res = type;
            }
            if (guardar == true)
            {
                var rowAdded = dataBase.Insert(new FuelType()
                {
                    CreatedOn = DateTime.Now,
                    FuelTypeValue = res



                });
            }
            return res;

        }


        public string readEthanolFuelPercentage(DataTransferSchema dr)
        {
            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
            {
                string data = dr.Response.Substring(dr.Response.Length - 2);
                double value = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
                value = value * 100 / 255;
                res = value.ToString();
            }
            if (guardar == true)
            {
                var rowAdded = dataBase.Insert(new EthanolFuelPercentage()
                {
                    CreatedOn = DateTime.Now,
                    Percentage = res



                });
            }

            return res;
        }

        public string readAbsoluteEvapSystemVaporPressure(DataTransferSchema dr)
        {
            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
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
                res = value.ToString();
            }
            if (guardar == true)
            {
                var rowAdded = dataBase.Insert(new AbsoluteEvapSystemVaporPressure()
                {
                    CreatedOn = DateTime.Now,
                    Pressure = res



                });
            }
            return res;

        }

        public string readEvapSystemVaporPressure(DataTransferSchema dr)
        {
            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
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
                res = value.ToString();
            }
            if (guardar == true)
            {
                var rowAdded = dataBase.Insert(new EvapSystemVaporPressure()
                {
                    CreatedOn = DateTime.Now,
                    EvapSystemVaporPressureValue = res



                });
            }

            return res;
        }

        public List<string> readSecondaryOxygenSensorTrim(DataTransferSchema dr)
        {
            List<string> res = new List<string>();
            string res1;
            string res2;
            if (dr.Response.Equals(NO_DATA))
            {
                res1 = NO_DATA;
                res2 = NO_DATA;
            }
            else
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

                res1 = value1.ToString();
                res2 = value2.ToString();
            }
            var rowAdded = 0;
            switch (dr.Pid)
            {
                case Parameters.PID.ShortTermSecondaryOxygenSensorTrim1_3:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new ShortTermSecondaryOxygenSensorTrim1_3()
                        {
                            CreatedOn = DateTime.Now,
                            valueBankA = res1,
                            valueBankB = res2

                        });
                    }
                    break;

                case Parameters.PID.LongTermSecondaryOxygenSensorTrim1_3:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new LongTermSecondaryOxygenSensorTrim1_3()
                        {
                            CreatedOn = DateTime.Now,
                            ValueBankA = res1,
                            ValueBankB = res2

                        });
                    }
                    break;

                case Parameters.PID.ShortTermSecondaryOxygenSensorTrim2_4:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new ShortTermSecondaryOxygenSensorTrim2_4()
                        {
                            CreatedOn = DateTime.Now,
                            valueBankA = res1,
                            valueBankB = res2

                        });
                    }
                    break;

                case Parameters.PID.LongTermSecondaryOxygenSensorTrim2_4:
                    if (guardar == true)
                    {
                        rowAdded = dataBase.Insert(new LongTermSecondaryOxygenSensorTrim2_4()
                        {
                            CreatedOn = DateTime.Now,
                            ValueBankA = res1,
                            ValueBankB = res2

                        });
                    }
                    break;

            }

            res.Add(res1);
            res.Add(res2);
            return res;

        }

        public string readFuelRailAbsolutePressure(DataTransferSchema dr)
        {

            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
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
                res = value.ToString();
            }
            if (guardar == true)
            {
                var rowAdded = dataBase.Insert(new FuelRailAbsolutePressure()
                {
                    CreatedOn = DateTime.Now,
                    Pressure = res

                });
            }

            return res;
        }

        public string readRelativeAcceleratorPedalPosition(DataTransferSchema dr)
        {
            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
            {
                string data = dr.Response.Substring(dr.Response.Length - 2);
                double value = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
                value = value * 100 / 255;
                res = value.ToString();
            }
            if (guardar == true)
            {
                var rowAdded = dataBase.Insert(new RelativeAcceleratorPedalPosition()
                {
                    CreatedOn = DateTime.Now,
                    Position = res

                });
            }
            return res;

        }

        public string readHybridBatteryPackRemainingLife(DataTransferSchema dr)
        {
            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
            {
                string data = dr.Response.Substring(dr.Response.Length - 2);
                double value = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
                value = value * 100 / 255;
                res = value.ToString();
            }
            if (guardar == true)
            {
                var rowAdded = dataBase.Insert(new HybridBateryPackRemainingLife()
                {
                    CreatedOn = DateTime.Now,
                    RemainingLife = res
                });
            }
            return res;
        }

        public string readEngineOilTemperature(DataTransferSchema dr)
        {
            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
            {
                string data = dr.Response.Substring(dr.Response.Length - 2);
                int value = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
                value = value - 40;
                res = value.ToString();
            }
            if (guardar == true)
            {
                var rowAdded = dataBase.Insert(new EngineOilTemperature()
                {
                    CreatedOn = DateTime.Now,
                    Temperature = res

                });
            }

            return res;
        }

        public string readFuelInjectionTiming(DataTransferSchema dr)
        {
            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
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
                res = value.ToString();
            }
            if (guardar == true)
            {
                var rowAdded = dataBase.Insert(new FuelInjectionTiming()
                {
                    CreatedOn = DateTime.Now,
                    FuelInjectionTimingValue = res

                });
            }

            return res;

        }
        public string readEngineFuelRate(DataTransferSchema dr)
        {
            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
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
                res = value.ToString();
            }
            if (guardar == true)
            {
                var rowAdded = dataBase.Insert(new EngineFuelRate()
                {
                    CreatedOn = DateTime.Now,
                    EngineFuelRateValue = res

                });
            }
            return res;

        }

        public string readDriverDemandEngine_PercentTorque(DataTransferSchema dr)
        {
            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
            {
                string data = dr.Response.Substring(dr.Response.Length - 2);
                int value = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);
                value = value - 125;
                res = value.ToString();
            }
            if (guardar == true)
            {
                var rowAdded = dataBase.Insert(new DriverDemandEngine_PercentTorque()
                {
                    CreatedOn = DateTime.Now,
                    Percentage = res

                });
            }

            return res;

        }

        public string readActualEnginePercentTorque(DataTransferSchema dr)
        {
            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
            {
                string data = dr.Response.Substring(dr.Response.Length - 2);

                int value = Int32.Parse(data, System.Globalization.NumberStyles.HexNumber);

                value = value - 125;
                res = value.ToString();
            }
            if (guardar == true)
            {
                var rowAdded = dataBase.Insert(new ActualEngine_PercentTorque()
                {
                    CreatedOn = DateTime.Now,
                    PercentageTorque = res

                });
            }

            return res;

        }

        public string readEngineReferenceTorque(DataTransferSchema dr)
        {
            string res;
            if (dr.Response.Equals(NO_DATA))
            {
                res = NO_DATA;
            }
            else
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
                res = value.ToString();
            }
            if (guardar == true)
            {
                var rowAdded = dataBase.Insert(new EngineReferenceTorque()
                {
                    CreatedOn = DateTime.Now,
                    ReferenceTorque = res

                });
            }

            return res;

        }

        public List<string> readEnginePercentTorqueData(DataTransferSchema dr)
        {
            List<string> res = new List<string>();
            string res1;
            string res2;
            string res3;
            string res4;
            string res5;
            if (dr.Response.Equals(NO_DATA))
            {
                res1 = NO_DATA;
                res2 = NO_DATA;
                res3 = NO_DATA;
                res4 = NO_DATA;
                res5 = NO_DATA;
            }
            else
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

                res1 = value1.ToString();
                res2 = value2.ToString();
                res3 = value3.ToString();
                res4 = value4.ToString();
                res5 = value5.ToString();

            }
            if (guardar == true)
            {
                var rowAdded = dataBase.Insert(new EnginePercentTorqueData()
                {
                    CreatedOn = DateTime.Now,
                    PercentageIdle = res1,
                    PercentageEnginePoint1 = res2,
                    PercentageEnginePoint2 = res3,
                    PercentageEnginePoint3 = res4,
                    PercentageEnginePoint4 = res5,


                });
            }

            res.Add(res1);
            res.Add(res2);
            res.Add(res3);
            res.Add(res4);
            res.Add(res5);

            return res;
        }

        public List<DiagnosticTroubleCode> DiagnosticTroubleCodes(DataTransferSchema dr)
        {

            DiagnosticTroubleCode diagnostic;
            List<DiagnosticTroubleCode> codes = new List<DiagnosticTroubleCode>();
            int lineasRespuesta = dr.Response.Split('\n').Length;
            if (dr.Response.Equals("4300\n\n"))
            {

            }
            else if (lineasRespuesta == 3 && dr.Response.Length <= 16)
            {
                //14 de respuesta y 2 de retornos
                string code = "";
                int cont = 0;
                for (int i = 2; i < dr.Response.Length; i++)
                {
                    if (!dr.Response[i].Equals('\n'))
                    {
                        code = code + dr.Response[i];
                        cont++;
                    }
                    if (cont == 4 && (!cont.Equals("0000")))
                    {
                        diagnostic = new DiagnosticTroubleCode(code);
                        codes.Add(diagnostic);
                        var rowAdded = dataBase.Insert(new DTCData()
                        {
                            CreatedOn = DateTime.Now,
                            DtcFound = diagnostic.TroubleCode,

                        });
                        cont = 0;
                        code = "";
                    }

                }
            }
            else
            {
                if (obdiiProtocol.Equals("6") || obdiiProtocol.Equals("7") || obdiiProtocol.Equals("8") || obdiiProtocol.Equals("9") || obdiiProtocol.Equals("A")
                    || obdiiProtocol.Equals("B") || obdiiProtocol.Equals("C"))
                {
                    int saltoLinea = 0;
                    string code = "";
                    int cont = 0;
                    for (int i = 0; i < dr.Response.Length; i++)
                    {
                        if (dr.Response[i].Equals('\n'))
                        {
                            saltoLinea++;
                        }
                        if (saltoLinea == 0)
                        {

                        }
                        if (saltoLinea == 1)
                        {
                            if (dr.Response[i].Equals('\n') || dr.Response[i - 1].Equals('\n') || dr.Response[i - 2].Equals('\n')
                               || dr.Response[i - 2].Equals('\n') || dr.Response[i - 3].Equals('\n') || dr.Response[i - 4].Equals('\n') ||
                                dr.Response[i - 5].Equals('\n'))
                            {

                            }
                            else
                            {
                                code = code + dr.Response[i];
                                cont++;
                            }
                        }
                        if (saltoLinea > 1)
                        {
                            if (dr.Response[i].Equals('\n') || dr.Response[i - 1].Equals('\n'))
                            {

                            }
                            else
                            {
                                code = code + dr.Response[i];
                                cont++;
                            }

                        }
                        if (cont == 4)
                        {
                            diagnostic = new DiagnosticTroubleCode(code);
                            codes.Add(diagnostic);
                            var rowAdded = dataBase.Insert(new DTCData()
                            {
                                CreatedOn = DateTime.Now,
                                DtcFound = diagnostic.TroubleCode,

                            });
                            code = "";
                            cont = 0;
                        }
                    }


                }
                else //if (obdiiProtocol.Contains("J1850")
                {
                    int cont = 0;
                    string code = "";
                    for (int i = 10; i < dr.Response.Length; i++)
                    {
                        if (dr.Response[i].Equals('\n') || dr.Response[i - 1].Equals('\n') || dr.Response[i - 2].Equals('\n'))
                        {

                        }
                        else
                        {
                            code = code + dr.Response[i];
                            cont++;
                        }

                        if (cont == 4)
                        {
                            diagnostic = new DiagnosticTroubleCode(code);
                            codes.Add(diagnostic);
                            var rowAdded = dataBase.Insert(new DTCData()
                            {
                                CreatedOn = DateTime.Now,
                                DtcFound = diagnostic.TroubleCode,

                            });
                            code = "";
                            cont = 0;
                        }
                    }

                }
            }

            return codes;

        }

        public Visibilidad GetVisibilidad()
        {
            return dataBase.Get<Visibilidad>(1);
        }

        public void setVisibilidad(Visibilidad visibilidad)
        {
            dataBase.Update(visibilidad);
        }

    }
}