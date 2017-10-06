using Android.Bluetooth;

namespace SmartMonitoring.Droid.Datos
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