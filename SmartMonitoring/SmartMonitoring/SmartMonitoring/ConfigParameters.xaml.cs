using System;
using SmartMonitoring.BBDD;
using SmartMonitoring.MVVM;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartMonitoring
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfigParameters : ContentPage
    {

        IConnectionManagement connectionManagement;

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
        Label ControlModuleVoltage;
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
        Label MaximunValueAirFlowRateFromMassAirFlowSensor;

        Label RelativeAcceleratorPedalPosition;
        Label RelativeThrottlePosition;
        Label ThrottlePosition;
        Label TimeRunWithMILOn;
        Visibilidad actualVisibilidad;

        public ConfigParameters(ConsultParameters page, IConnectionManagement connectionManagement, Visibilidad actualVisibilidad)
        {


            this.connectionManagement = connectionManagement;

            this.actualVisibilidad = actualVisibilidad;
            Button listo = new Button();

            listo.Text = "Listo";
            listo.Clicked += (sender, e) =>
            {
                connectionManagement.setVisibilidad(actualVisibilidad);
                App.Current.MainPage = new NavigationPage(page);

            };
            listo.IsEnabled = true;
            var layout = new StackLayout();
            var grid = new Grid();

            InitializeComponent();

            bool visible;
            RPM = new Label();
            RPM.Text = "RPM";
            if (actualVisibilidad.rpmVisible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }

            Switch rpmSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            rpmSwitch.Toggled += rpmSwitch_Toggled;


            Speed = new Label();
            Speed.Text = "Velocidad";
            if (actualVisibilidad.speedVisible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch speedSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            speedSwitch.Toggled += speedSwitch_Toggled;

            EngineTemperature = new Label();
            EngineTemperature.Text = "Temperatura del Motor";
            if (actualVisibilidad.engineTemperatureVisible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch engineTemperatureSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            engineTemperatureSwitch.Toggled += engineTemperatureSwitch_Toggled;

            TimeEngineStart = new Label();
            TimeEngineStart.Text = "Time Engine Start";
            if (actualVisibilidad.timeEngineStartVisible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch timeEngineStartSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            timeEngineStartSwitch.Toggled += timeEngineStartSwitch_Toggled;


            HybridBateryPackRemainingLife = new Label();
            HybridBateryPackRemainingLife.Text = "Batería Híbrida Restante";
            if (actualVisibilidad.hybridBateryPackRemainingLifeVisible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch hybridbaterySwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            hybridbaterySwitch.Toggled += hybridbaterySwitch_Toggled;

            AbsoluteBarometricPressure = new Label();
            AbsoluteBarometricPressure.Text = "Presión barométrica";
            if (actualVisibilidad.absoluteBarometricPressureVisible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch absolutebarometricpressureSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            absolutebarometricpressureSwitch.Toggled += absolutebarometricpressureSwitch_Toggled;

            AbsoluteEvapSystemVaporPressure = new Label();
            AbsoluteEvapSystemVaporPressure.Text = "Presión de vapor de Sist. Evaporativo";
            if (actualVisibilidad.absoluteEvapSystemVaporPressureVisible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch absoluteEvapSystemVaporPressureSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            absoluteEvapSystemVaporPressureSwitch.Toggled += absoluteEvapSystemVaporPressureSwitch_Toggled;

            AbsoluteLoadValue = new Label();
            AbsoluteLoadValue.Text = "Valor absoluto de carga";
            if (actualVisibilidad.absoluteLoadValueVisible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch absoluteLoadValueSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            absoluteLoadValueSwitch.Toggled += absoluteLoadValueSwitch_Toggled;

            AbsoluteThrottlePositionB = new Label();
            AbsoluteThrottlePositionB.Text = "Posición absoluta acelerador B";
            if (actualVisibilidad.absoluteThrottlePositionBVisible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch absoluteThrottlePositionBSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            absoluteThrottlePositionBSwitch.Toggled += absoluteThrottlePositionBSwitch_Toggled;

            AbsoluteThrottlePositionC = new Label();
            AbsoluteThrottlePositionC.Text = "Posición absoluta acelerador C";
            if (actualVisibilidad.absoluteThrottlePositionCVisible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch absoluteThrottlePositionCSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            absoluteThrottlePositionCSwitch.Toggled += absoluteThrottlePositionCSwitch_Toggled;

            AbsoluteThrottlePositionD = new Label();
            AbsoluteThrottlePositionD.Text = "Posición absoluta acelerador D";
            if (actualVisibilidad.absoluteThrottlePositionDVisible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch absoluteThrottlePositionDSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            absoluteThrottlePositionDSwitch.Toggled += absoluteThrottlePositionDSwitch_Toggled;

            AbsoluteThrottlePositionE = new Label();
            AbsoluteThrottlePositionE.Text = "Posición absoluta acelerador E";
            if (actualVisibilidad.absoluteThrottlePositionEVisible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch absoluteThrottlePositionESwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            absoluteThrottlePositionESwitch.Toggled += absoluteThrottlePositionESwitch_Toggled;

            AbsoluteThrottlePositionF = new Label();
            AbsoluteThrottlePositionF.Text = "Posición absoluta acelerador E";
            if (actualVisibilidad.absoluteThrottlePositionFVisible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch absoluteThrottlePositionFSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            absoluteThrottlePositionFSwitch.Toggled += absoluteThrottlePositionFSwitch_Toggled;

            CatalystTemperatureB1S1 = new Label();
            CatalystTemperatureB1S1.Text = "Temperatura Catalizador Banco:1 Sensor:1";
            if (actualVisibilidad.catalystTemperatureB1S1Visible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch catalystTemperatureB1S1Switch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            catalystTemperatureB1S1Switch.Toggled += catalystTemperatureB1S1Switch_Toggled;

            CatalystTemperatureB1S2 = new Label();
            CatalystTemperatureB1S2.Text = "Temperatura Catalizador Banco:1 Sensor:2";
            if (actualVisibilidad.catalystTemperatureB1S2Visible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch catalystTemperatureB1S2Switch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            catalystTemperatureB1S2Switch.Toggled += catalystTemperatureB1S2Switch_Toggled;

            CatalystTemperatureB2S1 = new Label();
            CatalystTemperatureB2S1.Text = "Temperatura Catalizador Banco:2 Sensor:1";
            if (actualVisibilidad.catalystTemperatureB2S1Visible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch catalystTemperatureB2S1Switch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            catalystTemperatureB2S1Switch.Toggled += catalystTemperatureB2S1Switch_Toggled;

            CatalystTemperatureB2S2 = new Label();
            CatalystTemperatureB2S2.Text = "Temperatura Catalizador Banco:2 Sensor:2";
            if (actualVisibilidad.catalystTemperatureB2S2Visible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch catalystTemperatureB2S2Switch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            catalystTemperatureB2S2Switch.Toggled += catalystTemperatureB2S2Switch_Toggled;

            CommandedEvaporativePurge = new Label();
            CommandedEvaporativePurge.Text = "Purga evaporativa comandada";
            if (actualVisibilidad.commanddEvaporativePurgeVisible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch commandedEvaporativePurgeSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            commandedEvaporativePurgeSwitch.Toggled += commandedEvaporativePurgeSwitch_Toggled;

            CommandedEGR = new Label();
            CommandedEGR.Text = "EGR comandada";
            if (actualVisibilidad.commandedEGRVisible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch commandedEGRSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            commandedEGRSwitch.Toggled += commandedEGRSwitch_Toggled;

            CommandedThrottleActuatorValue = new Label();
            CommandedThrottleActuatorValue.Text = "	Actuador comandando del acelerador";
            if (actualVisibilidad.commandedThrottleActuatorValueVisible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch commandedThrottleActuatorValueSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            commandedThrottleActuatorValueSwitch.Toggled += commandedThrottleActuatorValueSwitch_Toggled;

            ControlModuleVoltage = new Label();
            ControlModuleVoltage.Text = "Voltaje del módulo de control";

            Switch controlModuleVoltageSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            controlModuleVoltageSwitch.Toggled += controlModuleVoltageSwitchh_Toggled;


            DistanceTraveledSinceCodesCleared = new Label();
            DistanceTraveledSinceCodesCleared.Text = "Distancia recorrida desde borrado de fallas";
            if (actualVisibilidad.distanceTraveledSinceCodesClearedVisible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch distanceTraveledSinceCodesClearedResultSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            distanceTraveledSinceCodesClearedResultSwitch.Toggled += distanceTraveledSinceCodesClearedResultSwitch_Toggled;

            DistanceTraveledWithMILo = new Label();
            DistanceTraveledWithMILo.Text = "Distancia recorrida con MIL encendido";
            if (actualVisibilidad.distanceTraveledWithMILoVisible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch distanceTraveledWithMILoSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            distanceTraveledWithMILoSwitch.Toggled += distanceTraveledWithMILoSwitch_Toggled;


            EGRError = new Label();
            EGRError.Text = "Falla EGR";
            if (actualVisibilidad.EGRErrorVisible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch egrErrorSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            egrErrorSwitch.Toggled += egrErrorSwitch_Toggled;

            EngineFuelRateValue = new Label();
            EngineFuelRateValue.Text = "Velocidad de combustible del motor";
            if (actualVisibilidad.engineFuelRateValueVisible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch engineFuelRateValueSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            engineFuelRateValueSwitch.Toggled += engineFuelRateValueSwitch_Toggled;

            EngineOilTemperature = new Label();
            EngineOilTemperature.Text = "Temperatura del aceite del motor";
            if (actualVisibilidad.engineOilTemperatureVisible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch engineOilTemperatureSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            engineOilTemperatureSwitch.Toggled += engineOilTemperatureSwitch_Toggled;

            EvapSystemVaporPressure = new Label();
            EvapSystemVaporPressure.Text = "Presión del vapor del sistema de evaporación";
            if (actualVisibilidad.evapSystemVaporPressureVisible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch evapSystemVaporPressureSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            evapSystemVaporPressureSwitch.Toggled += evapSystemVaporPressureSwitch_Toggled;

            FuelAirCommandedEquivalenceRatio = new Label();
            FuelAirCommandedEquivalenceRatio.Text = "Relación equivaliente comandada de combustible - aire";
            if (actualVisibilidad.fuelAirCommandedEquivalenceRatioVisible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch fuelAirCommandedEquivalenceRatioSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            fuelAirCommandedEquivalenceRatioSwitch.Toggled += fuelAirCommandedEquivalenceRatioSwitch_Toggled;

            FuelInjectionTiming = new Label();
            FuelInjectionTiming.Text = "Sincronización de la inyección de combustible";
            if (actualVisibilidad.fuelInjectionTimingVisible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch fuelInjectionTimingSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            fuelInjectionTimingSwitch.Toggled += fuelInjectionTimingSwitch_Toggled;



            FuelPressure = new Label();
            FuelPressure.Text = "Presión del combustible";
            if (actualVisibilidad.fuelPressureVisible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch fuelPressureSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            fuelPressureSwitch.Toggled += fuelPressureSwitch_Toggled;

            FuelRailAbsolutePressure = new Label();
            FuelRailAbsolutePressure.Text = "	Presión absoluta del tren de combustible";
            if (actualVisibilidad.fuelRailAbsolutePressureVisible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch fuelRailAbsolutePressureSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            fuelRailAbsolutePressureSwitch.Toggled += fuelRailAbsolutePressureSwitch_Toggled;


            FuelRailGaugePressure = new Label();
            FuelRailGaugePressure.Text = "Presión del medidor del tren de combustible";
            if (actualVisibilidad.fuelRailGaugePressureVisible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch fuelRailGaugePressureSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            fuelRailGaugePressureSwitch.Toggled += fuelRailGaugePressureSwitch_Toggled;

            FuelTankLevel = new Label();
            FuelTankLevel.Text = "Nivel de entrada del tanque de combustible";
            if (actualVisibilidad.fuelTankLevelVisible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch fuelTankLevelSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            fuelTankLevelSwitch.Toggled += fuelTankLevelSwitch_Toggled;

            FuelType = new Label();
            FuelType.Text = "Tipo de combustible";
            if (actualVisibilidad.fuelTypeVisible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch fuelTypeSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            fuelTypeSwitch.Toggled += fuelTypeSwitch_Toggled;

            IntakeManifoldAbsolutePressureValue = new Label();
            IntakeManifoldAbsolutePressureValue.Text = "Presión absoluta del colector de admisión";
            if (actualVisibilidad.intakeManifoldAbsolutePressureValueVisible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch intakeManifoldAbsolutePressureValueSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            intakeManifoldAbsolutePressureValueSwitch.Toggled += intakeManifoldAbsolutePressureValueSwitch_Toggled;

            LongTermSecondaryOxygenSensorTrim1_3_ValueA = new Label();
            LongTermSecondaryOxygenSensorTrim1_3_ValueA.Text = "Ajuste sensor de oxigeno secundario: plazo largo. Banco 1-3";
            if (actualVisibilidad.longTermSecondaryOxygenSensorTrim1_3_Visible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch longTermSecondaryOxygenSensorTrim1_3_Switch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            longTermSecondaryOxygenSensorTrim1_3_Switch.Toggled += longTermSecondaryOxygenSensorTrim1_3_Switch_Toggled;



            LongTermSecondaryOxygenSensorTrim2_4_ValueA = new Label();
            LongTermSecondaryOxygenSensorTrim2_4_ValueA.Text = "Ajuste sensor de oxigeno secundario: plazo largo. Banco 2-4";
            if (actualVisibilidad.longTermSecondaryOxygenSensorTrim2_4_Visible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch longTermSecondaryOxygenSensorTrim2_4_Switch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            longTermSecondaryOxygenSensorTrim2_4_Switch.Toggled += longTermSecondaryOxygenSensorTrim2_4_Switch_Toggled;






            MAFAirFlowRate = new Label();
            MAFAirFlowRate.Text = "	Velocidad del flujo del aire MAF";
            if (actualVisibilidad.mAFAirFlowRateVisible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch mAFAirFlowRateSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            mAFAirFlowRateSwitch.Toggled += mAFAirFlowRateSwitch_Toggled;

            MaximunValueAirFlowRateFromMassAirFlowSensor = new Label();
            MaximunValueAirFlowRateFromMassAirFlowSensor.Text = "Velocidad de flujo de aire del sensor de flujo de aire masivo";
            if (actualVisibilidad.maximunValueAirFlowRateFromMassAirFlowSensorVisible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch maximunValueAirFlowRateFromMassAirFlowSensorSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            maximunValueAirFlowRateFromMassAirFlowSensorSwitch.Toggled += maximunValueAirFlowRateFromMassAirFlowSensor_ValueA_Toggled;



            RelativeAcceleratorPedalPosition = new Label();
            RelativeAcceleratorPedalPosition.Text = "Posición relativa del pedal del acelerador";
            if (actualVisibilidad.relativeAcceleratorPedalPositionVisible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch relativeAcceleratorPedalSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            relativeAcceleratorPedalSwitch.Toggled += relativeAcceleratorPedalSwitch_Toggled;


            RelativeThrottlePosition = new Label();
            RelativeThrottlePosition.Text = "Posición relativa del acelerador";
            if (actualVisibilidad.relativeThrottlePositionVisible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch relativeThrottlePositionSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            relativeThrottlePositionSwitch.Toggled += relativeThrottlePositionSwitch_Toggled;


            ShortTermSecondaryOxygenSensorTrim1_3_ValueA = new Label();
            ShortTermSecondaryOxygenSensorTrim1_3_ValueA.Text = "Ajuste sensor de oxigeno secundario: plazo corto. Banco 1-3";
            if (actualVisibilidad.shortTermSecondaryOxygenSensorTrim1_3_Visible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch shortTermSecondaryOxygenSensorTrim1_3_Switch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            shortTermSecondaryOxygenSensorTrim1_3_Switch.Toggled += shortTermSecondaryOxygenSensorTrim1_3_Switch_Toggled;

            ShortTermSecondaryOxygenSensorTrim2_4_ValueA = new Label();
            ShortTermSecondaryOxygenSensorTrim2_4_ValueA.Text = "Ajuste sensor de oxigeno secundario: plazo cort. Banco 2-4";
            if (actualVisibilidad.shortTermSecondaryOxygenSensorTrim2_4_Visible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch shortTermSecondaryOxygenSensorTrim2_4_Switch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            shortTermSecondaryOxygenSensorTrim2_4_Switch.Toggled += shortTermSecondaryOxygenSensorTrim2_4_Switch_Toggled;

            ThrottlePosition = new Label();
            ThrottlePosition.Text = "Posición del acelerador";
            if (actualVisibilidad.throttlePositionVisible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch throttlePositionSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            throttlePositionSwitch.Toggled += throttlePositionSwitch_Toggled;


            TimeRunWithMILOn = new Label();
            TimeRunWithMILOn.Text = "Tiempo con indicador MIL encendido";
            if (actualVisibilidad.timeRunWithMILOnVisible == 1)
            {
                visible = true;
            }
            else
            { visible = false; }
            Switch timeRunWithMILOnSwitch = new Switch
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsToggled = visible
            };
            timeRunWithMILOnSwitch.Toggled += timeRunWithMILOnSwitch_Toggled;



            int contador = 0;





            grid.Children.Add(RPM, 0, contador);
            grid.Children.Add(rpmSwitch, 2, contador);

            contador++;

            grid.Children.Add(Speed, 0, contador);
            grid.Children.Add(speedSwitch, 2, contador);

            contador++;

            grid.Children.Add(HybridBateryPackRemainingLife, 0, contador);
            grid.Children.Add(hybridbaterySwitch, 2, contador);

            contador++;

            grid.Children.Add(TimeEngineStart, 0, contador);
            grid.Children.Add(timeEngineStartSwitch, 2, contador);

            contador++;

            grid.Children.Add(AbsoluteBarometricPressure, 0, contador);
            grid.Children.Add(absolutebarometricpressureSwitch, 2, contador);

            contador++;

            grid.Children.Add(AbsoluteLoadValue, 0, contador);
            grid.Children.Add(absoluteLoadValueSwitch, 2, contador);

            contador++;


            grid.Children.Add(AbsoluteThrottlePositionB, 0, contador);
            grid.Children.Add(absoluteThrottlePositionBSwitch, 2, contador);

            contador++;

            grid.Children.Add(AbsoluteThrottlePositionC, 0, contador);
            grid.Children.Add(absoluteThrottlePositionCSwitch, 2, contador);

            contador++;

            grid.Children.Add(AbsoluteThrottlePositionD, 0, contador);
            grid.Children.Add(absoluteThrottlePositionDSwitch, 2, contador);

            contador++;

            grid.Children.Add(AbsoluteThrottlePositionE, 0, contador);
            grid.Children.Add(absoluteThrottlePositionESwitch, 2, contador);

            contador++;

            grid.Children.Add(AbsoluteThrottlePositionF, 0, contador);
            grid.Children.Add(absoluteThrottlePositionFSwitch, 2, contador);

            contador++;


            grid.Children.Add(CatalystTemperatureB1S1, 0, contador);
            grid.Children.Add(catalystTemperatureB1S1Switch, 2, contador);

            contador++;

            grid.Children.Add(CatalystTemperatureB1S2, 0, contador);
            grid.Children.Add(catalystTemperatureB1S2Switch, 2, contador);

            contador++;


            grid.Children.Add(CatalystTemperatureB2S1, 0, contador);
            grid.Children.Add(catalystTemperatureB2S1Switch, 2, contador);

            contador++;


            grid.Children.Add(CatalystTemperatureB2S2, 0, contador);
            grid.Children.Add(catalystTemperatureB2S2Switch, 2, contador);

            contador++;


            grid.Children.Add(CommandedEvaporativePurge, 0, contador);
            grid.Children.Add(commandedEvaporativePurgeSwitch, 2, contador);

            contador++;

            grid.Children.Add(CommandedEGR, 0, contador);
            grid.Children.Add(commandedEGRSwitch, 2, contador);

            contador++;


            grid.Children.Add(CommandedThrottleActuatorValue, 0, contador);
            grid.Children.Add(commandedThrottleActuatorValueSwitch, 2, contador);

            contador++;

            grid.Children.Add(ControlModuleVoltage, 0, contador);
            grid.Children.Add(controlModuleVoltageSwitch, 2, contador);

            contador++;

            grid.Children.Add(DistanceTraveledSinceCodesCleared, 0, contador);
            grid.Children.Add(distanceTraveledSinceCodesClearedResultSwitch, 2, contador);

            contador++;


            grid.Children.Add(DistanceTraveledWithMILo, 0, contador);
            grid.Children.Add(distanceTraveledWithMILoSwitch, 2, contador);

            contador++;

            grid.Children.Add(EGRError, 0, contador);
            grid.Children.Add(egrErrorSwitch, 2, contador);

            contador++;

            grid.Children.Add(EngineFuelRateValue, 0, contador);
            grid.Children.Add(engineFuelRateValueSwitch, 2, contador);

            contador++;

            grid.Children.Add(EngineOilTemperature, 0, contador);
            grid.Children.Add(engineOilTemperatureSwitch, 2, contador);

            contador++;


            grid.Children.Add(EvapSystemVaporPressure, 0, contador);
            grid.Children.Add(evapSystemVaporPressureSwitch, 2, contador);

            contador++;

            grid.Children.Add(FuelAirCommandedEquivalenceRatio, 0, contador);
            grid.Children.Add(fuelAirCommandedEquivalenceRatioSwitch, 2, contador);


            grid.Children.Add(FuelInjectionTiming, 0, contador);
            grid.Children.Add(fuelInjectionTimingSwitch, 2, contador);

            contador++;

            grid.Children.Add(FuelPressure, 0, contador);
            grid.Children.Add(fuelPressureSwitch, 2, contador);

            contador++;

            grid.Children.Add(FuelRailAbsolutePressure, 0, contador);
            grid.Children.Add(fuelRailAbsolutePressureSwitch, 2, contador);

            contador++;

            grid.Children.Add(FuelRailGaugePressure, 0, contador);
            grid.Children.Add(fuelRailGaugePressureSwitch, 2, contador);

            contador++;

            grid.Children.Add(FuelTankLevel, 0, contador);
            grid.Children.Add(fuelTankLevelSwitch, 2, contador);

            contador++;

            grid.Children.Add(FuelType, 0, contador);
            grid.Children.Add(fuelTypeSwitch, 2, contador);

            contador++;

            grid.Children.Add(IntakeManifoldAbsolutePressureValue, 0, contador);
            grid.Children.Add(intakeManifoldAbsolutePressureValueSwitch, 2, contador);

            contador++;

            grid.Children.Add(MAFAirFlowRate, 0, contador);
            grid.Children.Add(mAFAirFlowRateSwitch, 2, contador);

            contador++;

            grid.Children.Add(RelativeAcceleratorPedalPosition, 0, contador);
            grid.Children.Add(relativeAcceleratorPedalSwitch, 2, contador);

            contador++;

            grid.Children.Add(RelativeThrottlePosition, 0, contador);
            grid.Children.Add(relativeThrottlePositionSwitch, 2, contador);

            contador++;

            grid.Children.Add(ThrottlePosition, 0, contador);
            grid.Children.Add(throttlePositionSwitch, 2, contador);

            contador++;

            grid.Children.Add(TimeRunWithMILOn, 0, contador);
            grid.Children.Add(timeRunWithMILOnSwitch, 2, contador);

            contador++;

            grid.Children.Add(MaximunValueAirFlowRateFromMassAirFlowSensor, 0, contador);
            grid.Children.Add(maximunValueAirFlowRateFromMassAirFlowSensorSwitch, 2, contador);

            contador++;


            grid.Children.Add(LongTermSecondaryOxygenSensorTrim1_3_ValueA, 0, contador);
            grid.Children.Add(longTermSecondaryOxygenSensorTrim1_3_Switch, 2, contador);

            contador++;

            grid.Children.Add(LongTermSecondaryOxygenSensorTrim2_4_ValueA, 0, contador);
            grid.Children.Add(longTermSecondaryOxygenSensorTrim2_4_Switch, 2, contador);

            contador++;



            grid.Children.Add(ShortTermSecondaryOxygenSensorTrim1_3_ValueA, 0, contador);
            grid.Children.Add(shortTermSecondaryOxygenSensorTrim1_3_Switch, 2, contador);

            contador++;

            grid.Children.Add(ShortTermSecondaryOxygenSensorTrim2_4_ValueA, 0, contador);
            grid.Children.Add(shortTermSecondaryOxygenSensorTrim2_4_Switch, 2, contador);



            layout.Children.Add(grid);
            layout.Children.Add(listo);

            layout.Children.Add(grid);
            Content = new ScrollView()
            {
                Content = layout,
            };

        }

        private void shortTermSecondaryOxygenSensorTrim2_4_Switch_Toggled(object sender, ToggledEventArgs e)
        {
            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.shortTermSecondaryOxygenSensorTrim2_4_Visible = value;
        }

        private void shortTermSecondaryOxygenSensorTrim1_3_Switch_Toggled(object sender, ToggledEventArgs e)
        {
            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.shortTermSecondaryOxygenSensorTrim1_3_Visible = value;
        }

        private void longTermSecondaryOxygenSensorTrim1_3_Switch_Toggled(object sender, ToggledEventArgs e)
        {
            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.longTermSecondaryOxygenSensorTrim1_3_Visible = value;
        }

        private void longTermSecondaryOxygenSensorTrim2_4_Switch_Toggled(object sender, ToggledEventArgs e)
        {
            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.longTermSecondaryOxygenSensorTrim2_4_Visible = value;
        }

        private void maximunValueAirFlowRateFromMassAirFlowSensor_ValueA_Toggled(object sender, ToggledEventArgs e)
        {
            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.maximunValueAirFlowRateFromMassAirFlowSensorVisible = value;
        }




        private void commandedEGRSwitch_Toggled(object sender, ToggledEventArgs e)
        {

            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.commandedEGRVisible = value;
        }

        private void timeRunWithMILOnSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.timeRunWithMILOnVisible = value;
        }

        private void throttlePositionSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }

            actualVisibilidad.throttlePositionVisible = value;
        }

        private void relativeThrottlePositionSwitch_Toggled(object sender, ToggledEventArgs e)
        {

            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }

            actualVisibilidad.relativeThrottlePositionVisible = value;
        }

        private void relativeAcceleratorPedalSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.relativeAcceleratorPedalPositionVisible = value;
        }

        private void mAFAirFlowRateSwitch_Toggled(object sender, ToggledEventArgs e)
        {

            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.mAFAirFlowRateVisible = value;
        }

        private void intakeManifoldAbsolutePressureValueSwitch_Toggled(object sender, ToggledEventArgs e)
        {

            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.intakeManifoldAbsolutePressureValueVisible = value;
        }

        private void fuelTypeSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.fuelTypeVisible = value;
        }

        private void fuelTankLevelSwitch_Toggled(object sender, ToggledEventArgs e)
        {

            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.fuelTankLevelVisible = value;
        }

        private void fuelRailGaugePressureSwitch_Toggled(object sender, ToggledEventArgs e)
        {

            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.fuelRailGaugePressureVisible = value;
        }

        private void fuelRailAbsolutePressureSwitch_Toggled(object sender, ToggledEventArgs e)
        {

            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.fuelRailAbsolutePressureVisible = value;


        }

        private void fuelPressureSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.fuelPressureVisible = value;
        }

        private void fuelInjectionTimingSwitch_Toggled(object sender, ToggledEventArgs e)
        {

            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.fuelInjectionTimingVisible = value;
        }

        private void fuelAirCommandedEquivalenceRatioSwitch_Toggled(object sender, ToggledEventArgs e)
        {

            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.fuelAirCommandedEquivalenceRatioVisible = value;
        }

        private void evapSystemVaporPressureSwitch_Toggled(object sender, ToggledEventArgs e)
        {

            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.evapSystemVaporPressureVisible = value;
        }

        private void engineOilTemperatureSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.engineOilTemperatureVisible = value;
        }

        private void engineFuelRateValueSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.engineFuelRateValueVisible = value;
        }

        private void egrErrorSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.EGRErrorVisible = value;
        }

        private void distanceTraveledWithMILoSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.distanceTraveledWithMILoVisible = value;
        }

        private void distanceTraveledSinceCodesClearedResultSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.distanceTraveledSinceCodesClearedVisible = value;
        }

        private void controlModuleVoltageSwitchh_Toggled(object sender, ToggledEventArgs e)
        {
            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.controlModuleVoltageVisible = value;
        }

        private void commandedThrottleActuatorValueSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.commandedThrottleActuatorValueVisible = value;
        }

        private void commandedEvaporativePurgeSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.commanddEvaporativePurgeVisible = value;
        }

        private void catalystTemperatureB1S2Switch_Toggled(object sender, ToggledEventArgs e)
        {
            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.catalystTemperatureB1S2Visible = value;
        }

        private void catalystTemperatureB2S1Switch_Toggled(object sender, ToggledEventArgs e)
        {
            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.catalystTemperatureB2S1Visible = value;
        }

        private void catalystTemperatureB2S2Switch_Toggled(object sender, ToggledEventArgs e)
        {
            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.catalystTemperatureB2S2Visible = value;
        }

        private void catalystTemperatureB1S1Switch_Toggled(object sender, ToggledEventArgs e)
        {
            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.catalystTemperatureB1S1Visible = value;
        }

        private void absoluteThrottlePositionDSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.absoluteThrottlePositionDVisible = value;
        }

        private void absoluteThrottlePositionESwitch_Toggled(object sender, ToggledEventArgs e)
        {
            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.absoluteThrottlePositionEVisible = value;
        }

        private void absoluteThrottlePositionBSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.absoluteThrottlePositionBVisible = value;
        }

        private void absoluteThrottlePositionCSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.absoluteThrottlePositionCVisible = value;
        }

        private void absoluteThrottlePositionFSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.absoluteThrottlePositionFVisible = value;
        }

        private void absoluteLoadValueSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.absoluteLoadValueVisible = value;
        }

        private void absoluteEvapSystemVaporPressureSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.absoluteEvapSystemVaporPressureVisible = value;
        }

        private void absolutebarometricpressureSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.absoluteBarometricPressureVisible = value;
        }

        private void timeEngineStartSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.timeEngineStartVisible = value;
        }

        private void engineTemperatureSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.engineTemperatureVisible = value;
        }

        private void hybridbaterySwitch_Toggled(object sender, ToggledEventArgs e)
        {
            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.hybridBateryPackRemainingLifeVisible = value;
        }

        private void speedSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.speedVisible = value;
        }

        private void rpmSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            int value;
            if (e.Value == true)
            {
                value = 1;
            }
            else
            {
                value = 0;
            }
            actualVisibilidad.rpmVisible = value;
        }
    }
}