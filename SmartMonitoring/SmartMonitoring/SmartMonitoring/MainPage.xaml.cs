using SmartMonitoring.BBDD;
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

            var scan = DependencyService.Get<IBluetoothManagement>();
            //como hacer que espere
            devices = await scan.scanDevices();
            devices.Distinct().ToString();
            var listView = new ListView(ListViewCachingStrategy.RecycleElement);
            listView.ItemsSource = devices.Distinct().ToList();

            //   listView.ItemSelected += (object sender, ItemClickEventArgs e) => { String selectedFromList = lv.GetItemAtPosition(e.Position); };
            // Content = listView;
            if (devices.Count != 0)
            {
                // DisplayAlert("Title", devices.ElementAt(0), "OK");
                Content = Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    Children = { listView }
                };
            }
            else
            {
                await DisplayAlert("Title", "No hay dispositivos", "OK");
            }
            listView.ItemSelected += (sender, e) => openConnectionDevice(e.SelectedItem.ToString());

        }

        private void openConnectionDevice(String MAC)
        {

            var scan = DependencyService.Get<IBluetoothManagement>();
            bool result = scan.openConnection(MAC);
            if (result == true)
            {
                inConnection(MAC);

            }
            else
            {
                DisplayAlert("Title", "No se estableció la conexión con el dispositivo", "OK");
                var listView = new ListView(ListViewCachingStrategy.RecycleElement);
                listView.ItemsSource = devices;

                Content = Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    Children = { listView }
                };
            }


        }

        private void inConnection(String MAC)
        {
            var scan = DependencyService.Get<IBluetoothManagement>();
            var database = DependencyService.Get<ISQLite>();
            var connect = DependencyService.Get<IConnectionManagement>();
            connect.InitializedOBD2();
            database.GetConnection();
            database.initBBDD();
            Label label = new Label();
            string nameDevice = scan.getDevice(MAC);
            // scan.initializedOBD2();
            Button consultTR = new Button();
            consultTR.Text = " Consultar Parámetros";
            consultTR.Clicked += (sender, e) => consultParameters();
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




        private void consultParameters()
        {
            var scan = DependencyService.Get<IConnectionManagement>();
            scan.ConsultParameters();
        }


        // DisplayAlert("Consult Parameters", "Su velocidad es"+parameter, "OK");



        private void diagnosticCar()
        {

            var scan = DependencyService.Get<IConnectionManagement>();
            string troubles = scan.DiagnosticCar();
        }
    }
}

    



