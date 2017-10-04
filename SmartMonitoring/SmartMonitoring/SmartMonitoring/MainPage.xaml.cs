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
            
        }

    }
}
