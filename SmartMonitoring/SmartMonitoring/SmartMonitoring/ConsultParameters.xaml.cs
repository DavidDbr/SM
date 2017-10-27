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

        Label RPMUds;
        Label SpeedUds;
        Label EngineTemperatureUds;
        Label TimeEngineStartUds;
        Label AbsoluteBarometricPressureUds;
        Label AbsoluteEvapSystemVaporPressureUds;
        Label AbsoluteLoadValueUds;
        Label AbsoluteThrottlePositionBUds;
        Label AbsoluteThrottlePositionCUds;
        Label AbsoluteThrottlePositionDUds;
        Label AbsoluteThrottlePositionEUds;
        Label AbsoluteThrottlePositionFUds;
        Label CatalystTemperatureB1S1Uds;
        Label CatalystTemperatureB1S2Uds;
        Label CatalystTemperatureB2S1Uds;
        Label CatalystTemperatureB2S2Uds;
        Label CommandedEvaporativePurgeUds;
        Label CommandedEGRUds;
        Label CommandedThrottleActuatorValueUds;
        Label ControlModuleVoltageResultUds;
        Label DistanceTraveledSinceCodesClearedUds;
        Label DistanceTraveledWithMILoUds;
        Label EGRErrorUds;
        Label EngineFuelRateValueUds;
        Label EngineOilTemperatureUds;
        Label EvapSystemVaporPressureUds;
        Label FuelAirCommandedEquivalenceRatioUds;
        Label FuelInjectionTimingUds;
        Label FuelPressureUds;
        Label FuelRailAbsolutePressureUds;
        Label FuelRailGaugePressureUds;
        Label FuelTankLevelUds;
        Label FuelTypeUds;
        Label HybridBateryPackRemainingLifeUds;
        Label IntakeManifoldAbsolutePressureValueUds;
        Label LongTermSecondaryOxygenSensorTrim1_3_ValueAUds;
        Label LongTermSecondaryOxygenSensorTrim1_3_ValueBUds;
        Label LongTermSecondaryOxygenSensorTrim2_4_ValueAUds;
        Label LongTermSecondaryOxygenSensorTrim2_4_ValueBUds;
        Label ShortTermSecondaryOxygenSensorTrim1_3_ValueAUds;
        Label ShortTermSecondaryOxygenSensorTrim1_3_ValueBUds;
        Label ShortTermSecondaryOxygenSensorTrim2_4_ValueAUds;
        Label ShortTermSecondaryOxygenSensorTrim2_4_ValueBUds;
        Label MAFAirFlowRateUds;
        Label MaximunValueAirFlowRateFromMassAirFlowSensor_ValueAUds;
        Label MaximunValueAirFlowRateFromMassAirFlowSensor_ValueBUds;
        Label MaximunValueAirFlowRateFromMassAirFlowSensor_ValueCUds;
        Label MaximunValueAirFlowRateFromMassAirFlowSensor_ValueDUds;
        Label RelativeAcceleratorPedalPositionUds;
        Label RelativeThrottlePositionUds;
        Label ThrottlePositionUds;
        Label TimeRunWithMILOnUds;
        Thread t;
        
           

       

        public ConsultParameters(DispositivoConectado previousPage)
        {

            
            InitializeComponent();
            this.previousPage = previousPage;

            var layout = new StackLayout();

            layout.Padding = new Thickness(0, 20, 0, 0);
            var grid = new Grid();
            grid.BackgroundColor = Color.Azure;
            


            connectionManagement = DependencyService.Get<IConnectionManagement>();

            RPM = new Label();            
            RPM.Text = "RPM";
            RPM.HorizontalTextAlignment = TextAlignment.Center;
            RPM.VerticalTextAlignment = TextAlignment.Center;
            RPMResult = new Label();
            RPMResult.SetBinding(Label.TextProperty, "Rpm");
            RPMResult.HorizontalTextAlignment = TextAlignment.Center;
            RPMResult.VerticalTextAlignment = TextAlignment.Center;
            RPMUds = new Label();
            RPMUds.HorizontalTextAlignment = TextAlignment.Center;
            RPMUds.VerticalTextAlignment = TextAlignment.Center;
            RPMUds.Text = "rpm";
            RPMUds.FontAttributes = FontAttributes.Italic;


            Speed = new Label();
            Speed.Text = "Velocidad";
            Speed.HorizontalTextAlignment = TextAlignment.Center;
            Speed.VerticalTextAlignment = TextAlignment.Center;
            SpeedResult = new Label();
            SpeedResult.SetBinding(Label.TextProperty, "Speed");
            Speed.HorizontalTextAlignment = TextAlignment.Center;
            Speed.VerticalTextAlignment = TextAlignment.Center;
            SpeedUds = new Label();
            SpeedUds.Text = "Km/h";
            SpeedUds.HorizontalTextAlignment = TextAlignment.Center;
            SpeedUds.VerticalTextAlignment = TextAlignment.Center;
            SpeedUds.FontAttributes = FontAttributes.Italic;

            EngineTemperature = new Label();
            EngineTemperature.Text = "Temperatura del Motor";
            EngineTemperature.HorizontalTextAlignment = TextAlignment.Center;
            EngineTemperature.VerticalTextAlignment = TextAlignment.Center;
            EngineTemperatureResult = new Label();
            EngineTemperatureResult.SetBinding(Label.TextProperty, "EngineTemperature");
            EngineOilTemperatureResult.HorizontalTextAlignment = TextAlignment.Center;
            EngineTemperatureResult.VerticalTextAlignment = TextAlignment.Center;
            EngineTemperatureUds = new Label();
            EngineTemperatureUds.Text = "ºC";
            EngineTemperatureUds.HorizontalTextAlignment = TextAlignment.Center;
            EngineTemperatureUds.VerticalTextAlignment = TextAlignment.Center;
            EngineTemperatureUds.FontAttributes = FontAttributes.Italic;

            TimeEngineStart = new Label();
            TimeEngineStart.Text = "Time Engine Start";
            TimeEngineStart.HorizontalTextAlignment = TextAlignment.Center;
            TimeEngineStart.VerticalTextAlignment = TextAlignment.Center;
            TimeEngineStartResult = new Label();
            TimeEngineStartResult.SetBinding(Label.TextProperty, "TimeEngineStart");
            TimeEngineStartResult.HorizontalTextAlignment = TextAlignment.Center;
            TimeEngineStartResult.VerticalTextAlignment = TextAlignment.Center;
            TimeEngineStartUds = new Label();
            TimeEngineStartUds.Text = "segundos";
            TimeEngineStartUds.HorizontalTextAlignment = TextAlignment.Center;
            TimeEngineStartUds.VerticalTextAlignment = TextAlignment.Center;
            TimeEngineStartUds.FontAttributes = FontAttributes.Italic;


            HybridBateryPackRemainingLife = new Label();
            HybridBateryPackRemainingLife.Text = "Batería Híbrida Restante";
            HybridBateryPackRemainingLife.HorizontalTextAlignment = TextAlignment.Center;
            HybridBateryPackRemainingLife.VerticalTextAlignment = TextAlignment.Center;
            HybridBateryPackRemainingLifeResult = new Label();
            HybridBateryPackRemainingLifeResult.SetBinding(Label.TextProperty, "HybridBateryPackRemainingLife");
            HybridBateryPackRemainingLifeResult.HorizontalTextAlignment = TextAlignment.Center;
            HybridBateryPackRemainingLifeResult.VerticalTextAlignment = TextAlignment.Center;
            HybridBateryPackRemainingLifeUds = new Label();
            HybridBateryPackRemainingLifeUds.Text = "%";
            HybridBateryPackRemainingLifeUds.HorizontalTextAlignment = TextAlignment.Center;
            HybridBateryPackRemainingLifeUds.VerticalTextAlignment = TextAlignment.Center;
            HybridBateryPackRemainingLifeUds.FontAttributes = FontAttributes.Italic;

            AbsoluteBarometricPressure = new Label();
            AbsoluteBarometricPressure.Text = "Presión barométrica";
            AbsoluteBarometricPressure.HorizontalTextAlignment = TextAlignment.Center;
            AbsoluteBarometricPressure.VerticalTextAlignment = TextAlignment.Center;
            AbsoluteBarometricPressureResult = new Label();
            AbsoluteBarometricPressureResult.SetBinding(Label.TextProperty, "AbsoluteBarometricPressure");
            AbsoluteBarometricPressureResult.HorizontalTextAlignment = TextAlignment.Center;
            AbsoluteBarometricPressureResult.VerticalTextAlignment = TextAlignment.Center;
            AbsoluteBarometricPressureUds = new Label();
            AbsoluteBarometricPressureUds.Text = "kPa";
            AbsoluteBarometricPressureUds.HorizontalTextAlignment = TextAlignment.Center;
            AbsoluteBarometricPressureUds.VerticalTextAlignment = TextAlignment.Center;
            AbsoluteBarometricPressureUds.FontAttributes = FontAttributes.Italic;
            
            AbsoluteEvapSystemVaporPressure = new Label();
            AbsoluteEvapSystemVaporPressure.Text = "Presión de vapor de Sist. Evaporativo";
            AbsoluteEvapSystemVaporPressure.HorizontalTextAlignment = TextAlignment.Center;
            AbsoluteEvapSystemVaporPressure.VerticalTextAlignment = TextAlignment.Center;
            AbsoluteEvapSystemVaporPressureResult = new Label();
            AbsoluteEvapSystemVaporPressureResult.SetBinding(Label.TextProperty, "AbsoluteEvapSystemVaportPressure");
            AbsoluteEvapSystemVaporPressureResult.HorizontalTextAlignment = TextAlignment.Center;
            AbsoluteEvapSystemVaporPressureResult.VerticalTextAlignment = TextAlignment.Center;
            AbsoluteEvapSystemVaporPressureUds = new Label();
            AbsoluteEvapSystemVaporPressureUds.Text = "kPa";
            AbsoluteEvapSystemVaporPressureUds.HorizontalTextAlignment = TextAlignment.Center;
            AbsoluteEvapSystemVaporPressureUds.VerticalTextAlignment = TextAlignment.Center;
            AbsoluteEvapSystemVaporPressureUds.FontAttributes = FontAttributes.Italic;

            EvapSystemVaporPressure = new Label();
            EvapSystemVaporPressure.Text = "Presión de vapor de Sist. Evaporativo";
            EvapSystemVaporPressure.HorizontalTextAlignment = TextAlignment.Center;
            EvapSystemVaporPressure.VerticalTextAlignment = TextAlignment.Center;
            EvapSystemVaporPressureResult = new Label();
            EvapSystemVaporPressureResult.SetBinding(Label.TextProperty, "EvapSystemVaporPressure");
            EvapSystemVaporPressureResult.HorizontalTextAlignment = TextAlignment.Center;
            EvapSystemVaporPressureResult.VerticalTextAlignment = TextAlignment.Center;
            EvapSystemVaporPressureUds = new Label();
            EvapSystemVaporPressureUds.Text = "kPa";
            EvapSystemVaporPressureUds.HorizontalTextAlignment = TextAlignment.Center;
            EvapSystemVaporPressureUds.VerticalTextAlignment = TextAlignment.Center;
            EvapSystemVaporPressureUds.FontAttributes = FontAttributes.Italic;


            AbsoluteLoadValue = new Label();
            AbsoluteLoadValue.Text = "Valor absoluto de carga";
            AbsoluteLoadValue.HorizontalTextAlignment = TextAlignment.Center;
            AbsoluteLoadValue.VerticalTextAlignment = TextAlignment.Center;
            AbsoluteLoadValueResult = new Label();
            AbsoluteLoadValueResult.SetBinding(Label.TextProperty, "AbsoluteLoadValue");
            AbsoluteLoadValueResult.HorizontalTextAlignment = TextAlignment.Center;
            AbsoluteLoadValueResult.VerticalTextAlignment = TextAlignment.Center;
            AbsoluteLoadValueUds = new Label();
            AbsoluteLoadValueUds.Text = "%";
            AbsoluteLoadValueUds.HorizontalTextAlignment = TextAlignment.Center;
            AbsoluteLoadValueUds.VerticalTextAlignment = TextAlignment.Center;
            AbsoluteLoadValueUds.FontAttributes = FontAttributes.Italic;


            AbsoluteThrottlePositionB = new Label();
            AbsoluteThrottlePositionB.Text = "Posición absoluta acelerador B";
            AbsoluteThrottlePositionB.HorizontalTextAlignment = TextAlignment.Center;
            AbsoluteThrottlePositionB.VerticalTextAlignment = TextAlignment.Center;
            AbsoluteThrottlePositionBResult = new Label();
            AbsoluteThrottlePositionBResult.SetBinding(Label.TextProperty, "AbsoluteThrottlePositionB");
            AbsoluteThrottlePositionBResult.HorizontalTextAlignment = TextAlignment.Center;
            AbsoluteThrottlePositionBResult.VerticalTextAlignment = TextAlignment.Center;
            AbsoluteThrottlePositionBUds = new Label();
            AbsoluteThrottlePositionBUds.Text = "%";
            AbsoluteThrottlePositionBUds.HorizontalTextAlignment = TextAlignment.Center;
            AbsoluteThrottlePositionBUds.VerticalTextAlignment = TextAlignment.Center;
            AbsoluteThrottlePositionBUds.FontAttributes = FontAttributes.Italic;


            AbsoluteThrottlePositionC = new Label();
            AbsoluteThrottlePositionC.Text = "Posición absoluta acelerador C";
            AbsoluteThrottlePositionC.HorizontalTextAlignment = TextAlignment.Center;
            AbsoluteThrottlePositionC.VerticalTextAlignment = TextAlignment.Center;
            AbsoluteThrottlePositionCResult = new Label();
            AbsoluteThrottlePositionCResult.SetBinding(Label.TextProperty, "AbsoluteThrottlePositionC");
            AbsoluteThrottlePositionCResult.HorizontalTextAlignment = TextAlignment.Center;
            AbsoluteThrottlePositionCResult.VerticalTextAlignment = TextAlignment.Center;
            AbsoluteThrottlePositionCUds = new Label();
            AbsoluteThrottlePositionCUds.Text = "%";
            AbsoluteThrottlePositionCUds.HorizontalTextAlignment = TextAlignment.Center;
            AbsoluteThrottlePositionCUds.VerticalTextAlignment = TextAlignment.Center;
            AbsoluteThrottlePositionCUds.FontAttributes = FontAttributes.Italic;

            AbsoluteThrottlePositionD = new Label();
            AbsoluteThrottlePositionD.Text = "Posición absoluta acelerador D";
            AbsoluteThrottlePositionD.HorizontalTextAlignment = TextAlignment.Center;
            AbsoluteThrottlePositionD.VerticalTextAlignment = TextAlignment.Center;
            AbsoluteThrottlePositionDResult = new Label();
            AbsoluteThrottlePositionDResult.SetBinding(Label.TextProperty, "AbsoluteThrottlePositionD");
            AbsoluteThrottlePositionDResult.HorizontalTextAlignment = TextAlignment.Center;
            AbsoluteThrottlePositionDResult.VerticalTextAlignment = TextAlignment.Center;
            AbsoluteThrottlePositionDUds = new Label();
            AbsoluteThrottlePositionDUds.Text = "%";
            AbsoluteThrottlePositionDUds.HorizontalTextAlignment = TextAlignment.Center;
            AbsoluteThrottlePositionDUds.VerticalTextAlignment = TextAlignment.Center;
            AbsoluteThrottlePositionDUds.FontAttributes = FontAttributes.Italic;


            AbsoluteThrottlePositionE = new Label();
            AbsoluteThrottlePositionE.Text = "Posición absoluta acelerador E";
            AbsoluteThrottlePositionE.HorizontalTextAlignment = TextAlignment.Center;
            AbsoluteThrottlePositionE.VerticalTextAlignment = TextAlignment.Center;
            AbsoluteThrottlePositionEResult = new Label();
            AbsoluteThrottlePositionEResult.SetBinding(Label.TextProperty, "AbsoluteThrottlePositionE");
            AbsoluteThrottlePositionEResult.HorizontalTextAlignment = TextAlignment.Center;
            AbsoluteThrottlePositionEResult.VerticalTextAlignment = TextAlignment.Center;
            AbsoluteThrottlePositionEUds = new Label();
            AbsoluteThrottlePositionEUds.Text = "%";
            AbsoluteThrottlePositionEUds.HorizontalTextAlignment = TextAlignment.Center;
            AbsoluteThrottlePositionEUds.VerticalTextAlignment = TextAlignment.Center;
            AbsoluteThrottlePositionEUds.FontAttributes = FontAttributes.Italic;

            AbsoluteThrottlePositionF = new Label();
            AbsoluteThrottlePositionF.Text = "Posición absoluta acelerador F";
            AbsoluteThrottlePositionF.HorizontalTextAlignment = TextAlignment.Center;
            AbsoluteThrottlePositionF.VerticalTextAlignment = TextAlignment.Center;
            AbsoluteThrottlePositionFResult = new Label();
            AbsoluteThrottlePositionFResult.SetBinding(Label.TextProperty, "AbsoluteThrottlePositionF");
            AbsoluteThrottlePositionFResult.HorizontalTextAlignment = TextAlignment.Center;
            AbsoluteThrottlePositionFResult.VerticalTextAlignment = TextAlignment.Center;
            AbsoluteThrottlePositionFUds = new Label();
            AbsoluteThrottlePositionFUds.Text = "%";
            AbsoluteThrottlePositionFUds.HorizontalTextAlignment = TextAlignment.Center;
            AbsoluteThrottlePositionFUds.VerticalTextAlignment = TextAlignment.Center;
            AbsoluteThrottlePositionFUds.FontAttributes = FontAttributes.Italic;

            CatalystTemperatureB1S1 = new Label();
            CatalystTemperatureB1S1.Text = "Temperatura Catalizador Banco:1 Sensor:1";
            CatalystTemperatureB1S1.HorizontalTextAlignment = TextAlignment.Center;
            CatalystTemperatureB1S1.VerticalTextAlignment = TextAlignment.Center;
            CatalystTemperatureB1S1Result = new Label();
            CatalystTemperatureB1S1Result.SetBinding(Label.TextProperty, "CatalystTemperatureB1S1");
            CatalystTemperatureB1S1Result.HorizontalTextAlignment = TextAlignment.Center;
            CatalystTemperatureB1S1Result.VerticalTextAlignment = TextAlignment.Center;
            CatalystTemperatureB1S1Uds = new Label();
            AbsoluteThrottlePositionBUds.Text = "ºC";
            CatalystTemperatureB1S1Uds.HorizontalTextAlignment = TextAlignment.Center;
            CatalystTemperatureB1S1Uds.VerticalTextAlignment = TextAlignment.Center;
            CatalystTemperatureB1S1Uds.FontAttributes = FontAttributes.Italic;

            CatalystTemperatureB1S2 = new Label();
            CatalystTemperatureB1S2.Text = "Temperatura Catalizador Banco:1 Sensor:2";
            CatalystTemperatureB1S2.HorizontalTextAlignment = TextAlignment.Center;
            CatalystTemperatureB1S2.VerticalTextAlignment = TextAlignment.Center;
            CatalystTemperatureB1S2Result = new Label();
            CatalystTemperatureB1S2Result.SetBinding(Label.TextProperty, "CatalystTemperatureB1S2");
            CatalystTemperatureB1S2Result.HorizontalTextAlignment = TextAlignment.Center;
            CatalystTemperatureB1S2Result.VerticalTextAlignment = TextAlignment.Center;
            CatalystTemperatureB1S2Uds = new Label();
            AbsoluteThrottlePositionBUds.Text = "ºC";
            CatalystTemperatureB1S2Uds.HorizontalTextAlignment = TextAlignment.Center;
            CatalystTemperatureB1S2Uds.VerticalTextAlignment = TextAlignment.Center;
            CatalystTemperatureB1S2Uds.FontAttributes = FontAttributes.Italic;

            CatalystTemperatureB2S1 = new Label();
            CatalystTemperatureB2S1.Text = "Temperatura Catalizador Banco:2 Sensor:1";
            CatalystTemperatureB2S1.HorizontalTextAlignment = TextAlignment.Center;
            CatalystTemperatureB2S1.VerticalTextAlignment = TextAlignment.Center;
            CatalystTemperatureB2S1Result = new Label();
            CatalystTemperatureB2S1Result.SetBinding(Label.TextProperty, "CatalystTemperatureB2S1");
            CatalystTemperatureB2S1Result.HorizontalTextAlignment = TextAlignment.Center;
            CatalystTemperatureB2S1Result.VerticalTextAlignment = TextAlignment.Center;
            CatalystTemperatureB2S1Uds = new Label();
            AbsoluteThrottlePositionBUds.Text = "ºC";
            CatalystTemperatureB2S1Uds.HorizontalTextAlignment = TextAlignment.Center;
            CatalystTemperatureB2S1Uds.VerticalTextAlignment = TextAlignment.Center;
            CatalystTemperatureB2S1Uds.FontAttributes = FontAttributes.Italic;

            CatalystTemperatureB2S2 = new Label();
            CatalystTemperatureB2S2.Text = "Temperatura Catalizador Banco:2 Sensor:2";
            CatalystTemperatureB2S2.HorizontalTextAlignment = TextAlignment.Center;
            CatalystTemperatureB2S2.VerticalTextAlignment = TextAlignment.Center;
            CatalystTemperatureB2S2Result = new Label();
            CatalystTemperatureB2S2Result.SetBinding(Label.TextProperty, "CatalystTemperatureB2S2");
            CatalystTemperatureB2S2Result.HorizontalTextAlignment = TextAlignment.Center;
            CatalystTemperatureB2S2Result.VerticalTextAlignment = TextAlignment.Center;
            CatalystTemperatureB2S2Uds = new Label();
            AbsoluteThrottlePositionBUds.Text = "ºC";
            CatalystTemperatureB2S2Uds.HorizontalTextAlignment = TextAlignment.Center;
            CatalystTemperatureB2S2Uds.VerticalTextAlignment = TextAlignment.Center;
            CatalystTemperatureB2S2Uds.FontAttributes = FontAttributes.Italic;

            CommandedEvaporativePurge = new Label();
            CommandedEvaporativePurge.Text = "Purga evaporativa comandada";
            CommandedEvaporativePurge.HorizontalTextAlignment = TextAlignment.Center;
            CommandedEvaporativePurge.VerticalTextAlignment = TextAlignment.Center;
            CommandedEvaporativePurgeResult = new Label();
            CommandedEvaporativePurgeResult.SetBinding(Label.TextProperty, "CommanddEvaporativePurge");
            CommandedEvaporativePurgeResult.HorizontalTextAlignment = TextAlignment.Center;
            CommandedEvaporativePurgeResult.VerticalTextAlignment = TextAlignment.Center;
            CommandedEvaporativePurgeUds = new Label();
            CommandedEvaporativePurgeUds.Text = "%";
            CommandedEvaporativePurgeUds.HorizontalTextAlignment = TextAlignment.Center;
            CommandedEvaporativePurgeUds.VerticalTextAlignment = TextAlignment.Center;
            CommandedEvaporativePurgeUds.FontAttributes = FontAttributes.Italic;

            CommandedEGR = new Label();
            CommandedEGR.Text = "EGR comandada";
            CommandedEGR.HorizontalTextAlignment = TextAlignment.Center;
            CommandedEGR.VerticalTextAlignment = TextAlignment.Center;
            CommandedEGRResult = new Label();
            CommandedEGRResult.SetBinding(Label.TextProperty, "CommandedEGR");
            CommandedEGRResult.HorizontalTextAlignment = TextAlignment.Center;
            CommandedEGRResult.VerticalTextAlignment = TextAlignment.Center;
            CommandedEGRUds = new Label();
            CommandedEGRUds.Text = "%";
            CommandedEGRUds.HorizontalTextAlignment = TextAlignment.Center;
            CommandedEGRUds.VerticalTextAlignment = TextAlignment.Center;
            CommandedEGRUds.FontAttributes = FontAttributes.Italic;


            CommandedThrottleActuatorValue = new Label();
            CommandedThrottleActuatorValue.Text = "	Actuador comandando del acelerador";
            CommandedThrottleActuatorValue.HorizontalTextAlignment = TextAlignment.Center;
            CommandedThrottleActuatorValue.VerticalTextAlignment = TextAlignment.Center;
            CommandedThrottleActuatorValueResult = new Label();
            CommandedThrottleActuatorValueResult.SetBinding(Label.TextProperty, "CommandedThrottleActuatorValue");
            CommandedThrottleActuatorValueResult.HorizontalTextAlignment = TextAlignment.Center;
            CommandedThrottleActuatorValueResult.VerticalTextAlignment = TextAlignment.Center;
            CommandedThrottleActuatorValueUds = new Label();
            CommandedThrottleActuatorValueUds.Text = "%";
            CommandedThrottleActuatorValueUds.HorizontalTextAlignment = TextAlignment.Center;
            CommandedThrottleActuatorValueUds.VerticalTextAlignment = TextAlignment.Center;
            CommandedThrottleActuatorValueUds.FontAttributes = FontAttributes.Italic;


            ControlModuleVoltage = new Label();
            ControlModuleVoltage.Text = "Voltaje del módulo de control";
            ControlModuleVoltage.HorizontalTextAlignment = TextAlignment.Center;
            ControlModuleVoltage.VerticalTextAlignment = TextAlignment.Center;
            ControlModuleVoltageResult = new Label();
            ControlModuleVoltageResult.SetBinding(Label.TextProperty, "ControlModuleVoltage");
            ControlModuleVoltage.HorizontalTextAlignment = TextAlignment.Center;
            ControlModuleVoltage.VerticalTextAlignment = TextAlignment.Center;
            ControlModuleVoltageResultUds = new Label();
            ControlModuleVoltageResultUds.Text = "V";
            ControlModuleVoltageResultUds.HorizontalTextAlignment = TextAlignment.Center;
            ControlModuleVoltageResultUds.VerticalTextAlignment = TextAlignment.Center;
            ControlModuleVoltageResultUds.FontAttributes = FontAttributes.Italic;


            DistanceTraveledSinceCodesCleared = new Label();
            DistanceTraveledSinceCodesCleared.Text = "Distancia recorrida desde borrado de fallas";
            DistanceTraveledSinceCodesCleared.HorizontalTextAlignment = TextAlignment.Center;
            DistanceTraveledSinceCodesCleared.VerticalTextAlignment = TextAlignment.Center;
            DistanceTraveledSinceCodesClearedResult = new Label();
            DistanceTraveledSinceCodesClearedResult.SetBinding(Label.TextProperty, "DistanceTraveledSinceCodesCleared");
            DistanceTraveledSinceCodesClearedResult.HorizontalTextAlignment = TextAlignment.Center;
            DistanceTraveledSinceCodesClearedResult.VerticalTextAlignment = TextAlignment.Center;
            DistanceTraveledSinceCodesClearedUds = new Label();
            DistanceTraveledSinceCodesClearedUds.Text = "Km";
            DistanceTraveledSinceCodesClearedUds.HorizontalTextAlignment = TextAlignment.Center;
            DistanceTraveledSinceCodesClearedUds.VerticalTextAlignment = TextAlignment.Center;
            DistanceTraveledSinceCodesClearedUds.FontAttributes = FontAttributes.Italic;

            DistanceTraveledWithMILo = new Label();
            DistanceTraveledWithMILo.Text = "Distancia recorrida con MIL encendido";
            DistanceTraveledWithMILo.HorizontalTextAlignment = TextAlignment.Center;
            DistanceTraveledWithMILo.HorizontalTextAlignment = TextAlignment.Center;
            DistanceTraveledWithMILoResult = new Label();
            DistanceTraveledWithMILoResult.SetBinding(Label.TextProperty, "DistanceTraveledWithMILo");
            DistanceTraveledWithMILoResult.HorizontalTextAlignment = TextAlignment.Center;
            DistanceTraveledWithMILoResult.VerticalTextAlignment = TextAlignment.Center;
            DistanceTraveledWithMILoUds = new Label();
            DistanceTraveledWithMILoUds.Text = "Km";
            DistanceTraveledWithMILoUds.HorizontalTextAlignment = TextAlignment.Center;
            DistanceTraveledWithMILoUds.VerticalTextAlignment = TextAlignment.Center;
            DistanceTraveledWithMILoUds.FontAttributes = FontAttributes.Italic;

            EGRError = new Label();
            EGRError.Text = "Falla EGR";
            EGRError.HorizontalTextAlignment = TextAlignment.Center;
            EGRError.VerticalTextAlignment = TextAlignment.Center;
            EGRErrorResult = new Label();
            EGRErrorResult.SetBinding(Label.TextProperty, "EGRError1");
            EGRErrorResult.HorizontalTextAlignment = TextAlignment.Center;
            EGRErrorResult.VerticalTextAlignment = TextAlignment.Center;
            EGRErrorUds = new Label();
            EGRErrorUds.Text = "%";
            EGRErrorUds.HorizontalTextAlignment = TextAlignment.Center;
            EGRErrorUds.VerticalTextAlignment = TextAlignment.Center;
            EGRErrorUds.FontAttributes = FontAttributes.Italic;

            EngineFuelRateValue = new Label();
            EngineFuelRateValue.Text = "Velocidad de combustible del motor";
            EngineFuelRateValue.HorizontalTextAlignment = TextAlignment.Center;
            EngineFuelRateValue.VerticalTextAlignment = TextAlignment.Center;
            EngineFuelRateValueResult = new Label();
            EngineFuelRateValueResult.SetBinding(Label.TextProperty, "EngineFuelRateValue");
            EngineFuelRateValueResult.HorizontalTextAlignment = TextAlignment.Center;
            EngineFuelRateValueResult.VerticalTextAlignment = TextAlignment.Center;
            EngineFuelRateValueUds = new Label();
            EngineOilTemperatureUds.Text = "ºC";
            EngineFuelRateValueUds.HorizontalTextAlignment = TextAlignment.Center;
            EngineFuelRateValueUds.VerticalTextAlignment = TextAlignment.Center;
            EngineFuelRateValueUds.FontAttributes = FontAttributes.Italic;

            EngineOilTemperature = new Label();
            EngineOilTemperature.Text = "Temperatura del aceite del motor";
            EngineOilTemperature.HorizontalTextAlignment = TextAlignment.Center;
            EngineOilTemperature.VerticalTextAlignment = TextAlignment.Center;
            EngineOilTemperatureResult = new Label();
            EngineOilTemperatureResult.SetBinding(Label.TextProperty, "EngineOilTemperature");
            EngineOilTemperatureResult.HorizontalTextAlignment = TextAlignment.Center;
            EngineOilTemperatureResult.VerticalTextAlignment = TextAlignment.Center;
            EngineOilTemperatureUds = new Label();
            EngineOilTemperatureUds.Text = "ºC";
            EngineOilTemperatureUds.HorizontalTextAlignment = TextAlignment.Center;
            EngineOilTemperatureUds.VerticalTextAlignment = TextAlignment.Center;
            EngineOilTemperatureUds.FontAttributes = FontAttributes.Italic;

            FuelAirCommandedEquivalenceRatio = new Label();
            FuelAirCommandedEquivalenceRatio.Text = "Relación equivaliente comandada de combustible - aire";
            FuelAirCommandedEquivalenceRatio.HorizontalTextAlignment = TextAlignment.Center;
            FuelAirCommandedEquivalenceRatio.VerticalTextAlignment = TextAlignment.Center;
            FuelAirCommandedEquivalenceRatioResult = new Label();
            FuelAirCommandedEquivalenceRatioResult.SetBinding(Label.TextProperty, "FuelAirCommandedEquivalenceRatio");
            FuelAirCommandedEquivalenceRatioResult.HorizontalTextAlignment = TextAlignment.Center;
            FuelAirCommandedEquivalenceRatioResult.VerticalTextAlignment = TextAlignment.Center;
            FuelAirCommandedEquivalenceRatioUds = new Label();
            FuelAirCommandedEquivalenceRatioUds.Text = "ratio";
            FuelAirCommandedEquivalenceRatioUds.HorizontalTextAlignment = TextAlignment.Center;
            FuelAirCommandedEquivalenceRatioUds.VerticalTextAlignment = TextAlignment.Center;
            FuelAirCommandedEquivalenceRatioUds.FontAttributes = FontAttributes.Italic;

            FuelInjectionTiming = new Label();
            FuelInjectionTiming.Text = "Sincronización de la inyección de combustible";
            FuelInjectionTiming.HorizontalTextAlignment = TextAlignment.Center;
            FuelInjectionTiming.VerticalTextAlignment = TextAlignment.Center;
            FuelInjectionTimingResult = new Label();
            FuelInjectionTimingResult.SetBinding(Label.TextProperty, "FuelInjectionTiming");
            FuelInjectionTimingResult.HorizontalTextAlignment = TextAlignment.Center;
            FuelInjectionTimingResult.VerticalTextAlignment = TextAlignment.Center;
            FuelInjectionTimingUds = new Label();
            FuelInjectionTimingUds.Text = "º";
            FuelInjectionTimingUds.HorizontalTextAlignment = TextAlignment.Center;
            FuelInjectionTimingUds.VerticalTextAlignment = TextAlignment.Center;
            FuelInjectionTimingUds.FontAttributes = FontAttributes.Italic;

            FuelPressure = new Label();
            FuelPressure.Text = "Presión del combustible";
            FuelPressure.HorizontalTextAlignment = TextAlignment.Center;
            FuelPressure.VerticalTextAlignment = TextAlignment.Center;
            FuelPressureResult = new Label();
            FuelPressureResult.SetBinding(Label.TextProperty, "FuelPressure");
            FuelPressureResult.HorizontalTextAlignment = TextAlignment.Center;
            FuelPressureResult.VerticalTextAlignment = TextAlignment.Center;
            FuelPressureUds = new Label();
            FuelPressureUds.Text = "kPa";
            FuelPressureUds.HorizontalTextAlignment = TextAlignment.Center;
            FuelPressureUds.VerticalTextAlignment = TextAlignment.Center;
            FuelPressure.FontAttributes = FontAttributes.Italic;

            FuelRailAbsolutePressure = new Label();
            FuelRailAbsolutePressure.Text = "	Presión absoluta del tren de combustible";
            FuelRailAbsolutePressure.HorizontalTextAlignment = TextAlignment.Center;
            FuelRailAbsolutePressure.VerticalTextAlignment = TextAlignment.Center;
            FuelRailAbsolutePressureResult = new Label();
            FuelRailAbsolutePressureResult.SetBinding(Label.TextProperty, "FuelRailAbsolutePressure");
            FuelRailAbsolutePressureResult.HorizontalTextAlignment = TextAlignment.Center;
            FuelRailAbsolutePressureResult.VerticalTextAlignment = TextAlignment.Center;
            FuelRailAbsolutePressureUds = new Label();
            FuelRailAbsolutePressureUds.Text = "kPa";
            FuelRailAbsolutePressureUds.HorizontalTextAlignment = TextAlignment.Center;
            FuelRailAbsolutePressureUds.VerticalTextAlignment = TextAlignment.Center;
            FuelRailAbsolutePressureUds.FontAttributes = FontAttributes.Italic;

            FuelRailGaugePressure = new Label();
            FuelRailGaugePressure.Text = "Presión del medidor del tren de combustible (Diesel o inyección directa de gasolina)";
            FuelRailGaugePressure.HorizontalTextAlignment = TextAlignment.Center;
            FuelRailGaugePressure.VerticalTextAlignment = TextAlignment.Center;
            FuelRailGaugePressureResult = new Label();
            FuelRailGaugePressureResult.SetBinding(Label.TextProperty, "FuelRailGaugePressure");
            FuelRailGaugePressureResult.HorizontalTextAlignment = TextAlignment.Center;
            FuelRailGaugePressureResult.VerticalTextAlignment = TextAlignment.Center;
            FuelRailGaugePressureUds = new Label();
            FuelRailGaugePressureUds.Text = "kPa";
            FuelRailGaugePressureUds.HorizontalTextAlignment = TextAlignment.Center;
            FuelRailGaugePressureUds.VerticalTextAlignment = TextAlignment.Center;
            FuelRailGaugePressureUds.FontAttributes = FontAttributes.Italic;

            FuelTankLevel = new Label();
            FuelTankLevel.Text = "Nivel de entrada del tanque de combustible";
            FuelTankLevel.HorizontalTextAlignment = TextAlignment.Center;
            FuelTankLevel.VerticalTextAlignment = TextAlignment.Center;
            FuelTankLevelResult = new Label();
            FuelTankLevelResult.SetBinding(Label.TextProperty, "FuelTankLevel");
            FuelTankLevelResult.HorizontalTextAlignment = TextAlignment.Center;
            FuelTankLevelResult.VerticalTextAlignment = TextAlignment.Center;
            FuelTankLevelUds = new Label();
            FuelTankLevelUds.Text = "%";
            FuelTankLevelUds.HorizontalTextAlignment = TextAlignment.Center;
            FuelTankLevelUds.VerticalTextAlignment = TextAlignment.Center;
            FuelTankLevelUds.FontAttributes = FontAttributes.Italic;

            FuelType = new Label();
            FuelType.Text = "Tipo de combustible";
            FuelType.HorizontalTextAlignment = TextAlignment.Center;
            FuelType.VerticalTextAlignment = TextAlignment.Center;
            FuelTypeResult = new Label();
            FuelTypeResult.SetBinding(Label.TextProperty, "FuelType");
            FuelTypeResult.HorizontalTextAlignment = TextAlignment.Center;
            FuelTypeResult.VerticalTextAlignment = TextAlignment.Center;
            FuelTypeUds = new Label();
            FuelTypeUds.Text = "";
            FuelTypeUds.HorizontalTextAlignment = TextAlignment.Center;
            FuelTypeUds.VerticalTextAlignment = TextAlignment.Center;
            FuelTypeUds.FontAttributes = FontAttributes.Italic;

            IntakeManifoldAbsolutePressureValue = new Label();
            IntakeManifoldAbsolutePressureValue.Text = "Presión absoluta del colector de admisión";
            IntakeManifoldAbsolutePressureValue.HorizontalTextAlignment = TextAlignment.Center;
            IntakeManifoldAbsolutePressureValue.VerticalTextAlignment = TextAlignment.Center;
            IntakeManifoldAbsolutePressureValueResult = new Label();
            IntakeManifoldAbsolutePressureValueResult.SetBinding(Label.TextProperty, "IntakeManifoldAbsolutePressureValue");
            IntakeManifoldAbsolutePressureValueResult.HorizontalTextAlignment = TextAlignment.Center;
            IntakeManifoldAbsolutePressureValueResult.VerticalTextAlignment = TextAlignment.Center;
            IntakeManifoldAbsolutePressureValueUds = new Label();
            IntakeManifoldAbsolutePressureValueUds.Text = "kPa";
            IntakeManifoldAbsolutePressureValueUds.HorizontalTextAlignment = TextAlignment.Center;
            IntakeManifoldAbsolutePressureValueUds.VerticalTextAlignment = TextAlignment.Center;
            IntakeManifoldAbsolutePressureValueUds.FontAttributes = FontAttributes.Italic;

            LongTermSecondaryOxygenSensorTrim1_3_ValueA = new Label();
            LongTermSecondaryOxygenSensorTrim1_3_ValueA.Text = "Ajuste sensor de oxigeno secundario: plazo largo. Banco 1";
            LongTermSecondaryOxygenSensorTrim1_3_ValueA.HorizontalTextAlignment = TextAlignment.Center;
            LongTermSecondaryOxygenSensorTrim1_3_ValueA.VerticalTextAlignment = TextAlignment.Center;
            LongTermSecondaryOxygenSensorTrim1_3_ValueAResult = new Label();
            LongTermSecondaryOxygenSensorTrim1_3_ValueAResult.SetBinding(Label.TextProperty, "LongTermSecondaryOxygenSensorTrim1_3_ValueA");
            LongTermSecondaryOxygenSensorTrim1_3_ValueAResult.HorizontalTextAlignment = TextAlignment.Center;
            LongTermSecondaryOxygenSensorTrim1_3_ValueAResult.VerticalTextAlignment = TextAlignment.Center;
            LongTermSecondaryOxygenSensorTrim1_3_ValueAUds = new Label();
            LongTermSecondaryOxygenSensorTrim1_3_ValueAUds.Text = "%";
            LongTermSecondaryOxygenSensorTrim1_3_ValueAUds.HorizontalTextAlignment = TextAlignment.Center;
            LongTermSecondaryOxygenSensorTrim1_3_ValueAUds.VerticalTextAlignment = TextAlignment.Center;
            LongTermSecondaryOxygenSensorTrim1_3_ValueAUds.FontAttributes = FontAttributes.Italic;


            LongTermSecondaryOxygenSensorTrim1_3_ValueB = new Label();
            LongTermSecondaryOxygenSensorTrim1_3_ValueB.Text = "Ajuste sensor de oxigeno secundario: plazo largo. Banco 3";
            LongTermSecondaryOxygenSensorTrim1_3_ValueB.HorizontalTextAlignment = TextAlignment.Center;
            LongTermSecondaryOxygenSensorTrim1_3_ValueB.VerticalTextAlignment = TextAlignment.Center;
            LongTermSecondaryOxygenSensorTrim1_3_ValueBResult = new Label();
            LongTermSecondaryOxygenSensorTrim1_3_ValueBResult.SetBinding(Label.TextProperty, "LongTermSecondaryOxygenSensorTrim1_3_ValueB");
            LongTermSecondaryOxygenSensorTrim1_3_ValueBResult.HorizontalTextAlignment = TextAlignment.Center;
            LongTermSecondaryOxygenSensorTrim1_3_ValueBResult.VerticalTextAlignment = TextAlignment.Center;
            LongTermSecondaryOxygenSensorTrim1_3_ValueBUds = new Label();
            LongTermSecondaryOxygenSensorTrim1_3_ValueBUds.Text = "%";
            LongTermSecondaryOxygenSensorTrim1_3_ValueBUds.HorizontalTextAlignment = TextAlignment.Center;
            LongTermSecondaryOxygenSensorTrim1_3_ValueBUds.VerticalTextAlignment = TextAlignment.Center;
            LongTermSecondaryOxygenSensorTrim1_3_ValueBUds.FontAttributes = FontAttributes.Italic;


            LongTermSecondaryOxygenSensorTrim2_4_ValueA = new Label();
            LongTermSecondaryOxygenSensorTrim2_4_ValueA.Text = "Ajuste sensor de oxigeno secundario: plazo largo. Banco 2";
            LongTermSecondaryOxygenSensorTrim2_4_ValueA.HorizontalTextAlignment = TextAlignment.Center;
            LongTermSecondaryOxygenSensorTrim2_4_ValueA.VerticalTextAlignment = TextAlignment.Center;
            LongTermSecondaryOxygenSensorTrim2_4_ValueAResult = new Label();
            LongTermSecondaryOxygenSensorTrim2_4_ValueAResult.SetBinding(Label.TextProperty, "LongTermSecondaryOxygenSensorTrim2_4_ValueA");
            LongTermSecondaryOxygenSensorTrim2_4_ValueAResult.HorizontalTextAlignment = TextAlignment.Center;
            LongTermSecondaryOxygenSensorTrim2_4_ValueAResult.VerticalTextAlignment = TextAlignment.Center;
            LongTermSecondaryOxygenSensorTrim2_4_ValueAUds = new Label();
            LongTermSecondaryOxygenSensorTrim2_4_ValueAUds.Text = "%";
            LongTermSecondaryOxygenSensorTrim2_4_ValueAUds.HorizontalTextAlignment = TextAlignment.Center;
            LongTermSecondaryOxygenSensorTrim2_4_ValueAUds.VerticalTextAlignment = TextAlignment.Center;
            LongTermSecondaryOxygenSensorTrim2_4_ValueAUds.FontAttributes = FontAttributes.Italic;

            LongTermSecondaryOxygenSensorTrim2_4_ValueB = new Label();
            LongTermSecondaryOxygenSensorTrim2_4_ValueB.Text = "Ajuste sensor de oxigeno secundario: plazo largo. Banco 4";
            LongTermSecondaryOxygenSensorTrim2_4_ValueB.HorizontalTextAlignment = TextAlignment.Center;
            LongTermSecondaryOxygenSensorTrim2_4_ValueB.VerticalTextAlignment = TextAlignment.Center;
            LongTermSecondaryOxygenSensorTrim2_4_ValueBResult = new Label();
            LongTermSecondaryOxygenSensorTrim2_4_ValueBResult.SetBinding(Label.TextProperty, "LongTermSecondaryOxygenSensorTrim2_4_ValueB");
            LongTermSecondaryOxygenSensorTrim2_4_ValueBResult.HorizontalTextAlignment = TextAlignment.Center;
            LongTermSecondaryOxygenSensorTrim2_4_ValueBResult.VerticalTextAlignment = TextAlignment.Center;
            LongTermSecondaryOxygenSensorTrim2_4_ValueBUds = new Label();
            LongTermSecondaryOxygenSensorTrim2_4_ValueBUds.Text = "%";
            LongTermSecondaryOxygenSensorTrim2_4_ValueBUds.HorizontalTextAlignment = TextAlignment.Center;
            LongTermSecondaryOxygenSensorTrim2_4_ValueBUds.VerticalTextAlignment = TextAlignment.Center;
            LongTermSecondaryOxygenSensorTrim2_4_ValueBUds.FontAttributes = FontAttributes.Italic;


            MAFAirFlowRate = new Label();
            MAFAirFlowRate.Text = "	Velocidad del flujo del aire MAF";
            MAFAirFlowRate.HorizontalTextAlignment = TextAlignment.Center;
            MAFAirFlowRate.VerticalTextAlignment = TextAlignment.Center;
            MAFAirFlowRateResult = new Label();
            MAFAirFlowRateResult.SetBinding(Label.TextProperty, "MAFAirFlowRate");
            MAFAirFlowRateResult.HorizontalTextAlignment = TextAlignment.Center;
            MAFAirFlowRateResult.VerticalTextAlignment = TextAlignment.Center;
            MAFAirFlowRateUds = new Label();
            MAFAirFlowRateUds.Text = "gr/s";
            MAFAirFlowRateUds.HorizontalTextAlignment = TextAlignment.Center;
            MAFAirFlowRateUds.VerticalTextAlignment = TextAlignment.Center;
            MAFAirFlowRateUds.FontAttributes = FontAttributes.Italic;

            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueA = new Label();
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueA.Text = "Velocidad de flujo de aire del sensor de flujo de aire masivo; A";
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueA.HorizontalTextAlignment = TextAlignment.Center;
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueA.VerticalTextAlignment = TextAlignment.Center;
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueAResult = new Label();
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueAResult.SetBinding(Label.TextProperty, "MaximunValueAirFlowRateFromMassAirFlowSensor_ValueA");
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueAResult.HorizontalTextAlignment = TextAlignment.Center;
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueAResult.VerticalTextAlignment = TextAlignment.Center;
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueAUds = new Label();
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueAUds.Text = "g/s";
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueAUds.HorizontalTextAlignment = TextAlignment.Center;
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueAUds.VerticalTextAlignment = TextAlignment.Center;
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueAUds.FontAttributes = FontAttributes.Italic;

            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueB = new Label();
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueB.Text = "Velocidad de flujo de aire del sensor de flujo de aire masivo; B";
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueB.HorizontalTextAlignment = TextAlignment.Center;
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueB.VerticalTextAlignment = TextAlignment.Center;
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueBResult = new Label();
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueBResult.SetBinding(Label.TextProperty, "MaximunValueAirFlowRateFromMassAirFlowSensor_ValueB");
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueBResult.HorizontalTextAlignment = TextAlignment.Center;
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueBResult.VerticalTextAlignment = TextAlignment.Center;
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueBUds = new Label();
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueBUds.Text = "g/s";
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueBUds.HorizontalTextAlignment = TextAlignment.Center;
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueBUds.VerticalTextAlignment = TextAlignment.Center;
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueBUds.FontAttributes = FontAttributes.Italic;

            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueC = new Label();
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueC.Text = "Velocidad de flujo de aire del sensor de flujo de aire masivo; C";
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueC.HorizontalTextAlignment = TextAlignment.Center;
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueC.VerticalTextAlignment = TextAlignment.Center;
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueCResult = new Label();
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueCResult.SetBinding(Label.TextProperty, "MaximunValueAirFlowRateFromMassAirFlowSensor_ValueC");
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueCResult.HorizontalTextAlignment = TextAlignment.Center;
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueCResult.VerticalTextAlignment = TextAlignment.Center;
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueCUds = new Label();
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueCUds.Text = "g/s";
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueCUds.HorizontalTextAlignment = TextAlignment.Center;
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueCUds.VerticalTextAlignment = TextAlignment.Center;
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueCUds.FontAttributes = FontAttributes.Italic;


            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueD = new Label();
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueD.Text = "Velocidad de flujo de aire del sensor de flujo de aire masivo; D";
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueD.HorizontalTextAlignment = TextAlignment.Center;
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueD.VerticalTextAlignment = TextAlignment.Center;
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueDResult = new Label();
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueDResult.SetBinding(Label.TextProperty, "MaximunValueAirFlowRateFromMassAirFlowSensor_ValueD");
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueDResult.HorizontalTextAlignment = TextAlignment.Center;
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueDResult.VerticalTextAlignment = TextAlignment.Center;
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueDUds = new Label();
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueDUds.Text = "g/s";
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueDUds.HorizontalTextAlignment = TextAlignment.Center;
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueDUds.VerticalTextAlignment = TextAlignment.Center;
            MaximunValueAirFlowRateFromMassAirFlowSensor_ValueDUds.FontAttributes = FontAttributes.Italic;


            RelativeAcceleratorPedalPosition = new Label();
            RelativeAcceleratorPedalPosition.Text = "Posición relativa del pedal del acelerador";
            RelativeAcceleratorPedalPosition.HorizontalTextAlignment = TextAlignment.Center;
            RelativeAcceleratorPedalPosition.VerticalTextAlignment = TextAlignment.Center;
            RelativeAcceleratorPedalPositionResult = new Label();
            RelativeAcceleratorPedalPositionResult.SetBinding(Label.TextProperty, "RelativeAcceleratorPedalPosition");
            RelativeAcceleratorPedalPositionResult.HorizontalTextAlignment = TextAlignment.Center;
            RelativeAcceleratorPedalPositionResult.VerticalTextAlignment = TextAlignment.Center;
            RelativeAcceleratorPedalPositionUds = new Label();
            RelativeAcceleratorPedalPositionUds.Text = "%";
            RelativeAcceleratorPedalPositionUds.HorizontalTextAlignment = TextAlignment.Center;
            RelativeAcceleratorPedalPositionUds.VerticalTextAlignment = TextAlignment.Center;
            RelativeAcceleratorPedalPositionUds.FontAttributes = FontAttributes.Italic;

            RelativeThrottlePosition = new Label();
            RelativeThrottlePosition.Text = "Posición relativa del acelerador";
            RelativeThrottlePosition.HorizontalTextAlignment = TextAlignment.Center;
            RelativeThrottlePosition.VerticalTextAlignment = TextAlignment.Center;
            RelativeThrottlePositionResult = new Label();
            RelativeThrottlePositionResult.SetBinding(Label.TextProperty, "RelativeThrottlePosition");
            RelativeThrottlePositionResult.HorizontalTextAlignment = TextAlignment.Center;
            RelativeThrottlePositionResult.VerticalTextAlignment = TextAlignment.Center;
            RelativeThrottlePositionUds = new Label();
            RelativeThrottlePositionUds.Text = "%";
            RelativeThrottlePositionUds.HorizontalTextAlignment = TextAlignment.Center;
            RelativeThrottlePositionUds.VerticalTextAlignment = TextAlignment.Center;
            RelativeThrottlePositionUds.FontAttributes = FontAttributes.Italic;


            ShortTermSecondaryOxygenSensorTrim1_3_ValueA = new Label();
            ShortTermSecondaryOxygenSensorTrim1_3_ValueA.Text = "Ajuste sensor de oxigeno secundario: plazo corto. Banco 1";
            ShortTermSecondaryOxygenSensorTrim1_3_ValueA.HorizontalTextAlignment = TextAlignment.Center;
            ShortTermSecondaryOxygenSensorTrim1_3_ValueA.VerticalTextAlignment = TextAlignment.Center;
            ShortTermSecondaryOxygenSensorTrim1_3_ValueAResult = new Label();
            ShortTermSecondaryOxygenSensorTrim1_3_ValueAResult.SetBinding(Label.TextProperty, "ShortTermSecondaryOxygenSensorTrim1_3_ValueA");
            ShortTermSecondaryOxygenSensorTrim1_3_ValueAResult.HorizontalTextAlignment = TextAlignment.Center;
            ShortTermSecondaryOxygenSensorTrim1_3_ValueAResult.VerticalTextAlignment = TextAlignment.Center;
            ShortTermSecondaryOxygenSensorTrim1_3_ValueAUds = new Label();
            ShortTermSecondaryOxygenSensorTrim1_3_ValueAUds.Text = "%";
            ShortTermSecondaryOxygenSensorTrim1_3_ValueAUds.HorizontalTextAlignment = TextAlignment.Center;
            ShortTermSecondaryOxygenSensorTrim1_3_ValueAUds.VerticalTextAlignment = TextAlignment.Center;
            ShortTermSecondaryOxygenSensorTrim1_3_ValueAUds.FontAttributes = FontAttributes.Italic;


            ShortTermSecondaryOxygenSensorTrim1_3_ValueB = new Label();
            ShortTermSecondaryOxygenSensorTrim1_3_ValueB.Text = "Ajuste sensor de oxigeno secundario: plazo corto. Banco 3";
            ShortTermSecondaryOxygenSensorTrim1_3_ValueB.HorizontalTextAlignment = TextAlignment.Center;
            ShortTermSecondaryOxygenSensorTrim1_3_ValueB.VerticalTextAlignment = TextAlignment.Center;
            ShortTermSecondaryOxygenSensorTrim1_3_ValueBResult = new Label();
            ShortTermSecondaryOxygenSensorTrim1_3_ValueBResult.SetBinding(Label.TextProperty, "ShortTermSecondaryOxygenSensorTrim1_3_ValueB");
            ShortTermSecondaryOxygenSensorTrim1_3_ValueBResult.HorizontalTextAlignment = TextAlignment.Center;
            ShortTermSecondaryOxygenSensorTrim1_3_ValueBResult.VerticalTextAlignment = TextAlignment.Center;
            ShortTermSecondaryOxygenSensorTrim1_3_ValueBUds = new Label();
            ShortTermSecondaryOxygenSensorTrim1_3_ValueBUds.Text = "%";
            ShortTermSecondaryOxygenSensorTrim1_3_ValueBUds.HorizontalTextAlignment = TextAlignment.Center;
            ShortTermSecondaryOxygenSensorTrim1_3_ValueBUds.VerticalTextAlignment = TextAlignment.Center;
            ShortTermSecondaryOxygenSensorTrim1_3_ValueBUds.FontAttributes = FontAttributes.Italic;


            ShortTermSecondaryOxygenSensorTrim2_4_ValueA = new Label();
            ShortTermSecondaryOxygenSensorTrim2_4_ValueA.Text = "Ajuste sensor de oxigeno secundario: plazo corto. Banco 2";
            ShortTermSecondaryOxygenSensorTrim2_4_ValueA.HorizontalTextAlignment = TextAlignment.Center;
            ShortTermSecondaryOxygenSensorTrim2_4_ValueA.VerticalTextAlignment = TextAlignment.Center;
            ShortTermSecondaryOxygenSensorTrim2_4_ValueAResult = new Label();
            ShortTermSecondaryOxygenSensorTrim2_4_ValueAResult.SetBinding(Label.TextProperty, "ShortTermSecondaryOxygenSensorTrim2_4_ValueA");
            ShortTermSecondaryOxygenSensorTrim2_4_ValueAResult.HorizontalTextAlignment = TextAlignment.Center;
            ShortTermSecondaryOxygenSensorTrim2_4_ValueAResult.VerticalTextAlignment = TextAlignment.Center;
            ShortTermSecondaryOxygenSensorTrim2_4_ValueAUds = new Label();
            ShortTermSecondaryOxygenSensorTrim2_4_ValueAUds.Text = "%";
            ShortTermSecondaryOxygenSensorTrim2_4_ValueAUds.HorizontalTextAlignment = TextAlignment.Center;
            ShortTermSecondaryOxygenSensorTrim2_4_ValueAUds.VerticalTextAlignment = TextAlignment.Center;
            ShortTermSecondaryOxygenSensorTrim2_4_ValueAUds.FontAttributes = FontAttributes.Italic;

            ShortTermSecondaryOxygenSensorTrim2_4_ValueB = new Label();
            ShortTermSecondaryOxygenSensorTrim2_4_ValueB.Text = "Ajuste sensor de oxigeno secundario: plazo corto. Banco 4";
            ShortTermSecondaryOxygenSensorTrim2_4_ValueB.HorizontalTextAlignment = TextAlignment.Center;
            ShortTermSecondaryOxygenSensorTrim2_4_ValueB.VerticalTextAlignment = TextAlignment.Center;
            ShortTermSecondaryOxygenSensorTrim2_4_ValueBResult = new Label();
            ShortTermSecondaryOxygenSensorTrim2_4_ValueBResult.SetBinding(Label.TextProperty, "ShortTermSecondaryOxygenSensorTrim2_4_ValueB");
            ShortTermSecondaryOxygenSensorTrim2_4_ValueBResult.HorizontalTextAlignment = TextAlignment.Center;
            ShortTermSecondaryOxygenSensorTrim2_4_ValueBResult.VerticalTextAlignment = TextAlignment.Center;
            ShortTermSecondaryOxygenSensorTrim2_4_ValueBUds = new Label();
            ShortTermSecondaryOxygenSensorTrim2_4_ValueBUds.Text = "%";
            ShortTermSecondaryOxygenSensorTrim2_4_ValueBUds.HorizontalTextAlignment = TextAlignment.Center;
            ShortTermSecondaryOxygenSensorTrim2_4_ValueBUds.VerticalTextAlignment = TextAlignment.Center;
            ShortTermSecondaryOxygenSensorTrim2_4_ValueBUds.FontAttributes = FontAttributes.Italic;

            ThrottlePosition = new Label();
            ThrottlePosition.Text = "Posición del acelerador";
            ThrottlePosition.HorizontalTextAlignment = TextAlignment.Center;
            ThrottlePosition.VerticalTextAlignment = TextAlignment.Center;
            ThrottlePositionResult = new Label();
            ThrottlePositionResult.SetBinding(Label.TextProperty, "ThrottlePosition");
            ThrottlePositionResult.HorizontalTextAlignment = TextAlignment.Center;
            ThrottlePositionResult.VerticalTextAlignment = TextAlignment.Center;
            ThrottlePositionUds = new Label();
            ThrottlePositionUds.Text = "%";
            ThrottlePositionUds.HorizontalTextAlignment = TextAlignment.Center;
            ThrottlePositionUds.VerticalTextAlignment = TextAlignment.Center;
            ThrottlePositionUds.FontAttributes = FontAttributes.Italic;

            TimeRunWithMILOn = new Label();
            TimeRunWithMILOn.Text = "Tiempo con indicador MIL encendido";
            TimeRunWithMILOn.HorizontalTextAlignment = TextAlignment.Center;
            TimeRunWithMILOn.VerticalTextAlignment = TextAlignment.Center;
            TimeRunWithMILOnResult = new Label();
            TimeRunWithMILOnResult.SetBinding(Label.TextProperty, "TimeRunWithMILOn");
            TimeRunWithMILOnResult.HorizontalTextAlignment = TextAlignment.Center;
            TimeRunWithMILOnResult.VerticalTextAlignment = TextAlignment.Center;
            TimeRunWithMILOnUds = new Label();
            TimeRunWithMILOnUds.Text = "segundos";
            TimeRunWithMILOnUds.HorizontalTextAlignment = TextAlignment.Center;
            TimeRunWithMILOnUds.VerticalTextAlignment = TextAlignment.Center;
            TimeRunWithMILOnUds.FontAttributes = FontAttributes.Italic;


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
                t = new Thread(launchVM());
                t.Start();
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
                grid.Children.Add(RPMUds, 2, contador);
                contador++;

            }
            if (actualVisibilidad.speedVisible == 1)
            {
                grid.Children.Add(Speed, 0, contador);
                grid.Children.Add(SpeedResult, 1, contador);
                grid.Children.Add(SpeedUds, 2, contador);
                contador++;
            }
            if (actualVisibilidad.hybridBateryPackRemainingLifeVisible == 1)
            {
                grid.Children.Add(HybridBateryPackRemainingLife, 0, contador);
                grid.Children.Add(HybridBateryPackRemainingLifeResult, 1, contador);
                grid.Children.Add(HybridBateryPackRemainingLifeUds, 2, contador);
                contador++;
            }


            if (actualVisibilidad.timeEngineStartVisible == 1)
            {
                grid.Children.Add(TimeEngineStart, 0, contador);
                grid.Children.Add(TimeEngineStartResult, 1, contador);
                grid.Children.Add(TimeEngineStartUds, 2, contador);
                contador++;
            }
            if (actualVisibilidad.absoluteBarometricPressureVisible == 1)
            {
                grid.Children.Add(AbsoluteBarometricPressure, 0, contador);
                grid.Children.Add(AbsoluteBarometricPressureResult, 1, contador);
                grid.Children.Add(AbsoluteBarometricPressureUds, 2, contador);
                contador++;
            }

            if (actualVisibilidad.absoluteLoadValueVisible == 1)
            {
                grid.Children.Add(AbsoluteLoadValue, 0, contador);
                grid.Children.Add(AbsoluteLoadValueResult, 1, contador);
                grid.Children.Add(AbsoluteLoadValueUds, 2, contador);
                contador++;
            }

            if (actualVisibilidad.absoluteThrottlePositionBVisible == 1)
            {
                grid.Children.Add(AbsoluteThrottlePositionB, 0, contador);
                grid.Children.Add(AbsoluteThrottlePositionBResult, 1, contador);
                grid.Children.Add(AbsoluteThrottlePositionBUds, 2, contador);
                contador++;
            }


            if (actualVisibilidad.absoluteThrottlePositionCVisible == 1)
            {
                grid.Children.Add(AbsoluteThrottlePositionC, 0, contador);
                grid.Children.Add(AbsoluteThrottlePositionCResult, 1, contador);
                grid.Children.Add(AbsoluteThrottlePositionCUds, 2, contador);
                contador++;
            }

            if (actualVisibilidad.absoluteThrottlePositionDVisible == 1)
            {
                grid.Children.Add(AbsoluteThrottlePositionD, 0, contador);
                grid.Children.Add(AbsoluteThrottlePositionDResult, 1, contador);
                grid.Children.Add(AbsoluteThrottlePositionDUds, 2, contador);
                contador++;
            }

            if (actualVisibilidad.absoluteThrottlePositionEVisible == 1)
            {
                grid.Children.Add(AbsoluteThrottlePositionE, 0, contador);
                grid.Children.Add(AbsoluteThrottlePositionEResult, 1, contador);
                grid.Children.Add(AbsoluteThrottlePositionEUds, 2, contador);
                contador++;
            }

            if (actualVisibilidad.absoluteThrottlePositionFVisible == 1)
            {
                grid.Children.Add(AbsoluteThrottlePositionF, 0, contador);
                grid.Children.Add(AbsoluteThrottlePositionFResult, 1, contador);
                grid.Children.Add(AbsoluteThrottlePositionFUds, 2, contador);
                contador++;

            }

            if (actualVisibilidad.catalystTemperatureB1S1Visible == 1)
            {
                grid.Children.Add(CatalystTemperatureB1S1, 0, contador);
                grid.Children.Add(CatalystTemperatureB1S1Result, 1, contador);
                grid.Children.Add(CatalystTemperatureB1S1Uds, 2, contador);
                contador++;
            }

            if (actualVisibilidad.catalystTemperatureB1S2Visible == 1)
            {
                grid.Children.Add(CatalystTemperatureB1S2, 0, contador);
                grid.Children.Add(CatalystTemperatureB1S2Result, 1, contador);
                grid.Children.Add(CatalystTemperatureB1S2Uds, 2, contador);
                contador++;
            }

            if (actualVisibilidad.catalystTemperatureB2S1Visible == 1)
            {
                grid.Children.Add(CatalystTemperatureB2S1, 0, contador);
                grid.Children.Add(CatalystTemperatureB2S1Result, 1, contador);
                grid.Children.Add(CatalystTemperatureB2S1Uds, 2, contador);
                contador++;
            }

            if (actualVisibilidad.catalystTemperatureB2S2Visible == 1)
            {
                grid.Children.Add(CatalystTemperatureB2S2, 0, contador);
                grid.Children.Add(CatalystTemperatureB2S2Result, 1, contador);
                grid.Children.Add(CatalystTemperatureB2S2Uds, 2, contador);
                contador++;
            }


            if (actualVisibilidad.commanddEvaporativePurgeVisible == 1)
            {
                grid.Children.Add(CommandedEvaporativePurge, 0, contador);
                grid.Children.Add(CommandedEvaporativePurgeResult, 1, contador);
                grid.Children.Add(CommandedEvaporativePurgeUds, 2, contador);
                contador++;
            }

            if (actualVisibilidad.commandedEGRVisible == 1)
            {
                grid.Children.Add(CommandedEGR, 0, contador);
                grid.Children.Add(CommandedEGRResult, 1, contador);
                grid.Children.Add(CommandedEGRUds, 2, contador);
                contador++;
            }

            if (actualVisibilidad.commandedThrottleActuatorValueVisible == 1)
            {
                grid.Children.Add(CommandedThrottleActuatorValue, 0, contador);
                grid.Children.Add(CommandedThrottleActuatorValueResult, 1, contador);
                grid.Children.Add(CommandedThrottleActuatorValueUds, 2, contador);
                contador++;

            }
            if (actualVisibilidad.controlModuleVoltageVisible == 1)
            {
                grid.Children.Add(ControlModuleVoltage, 0, contador);
                grid.Children.Add(ControlModuleVoltageResult, 1, contador);
                grid.Children.Add(ControlModuleVoltageResultUds, 2, contador);
                contador++;
            }

            if (actualVisibilidad.distanceTraveledSinceCodesClearedVisible == 1)
            {
                grid.Children.Add(DistanceTraveledSinceCodesCleared, 0, contador);
                grid.Children.Add(DistanceTraveledSinceCodesClearedResult, 1, contador);
                grid.Children.Add(DistanceTraveledSinceCodesClearedUds, 2, contador);
                contador++;
            }

            if (actualVisibilidad.distanceTraveledWithMILoVisible == 1)
            {
                grid.Children.Add(DistanceTraveledWithMILo, 0, contador);
                grid.Children.Add(DistanceTraveledWithMILoResult, 1, contador);
                grid.Children.Add(DistanceTraveledWithMILoUds, 2, contador);
                contador++;
            }
            if (actualVisibilidad.EGRErrorVisible == 1)
            {
                grid.Children.Add(EGRError, 0, contador);
                grid.Children.Add(EGRErrorResult, 1, contador);
                grid.Children.Add(EGRErrorUds, 2, contador);
                contador++;
            }
            if (actualVisibilidad.engineFuelRateValueVisible == 1)
            {

                grid.Children.Add(EngineFuelRateValue, 0, contador);
                grid.Children.Add(EngineFuelRateValueResult, 1, contador);
                grid.Children.Add(EngineFuelRateValueUds, 2, contador);
                contador++;
            }

            if (actualVisibilidad.engineOilTemperatureVisible == 1)
            {
                grid.Children.Add(EngineOilTemperature, 0, contador);
                grid.Children.Add(EngineOilTemperatureResult, 1, contador);
                grid.Children.Add(EngineOilTemperatureUds, 2, contador);
                contador++;
            }
            if (actualVisibilidad.evapSystemVaporPressureVisible == 1)
            {
                grid.Children.Add(EvapSystemVaporPressure, 0, contador);
                grid.Children.Add(EvapSystemVaporPressureResult, 1, contador);
                grid.Children.Add(CommandedEvaporativePurgeUds, 2, contador);
                contador++;
            }
            if (actualVisibilidad.fuelAirCommandedEquivalenceRatioVisible == 1)
            {
                grid.Children.Add(FuelAirCommandedEquivalenceRatio, 0, contador);
                grid.Children.Add(FuelAirCommandedEquivalenceRatioResult, 1, contador);
                grid.Children.Add(FuelAirCommandedEquivalenceRatioUds, 2, contador);
                contador++;
            }

            if (actualVisibilidad.fuelInjectionTimingVisible == 1)
            {
                grid.Children.Add(FuelInjectionTiming, 0, contador);
                grid.Children.Add(FuelInjectionTimingResult, 1, contador);
                grid.Children.Add(FuelInjectionTimingUds, 2, contador);
                contador++;
            }



            if (actualVisibilidad.fuelPressureVisible == 1)
            {
                grid.Children.Add(FuelPressure, 0, contador);
                grid.Children.Add(FuelPressureResult, 1, contador);
                grid.Children.Add(FuelPressureUds, 2, contador);
                contador++;
            }
            if (actualVisibilidad.fuelRailAbsolutePressureVisible == 1)
            {
                grid.Children.Add(FuelRailAbsolutePressure, 0, contador);
                grid.Children.Add(FuelRailAbsolutePressureResult, 1, contador);
                grid.Children.Add(FuelRailAbsolutePressureUds, 2, contador);
                contador++;
            }
            if (actualVisibilidad.fuelRailGaugePressureVisible == 1)
            {
                grid.Children.Add(FuelRailGaugePressure, 0, contador);
                grid.Children.Add(FuelRailGaugePressureResult, 1, contador);
                grid.Children.Add(FuelRailGaugePressureUds, 2, contador);
                contador++;
            }

            if (actualVisibilidad.fuelTankLevelVisible == 1)
            {
                grid.Children.Add(FuelTankLevel, 0, contador);
                grid.Children.Add(FuelTankLevelResult, 1, contador);
                grid.Children.Add(FuelTankLevelUds, 2, contador);
                contador++;
            }

            if (actualVisibilidad.fuelTypeVisible == 1)
            {
                grid.Children.Add(FuelType, 0, contador);
                grid.Children.Add(FuelTypeResult, 1, contador);
                grid.Children.Add(FuelTypeUds, 2, contador);
                contador++;
            }

            if (actualVisibilidad.intakeManifoldAbsolutePressureValueVisible == 1)
            {
                grid.Children.Add(IntakeManifoldAbsolutePressureValue, 0, contador);
                grid.Children.Add(IntakeManifoldAbsolutePressureValueResult, 1, contador);
                grid.Children.Add(IntakeManifoldAbsolutePressureValueUds, 2, contador);
                contador++;
            }

            if (actualVisibilidad.mAFAirFlowRateVisible == 1)
            {
                grid.Children.Add(MAFAirFlowRate, 0, contador);
                grid.Children.Add(MAFAirFlowRateResult, 1, contador);
                grid.Children.Add(MAFAirFlowRateUds, 2, contador);
                contador++;
            }

            if (actualVisibilidad.relativeAcceleratorPedalPositionVisible == 1)
            {
                grid.Children.Add(RelativeAcceleratorPedalPosition, 0, contador);
                grid.Children.Add(RelativeAcceleratorPedalPositionResult, 1, contador);
                grid.Children.Add(RelativeAcceleratorPedalPositionUds, 2, contador);
                contador++;
            }

            if (actualVisibilidad.relativeThrottlePositionVisible == 1)
            {
                grid.Children.Add(RelativeThrottlePosition, 0, contador);
                grid.Children.Add(RelativeThrottlePositionResult, 1, contador);
                grid.Children.Add(RelativeThrottlePositionUds, 2, contador);
                contador++;
            }

            if (actualVisibilidad.throttlePositionVisible == 1)
            {
                grid.Children.Add(ThrottlePosition, 0, contador);
                grid.Children.Add(ThrottlePositionResult, 1, contador);
                grid.Children.Add(ThrottlePositionUds, 2, contador);
                contador++;
            }

            if (actualVisibilidad.timeRunWithMILOnVisible == 1)
            {
                grid.Children.Add(TimeRunWithMILOn, 0, contador);
                grid.Children.Add(TimeRunWithMILOnResult, 1, contador);
                grid.Children.Add(TimeRunWithMILOnUds, 2, contador);
                contador++;
            }

            if (actualVisibilidad.longTermSecondaryOxygenSensorTrim1_3_Visible == 1)
            {
                grid.Children.Add(LongTermSecondaryOxygenSensorTrim1_3_ValueA, 0, contador);
                grid.Children.Add(LongTermSecondaryOxygenSensorTrim1_3_ValueAResult, 1, contador);
                grid.Children.Add(LongTermSecondaryOxygenSensorTrim1_3_ValueAUds, 2, contador);
                contador++;

                grid.Children.Add(LongTermSecondaryOxygenSensorTrim1_3_ValueB, 0, contador);
                grid.Children.Add(LongTermSecondaryOxygenSensorTrim1_3_ValueBResult, 1, contador);
                grid.Children.Add(LongTermSecondaryOxygenSensorTrim1_3_ValueBUds, 2, contador);

                contador++;
            }



            if (actualVisibilidad.longTermSecondaryOxygenSensorTrim2_4_Visible == 1)
            {
                grid.Children.Add(LongTermSecondaryOxygenSensorTrim2_4_ValueA, 0, contador);
                grid.Children.Add(LongTermSecondaryOxygenSensorTrim2_4_ValueAResult, 1, contador);
                grid.Children.Add(LongTermSecondaryOxygenSensorTrim2_4_ValueAUds, 2, contador);

                contador++;

                grid.Children.Add(LongTermSecondaryOxygenSensorTrim2_4_ValueB, 0, contador);
                grid.Children.Add(LongTermSecondaryOxygenSensorTrim2_4_ValueBResult, 1, contador);
                grid.Children.Add(LongTermSecondaryOxygenSensorTrim2_4_ValueAUds, 2, contador);

                contador++;
            }



            if (actualVisibilidad.shortTermSecondaryOxygenSensorTrim1_3_Visible == 1)
            {
                grid.Children.Add(ShortTermSecondaryOxygenSensorTrim1_3_ValueA, 0, contador);
                grid.Children.Add(ShortTermSecondaryOxygenSensorTrim1_3_ValueAResult, 1, contador);
                grid.Children.Add(ShortTermSecondaryOxygenSensorTrim1_3_ValueAUds, 2, contador);

                contador++;

                grid.Children.Add(ShortTermSecondaryOxygenSensorTrim1_3_ValueB, 0, contador);
                grid.Children.Add(ShortTermSecondaryOxygenSensorTrim1_3_ValueBResult, 1, contador);
                grid.Children.Add(ShortTermSecondaryOxygenSensorTrim1_3_ValueBUds, 2, contador);

                contador++;
            }


            if (actualVisibilidad.shortTermSecondaryOxygenSensorTrim2_4_Visible == 1)
            {
                grid.Children.Add(ShortTermSecondaryOxygenSensorTrim2_4_ValueA, 0, contador);
                grid.Children.Add(ShortTermSecondaryOxygenSensorTrim2_4_ValueAResult, 1, contador);
                grid.Children.Add(ShortTermSecondaryOxygenSensorTrim2_4_ValueAUds, 2, contador);

                contador++;

                grid.Children.Add(ShortTermSecondaryOxygenSensorTrim2_4_ValueB, 0, contador);
                grid.Children.Add(ShortTermSecondaryOxygenSensorTrim2_4_ValueBResult, 1, contador);
                grid.Children.Add(ShortTermSecondaryOxygenSensorTrim2_4_ValueBUds, 2, contador);

                contador++;
            }

            if (actualVisibilidad.maximunValueAirFlowRateFromMassAirFlowSensorVisible == 1)
            {
                grid.Children.Add(MaximunValueAirFlowRateFromMassAirFlowSensor_ValueA, 0, contador);
                grid.Children.Add(MaximunValueAirFlowRateFromMassAirFlowSensor_ValueAResult, 1, contador);
                grid.Children.Add(MaximunValueAirFlowRateFromMassAirFlowSensor_ValueAUds, 2, contador);

                contador++;

                grid.Children.Add(MaximunValueAirFlowRateFromMassAirFlowSensor_ValueB, 0, contador);
                grid.Children.Add(MaximunValueAirFlowRateFromMassAirFlowSensor_ValueBResult, 1, contador);
                grid.Children.Add(MaximunValueAirFlowRateFromMassAirFlowSensor_ValueBUds, 2, contador);

                contador++;

                grid.Children.Add(MaximunValueAirFlowRateFromMassAirFlowSensor_ValueC, 0, contador);
                grid.Children.Add(MaximunValueAirFlowRateFromMassAirFlowSensor_ValueCResult, 1, contador);
                grid.Children.Add(MaximunValueAirFlowRateFromMassAirFlowSensor_ValueCUds, 2, contador);

                contador++;

                grid.Children.Add(MaximunValueAirFlowRateFromMassAirFlowSensor_ValueD, 0, contador);
                grid.Children.Add(MaximunValueAirFlowRateFromMassAirFlowSensor_ValueDResult, 1, contador);
                grid.Children.Add(MaximunValueAirFlowRateFromMassAirFlowSensor_ValueDUds, 2, contador);

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
