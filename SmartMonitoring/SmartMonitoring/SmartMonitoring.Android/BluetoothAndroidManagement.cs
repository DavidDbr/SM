using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Bluetooth;
using Xamarin.Forms;
using System.Threading;
using SmartMonitoring.Droid;

[assembly: Dependency(typeof(BluetoothAndroidManagement))]
namespace SmartMonitoring.Droid
{
    public class BluetoothAndroidManagement : IBluetoothManagement
    {
        static BluetoothAdapter bluetoothAdapter;
        static List<BluetoothDevice> discoveredDevices = new List<BluetoothDevice>();

        static public BluetoothAdapter getBluetoothAdapter()
        {
            return bluetoothAdapter;
        }

        public string getDevice(string MAC)
        {
            throw new NotImplementedException();
        }
        internal static void getScanDevices(BluetoothDevice bd)
        {
            discoveredDevices.Add(bd);
            discoveredDevices = discoveredDevices.Distinct().ToList();
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
            throw new NotImplementedException();
        }

        public async Task<List<string>> scanDevices()
        {
            if (bluetoothAdapter.IsDiscovering)
            {
                bluetoothAdapter.CancelDiscovery();
            }


            bluetoothAdapter.StartDiscovery();
            System.Console.WriteLine("Comienza el descubrimiento");
            Thread.Sleep(2000);
            List<string> list = new List<string>();

            await Task.Delay(8000);
            foreach (BluetoothDevice currentDevice in discoveredDevices)
            {

                // if (currentDevice.Name.Equals("OBDII")){
                list.Add(currentDevice.Address.ToString());
                // }

            }


            return list;
        }
    }
}