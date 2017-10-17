using Java.Lang;
using SmartMonitoring.BBDD;
using SmartMonitoring.MVVM;
using SmartMonitoring.OBDII.Excepciones;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;

namespace SmartMonitoring
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
        public partial class ConsultParameters : ContentPage
        { 
        ViewModel vm = null;
        Label RPMResult;
        Label SpeedResult;
        Label EngineTemperatureResult;
        Label TimeEngineStartResult;
        Label AbsoluteBarometricPressureResult;
        Label AbsoluteEvapSystemVaporPressureResult;
        Label AbsoluteLoadValueResult;
        Label AbsoluteThrottlePositionBResult;
        Label AbsoluteThrottlePositionCResult;
        Label AbsoluteThrottlePositionDResult;
        Label AbsoluteThrottlePositionEResult;
        Label AbsoluteThrottlePositionFResult;
        Label CatalystTemperatureB1S1Result;
        Label CatalystTemperatureB1S2Result;
        Label CatalystTemperatureB2S1Result;
        Label CatalystTemperatureB2S2Result;
        Label CommandedEvaporativePurgeResult;
        Label CommandedEGRResult;
        Label CommandedThrottleActuatorValueResult;
        Label DistanceTraveledSinceCodesClearedResult;
        Label DistanceTraveledWithMILoResult;
        Label EGRErrorResult;
        Label EngineFuelRateValueResult;
        Label EngineOilTemperatureResult;
        Label EvapSystemVaporPressureResult;
        Label FuelAirCommandedEquivalenceRatioResult;
        Label FuelInjectionTimingResult;
        Label FuelPressureResult;
        Label FuelRailAbsolutePressureResult;
        Label FuelRailGaugePressureResult;
        Label FuelTankLevelResult;
        Label FuelTypeResult;
        Label HybridBateryPackRemainingLifeResult;
        Label IntakeManifoldAbsolutePressureValueResult;
        Label MAFAirFlowRateResult;
        Label RelativeAcceleratorPedalPositionResult;
        Label RelativeThrottlePositionResult;
        Label ThrottlePositionResult;
        Label TimeRunWithMILOnResult;

        Label RPM;
        Label Speed;
        Label EngineTemperature;
        Label TimeEngineStart;
        Label AbsoluteBarometricPressure;
        Label AbsoluteEvapSystemVaporPressure;
        Label AbsoluteLoadValue;
        Label AbsoluteThrottlePositionB;
        Label AbsoluteThrottlePositionC;
        Label AbsoluteThrottlePositionD;
        Label AbsoluteThrottlePositionE;
        Label AbsoluteThrottlePositionF;
        Label CatalystTemperatureB1S1;
        Label CatalystTemperatureB1S2;
        Label CatalystTemperatureB2S1;
        Label CatalystTemperatureB2S2;
        Label CommandedEvaporativePurge;
        Label CommandedEGR;
        Label CommandedThrottleActuatorValue;
        Label DistanceTraveledSinceCodesCleared;
        Label DistanceTraveledWithMILo;
        Label EGRError;
        Label EngineFuelRateValue;
        Label EngineOilTemperature;
        Label EvapSystemVaporPressure;
        Label FuelAirCommandedEquivalenceRatio;
        Label FuelInjectionTiming;
        Label FuelPressure;
        Label FuelRailAbsolutePressure;
        Label FuelRailGaugePressure;
        Label FuelTankLevel;
        Label FuelType;
        Label HybridBateryPackRemainingLife;
        Label IntakeManifoldAbsolutePressureValue;
        Label MAFAirFlowRate;
        Label RelativeAcceleratorPedalPosition;
        Label RelativeThrottlePosition;
        Label ThrottlePosition;
        Label TimeRunWithMILOn;

        public ConsultParameters()
        {
            InitializeComponent();
            vm = new ViewModel();

            var layout = new StackLayout();
            var grid = new Grid();


            RPM = new Label();
            RPM.Text = "RPM";
            RPMResult = new Label();
            RPMResult.SetBinding(Label.TextProperty, "Rpm");
            Switch rpmSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            rpmSwitch.Toggled += rpmSwitch_Toggled;


            Speed = new Label();
            Speed.Text = "Velocidad";
            SpeedResult = new Label();
            SpeedResult.SetBinding(Label.TextProperty, "Speed");
            Switch speedSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            speedSwitch.Toggled += speedSwitch_Toggled;

            EngineTemperature = new Label();
            EngineTemperature.Text = "Temperatura del Motor";
            EngineTemperatureResult = new Label();
            EngineTemperatureResult.SetBinding(Label.TextProperty, "EngineTemperature");
            Switch engineTemperatureSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            engineTemperatureSwitch.Toggled += engineTemperatureSwitch_Toggled;

            TimeEngineStart = new Label();
            TimeEngineStart.Text = "Time Engine Start";
            TimeEngineStartResult = new Label();
            TimeEngineStartResult.SetBinding(Label.TextProperty, "TimeEngineStart");
            Switch timeEngineStartSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            timeEngineStartSwitch.Toggled += timeEngineStartSwitch_Toggled;

            HybridBateryPackRemainingLife = new Label();
            HybridBateryPackRemainingLife.Text="Batería Híbrida Restante";
            HybridBateryPackRemainingLifeResult = new Label();
            HybridBateryPackRemainingLifeResult.SetBinding(Label.TextProperty, "HybridBateryPackRemainingLife");
            Switch hybridbaterySwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            hybridbaterySwitch.Toggled += hybridbaterySwitch_Toggled;

            AbsoluteBarometricPressure = new Label();
            AbsoluteBarometricPressure.Text = "Presión barométrica";
            AbsoluteBarometricPressureResult = new Label();
            HybridBateryPackRemainingLifeResult.SetBinding(Label.TextProperty, "AbsoluteBarometricPressure");
            Switch absolutebarometricpressureSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            absolutebarometricpressureSwitch.Toggled += absolutebarometricpressureSwitch_Toggled;

            AbsoluteEvapSystemVaporPressure = new Label();
            AbsoluteEvapSystemVaporPressure.Text = "Presión de vapor de Sist. Evaporativo";
            AbsoluteEvapSystemVaporPressureResult = new Label();
            AbsoluteEvapSystemVaporPressureResult.SetBinding(Label.TextProperty, "AbsoluteEvapSystemVaportPressure");
            Switch absoluteEvapSystemVaporPressureSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            absoluteEvapSystemVaporPressureSwitch.Toggled += absoluteEvapSystemVaporPressureSwitch_Toggled;

            AbsoluteLoadValue = new Label();
            AbsoluteLoadValue.Text = "Valor absoluto de carga";
            AbsoluteLoadValueResult = new Label();
            AbsoluteLoadValueResult.SetBinding(Label.TextProperty, "AbsoluteLoadValue");
            Switch absoluteLoadValueSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            absoluteLoadValueSwitch.Toggled += absoluteLoadValueSwitch_Toggled;

            AbsoluteThrottlePositionB = new Label();
            AbsoluteThrottlePositionB.Text = "Valor absoluto de carga";
            AbsoluteThrottlePositionBResult = new Label();
            AbsoluteThrottlePositionBResult.SetBinding(Label.TextProperty, "AbsoluteThrottlePositionB");
            Switch absoluteThrottlePositionBSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            absoluteThrottlePositionBSwitch.Toggled += absoluteThrottlePositionBSwitch_Toggled;

            AbsoluteThrottlePositionC = new Label();
            AbsoluteThrottlePositionC.Text = "Valor absoluto de carga";
            AbsoluteThrottlePositionCResult = new Label();
            AbsoluteThrottlePositionCResult.SetBinding(Label.TextProperty, "AbsoluteThrottlePositionC");
            Switch absoluteThrottlePositionCSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            absoluteThrottlePositionCSwitch.Toggled += absoluteThrottlePositionCSwitch_Toggled;

            AbsoluteThrottlePositionD = new Label();
            AbsoluteThrottlePositionD.Text = "Valor absoluto de carga";
            AbsoluteThrottlePositionDResult = new Label();
            AbsoluteThrottlePositionDResult.SetBinding(Label.TextProperty, "AbsoluteThrottlePositionD");
            Switch absoluteThrottlePositionDSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            absoluteThrottlePositionDSwitch.Toggled += absoluteThrottlePositionDSwitch_Toggled;

            AbsoluteThrottlePositionE = new Label();
            AbsoluteThrottlePositionE.Text = "Valor absoluto de carga";
            AbsoluteThrottlePositionEResult = new Label();
            AbsoluteThrottlePositionEResult.SetBinding(Label.TextProperty, "AbsoluteThrottlePositionE");
            Switch absoluteThrottlePositionESwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            absoluteThrottlePositionESwitch.Toggled += absoluteThrottlePositionESwitch_Toggled;

            AbsoluteThrottlePositionF = new Label();
            AbsoluteThrottlePositionF.Text = "Valor absoluto de carga";
            AbsoluteThrottlePositionFResult = new Label();
            AbsoluteThrottlePositionFResult.SetBinding(Label.TextProperty, "AbsoluteThrottlePositionB");
            Switch absoluteThrottlePositionFSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            absoluteThrottlePositionFSwitch.Toggled += absoluteThrottlePositionFSwitch_Toggled;

            CatalystTemperatureB1S1 = new Label();
            CatalystTemperatureB1S1.Text = "Valor absoluto de carga";
            CatalystTemperatureB1S1Result = new Label();
            CatalystTemperatureB1S1Result.SetBinding(Label.TextProperty, "CatalystTemperatureB1S1");
            Switch catalystTemperatureB1S1Switch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            catalystTemperatureB1S1Switch.Toggled += catalystTemperatureB1S1Switch_Toggled;

            CatalystTemperatureB1S2 = new Label();
            CatalystTemperatureB1S2.Text = "Valor absoluto de carga";
            CatalystTemperatureB1S2Result = new Label();
            CatalystTemperatureB1S2Result.SetBinding(Label.TextProperty, "CatalystTemperatureB1S2");
            Switch catalystTemperatureB1S2Switch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            catalystTemperatureB1S2Switch.Toggled += catalystTemperatureB1S2Switch_Toggled;

            CatalystTemperatureB2S1 = new Label();
            CatalystTemperatureB2S1.Text = "Valor absoluto de carga";
            CatalystTemperatureB2S1Result = new Label();
            CatalystTemperatureB2S1Result.SetBinding(Label.TextProperty, "CatalystTemperatureB2S1");
            Switch catalystTemperatureB2S1Switch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            catalystTemperatureB2S1Switch.Toggled += catalystTemperatureB2S1Switch_Toggled;

            CommandedEvaporativePurge = new Label();
            CommandedEvaporativePurge.Text = "Valor absoluto de carga";
            CommandedEvaporativePurgeResult = new Label();
            CommandedEvaporativePurgeResult.SetBinding(Label.TextProperty, "CommanddEvaporativePurge");
            Switch commandedEvaporativePurgeSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            commandedEvaporativePurgeSwitch.Toggled += commandedEvaporativePurgeSwitch_Toggled;

             



            Button b = new Button();
            b.Text = "Stop";
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
            b.Clicked += (sender, e) => vm.T.Stop();
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
            
            
            BindingContext = vm;
                  

           
           

         

            /*  Content = Content = new StackLayout()
              {
                  VerticalOptions = LayoutOptions.FillAndExpand,
                  Children = { RPM, RPMResult, Speed, SpeedResult, EngineTemperature, EngineTemperatureResult,
                             TimeEngineStartLabel, TimeEngineStartResult }

              };*/

            grid.Children.Add(RPM, 0, 0);
            grid.Children.Add(RPMResult, 1, 0);
            grid.Children.Add(rpmSwitch, 2, 0);
            grid.Children.Add(Speed, 0, 1);
            grid.Children.Add(speedSwitch, 2, 1);
            grid.Children.Add(SpeedResult, 1, 1);
            grid.Children.Add(HybridBateryPackRemainingLife, 0, 2);
            grid.Children.Add(hybridbaterySwitch, 2, 2);
            grid.Children.Add(HybridBateryPackRemainingLifeResult, 1, 2);
            grid.Children.Add(TimeEngineStart, 0, 3);
            grid.Children.Add(TimeEngineStartResult, 1, 3);
            grid.Children.Add(timeEngineStartSwitch, 2, 3);
            layout.Children.Add(grid);
            Content = new ScrollView()
            {
                Content = layout,
            };

            

        }

        private void commandedEvaporativePurgeSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            CommandedEvaporativePurgeResult.IsVisible = e.Value;
        }

        private void catalystTemperatureB1S2Switch_Toggled(object sender, ToggledEventArgs e)
        {
            CatalystTemperatureB1S2Result.IsVisible = e.Value;
        }

        private void catalystTemperatureB2S1Switch_Toggled(object sender, ToggledEventArgs e)
        {
            CatalystTemperatureB2S1Result.IsVisible = e.Value;
        }

        private void catalystTemperatureB2S2Switch_Toggled(object sender, ToggledEventArgs e)
        {
            CatalystTemperatureB2S2Result.IsVisible = e.Value;
        }

        private void catalystTemperatureB1S1Switch_Toggled(object sender, ToggledEventArgs e)
        {
            CatalystTemperatureB1S1Result.IsVisible = e.Value;
        }

        private void absoluteThrottlePositionDSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            AbsoluteThrottlePositionDResult.IsVisible = e.Value;
        }

        private void absoluteThrottlePositionESwitch_Toggled(object sender, ToggledEventArgs e)
        {
            AbsoluteThrottlePositionEResult.IsVisible = e.Value;
        }

        private void absoluteThrottlePositionBSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            AbsoluteThrottlePositionBResult.IsVisible = e.Value;
        }

        private void absoluteThrottlePositionCSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            AbsoluteThrottlePositionCResult.IsVisible = e.Value;
        }

        private void absoluteThrottlePositionFSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            AbsoluteThrottlePositionFResult.IsVisible = e.Value;
        }

        private void absoluteLoadValueSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            AbsoluteLoadValue.IsVisible = e.Value;
        }

        private void absoluteEvapSystemVaporPressureSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            AbsoluteBarometricPressureResult.IsVisible = e.Value;
        }

        private void absolutebarometricpressureSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            AbsoluteBarometricPressureResult.IsVisible = e.Value;
        }

        private void timeEngineStartSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            TimeEngineStartResult.IsVisible = e.Value;
        }

        private void engineTemperatureSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            EngineTemperatureResult.IsVisible = e.Value;
        }

        private void hybridbaterySwitch_Toggled(object sender, ToggledEventArgs e)
        {
            HybridBateryPackRemainingLifeResult.IsVisible = e.Value;
        }

        private void speedSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            SpeedResult.IsVisible = e.Value;
        }

        private void rpmSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            RPMResult.IsVisible = e.Value;
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
