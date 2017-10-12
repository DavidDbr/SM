using SmartMonitoring.BBDD;
using SmartMonitoring.MVVM;
using SmartMonitoring.OBDII.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmartMonitoring
{
    public partial class MainPage : ContentPage
    { 
        List<string> devices;
        public MainPage()
        {
            InitializeComponent();
            InitializeBluetooth();
        }

        //INICIALIZAR
        private void InitializeBluetooth()
        {
            bool res = false;


            var typeB = DependencyService.Get<IBluetoothManagement>();

            res = typeB.IsOn();

            if (res == false)
            {
                DisplayAlert("Title", "El dispositivo no dispone de BT", "OK");

            }
            else
            {
                // DisplayAlert("Title", "BT active", "OK");
                //scanDevices();
            }



        }
        //CLICKED
        private async void scanDevices(object sender1, EventArgs e1)
        {
            indicator.IsRunning = true;
            var scan = DependencyService.Get<IBluetoothManagement>();
            runBluetooth.IsEnabled = false;
            devices = await scan.scanDevices();
            devices.Distinct().ToString();
            var listView = new ListView(ListViewCachingStrategy.RecycleElement);
            listView.ItemsSource = devices.Distinct().ToList();
            ActivityIndicator indicator2 = new ActivityIndicator();
            //   listView.ItemSelected += (object sender, ItemClickEventArgs e) => { String selectedFromList = lv.GetItemAtPosition(e.Position); };
            // Content = listView;
            if (devices.Count != 0)
            {
                indicator.IsRunning = false;
                
                // DisplayAlert("Title", devices.ElementAt(0), "OK");
                Content = Content = new StackLayout 
                {
                    
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    Children = { listView, indicator2 }
                };
                
            }
            else
            {
                indicator.IsRunning = false;
                await DisplayAlert("Error", "No hay dispositivos OBDII cercanos", "OK");
                
            }
            
            runBluetooth.IsEnabled = true;

            listView.ItemSelected += (sender, e) => { openConnectionDevice(e.SelectedItem.ToString()); indicator2.IsRunning = true; };


            }

        private void openConnectionDevice(String MAC)
        {
            indicator.IsRunning = true;
            var scan = DependencyService.Get<IBluetoothManagement>();
            bool result = scan.openConnection(MAC);
            if (result == true)
            {
                indicator.IsRunning = false;
                inConnection(MAC);

            }
            else
            {
                indicator.IsRunning = false;
                DisplayAlert("Title", "No se estableció la conexión con el dispositivo", "OK");
                var listView = new ListView(ListViewCachingStrategy.RecycleElement);
                listView.ItemsSource = devices.Distinct();

                Content = Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    Children = { listView },
                    
            };
                listView.ItemSelected += (sender, e) => openConnectionDevice(e.SelectedItem.ToString());
                
            }


        }

        private void inConnection(String MAC)
        {
            indicator.IsRunning = false;
            var scan = DependencyService.Get<IBluetoothManagement>();
            var database = DependencyService.Get<ISQLite>();
            var connect = DependencyService.Get<IConnectionManagement>();
            try
            {
                connect.InitializedOBD2();
            }
            catch (UnableToConnectException u)
            {
                DisplayActionSheet("Error", "No se puede conectar a la ECU", "OK");
            }
            database.GetConnection();
            database.initBBDD();
            Label label = new Label();
            string nameDevice = scan.getDevice(MAC);
            // scan.initializedOBD2();
            Button consultTR = new Button();
            consultTR.Text = " Consultar Parámetros";
            ConsultParameters page = null;
            // consultTR.Clicked += (sender, e) => consultParameters();
            consultTR.Clicked += (sender, e) =>
            {
                
                page = new ConsultParameters();
                App.Current.MainPage = new NavigationPage(page);
                
                        
                              
            };
            Button diagnostic = new Button();
            diagnostic.Text = "Diagnóstico";
            diagnostic.Clicked += (sender, e) => diagnosticCar();
            label.Text = ("Connected to " + nameDevice + " MAC: " + MAC);
            Content = Content = new StackLayout()
            {

                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { label, consultTR, diagnostic }
            };          
        }




        /*private void consultParameters()
        {
            var connect = DependencyService.Get<IConnectionManagement>();
            connect.ConsultParameters();
        }*/


        // DisplayAlert("Consult Parameters", "Su velocidad es"+parameter, "OK");



        private void diagnosticCar()
        {

            var scan = DependencyService.Get<IConnectionManagement>();
            string troubles = scan.DiagnosticCar();
        }
    }
}

    



