using Android.Bluetooth;
using SmartMonitoring.OBDII;
using System.Collections.Generic;

namespace SmartMonitoring.Droid.Datos
{
    public interface ISmartMonitoringDAO
    {
        void Initialize();

        string Read();

        void ConsultParameters();

        List<DiagnosticTroubleCode>  DiagnosticCar();

        DataBaseReader getReader();

        List<byte[]> getPids();
    }
}