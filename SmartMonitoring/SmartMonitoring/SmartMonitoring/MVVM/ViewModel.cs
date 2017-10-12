using Java.Lang;
using SmartMonitoring.BBDD;
using SmartMonitoring.OBDII.Excepciones;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace SmartMonitoring.MVVM
{
    public class ViewModel : INotifyPropertyChanged
    {
        private string speed;
        private string rpm;
        private string engineTemperature;
        private string timeEngineStart;
        private Thread t;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string Speed
        {
            get
            {
                return speed;
            }

            set
            {
                speed = value;
                OnPropertyChanged("Speed");
            }
        }

        public string Rpm
        {
            get
            {
                return rpm;
            }

            set
            {
                rpm = value;
                OnPropertyChanged("Rpm");
            }
        }

        public Thread T { get => t; set => t = value; }
        public string EngineTemperature { get => engineTemperature; set => engineTemperature = value; }
        public string TimeEngineStart { get => timeEngineStart; set => timeEngineStart = value; }

        public ViewModel()
        {

            T = new Thread(consultParameters);
            T.Start();
        }

        public void consultParameters()
        {
            var scan = DependencyService.Get<IConnectionManagement>();
            // string parameter = scan.consultParameters();

            var database = DependencyService.Get<ISQLite>();
            var connection = database.GetConnection();

            try
            {
                scan.ConsultParameters();
            }
            catch (UnableToConnectException u)
            {
                //  DisplayAlert("Title", "No se puede conectar a la ECU", "OK");
            }
            catch (NoDataException u)
            {
                //  DisplayAlert("Title", "No hay datos disponibles", "OK");
            }
            catch (StoppedException u)
            {
                //  DisplayAlert("Title", "El dispositivo OBDII se ha detenido", "OK");
            }

            int contador = 0;
            while (contador < 50)
            {
                contador = contador + 1;
            }

            while (true)
            {

                Speed = scan.getLastSpeed().ToString();
                Rpm = scan.getLastRPM().ToString();
                EngineTemperature = scan.getLastEngineTemperature();
                TimeEngineStart = scan.getLastEngineStartTime();
         //       Debug.WriteLine("Last rmp: " + Rpm);
            }


        }

    }
}
