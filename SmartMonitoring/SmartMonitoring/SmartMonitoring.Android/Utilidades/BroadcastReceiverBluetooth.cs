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
    [IntentFilter(new[] { BluetoothDevice.ActionPairingRequest })]
    public class BroadcastReceiverBluetooth : BroadcastReceiver
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

                BluetoothAndroidManagement.getScanDevices(device);

            }

            if (BluetoothAdapter.ActionDiscoveryFinished.Equals(action))
            {
                BluetoothAndroidManagement.Semaforo = true;
                Console.WriteLine("DescubrimientoFinalizado");

            }
            if (BluetoothAdapter.ActionDiscoveryStarted.Equals(action))
            {
                BluetoothAndroidManagement.Semaforo = false;
                Console.WriteLine("DescubrimientoIniciado");

            }
            if (BluetoothDevice.ActionPairingRequest.Equals(action))
            {
                device = (BluetoothDevice)intent.GetParcelableExtra(BluetoothDevice.ExtraDevice);
                int extraPairingVariant = intent.GetIntExtra(BluetoothDevice.ExtraPairingVariant, 0);
                int pin = intent.GetIntExtra(BluetoothDevice.ExtraPairingKey, 0);
                switch (extraPairingVariant)
                {
                    case BluetoothDevice.PairingVariantPin: // 0
                        TrySetPin(device, "1234");
                        //device.SetPairingConfirmation(false);
                        break;
                    case BluetoothDevice.PairingVariantPasskeyConfirmation: // 2
                                                                            //we don't care for this scenario
                        break;
                }
            }
        }
        private static bool TrySetPin(BluetoothDevice device, string pin)
        {
            try
            {
                return device.SetPin(PinToByteArray(pin));
            }
            catch
            {
                return false;
            }
        }

        private static byte[] PinToByteArray(string pin)
        {
            return System.Text.Encoding.UTF8.GetBytes(pin);
        }
    }
}