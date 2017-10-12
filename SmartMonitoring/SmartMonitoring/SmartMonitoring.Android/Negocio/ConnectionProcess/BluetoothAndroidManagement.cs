using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Bluetooth;
using Xamarin.Forms;
using System.Threading;
using System.IO;
using SmartMonitoring.Droid.Negocio.ConnectionProcess;
using System;

[assembly: Dependency(typeof(BluetoothAndroidManagement))]
namespace SmartMonitoring.Droid.Negocio.ConnectionProcess
{
    public class BluetoothAndroidManagement : IBluetoothManagement
    {
        static BluetoothAdapter bluetoothAdapter;
        static List<BluetoothDevice> discoveredDevices = new List<BluetoothDevice>();
        BluetoothDevice device = null;
        static BluetoothSocket socket = null;
        private static bool semaforo = true;

        public static bool Semaforo
        {
            get
            {
                return semaforo;
            }

            set
            {
                semaforo = value;
            }
        }

        static public BluetoothAdapter getBluetoothAdapter()
        {
            return bluetoothAdapter;
        }

        public static BluetoothSocket getSocket()
        {
            return socket;
        }

        public string getDevice(string MAC)
        {
            return bluetoothAdapter.GetRemoteDevice(MAC).Name;
        }
        internal static void getScanDevices(BluetoothDevice bd)
        {
            if (bd.Name.Equals("OBDII"))
            {
                discoveredDevices.Add(bd);
                discoveredDevices = discoveredDevices.Distinct().ToList();
            }
        }


        public bool IsOn()
        {
            bool res;
            bluetoothAdapter = BluetoothAdapter.DefaultAdapter;

            if (bluetoothAdapter == null)
            {
                res = false;
            }
            else
            {
                if (!bluetoothAdapter.IsEnabled)
                {
                    Intent visible = new Intent(BluetoothAdapter.ActionRequestEnable);
                    ((Activity)Forms.Context).StartActivityForResult(visible, 0);

                    res = true;

                }
                else
                {

                    res = true;
                }
            }

            return res;
        }

        public bool openConnection(string MAC)
        {
            if (bluetoothAdapter.IsDiscovering)
            {
                bluetoothAdapter.CancelDiscovery();
                System.Console.WriteLine("Sigue DESCUBRIENDO");
            }
            bluetoothAdapter.CancelDiscovery(); //para abrir conexion hay que parar https://developer.android.com/reference/android/bluetooth/BluetoothSocket.html#connect()
            device = bluetoothAdapter.GetRemoteDevice(MAC);


            if (device.BondState == Bond.None)
            {


                bondedDevice(device);



            }

            return Connect(device);
        }

        public async Task<List<string>> scanDevices()
        {
            if (bluetoothAdapter.IsDiscovering)
            {
                bluetoothAdapter.CancelDiscovery();
            }


            bluetoothAdapter.StartDiscovery();
            System.Console.WriteLine("Comienza el descubrimiento");
            await Task.Delay(1000);
            List<string> list = new List<string>();

            
            while (Semaforo == false)
            {
                await Task.Delay(1000);
                Console.WriteLine("Aun está descubriendo");
            }
            foreach (BluetoothDevice currentDevice in discoveredDevices)
            {

                // if (currentDevice.Name.Equals("OBDII")){
                list.Add(currentDevice.Address.ToString());
                // }

            }


            return list;
        }

        public void bondedDevice(BluetoothDevice device)
        {
            bluetoothAdapter.CancelDiscovery(); //para abrir conexion hay que parar https://developer.android.com/reference/android/bluetooth/BluetoothSocket.html#connect()

            bool res = device.CreateBond();
            Thread.Sleep(10000);

        }


        /**
         * Método para establecer la conexión con el dispositivo BT
         * **/
        protected bool Connect(BluetoothDevice device)
        {

            ParcelUuid[] uuids = null;
            bool connected = false;
            if (device.FetchUuidsWithSdp())
            {
                uuids = device.GetUuids();
            }
            if ((uuids != null) && (uuids.Length > 0))
            {
                // Check if there is no socket already
                foreach (var uuid in uuids)
                {

                    // if (bs == null)
                    if (!connected)
                    {
                        try
                        {
                            socket = device.CreateRfcommSocketToServiceRecord(uuid.Uuid);

                        }
                        catch (IOException ex)
                        {
                            throw ex;
                        }
                        //  }

                        try
                        {
                            System.Console.WriteLine("Attempting to connect...");

                            // Create a socket connection
                            socket.Connect();

                            connected = true;
                        }
                        catch
                        {
                            System.Console.WriteLine("Connection failed...");
                            connected = false;
                            System.Console.WriteLine("Attempting to connect...");
                            try
                            {
                                socket = device.CreateInsecureRfcommSocketToServiceRecord(uuid.Uuid);
                                socket.Connect();

                                connected = true;
                            }
                            catch
                            {
                                System.Console.WriteLine("Connection failed...");
                                connected = false;

                            }
                        }
                    }
                }



            }
            if (connected)
            {
                System.Console.WriteLine("Client socket is connected!");
               

            }
            return connected;
        }
    }
}


       