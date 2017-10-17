using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SmartMonitoring.Droid.Utilidades;
using Android.Content;
using Android.Bluetooth;

namespace SmartMonitoring.Droid
{
    [Activity(Label = "SmartMonitoring", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            BroadcastReceiverBluetooth broadcastReceiver = new BroadcastReceiverBluetooth();

            IntentFilter intentFilter = new IntentFilter();
            intentFilter.AddAction(BluetoothDevice.ActionFound);
            intentFilter.AddAction(BluetoothAdapter.ActionDiscoveryFinished);
            intentFilter.AddAction(BluetoothAdapter.ActionDiscoveryStarted);
            intentFilter.AddAction(BluetoothDevice.ActionPairingRequest);
            RegisterReceiver(broadcastReceiver, intentFilter);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}

