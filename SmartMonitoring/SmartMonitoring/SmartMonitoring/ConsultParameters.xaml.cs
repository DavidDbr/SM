using Java.Lang;
using SmartMonitoring.BBDD;
using SmartMonitoring.MVVM;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartMonitoring
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultParameters : ContentPage
    {

        IConnectionManagement connectionManagement;

        static int reinicio = 1;
        static int ejecutando = 0;
        ViewModel vm = null;

        DispositivoConectado previousPage;
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
        Label LongTermSecondaryOxygenSensorTrim1_3_ValueAResult;
        Label LongTermSecondaryOxygenSensorTrim1_3_ValueBResult;
        Label LongTermSecondaryOxygenSensorTrim2_4_ValueAResult;
        Label LongTermSecondaryOxygenSensorTrim2_4_ValueBResult;
        Label ShortTermSecondaryOxygenSensorTrim1_3_ValueAResult;
        Label ShortTermSecondaryOxygenSensorTrim1_3_ValueBResult;
        Label ShortTermSecondaryOxygenSensorTrim2_4_ValueAResult;
        Label ShortTermSecondaryOxygenSensorTrim2_4_ValueBResult;
        Label MAFAirFlowRateResult;
        Label MaximunValueAirFlowRateFromMassAirFlowSensor_ValueAResult;
        Label MaximunValueAirFlowRateFromMassAirFlowSensor_ValueBResult;
        Label MaximunValueAirFlowRateFromMassAirFlowSensor_ValueCResult;
        Label MaximunValueAirFlowRateFromMassAirFlowSensor_ValueDResult;
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
        Label LongTermSecondaryOxygenSensorTrim1_3_ValueA;
        Label LongTermSecondaryOxygenSensorTrim1_3_ValueB;
        Label LongTermSecondaryOxygenSensorTrim2_4_ValueA;
        Label LongTermSecondaryOxygenSensorTrim2_4_ValueB;
        Label ShortTermSecondaryOxygenSensorTrim1_3_ValueA;
        Label ShortTermSecondaryOxygenSensorTrim1_3_ValueB;
        Label ShortTermSecondaryOxygenSensorTrim2_4_ValueA;
        Label ShortTermSecondaryOxygenSensorTrim2_4_ValueB;
        Label MAFAirFlowRate;
        Label MaximunValueAirFlowRateFromMassAirFlowSensor_ValueA;
        Label MaximunValueAirFlowRateFromMassAirFlowSensor_ValueB;
        Label MaximunValueAirFlowRateFromMassAirFlowSensor_ValueC;
        Label MaximunValueAirFlowRateFromMassAirFlowSensor_ValueD;
        Label RelativeAcceleratorPedalPosition;
        Label RelativeThrottlePosition;
        Label ThrottlePosition;
        Label TimeRunWithMILOn;
        Visibilidad actualVisibilidad;
        Thread t;

        public Thread T
        {
            get
            {
                return T;
            }
            set
            {
                T = value;
            }
        }
           

       

        public ConsultParameters(DispositivoConectado previousPage)
        {

            this.previousPage = previousPage;
            InitializeComponent();


            var layout = new StackLayout();
            var grid = new Grid();


            connectionManagement = DependencyService.Get<IConnectionManagement>();
            RPM = new Label();
            RPM.Text = "RPM";
            RPMResult = new Label();
            RPMResult.SetBinding(Label.TextProperty, "Rpm");



            Speed = new Label();
            Speed.Text = "Velocidad";
            SpeedResult = new Label();
            SpeedResult.SetBinding(Label.TextProperty, "Speed");


            EngineTemperature = new Label();
            EngineTemperature.Text = "Temperatura del Motor";
            EngineTemperatureResult = new Label();
            EngineTemperatureResult.SetBinding(Label.TextProperty, "EngineTemperature");


            TimeEngineStart = new Label();
            TimeEngineStart.Text = "Time Engine Start";
            TimeEngineStartResult = new Label();
            TimeEngineStartResult.SetBinding(Label.TextProperty, "TimeEngineStart");


            HybridBateryPackRemainingLife = new Label();
            HybridBateryPackRemainingLife.Text = "Batería Híbrida Restante";
            HybridBateryPackRemainingLifeResult = new Label();
            HybridBateryPackRemainingLifeResult.SetBinding(Label.TextProperty, "HybridBateryPackRemainingLife");


            AbsoluteBarometricPressure = new Label();
            AbsoluteBarometricPressure.Text = "Presión barométrica";
            AbsoluteBarometricPressureResult = new Label();
            AbsoluteBarometricPressureResult.SetBinding(Label.TextProperty, "AbsoluteBarometricPressure");


            AbsoluteEvapSystemVaporPressure = new Label();
            AbsoluteEvapSystemVaporPressure.Text = "Presión de vapor de Sist. Evaporativo";
            AbsoluteEvapSystemVaporPressureResult = new Label();
            AbsoluteEvapSystemVaporPressureResult.SetBinding(Label.TextProperty, "AbsoluteEvapSystemVaportPressure");


            AbsoluteLoadValue = new Label();
            AbsoluteLoadValue.Text = "Valor absoluto de carga";
            AbsoluteLoadValueResult = new Label();
            AbsoluteLoadValueResult.SetBinding(Label.TextProperty, "AbsoluteLoadValue");


            AbsoluteThrottlePositionB = new Label();
            AbsoluteThrottlePositionB.Text = "Posición absoluta acelerador B";
            AbsoluteThrottlePositionBResult = new Label();
            AbsoluteThrottlePositionBResult.SetBinding(Label.TextProperty, "AbsoluteThrottlePositionB");


            AbsoluteThrottlePositionC = new Label();
            AbsoluteThrottlePositionC.Text = "Posición absoluta acelerador C";
            AbsoluteThrottlePositionCResult = new Label();
            AbsoluteThrottlePositionCResult.SetBinding(Label.TextProperty, "AbsoluteThrottlePositionC");


            AbsoluteThrottlePositionD = new Label();
            AbsoluteThrottlePositionD.Text = "Posición absoluta acelerador D";
            AbsoluteThrottlePositionDResult = new Label();
            AbsoluteThrottlePositionDResult.SetBinding(Label.TextProperty, "AbsoluteThrottlePositionD");


            AbsoluteThrottlePositionE = new Label();
            AbsoluteThrottlePositionE.Text = "Posición absoluta acelerador E";
            AbsoluteThrottlePositionEResult = new Label();
            AbsoluteThrottlePositionEResult.SetBinding(Label.TextProperty, "AbsoluteThrottlePositionE");


            AbsoluteThrottlePositionF = new Label();
            AbsoluteThrottlePositionF.Text = "Posición absoluta acelerador E";
            AbsoluteThrottlePositionFResult = new Label();
            AbsoluteThrottlePositionFResult.SetBinding(Label.TextProperty, "AbsoluteThrottlePositionB");


            CatalystTemperatureB1S1 = new Label();
            CatalystTemperatureB1S1.Text = "Temperatura Catalizador Banco:1 Sensor:1";
            CatalystTemperatureB1S1Result = new Label();
            CatalystTemperatureB1S1Result.SetBinding(Label.TextProperty, "CatalystTemperatureB1S1");


            CatalystTemperatureB1S2 = new Label();
            CatalystTemperatureB1S2.Text = "Temperatura Catalizador Banco:1 Sensor:2";
            CatalystTemperatureB1S2Result = new Label();
            CatalystTemperatureB1S2Result.SetBinding(Label.TextProperty, "CatalystTemperatureB1S2");


            CatalystTemperatureB2S1 = new Label();
            CatalystTemperatureB2S1.Text = "Temperatura Catalizador Banco:2 Sensor:1";
            CatalystTemperatureB2S1Result = new Label();
            CatalystTemperatureB2S1Result.SetBinding(Label.TextProperty, "CatalystTemperatureB2S1");


            CatalystTemperatureB2S2 = new Label();
            CatalystTemperatureB2S2.Text = "Temperatura Catalizador Banco:2 Sensor:2";
            CatalystTemperatureB2S2Result = new Label();
            CatalystTemperatureB2S2Result.SetBinding(Label.TextProperty, "CatalystTemperatureB2S2");


            CommandedEvaporativePurge = new Label();
            CommandedEvaporativePurge.Text = "Purga evaporativa comandada";
            CommandedEvaporativePurgeResult = new Label();
            CommandedEvaporativePurgeResult.SetBinding(Label.TextProperty, "CommanddEvaporativePurge");


            CommandedEGR = new Label();
            CommandedEGR.Text = "EGR comandada";
            CommandedEGRResult = new Label();
            CommandedEGRResult.SetBinding(Label.TextProperty, "CommandedEGR");


            CommandedThrottleActuatorValue = new Label();
            CommandedThrottleActuatorValue.Text = "	Actuador comandando del acelerador";
            CommandedThrottleActuatorValueResult = new Label();
            CommandedThrottleActuatorValueResult.SetBinding(Label.TextProperty, "CommandedThrottleActuatorValue");


            ControlModuleVoltage = new Label();
            ControlModuleVoltage.Text = "Voltaje del módulo de control";
            ControlModuleVoltageResult = new Label();


            DistanceTraveledSinceCodesCleared = new Label();
            DistanceTraveledSinceCodesCleared.Text = "Distancia recorrida desde borrado de fallas";
            DistanceTraveledSinceCodesClearedResult = new Label();
            DistanceTraveledSinceCodesClearedResult.SetBinding(Label.TextProperty, "DistanceTraveledSinceCodesCleared");

            DistanceTraveledWithMILo = new Label();
            DistanceTraveledWithMILo.Text = "Distancia recorrida con MIL encendido";
            DistanceTraveledWithMILoResult = new Label();
            DistanceTraveledWithMILoResult.SetBinding(Label.TextProperty, "DistanceTraveledWithMILo");


            EGRError = new Label();
            EGRError.Text = "Falla EGR";
            EGRErrorResult = new Label();
            EGRErrorResult.SetBinding(Label.TextProperty, "EGRError1");

            EngineFuelRateValue = new Label();
            EngineFuelRateValue.Text = "Velocidad de combustible del motor";
            EngineFuelRateValueResult = new Label();
            EngineFuelRateValueResult.SetBinding(Label.TextProperty, "EngineFuelRateValue");

            EngineOilTemperature = new Label();
            EngineOilTemperature.Text = "Temperatura del aceite del motor";
            EngineOilTemperatureResult = new Label();
            EngineOilTemperatureResult.SetBinding(Label.TextProperty, "EngineOilTemperature");

            EvapSystemVaporPressure = new Label();
            EvapSystemVaporPressure.Text = "Presión del vapor del sistema de evaporación";
            EvapSystemVaporPressureResult = new Label();
            EngineOilTemperatureResult.SetBinding(Label.TextProperty, "EvapSystemVaporPressure");


            FuelAirCommandedEquivalenceRatio = new Label();
            FuelAirCommandedEquivalenceRatio.Text = "Relación equivaliente comandada de combustible - aire";
            FuelAirCommandedEquivalenceRatioResult = new Label();
            FuelAirCommandedEquivalenceRatioResult.SetBinding(Label.TextProperty, "FuelAirCommandedEquivalenceRatio");


            FuelInjectionTiming = new Label();
            FuelInjectionTiming.Text = "Sincronización de la inyección de combustible";
            FuelInjectionTimingResult = new Label();
            FuelInjectionTimingResult.SetBinding(Label.TextProperty, "FuelInjectionTiming");


            FuelPressure = new Label();
            FuelPressure.Text = "Presión del combustible";
            FuelPressureResult = new Label();
            FuelPressureResult.SetBinding(Label.TextProperty, "FuelPressure");


            FuelRailAbsolutePressure = new Label();
            FuelRailAbsolutePressure.Text = "	Presión absoluta del tren de combustible";
            FuelRailAbsolutePressureResult = new Label();
            FuelRailAbsolutePressureResult.SetBinding(Label.TextProperty, "FuelRailAbsolutePressure");


            FuelRailGaugePressure = new Label();
            FuelRailGaugePressure.Text = "Presión del medidor del tren de combustible (Diesel o inyección directa de gasolina)";
            FuelRailGaugePressureResult = new Label();
            FuelRailGaugePressureResult.SetBinding(Label.TextProperty, "FuelRailGaugePressure");


            FuelTankLevel = new Label();
            FuelTankLevel.Text = "Nivel de entrada del tanque de combustible";
            FuelTankLevelResult = new Label();
            FuelTankLevelResult.SetBinding(Label.TextProperty, "FuelTankLevel");


            FuelType = new Label();
            FuelType.Text = "Tipo de combustible";
            FuelTypeResult = new Label();
            FuelTypeResult.SetBinding(Label.TextProperty, "FuelType");


            IntakeManifoldAbsolutePressureValue = new Label();
            IntakeManifoldAbsolutePressureValue.Text = "Presión absoluta del colector de admisión";
            IntakeManifoldAbsolutePressureValueResult = new Label();
            IntakeManifoldAbsolutePressureValueResult.SetBinding(Label.TextProperty, "IntakeManifoldAbsolutePressureValue");

            LongTermSecondaryOxygenSensorTrim1_3_ValueA = new Label();
            LongTermSecondaryOxygenSensorTrim1_3_ValueA.Text = "Ajuste sensor de oxigeno secundario: plazo largo. Banco 1";
            LongTermSecondaryOxygenSensorTrim1_3_ValueAResult = new Label();
            LongTermSecondaryOxygenSensorTrim1_3_ValueAResult.SetBinding(Label.TextProperty, "LongTermSecondaryOxygenSensorTrim1_3_ValueA");

            LongTermSecondaryOxygenSensorTrim1_3_ValueB = new Label();
            LongTermSecondaryOxygenSensorTrim1_3_ValueB.Text = "Ajuste sensor de oxigeno secundario: plazo largo. Banco 3";
            LongTermSecondaryOxygenSensorTrim1_3_ValueBResult = new Label();
            LongTermSecondaryOxygenSensorTrim1_3_ValueBResult.SetBinding(Label.TextProperty, "LongTermSecondaryOxygenSensorTrim1_3_ValueB");

            LongTermSecondaryOxygenSensorTrim2_4_ValueA = new Label();
            LongTermSecondaryOxygenSensorTrim2_4_ValueA.Text = "Ajuste sensor de oxigeno secundario: plazo largo. Banco 2";
            LongTermSecondaryOxygenSensorTrim2_4_ValueAResult = new Label();
            LongTermSecondaryOxygenSensorTrim2_4_ValueAResult.SetBinding(Label.TextProperty, "LongTermSecondaryOxygenSensorTrim2_4_ValueA");

            LongTermSecondaryOxygenSensorTrim2_4_ValueB = new Label();
            LongTermSecondaryOxygenSensorTrim2_4_ValueB.Text = "Ajuste sensor de oxigeno secundario: plazo largo. Banco 4";
            LongTermSecondaryOxygenSensorTrim2_4_ValueBResult = new Label();
            LongTermSecondaryOxygenSensorTrim2_4_ValueBResult.SetBinding(Label.TextProperty, "LongTermSecondaryOxygenSensorTrim2_4_ValueB");



            MAFAirFlowRate = new Label();
            MAFAirFlowRate.Text = "	Velocidad del flujo del aire MAF";
            MAFAirFlowRateResult = new Label();
            MAFAirFlowRateResult.SetBinding(Label.TextProperty, "MAFAirFlowRate");

            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueA = new Label();
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueA.Text = "Velocidad de flujo de aire del sensor de flujo de aire masivo; A";
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueAResult = new Label();
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueAResult.SetBinding(Label.TextProperty, "MaximunValueAirFlowRateFromMassAirFlowSensor_ValueA");

            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueB = new Label();
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueB.Text = "Velocidad de flujo de aire del sensor de flujo de aire masivo; B";
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueBResult = new Label();
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueBResult.SetBinding(Label.TextProperty, "MaximunValueAirFlowRateFromMassAirFlowSensor_ValueB");

            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueC = new Label();
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueC.Text = "Velocidad de flujo de aire del sensor de flujo de aire masivo; C";
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueCResult = new Label();
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueCResult.SetBinding(Label.TextProperty, "MaximunValueAirFlowRateFromMassAirFlowSensor_ValueC");

            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueD = new Label();
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueD.Text = "Velocidad de flujo de aire del sensor de flujo de aire masivo; D";
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueDResult = new Label();
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueDResult.SetBinding(Label.TextProperty, "MaximunValueAirFlowRateFromMassAirFlowSensor_ValueD");


            RelativeAcceleratorPedalPosition = new Label();
            RelativeAcceleratorPedalPosition.Text = "Posición relativa del pedal del acelerador";
            RelativeAcceleratorPedalPositionResult = new Label();
            RelativeAcceleratorPedalPositionResult.SetBinding(Label.TextProperty, "RelativeAcceleratorPedalPosition");


            RelativeThrottlePosition = new Label();
            RelativeThrottlePosition.Text = "Posición relativa del acelerador";
            RelativeThrottlePositionResult = new Label();
            RelativeThrottlePositionResult.SetBinding(Label.TextProperty, "RelativeThrottlePosition");

            ShortTermSecondaryOxygenSensorTrim1_3_ValueA = new Label();
            ShortTermSecondaryOxygenSensorTrim1_3_ValueA.Text = "Ajuste sensor de oxigeno secundario: plazo corto. Banco 1";
            ShortTermSecondaryOxygenSensorTrim1_3_ValueAResult = new Label();
            ShortTermSecondaryOxygenSensorTrim1_3_ValueAResult.SetBinding(Label.TextProperty, "ShortTermSecondaryOxygenSensorTrim1_3_ValueA");

            ShortTermSecondaryOxygenSensorTrim1_3_ValueB = new Label();
            ShortTermSecondaryOxygenSensorTrim1_3_ValueB.Text = "Ajuste sensor de oxigeno secundario: plazo corto. Banco 3";
            ShortTermSecondaryOxygenSensorTrim1_3_ValueBResult = new Label();
            ShortTermSecondaryOxygenSensorTrim1_3_ValueBResult.SetBinding(Label.TextProperty, "ShortTermSecondaryOxygenSensorTrim1_3_ValueB");

            ShortTermSecondaryOxygenSensorTrim2_4_ValueA = new Label();
            ShortTermSecondaryOxygenSensorTrim2_4_ValueA.Text = "Ajuste sensor de oxigeno secundario: plazo corto. Banco 2";
            ShortTermSecondaryOxygenSensorTrim2_4_ValueAResult = new Label();
            ShortTermSecondaryOxygenSensorTrim2_4_ValueAResult.SetBinding(Label.TextProperty, "ShortTermSecondaryOxygenSensorTrim2_4_ValueA");

            ShortTermSecondaryOxygenSensorTrim2_4_ValueB = new Label();
            ShortTermSecondaryOxygenSensorTrim2_4_ValueB.Text = "Ajuste sensor de oxigeno secundario: plazo corto. Banco 4";
            ShortTermSecondaryOxygenSensorTrim2_4_ValueBResult = new Label();
            ShortTermSecondaryOxygenSensorTrim2_4_ValueBResult.SetBinding(Label.TextProperty, "ShortTermSecondaryOxygenSensorTrim2_4_ValueB");

            ThrottlePosition = new Label();
            ThrottlePosition.Text = "Posición del acelerador";
            ThrottlePositionResult = new Label();
            ThrottlePositionResult.SetBinding(Label.TextProperty, "ThrottlePosition");


            TimeRunWithMILOn = new Label();
            TimeRunWithMILOn.Text = "Tiempo con indicador MIL encendido";
            TimeRunWithMILOnResult = new Label();
            TimeRunWithMILOnResult.SetBinding(Label.TextProperty, "TimeRunWithMILOn");


            actualVisibilidad = connectionManagement.getVisibilidad();
            BindingContext = vm;




        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            AfterConfig();
            vm = connectionManagement.getViewModel();
            BindingContext = vm;

            if (ejecutando == 0)
            {
                T = new Thread(launchVM());
                T.Start();
                ejecutando = 1;
            }
        }

        public async void AfterConfig()
        {

            ActivityIndicator indicator = new ActivityIndicator();

            if (reinicio == 1)
            {
                var previousLayout = new StackLayout();
                previousLayout.Children.Add(indicator);
                Content = previousLayout;
                indicator.IsRunning = true;
                await Task.Delay(15000);


                ToolbarItem guardarDatosToolbar = new ToolbarItem
                {
                    Text = "Almacenar Datos",
                    Order = ToolbarItemOrder.Secondary,
                    Priority = 0
                };

                guardarDatosToolbar.Clicked += (sender, e) => guardarDatosAction(sender, e);
                ToolbarItem configurarParametros = new ToolbarItem
                {
                    Text = "Configurar Parámetros",
                    Order = ToolbarItemOrder.Secondary,
                    Priority = 1
                };
                configurarParametros.Clicked += (sender, e) => configurarParametrosAction();

                ToolbarItem regresarToolbar = new ToolbarItem
                {
                    Text = "Regresar",
                    Icon = "drawable/icon.png",
                    Order = ToolbarItemOrder.Primary,
                    Priority = 1
                };
                regresarToolbar.Clicked += (sender, e) => regresarAction();

                ToolbarItems.Add(regresarToolbar);
                ToolbarItems.Add(guardarDatosToolbar);
                ToolbarItems.Add(configurarParametros);

                reinicio = 0;
            }
            int contador = 0;
            var layout = new StackLayout();
            var grid = new Grid();

            if (actualVisibilidad.rpmVisible == 1)
            {

                grid.Children.Add(RPM, 0, contador);
                grid.Children.Add(RPMResult, 1, contador);
                contador++;

            }
            if (actualVisibilidad.speedVisible == 1)
            {
                grid.Children.Add(Speed, 0, contador);
                grid.Children.Add(SpeedResult, 1, contador);
                contador++;
            }
            if (actualVisibilidad.hybridBateryPackRemainingLifeVisible == 1)
            {
                grid.Children.Add(HybridBateryPackRemainingLife, 0, contador);
                grid.Children.Add(HybridBateryPackRemainingLifeResult, 1, contador);
                contador++;
            }


            if (actualVisibilidad.timeEngineStartVisible == 1)
            {
                grid.Children.Add(TimeEngineStart, 0, contador);
                grid.Children.Add(TimeEngineStartResult, 1, contador);
                contador++;
            }
            if (actualVisibilidad.absoluteBarometricPressureVisible == 1)
            {
                grid.Children.Add(AbsoluteBarometricPressure, 0, contador);
                grid.Children.Add(AbsoluteBarometricPressureResult, 1, contador);
                contador++;
            }

            if (actualVisibilidad.absoluteLoadValueVisible == 1)
            {
                grid.Children.Add(AbsoluteLoadValue, 0, contador);
                grid.Children.Add(AbsoluteLoadValueResult, 1, contador);
                contador++;
            }

            if (actualVisibilidad.absoluteThrottlePositionBVisible == 1)
            {
                grid.Children.Add(AbsoluteThrottlePositionB, 0, contador);
                grid.Children.Add(AbsoluteThrottlePositionBResult, 1, contador);
                contador++;
            }


            if (actualVisibilidad.absoluteThrottlePositionCVisible == 1)
            {
                grid.Children.Add(AbsoluteThrottlePositionC, 0, contador);
                grid.Children.Add(AbsoluteThrottlePositionCResult, 1, contador);
                contador++;
            }

            if (actualVisibilidad.absoluteThrottlePositionDVisible == 1)
            {
                grid.Children.Add(AbsoluteThrottlePositionD, 0, contador);
                grid.Children.Add(AbsoluteThrottlePositionDResult, 1, contador);
                contador++;
            }

            if (actualVisibilidad.absoluteThrottlePositionEVisible == 1)
            {
                grid.Children.Add(AbsoluteThrottlePositionE, 0, contador);
                grid.Children.Add(AbsoluteThrottlePositionEResult, 1, contador);
                contador++;
            }

            if (actualVisibilidad.absoluteThrottlePositionFVisible == 1)
            {
                grid.Children.Add(AbsoluteThrottlePositionF, 0, contador);
                grid.Children.Add(AbsoluteThrottlePositionFResult, 1, contador);
                contador++;
            }

            if (actualVisibilidad.catalystTemperatureB1S1Visible == 1)
            {
                grid.Children.Add(CatalystTemperatureB1S1, 0, contador);
                grid.Children.Add(CatalystTemperatureB1S1Result, 1, contador);
                contador++;
            }

            if (actualVisibilidad.catalystTemperatureB1S2Visible == 1)
            {
                grid.Children.Add(CatalystTemperatureB1S2, 0, contador);
                grid.Children.Add(CatalystTemperatureB1S2Result, 1, contador);
                contador++;
            }

            if (actualVisibilidad.catalystTemperatureB2S1Visible == 1)
            {
                grid.Children.Add(CatalystTemperatureB2S1, 0, contador);
                grid.Children.Add(CatalystTemperatureB2S1Result, 1, contador);
                contador++;
            }

            if (actualVisibilidad.catalystTemperatureB2S2Visible == 1)
            {
                grid.Children.Add(CatalystTemperatureB2S2, 0, contador);
                grid.Children.Add(CatalystTemperatureB2S2Result, 1, contador);
                contador++;
            }


            if (actualVisibilidad.commanddEvaporativePurgeVisible == 1)
            {
                grid.Children.Add(CommandedEvaporativePurge, 0, contador);
                grid.Children.Add(CommandedEvaporativePurgeResult, 1, contador);
                contador++;
            }

            if (actualVisibilidad.commandedEGRVisible == 1)
            {
                grid.Children.Add(CommandedEGR, 0, contador);
                grid.Children.Add(CommandedEGRResult, 1, contador);
                contador++;
            }

            if (actualVisibilidad.commandedThrottleActuatorValueVisible == 1)
            {
                grid.Children.Add(CommandedThrottleActuatorValue, 0, contador);
                grid.Children.Add(CommandedThrottleActuatorValueResult, 1, contador);
                contador++;

            }
            if (actualVisibilidad.controlModuleVoltageVisible == 1)
            {
                grid.Children.Add(ControlModuleVoltage, 0, contador);
                grid.Children.Add(ControlModuleVoltageResult, 1, contador);
                contador++;
            }

            if (actualVisibilidad.distanceTraveledSinceCodesClearedVisible == 1)
            {
                grid.Children.Add(DistanceTraveledSinceCodesCleared, 0, contador);
                grid.Children.Add(DistanceTraveledSinceCodesClearedResult, 1, contador);
                contador++;
            }

            if (actualVisibilidad.distanceTraveledWithMILoVisible == 1)
            {
                grid.Children.Add(DistanceTraveledWithMILo, 0, contador);
                grid.Children.Add(DistanceTraveledWithMILoResult, 1, contador);
                contador++;
            }
            if (actualVisibilidad.EGRErrorVisible == 1)
            {
                grid.Children.Add(EGRError, 0, contador);
                grid.Children.Add(EGRErrorResult, 1, contador);
                contador++;
            }
            if (actualVisibilidad.engineFuelRateValueVisible == 1)
            {

                grid.Children.Add(EngineFuelRateValue, 0, contador);
                grid.Children.Add(EngineFuelRateValueResult, 1, contador);
                contador++;
            }

            if (actualVisibilidad.engineOilTemperatureVisible == 1)
            {
                grid.Children.Add(EngineOilTemperature, 0, contador);
                grid.Children.Add(EngineOilTemperatureResult, 1, contador);
                contador++;
            }
            if (actualVisibilidad.evapSystemVaporPressureVisible == 1)
            {
                grid.Children.Add(EvapSystemVaporPressure, 0, contador);
                grid.Children.Add(EvapSystemVaporPressureResult, 1, contador);
                contador++;
            }
            if (actualVisibilidad.fuelAirCommandedEquivalenceRatioVisible == 1)
            {
                grid.Children.Add(FuelAirCommandedEquivalenceRatio, 0, contador);
                grid.Children.Add(FuelAirCommandedEquivalenceRatioResult, 1, contador);
                contador++;
            }

            if (actualVisibilidad.fuelInjectionTimingVisible == 1)
            {
                grid.Children.Add(FuelInjectionTiming, 0, contador);
                grid.Children.Add(FuelInjectionTimingResult, 1, contador);
                contador++;
            }


            if (actualVisibilidad.fuelPressureVisible == 1)
            {
                grid.Children.Add(FuelPressure, 0, contador);
                grid.Children.Add(FuelPressureResult, 1, contador);
                contador++;
            }
            if (actualVisibilidad.fuelRailAbsolutePressureVisible == 1)
            {
                grid.Children.Add(FuelRailAbsolutePressure, 0, contador);
                grid.Children.Add(FuelRailAbsolutePressureResult, 1, contador);
                contador++;
            }
            if (actualVisibilidad.fuelRailGaugePressureVisible == 1)
            {
                grid.Children.Add(FuelRailGaugePressure, 0, contador);
                grid.Children.Add(FuelRailGaugePressureResult, 1, contador);
                contador++;
            }

            if (actualVisibilidad.fuelTankLevelVisible == 1)
            {
                grid.Children.Add(FuelTankLevel, 0, contador);
                grid.Children.Add(FuelTankLevelResult, 1, contador);
                contador++;
            }

            if (actualVisibilidad.fuelTypeVisible == 1)
            {
                grid.Children.Add(FuelType, 0, contador);
                grid.Children.Add(FuelTypeResult, 1, contador);
                contador++;
            }

            if (actualVisibilidad.intakeManifoldAbsolutePressureValueVisible == 1)
            {
                grid.Children.Add(IntakeManifoldAbsolutePressureValue, 0, contador);
                grid.Children.Add(IntakeManifoldAbsolutePressureValueResult, 1, contador);
                contador++;
            }

            if (actualVisibilidad.mAFAirFlowRateVisible == 1)
            {
                grid.Children.Add(MAFAirFlowRate, 0, contador);
                grid.Children.Add(MAFAirFlowRateResult, 1, contador);
                contador++;
            }

            if (actualVisibilidad.relativeAcceleratorPedalPositionVisible == 1)
            {
                grid.Children.Add(RelativeAcceleratorPedalPosition, 0, contador);
                grid.Children.Add(RelativeAcceleratorPedalPositionResult, 1, contador);
                contador++;
            }

            if (actualVisibilidad.relativeThrottlePositionVisible == 1)
            {
                grid.Children.Add(RelativeThrottlePosition, 0, contador);
                grid.Children.Add(RelativeThrottlePositionResult, 1, contador);
                contador++;
            }

            if (actualVisibilidad.throttlePositionVisible == 1)
            {
                grid.Children.Add(ThrottlePosition, 0, contador);
                grid.Children.Add(ThrottlePositionResult, 1, contador);
                contador++;
            }

            if (actualVisibilidad.timeRunWithMILOnVisible == 1)
            {
                grid.Children.Add(TimeRunWithMILOn, 0, contador);
                grid.Children.Add(TimeRunWithMILOnResult, 1, contador);
                contador++;
            }

            if (actualVisibilidad.longTermSecondaryOxygenSensorTrim1_3_Visible == 1)
            {
                grid.Children.Add(LongTermSecondaryOxygenSensorTrim1_3_ValueA, 0, contador);
                grid.Children.Add(LongTermSecondaryOxygenSensorTrim1_3_ValueAResult, 1, contador);
                contador++;

                grid.Children.Add(LongTermSecondaryOxygenSensorTrim1_3_ValueB, 0, contador);
                grid.Children.Add(LongTermSecondaryOxygenSensorTrim1_3_ValueBResult, 1, contador);
                contador++;
            }



            if (actualVisibilidad.longTermSecondaryOxygenSensorTrim2_4_Visible == 1)
            {
                grid.Children.Add(LongTermSecondaryOxygenSensorTrim2_4_ValueA, 0, contador);
                grid.Children.Add(LongTermSecondaryOxygenSensorTrim2_4_ValueAResult, 1, contador);
                contador++;

                grid.Children.Add(LongTermSecondaryOxygenSensorTrim2_4_ValueB, 0, contador);
                grid.Children.Add(LongTermSecondaryOxygenSensorTrim2_4_ValueBResult, 1, contador);
                contador++;
            }



            if (actualVisibilidad.shortTermSecondaryOxygenSensorTrim1_3_Visible == 1)
            {
                grid.Children.Add(ShortTermSecondaryOxygenSensorTrim1_3_ValueA, 0, contador);
                grid.Children.Add(ShortTermSecondaryOxygenSensorTrim1_3_ValueAResult, 1, contador);
                contador++;

                grid.Children.Add(ShortTermSecondaryOxygenSensorTrim1_3_ValueB, 0, contador);
                grid.Children.Add(ShortTermSecondaryOxygenSensorTrim1_3_ValueBResult, 1, contador);
                contador++;
            }


            if (actualVisibilidad.shortTermSecondaryOxygenSensorTrim2_4_Visible == 1)
            {
                grid.Children.Add(ShortTermSecondaryOxygenSensorTrim2_4_ValueA, 0, contador);
                grid.Children.Add(ShortTermSecondaryOxygenSensorTrim2_4_ValueAResult, 1, contador);
                contador++;

                grid.Children.Add(ShortTermSecondaryOxygenSensorTrim2_4_ValueB, 0, contador);
                grid.Children.Add(ShortTermSecondaryOxygenSensorTrim2_4_ValueBResult, 1, contador);
                contador++;
            }

            if (actualVisibilidad.maximunValueAirFlowRateFromMassAirFlowSensorVisible == 1)
            {
                grid.Children.Add(MaximunValueAirFlowRateFromMassAirFlowSensor_ValueA, 0, contador);
                grid.Children.Add(MaximunValueAirFlowRateFromMassAirFlowSensor_ValueAResult, 1, contador);
                contador++;

                grid.Children.Add(MaximunValueAirFlowRateFromMassAirFlowSensor_ValueB, 0, contador);
                grid.Children.Add(MaximunValueAirFlowRateFromMassAirFlowSensor_ValueBResult, 1, contador);
                contador++;

                grid.Children.Add(MaximunValueAirFlowRateFromMassAirFlowSensor_ValueC, 0, contador);
                grid.Children.Add(MaximunValueAirFlowRateFromMassAirFlowSensor_ValueCResult, 1, contador);
                contador++;

                grid.Children.Add(MaximunValueAirFlowRateFromMassAirFlowSensor_ValueD, 0, contador);
                grid.Children.Add(MaximunValueAirFlowRateFromMassAirFlowSensor_ValueDResult, 1, contador);
                contador++;
            }




            layout.Children.Add(grid);


            Content = new ScrollView()
            {
                Content = layout,

            };


        }

        private void regresarAction()
        {
            connectionManagement.setEstadoConsultar(false);
            App.Current.MainPage = new NavigationPage(previousPage);
        }

        private void configurarParametrosAction()
        {
            ConfigParameters configPage = new ConfigParameters(this, connectionManagement, actualVisibilidad);
            App.Current.MainPage = new NavigationPage(configPage);
        }

        private void guardarDatosAction(System.Object sender, System.EventArgs e)
        {
            //Lanzar un POPup
            if (connectionManagement.getGuardarDatos() == false)
            {
                connectionManagement.setGuardarDatos(true);
            }
            else
            {
                connectionManagement.setGuardarDatos(false);
            }

        }

        private System.Action launchVM()
        {

            connectionManagement.ConsultParameters();
            return null;

        }


    }
}
