using SmartMonitoring.BBDD;
using SmartMonitoring.OBDII.Excepciones;
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
    public partial class DispositivoConectado : ContentPage
    {
        public DispositivoConectado(string MAC)
        {

            InitializeComponent();
            

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
            connect.getVisibilidad();
            string nameDevice = scan.getDevice(MAC);
            Button consultTR = new Button();
            FileImageSource consultTRImage = new FileImageSource { File = "dashboard.png" };
            FileImageSource diagnosticImage = new FileImageSource { File = "diagnostic.png" };
            consultTR.Text = " Consultar Parámetros";
            consultTR.HorizontalOptions = LayoutOptions.Center;
            consultTR.VerticalOptions = LayoutOptions.Center;
            consultTR.Image = consultTRImage;
            consultTR.Clicked += (sender, e) =>
            {

                ConsultParameters page = new ConsultParameters(this);
                if (connect.getEstadoConsultar() == false)
                {
                    connect.setEstadoConsultar(true);
                }

                App.Current.MainPage = new NavigationPage(page);


            };
            Button diagnostic = new Button();
            diagnostic.Text = "Diagnóstico";
            diagnostic.HorizontalOptions = LayoutOptions.Center;
            diagnostic.VerticalOptions = LayoutOptions.Center;
            diagnostic.Image = diagnosticImage;
            diagnostic.Clicked += (sender, e) =>
            {

                DiagnosticPage page = new DiagnosticPage(this);
                App.Current.MainPage = new NavigationPage(page);

            };
            

            Content = Content = new StackLayout()
            {

                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = {consultTR, diagnostic }
            };

        }
    }
}