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
using SmartMonitoring.Droid.Datos;

namespace SmartMonitoring.Droid
{
    public interface ISmartMonitoringDAO
    {
        void Initialize();

        string Read();

        void ConsultParameters();

        string DiagnosticCar();

        DataBaseReader getReader();
    }
}