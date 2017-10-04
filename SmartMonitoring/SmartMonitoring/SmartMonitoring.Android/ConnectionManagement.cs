using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Bluetooth;

namespace SmartMonitoring.Droid
{
    public class ConnectionManagement
    {
        BluetoothSocket socket = null;
      
        ISmartMonitoringDAO dao;


        public ConnectionManagement(BluetoothSocket socket)
        {

            this.socket = socket;
            dao = new SmartMonitoringDAO(socket);
            dao.Initialize();
           

        }

        public void ConsultParameters()
        {
            dao.ConsultParameters();
        }

        public string DiagnosticCar()
        {
            return dao.DiagnosticCar();
        }

        public void InitializedOBD2()
        {
            dao.Initialize();
        }

      
    }
}