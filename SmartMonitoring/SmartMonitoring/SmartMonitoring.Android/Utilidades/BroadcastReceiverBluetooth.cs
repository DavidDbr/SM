using System;

using Android.App;
using Android.Content;
using Android.Bluetooth;
using SmartMonitoring.Droid.Negocio.ConnectionProcess;

namespace SmartMonitoring.Droid.Utilidades
{
    [BroadcastReceiver(Enabled = true, Label = "Receiver Label")]
    [IntentFilter(new[] { BluetoothDevice.ActionFound })]
    [IntentFilter(new[] { BluetoothAdapter.ActionDiscoveryFinished })]
    [IntentFilter(new[] { BluetoothAdapter.ActionDiscoveryStarted })]
    class BroadcastReceiverBluetooth : BroadcastReceiver
    {
        BluetoothDevice device;
        BluetoothAdapter ba = BluetoothAdapter.DefaultAdapter;

        public override void OnReceive(Context context, Intent intent)
        {
            String action = intent.Action;

            if (BluetoothDevice.ActionFound.Equals(action))
            {

                device = (BluetoothDevice)intent.GetParcelableExtra(BluetoothDevice.ExtraDevice);
                Console.WriteLine(device.Name);
                // if (device.Name.Equals("OBDII"))
                //  {

                
                BluetoothAndroidManagement.getScanDevices(device);
                //}
            }

            if (BluetoothAdapter.ActionDiscoveryFinished.Equals(action))
            {
                BluetoothAndroidManagement.Semaforo = true;
                Console.WriteLine("DescubrimientoFinalizado");
                //BluetoothAndroid.setDiscovery(true);
            }
            if (BluetoothAdapter.ActionDiscoveryStarted.Equals(action))
            {
                BluetoothAndroidManagement.Semaforo = false;
                Console.WriteLine("DescubrimientoIniciado");
                //  BluetoothAndroid.setDiscovery(false);
            }
        }
    }
}