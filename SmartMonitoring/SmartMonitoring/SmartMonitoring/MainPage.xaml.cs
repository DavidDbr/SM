using SmartMonitoring.BBDD;
using SmartMonitoring.OBDII;
using SmartMonitoring.OBDII.Excepciones;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            runBluetooth.IsEnabled = false;
            devices = await scan.scanDevices();
            devices.Distinct().ToString();
            var listView = new ListView(ListViewCachingStrategy.RecycleElement);
            List<ListViewItem> obdii = new List<ListViewItem>();
            foreach(String s in devices)
            {
                obdii.Add(new ListViewItem(s));
            }
             
            listView.ItemsSource = devices.Distinct().ToList();
            listView.ItemTemplate = new DataTemplate(typeof(TextCell));
            listView.ItemTemplate.SetBinding(TextCell.TextProperty,"Showing");
            listView.ItemTemplate.SetValue(TextCell.TextColorProperty, Color.Black);
           
            Label l = new Label();
            l.Text = "Dispositivos OBDII cercanos";
            if (devices.Count != 0)
            {


                Content = Content = new StackLayout
                {

                    VerticalOptions = LayoutOptions.FillAndExpand,
                    Children = { l, listView }
                };

            }
            else
            {
                indicator.IsRunning = false;
                await DisplayAlert("Error", "No hay dispositivos OBDII cercanos", "OK");

            }

            runBluetooth.IsEnabled = true;

            listView.ItemSelected += (sender, e) => { openConnectionDevice(e.SelectedItem.ToString()); };


        }

        private async void openConnectionDevice(String MAC)
        {
            indicator.IsRunning = true;

            var scan = DependencyService.Get<IBluetoothManagement>();
            await Task.Delay(50);
            bool result = await scan.openConnectionAsync(MAC);



            if (result == true)
            {
                indicator.IsRunning = false;
                DispositivoConectado page = new DispositivoConectado(MAC);
                App.Current.MainPage = new NavigationPage(page);

            }
            else
            {
                indicator.IsRunning = false;
                await DisplayAlert("Title", "No se estableció la conexión con el dispositivo", "OK");
                var listView = new ListView(ListViewCachingStrategy.RecycleElement);
                listView.ItemsSource = devices.Distinct();


                Content = Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    Children = { listView, indicator },

                };
                listView.ItemSelected += (sender, e) => openConnectionDevice(e.SelectedItem.ToString());

            }


        }









    }
}





