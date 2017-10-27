using SmartMonitoring.OBDII;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartMonitoring
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DiagnosticPage : ContentPage
    {
        List<string> list;
        public DiagnosticPage(DispositivoConectado previousPage)
        {
            list = new List<string>();
            InitializeComponent();
            ToolbarItem regresarToolbar = new ToolbarItem
            {
                Text = "regresar",
                Icon = "drawable/icon.png",
                Order = ToolbarItemOrder.Primary,


            };

            regresarToolbar.Clicked += (sender, e) =>
            {
                App.Current.MainPage = new NavigationPage(previousPage);

            };

            ToolbarItems.Add(regresarToolbar);
            var scan = DependencyService.Get<IConnectionManagement>();
            List<DiagnosticTroubleCode> dtc = scan.DiagnosticCar();
            foreach (DiagnosticTroubleCode d in dtc)
            {
                list.Add(d.TroubleCode);
            }
            // list.Add(new DiagnosticTroubleCode("2133").TroubleCode);
            if (list.Count == 0)
            {

                DisplayAlert("Diagnóstico", "No hay códigos de falla almacenados en la ECU", "OK");


            }
            else
            {
                showDiagnostic();
            }
        }

        public void showDiagnostic()

        {
            var listView = new ListView(ListViewCachingStrategy.RecycleElement);
            Button enviar = new Button();
            enviar.Text = "Enviar Diagnóstico";
            listView.ItemsSource = list;
            ToolbarItem enviarDiagnosticoToolbar = new ToolbarItem
            {
                Text = "Enviar Diagnóstico por Email",
                Icon = "drawable\form.png",
                Order = ToolbarItemOrder.Secondary
            };

            enviarDiagnosticoToolbar.Clicked += (sender, e) =>
            {
                sendDiagnostic(sender, e, list);

            };

            ToolbarItems.Add(enviarDiagnosticoToolbar);


            Label codes = new Label { FontSize = 16 };
            codes.Text = "Códigos OBDII detectados";
            Content = Content = new StackLayout()
            {

                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { codes, listView }
            };
        }

        public void sendDiagnostic(object sender, System.EventArgs e, List<string> list)
        {
            var NetworkManagement = DependencyService.Get<INetworkManagement>();
            NetworkManagement.sendEmail(list);
        }
    }
}