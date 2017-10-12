using Java.Lang;
using SmartMonitoring.BBDD;
using SmartMonitoring.MVVM;
using SmartMonitoring.OBDII.Excepciones;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartMonitoring
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
        public partial class ConsultParameters : ContentPage
        { 
        ViewModel vm = null;
            /*IConnectionManagement scan;
            ISQLite database;*/
        public ConsultParameters()
        {
            InitializeComponent();
            vm = new ViewModel();

            TableRoot results = new TableRoot();
            TableSection parametros = new TableSection();
            TableSection valores = new TableSection();
            results.Add(parametros);
            results.Add(valores);
            Cell RPMCell = new TextCell
            {
                Text = "RPMCell",
            };
            Cell RPMResultCell = new TextCell();
            RPMResultCell.SetBinding(Label.TextProperty, "Rpm");
            parametros.Add(RPMCell);
            valores.Add(RPMResultCell);



            Label RPM = new Label();
            RPM.Text = "RPM";
            Label Speed = new Label();
            Speed.Text = "Velocidad";
            Label EngineTemperature = new Label();
            EngineTemperature.Text = "Temperatura del Motor";
            Label EngineTemperatureResult = new Label();
            EngineTemperatureResult.SetBinding(Label.TextProperty, "EngineTemperature");

            Label TimeEngineStartLabel = new Label();
            TimeEngineStartLabel.Text = "Time Engine Start";

            Label TimeEngineStartResult = new Label();
            TimeEngineStartResult.SetBinding(Label.TextProperty, "TimeEngineStart");  

            Button b = new Button();
            b.Text = "Stop";
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
            b.Clicked += (sender, e) => vm.T.Stop();
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
            Label RPMResult = new Label();
            RPMResult.Text = "0";
            RPMResult.IsVisible = true;
            Label SpeedResult = new Label();
            RPMResult.Text = "0";
            RPMResult.SetBinding(Label.TextProperty, "Rpm");
            SpeedResult.SetBinding(Label.TextProperty, "Speed");
            BindingContext = vm;
            //RPMResult.BindingContext = vm.Rpm;
            /*ContentPage resultados = new ContentPage
            {
                Content = new TableView
                {
                    Intent = TableIntent.Form,
                    Root = results

                }
            };*/
            RPMResult.TextColor = Color.Black;
            Content = Content = new StackLayout()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { RPM, RPMResult, Speed, SpeedResult, EngineTemperature, EngineTemperatureResult,
                           TimeEngineStartLabel, TimeEngineStartResult }
            };

            

        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();
           // BindingContext = vm;
            Thread t = new Thread(launchVM);
            
            t.Start();
        }

        private void launchVM()
        {
            
           
            vm.consultParameters();
        }
    }
    }
