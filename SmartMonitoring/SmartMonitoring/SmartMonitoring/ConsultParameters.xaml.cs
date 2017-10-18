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
        Label ControlModuleVoltage;
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
        Label ControlModuleVoltageResult;
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
            AbsoluteThrottlePositionB.Text = "Posición absoluta acelerador B";
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
            AbsoluteThrottlePositionC.Text = "Posición absoluta acelerador C";
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
            AbsoluteThrottlePositionD.Text = "Posición absoluta acelerador D";
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
            AbsoluteThrottlePositionE.Text = "Posición absoluta acelerador E";
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
            AbsoluteThrottlePositionF.Text = "Posición absoluta acelerador E";
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
            CatalystTemperatureB1S1.Text = "Temperatura Catalizador Banco:1 Sensor:1";
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
            CatalystTemperatureB1S2.Text = "Temperatura Catalizador Banco:1 Sensor:2";
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
            CatalystTemperatureB2S1.Text = "Temperatura Catalizador Banco:2 Sensor:1";
            CatalystTemperatureB2S1Result = new Label();
            CatalystTemperatureB2S1Result.SetBinding(Label.TextProperty, "CatalystTemperatureB2S1");
            Switch catalystTemperatureB2S1Switch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            catalystTemperatureB2S1Switch.Toggled += catalystTemperatureB2S1Switch_Toggled;

            CatalystTemperatureB2S2 = new Label();
            CatalystTemperatureB2S2.Text = "Temperatura Catalizador Banco:2 Sensor:2";
            CatalystTemperatureB2S2Result = new Label();
            CatalystTemperatureB2S2Result.SetBinding(Label.TextProperty, "CatalystTemperatureB2S2");
            Switch catalystTemperatureB2S2Switch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            catalystTemperatureB2S2Switch.Toggled += catalystTemperatureB2S2Switch_Toggled;

            CommandedEvaporativePurge = new Label();
            CommandedEvaporativePurge.Text = "Purga evaporativa comandada";
            CommandedEvaporativePurgeResult = new Label();
            CommandedEvaporativePurgeResult.SetBinding(Label.TextProperty, "CommanddEvaporativePurge");
            Switch commandedEvaporativePurgeSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            commandedEvaporativePurgeSwitch.Toggled += commandedEvaporativePurgeSwitch_Toggled;

            CommandedThrottleActuatorValue = new Label();
            CommandedThrottleActuatorValue.Text = "	Actuador comandando del acelerador";
            CommandedThrottleActuatorValueResult = new Label();
            CommandedThrottleActuatorValueResult.SetBinding(Label.TextProperty, "CommandedThrottleActuatorValue");
            Switch commandedThrottleActuatorValueSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            commandedThrottleActuatorValueSwitch.Toggled += commandedThrottleActuatorValueSwitch_Toggled;

            ControlModuleVoltage = new Label();
            ControlModuleVoltage.Text = "Voltaje del módulo de control";
            ControlModuleVoltageResult = new Label();
            ControlModuleVoltageResult.SetBinding(Label.TextProperty, "ControlModuleVoltage");
            Switch controlModuleVoltageSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            controlModuleVoltageSwitch.Toggled += controlModuleVoltageSwitchh_Toggled;


            DistanceTraveledSinceCodesCleared = new Label();
            DistanceTraveledSinceCodesCleared.Text = "Distancia recorrida desde borrado de fallas";
            DistanceTraveledSinceCodesClearedResult = new Label();
            DistanceTraveledSinceCodesClearedResult.SetBinding(Label.TextProperty, "DistanceTraveledSinceCodesCleared");
            Switch distanceTraveledSinceCodesClearedResultSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            distanceTraveledSinceCodesClearedResultSwitch.Toggled += distanceTraveledSinceCodesClearedResultSwitch_Toggled;

            DistanceTraveledWithMILo = new Label();
            DistanceTraveledWithMILo.Text = "Distancia recorrida con MIL encendido";
            DistanceTraveledWithMILoResult = new Label();
            DistanceTraveledWithMILoResult.SetBinding(Label.TextProperty, "DistanceTraveledWithMILo");
            Switch distanceTraveledWithMILoSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            distanceTraveledWithMILoSwitch.Toggled += distanceTraveledWithMILoSwitch_Toggled;


            EGRError = new Label();
            EGRError.Text = "Falla EGR";
            EGRErrorResult = new Label();
            EGRErrorResult.SetBinding(Label.TextProperty, "EGRError1");
            Switch egrErrorSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            egrErrorSwitch.Toggled += egrErrorSwitch_Toggled;

            EngineFuelRateValue = new Label();
            EngineFuelRateValue.Text = "Velocidad de combustible del motor";
            EngineFuelRateValueResult = new Label();
            EngineFuelRateValueResult.SetBinding(Label.TextProperty, "EngineFuelRateValue");
            Switch engineFuelRateValueSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            engineFuelRateValueSwitch.Toggled += engineFuelRateValueSwitch_Toggled;

            EngineOilTemperature = new Label();
            EngineOilTemperature.Text = "Temperatura del aceite del motor";
            EngineOilTemperatureResult = new Label();
            EngineOilTemperatureResult.SetBinding(Label.TextProperty, "EngineOilTemperature");
            Switch engineOilTemperatureSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            engineOilTemperatureSwitch.Toggled += engineOilTemperatureSwitch_Toggled;
        
            EvapSystemVaporPressure = new Label();
            EvapSystemVaporPressure.Text = "Presión del vapor del sistema de evaporación";
            EvapSystemVaporPressureResult = new Label();
            EngineOilTemperatureResult.SetBinding(Label.TextProperty, "EvapSystemVaporPressure");
            Switch evapSystemVaporPressureSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            evapSystemVaporPressureSwitch.Toggled += evapSystemVaporPressureSwitch_Toggled;

            FuelAirCommandedEquivalenceRatio = new Label();
            FuelAirCommandedEquivalenceRatio.Text = "Relación equivaliente comandada de combustible - aire";
            FuelAirCommandedEquivalenceRatioResult = new Label();
            FuelAirCommandedEquivalenceRatioResult.SetBinding(Label.TextProperty, "FuelAirCommandedEquivalenceRatio");
            Switch fuelAirCommandedEquivalenceRatioSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            fuelAirCommandedEquivalenceRatioSwitch.Toggled += fuelAirCommandedEquivalenceRatioSwitch_Toggled;

            FuelInjectionTiming = new Label();
            FuelInjectionTiming.Text = "Sincronización de la inyección de combustible";
            FuelInjectionTimingResult = new Label();
            FuelInjectionTimingResult.SetBinding(Label.TextProperty, "FuelInjectionTiming");
            Switch fuelInjectionTimingSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            fuelInjectionTimingSwitch.Toggled += fuelInjectionTimingSwitch_Toggled;



            FuelPressure = new Label();
            FuelPressure.Text = "Presión del combustible";
            FuelPressureResult = new Label();
            FuelPressureResult.SetBinding(Label.TextProperty, "FuelPressure");
            Switch fuelPressureSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            fuelPressureSwitch.Toggled += fuelPressureSwitch_Toggled;

            FuelRailAbsolutePressure = new Label();
            FuelRailAbsolutePressure.Text = "	Presión absoluta del tren de combustible";
            FuelRailAbsolutePressureResult = new Label();
            FuelRailAbsolutePressureResult.SetBinding(Label.TextProperty, "FuelRailAbsolutePressure");
            Switch fuelRailAbsolutePressureSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            fuelRailAbsolutePressureSwitch.Toggled += fuelRailAbsolutePressureSwitch_Toggled;
   

            FuelRailGaugePressure = new Label();
            FuelRailGaugePressure.Text = "Presión del medidor del tren de combustible (Diesel o inyección directa de gasolina)";
            FuelRailGaugePressureResult = new Label();
            FuelRailGaugePressureResult.SetBinding(Label.TextProperty, "FuelRailGaugePressure");
            Switch fuelRailGaugePressureSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            fuelRailGaugePressureSwitch.Toggled += fuelRailGaugePressureSwitch_Toggled;

            FuelTankLevel = new Label();
            FuelTankLevel.Text = "Nivel de entrada del tanque de combustible";
            FuelTankLevelResult = new Label();
            FuelTankLevelResult.SetBinding(Label.TextProperty, "FuelTankLevel");
            Switch fuelTankLevelSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            fuelTankLevelSwitch.Toggled += fuelTankLevelSwitch_Toggled;

            FuelType = new Label();
            FuelType.Text = "Tipo de combustible";
            FuelTypeResult = new Label();
            FuelTypeResult.SetBinding(Label.TextProperty, "FuelType");
            Switch fuelTypeSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            fuelTypeSwitch.Toggled += fuelTypeSwitch_Toggled;

            IntakeManifoldAbsolutePressureValue = new Label();
            IntakeManifoldAbsolutePressureValue.Text = "Presión absoluta del colector de admisión";
            IntakeManifoldAbsolutePressureValueResult = new Label();
            IntakeManifoldAbsolutePressureValueResult.SetBinding(Label.TextProperty, "IntakeManifoldAbsolutePressureValue");
            Switch intakeManifoldAbsolutePressureValueSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            intakeManifoldAbsolutePressureValueSwitch.Toggled += intakeManifoldAbsolutePressureValueSwitch_Toggled;

            MAFAirFlowRate = new Label();
            MAFAirFlowRate.Text = "	Velocidad del flujo del aire MAF";
            MAFAirFlowRateResult = new Label();
            MAFAirFlowRateResult.SetBinding(Label.TextProperty, "MAFAirFlowRate");
            Switch mAFAirFlowRateSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            mAFAirFlowRateSwitch.Toggled += mAFAirFlowRateSwitch_Toggled;

            RelativeAcceleratorPedalPosition = new Label();
            RelativeAcceleratorPedalPosition.Text = "Posición relativa del pedal del acelerador";
            RelativeAcceleratorPedalPositionResult = new Label();
            RelativeAcceleratorPedalPositionResult.SetBinding(Label.TextProperty, "RelativeAcceleratorPedalPosition");
            Switch relativeAcceleratorPedalSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            relativeAcceleratorPedalSwitch.Toggled += relativeAcceleratorPedalSwitch_Toggled;


            RelativeThrottlePosition = new Label();
            RelativeThrottlePosition.Text = "Posición relativa del acelerador";
            RelativeThrottlePositionResult = new Label();
            RelativeThrottlePositionResult.SetBinding(Label.TextProperty, "RelativeThrottlePosition");
            Switch relativeThrottlePositionSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            relativeThrottlePositionSwitch.Toggled += relativeThrottlePositionSwitch_Toggled;

            ThrottlePosition = new Label();
            ThrottlePosition.Text = "Posición del acelerador";
            ThrottlePositionResult = new Label();
            ThrottlePositionResult.SetBinding(Label.TextProperty, "ThrottlePosition");
            Switch throttlePositionSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            throttlePositionSwitch.Toggled += throttlePositionSwitch_Toggled;


            TimeRunWithMILOn = new Label();
            TimeRunWithMILOn.Text = "Tiempo con indicador MIL encendido";
            TimeRunWithMILOnResult = new Label();
            TimeRunWithMILOnResult.SetBinding(Label.TextProperty, "TimeRunWithMILOn");
            Switch timeRunWithMILOnSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = true
            };
            timeRunWithMILOnSwitch.Toggled += timeRunWithMILOnSwitch_Toggled;


            



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

            grid.Children.Add(AbsoluteBarometricPressure, 0, 4);
            grid.Children.Add(AbsoluteBarometricPressureResult, 1, 4);
            grid.Children.Add(absolutebarometricpressureSwitch, 2, 4);

            grid.Children.Add(AbsoluteLoadValue, 0, 5);
            grid.Children.Add(AbsoluteLoadValueResult, 1, 5);
            grid.Children.Add(absoluteLoadValueSwitch, 2, 5);


            grid.Children.Add(AbsoluteThrottlePositionB, 0, 6);
            grid.Children.Add(AbsoluteThrottlePositionBResult, 1, 6);
            grid.Children.Add(absoluteThrottlePositionBSwitch, 2, 6);

            grid.Children.Add(AbsoluteThrottlePositionC, 0, 7);
            grid.Children.Add(AbsoluteThrottlePositionCResult, 1, 7);
            grid.Children.Add(absoluteThrottlePositionCSwitch, 2, 7);

            grid.Children.Add(AbsoluteThrottlePositionD, 0, 8);
            grid.Children.Add(AbsoluteThrottlePositionDResult, 1, 8);
            grid.Children.Add(absoluteThrottlePositionDSwitch, 2, 8);

            grid.Children.Add(AbsoluteThrottlePositionE, 0, 9);
            grid.Children.Add(AbsoluteThrottlePositionEResult, 1, 10);
            grid.Children.Add(absoluteThrottlePositionESwitch, 2, 10);

            grid.Children.Add(AbsoluteThrottlePositionF, 0, 11);
            grid.Children.Add(AbsoluteThrottlePositionFResult, 1, 11);
            grid.Children.Add(absoluteThrottlePositionFSwitch, 2, 11);


            grid.Children.Add(CatalystTemperatureB1S1, 0, 12);
            grid.Children.Add(CatalystTemperatureB1S1Result, 1, 12);
            grid.Children.Add(catalystTemperatureB1S1Switch, 2, 12);

            grid.Children.Add(CatalystTemperatureB1S2, 0, 13);
            grid.Children.Add(CatalystTemperatureB1S1Result, 1, 13);
            grid.Children.Add(catalystTemperatureB1S1Switch, 2, 13);


            grid.Children.Add(CatalystTemperatureB1S1, 0, 14);
            grid.Children.Add(CatalystTemperatureB1S1Result, 1, 14);
            grid.Children.Add(catalystTemperatureB1S1Switch, 2, 14);


            grid.Children.Add(CatalystTemperatureB1S1, 0, 15);
            grid.Children.Add(CatalystTemperatureB1S1Result, 1, 15);
            grid.Children.Add(catalystTemperatureB1S1Switch, 2, 15);


            grid.Children.Add(CommandedEvaporativePurge, 0, 16);
            grid.Children.Add(CommandedEvaporativePurgeResult, 1, 16);
            grid.Children.Add(commandedEvaporativePurgeSwitch, 2, 16);

            // grid.Children.Add(CommandedEGR, 0, 16);
            //grid.Children.Add(CommandedEGRResult, 1, 16);
            //   grid.Children.Add(commandedEGRSw, 2, 16);


            grid.Children.Add(CommandedThrottleActuatorValue, 0, 18);
            grid.Children.Add(CommandedThrottleActuatorValueResult, 1, 18);
            grid.Children.Add(commandedThrottleActuatorValueSwitch, 2, 18);


            grid.Children.Add(ControlModuleVoltage, 0, 19);
            grid.Children.Add(ControlModuleVoltageResult, 1, 19);
            grid.Children.Add(controlModuleVoltageSwitch, 2, 19);


            grid.Children.Add(DistanceTraveledSinceCodesCleared, 0, 20);
            grid.Children.Add(DistanceTraveledSinceCodesClearedResult, 1, 20);
            grid.Children.Add(distanceTraveledSinceCodesClearedResultSwitch, 2, 20);


            grid.Children.Add(DistanceTraveledWithMILo, 0, 21);
            grid.Children.Add(DistanceTraveledWithMILoResult, 1, 21);
            grid.Children.Add(distanceTraveledWithMILoSwitch, 2, 21);

            grid.Children.Add(EGRError, 0, 22);
            grid.Children.Add(EGRErrorResult, 1, 22);
            grid.Children.Add(egrErrorSwitch, 2, 22);

            grid.Children.Add(EngineFuelRateValue, 0, 23);
            grid.Children.Add(EngineFuelRateValueResult, 1, 23);
            grid.Children.Add(engineFuelRateValueSwitch, 2, 23);

            grid.Children.Add(EngineOilTemperature, 0, 24);
            grid.Children.Add(EngineOilTemperatureResult, 1, 24);
            grid.Children.Add(engineOilTemperatureSwitch, 2, 24);


            grid.Children.Add(EvapSystemVaporPressure, 0, 25);
            grid.Children.Add(EvapSystemVaporPressureResult, 1, 25);
            grid.Children.Add(evapSystemVaporPressureSwitch, 2, 25);

            grid.Children.Add(FuelAirCommandedEquivalenceRatio, 0, 26);
            grid.Children.Add(FuelAirCommandedEquivalenceRatioResult, 1, 26);
            grid.Children.Add(fuelAirCommandedEquivalenceRatioSwitch, 2, 26);


            grid.Children.Add(FuelInjectionTiming, 0, 27);
            grid.Children.Add(FuelInjectionTimingResult, 1, 27);
            grid.Children.Add(fuelInjectionTimingSwitch, 2, 27);



            grid.Children.Add(FuelPressure, 0, 28);
            grid.Children.Add(FuelPressureResult, 1, 28);
            grid.Children.Add(fuelPressureSwitch, 2, 28);


            grid.Children.Add(FuelRailAbsolutePressure, 0, 29);
            grid.Children.Add(FuelRailAbsolutePressureResult, 1, 29);
            grid.Children.Add(fuelRailAbsolutePressureSwitch, 2, 29);

            grid.Children.Add(FuelRailGaugePressure, 0, 30);
            grid.Children.Add(FuelRailGaugePressureResult, 1, 30);
            grid.Children.Add(fuelRailGaugePressureSwitch, 2, 30);

            grid.Children.Add(FuelTankLevel, 0, 31);
            grid.Children.Add(FuelTankLevelResult, 1, 31);
            grid.Children.Add(fuelTankLevelSwitch, 2, 31);

            grid.Children.Add(FuelType, 0, 32);
            grid.Children.Add(FuelTypeResult, 1, 32);
            grid.Children.Add(fuelTypeSwitch, 2, 32);

            grid.Children.Add(IntakeManifoldAbsolutePressureValue, 0, 33);
            grid.Children.Add(IntakeManifoldAbsolutePressureValueResult, 1, 33);
            grid.Children.Add(intakeManifoldAbsolutePressureValueSwitch, 2, 33);

            grid.Children.Add(MAFAirFlowRate, 0, 34);
            grid.Children.Add(MAFAirFlowRateResult, 1, 34);
            grid.Children.Add(mAFAirFlowRateSwitch, 2, 34);

            grid.Children.Add(RelativeAcceleratorPedalPosition, 0, 35);
            grid.Children.Add(RelativeAcceleratorPedalPositionResult, 1, 35);
            grid.Children.Add(relativeAcceleratorPedalSwitch, 2, 35);

            grid.Children.Add(RelativeThrottlePosition, 0, 36);
            grid.Children.Add(RelativeThrottlePositionResult, 1, 36);
            grid.Children.Add(relativeThrottlePositionSwitch, 2, 36);

            grid.Children.Add(ThrottlePosition, 0, 37);
            grid.Children.Add(ThrottlePositionResult, 1, 37);
            grid.Children.Add(throttlePositionSwitch, 2, 37);

            grid.Children.Add(TimeRunWithMILOn, 0, 38);
            grid.Children.Add(TimeRunWithMILOnResult, 1, 38);
            grid.Children.Add(timeRunWithMILOnSwitch, 2, 38);






            /*                   
        
            Label CommandedEGR;
            
          
            Label TimeRunWithMILOn;*/


            layout.Children.Add(grid);
            Content = new ScrollView()
            {
                Content = layout,
            };            

        }

        private void timeRunWithMILOnSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            TimeRunWithMILOnResult.IsVisible = e.Value;
        }

        private void throttlePositionSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            ThrottlePosition.IsVisible = e.Value;
        }

        private void relativeThrottlePositionSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            RelativeThrottlePosition.IsVisible = e.Value;
        }

        private void relativeAcceleratorPedalSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            RelativeAcceleratorPedalPositionResult.IsVisible = e.Value;
        }

        private void mAFAirFlowRateSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            MAFAirFlowRateResult.IsVisible = e.Value;
        }

        private void intakeManifoldAbsolutePressureValueSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            IntakeManifoldAbsolutePressureValueResult.IsVisible = e.Value;
        }

        private void fuelTypeSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            FuelTypeResult.IsVisible = true;
        }

        private void fuelTankLevelSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            FuelTankLevelResult.IsVisible = e.Value;
        }

        private void fuelRailGaugePressureSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            FuelRailGaugePressureResult.IsVisible = e.Value;
        }

        private void fuelRailAbsolutePressureSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            FuelRailAbsolutePressureResult.IsVisible = e.Value;
        }

        private void fuelPressureSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            FuelPressureResult.IsVisible = e.Value;
        }

        private void fuelInjectionTimingSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            FuelInjectionTimingResult.IsVisible = e.Value;
        }

        private void fuelAirCommandedEquivalenceRatioSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            FuelAirCommandedEquivalenceRatioResult.IsVisible = e.Value;
        }

        private void evapSystemVaporPressureSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            EvapSystemVaporPressureResult.IsVisible = e.Value;
        }

        private void engineOilTemperatureSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            EngineFuelRateValueResult.IsVisible = e.Value;
        }

        private void engineFuelRateValueSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            EngineFuelRateValueResult.IsVisible = e.Value;
        }

        private void egrErrorSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            EGRErrorResult.IsVisible = e.Value;
        }

        private void distanceTraveledWithMILoSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            DistanceTraveledWithMILoResult.IsVisible = e.Value;
        }

        private void distanceTraveledSinceCodesClearedResultSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            DistanceTraveledSinceCodesClearedResult.IsVisible = e.Value;
        }

        private void controlModuleVoltageSwitchh_Toggled(object sender, ToggledEventArgs e)
        {
            ControlModuleVoltageResult.IsVisible = e.Value;
        }

        private void commandedThrottleActuatorValueSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            CommandedThrottleActuatorValueResult.IsVisible = e.Value;
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
