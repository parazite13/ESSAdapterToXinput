using Nefarius.ViGEm.Client;
using Nefarius.ViGEm.Client.Targets;
using Nefarius.ViGEm.Client.Targets.Xbox360;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp.InputReader;

namespace WpfApp
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool connected;
        public bool Connected
        {
            get => connected;
            set
            {
                connected = value;
                Button_Plug.IsEnabled = !connected;
                Button_Unplug.IsEnabled = connected;
                ComboBox_Com.IsEnabled = !connected;
                ComboBox_Device.IsEnabled = !connected;
            }
        }

        public int DeviceIndex { get; private set; }

        private IControllerReader controllerReader;

        private IXbox360Controller controller;

        private readonly ViGEmClient client = new ViGEmClient();

        public MainWindow()
        {
            InitializeComponent();
            ComboBox_Com.SelectedIndex = 0;
            ComboBox_Device.SelectedIndex = 0;
        }

        public void Disconnect()
        {
            if(Connected && controllerReader != null)
            {
                controllerReader.Finish();
                Connected = false;
            }
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            Disconnect();
        }

        private void ControllerReader_ControllerStateChanged(IControllerReader sender, ControllerState state)
        {          
            switch(DeviceIndex)
            {
                // NES
                case 0:

                    // Buttons
                    controller.SetButtonState(Xbox360Button.A, state.Buttons["a"]);
                    controller.SetButtonState(Xbox360Button.B, state.Buttons["b"]);

                    // D-pad
                    controller.SetButtonState(Xbox360Button.Left, state.Buttons["left"]);
                    controller.SetButtonState(Xbox360Button.Up, state.Buttons["up"]);
                    controller.SetButtonState(Xbox360Button.Down, state.Buttons["down"]);
                    controller.SetButtonState(Xbox360Button.Right, state.Buttons["right"]);

                    // Start/Select
                    controller.SetButtonState(Xbox360Button.Start, state.Buttons["start"]);
                    controller.SetButtonState(Xbox360Button.Guide, state.Buttons["select"]);

                    break;

                // SNES
                case 1:

                    // Buttons
                    controller.SetButtonState(Xbox360Button.A, state.Buttons["a"]);
                    controller.SetButtonState(Xbox360Button.B, state.Buttons["b"]);
                    controller.SetButtonState(Xbox360Button.X, state.Buttons["x"]);
                    controller.SetButtonState(Xbox360Button.Y, state.Buttons["y"]);

                    // D-pad
                    controller.SetButtonState(Xbox360Button.Left, state.Buttons["left"]);
                    controller.SetButtonState(Xbox360Button.Up, state.Buttons["up"]);
                    controller.SetButtonState(Xbox360Button.Down, state.Buttons["down"]);
                    controller.SetButtonState(Xbox360Button.Right, state.Buttons["right"]);

                    // Trigger
                    controller.SetSliderValue(Xbox360Slider.LeftTrigger, (byte)(Convert.ToInt32(state.Buttons["l"]) * 255));
                    controller.SetSliderValue(Xbox360Slider.RightTrigger, (byte)(Convert.ToInt32(state.Buttons["r"]) * 255));

                    // Start/Select
                    controller.SetButtonState(Xbox360Button.Start, state.Buttons["start"]);
                    controller.SetButtonState(Xbox360Button.Guide, state.Buttons["select"]);

                    break;

                // N64
                case 2:

                    // Buttons
                    controller.SetButtonState(Xbox360Button.A, state.Buttons["a"]);
                    controller.SetButtonState(Xbox360Button.B, state.Buttons["b"]);

                    // Axis
                    controller.SetAxisValue(Xbox360Axis.LeftThumbX, (short)(state.Analogs["stick_x"] * short.MaxValue));
                    controller.SetAxisValue(Xbox360Axis.LeftThumbY, (short)(state.Analogs["stick_y"] * short.MaxValue));

                    // C-buttons
                    controller.SetAxisValue(Xbox360Axis.RightThumbX, (short)(Convert.ToInt32(state.Buttons["cright"]) * short.MaxValue + Convert.ToInt32(state.Buttons["cleft"]) * short.MinValue));
                    controller.SetAxisValue(Xbox360Axis.RightThumbY, (short)(Convert.ToInt32(state.Buttons["cup"]) * short.MaxValue + Convert.ToInt32(state.Buttons["cdown"]) * short.MinValue));

                    // D-pad
                    controller.SetButtonState(Xbox360Button.Left, state.Buttons["left"]);
                    controller.SetButtonState(Xbox360Button.Up, state.Buttons["up"]);
                    controller.SetButtonState(Xbox360Button.Down, state.Buttons["down"]);
                    controller.SetButtonState(Xbox360Button.Right, state.Buttons["right"]);

                    // Trigger
                    controller.SetSliderValue(Xbox360Slider.LeftTrigger, (byte)(Convert.ToInt32(state.Buttons["z"]) * 255));
                    controller.SetSliderValue(Xbox360Slider.RightTrigger, (byte)(Convert.ToInt32(state.Buttons["r"]) * 255));
                    controller.SetButtonState(Xbox360Button.LeftShoulder, state.Buttons["l"]);                    

                    // Start
                    controller.SetButtonState(Xbox360Button.Start, state.Buttons["start"]);

                    break;

                // GameCube
                case 3:

                    // Buttons
                    controller.SetButtonState(Xbox360Button.A, state.Buttons["a"]);
                    controller.SetButtonState(Xbox360Button.B, state.Buttons["b"]);
                    controller.SetButtonState(Xbox360Button.X, state.Buttons["x"]);
                    controller.SetButtonState(Xbox360Button.Y, state.Buttons["y"]);

                    // Axis
                    controller.SetAxisValue(Xbox360Axis.LeftThumbX, (short)(state.Analogs["lstick_x"] * short.MaxValue));
                    controller.SetAxisValue(Xbox360Axis.LeftThumbY, (short)(state.Analogs["lstick_y"] * short.MaxValue));
                    controller.SetAxisValue(Xbox360Axis.RightThumbX, (short)(state.Analogs["cstick_x"] * short.MaxValue));
                    controller.SetAxisValue(Xbox360Axis.RightThumbY, (short)(state.Analogs["cstick_y"] * short.MaxValue));

                    // D-pad
                    controller.SetButtonState(Xbox360Button.Left, state.Buttons["left"]);
                    controller.SetButtonState(Xbox360Button.Up, state.Buttons["up"]);
                    controller.SetButtonState(Xbox360Button.Down, state.Buttons["down"]);
                    controller.SetButtonState(Xbox360Button.Right, state.Buttons["right"]);

                    // Trigger
                    controller.SetSliderValue(Xbox360Slider.LeftTrigger, (byte)(state.Analogs["trig_l"] * 255));
                    controller.SetSliderValue(Xbox360Slider.RightTrigger, (byte)(state.Analogs["trig_r"] * 255));
                    controller.SetButtonState(Xbox360Button.RightShoulder, state.Buttons["z"]);

                    // Start
                    controller.SetButtonState(Xbox360Button.Start, state.Buttons["start"]);
                    break;
            }   
        }

        private void ControllerReader_ControllerDisconnected(object sender, EventArgs e)
        {
            controllerReader.Finish();
            Connected = false;
        }

        private void Plug_ButtonClicked(object sender, RoutedEventArgs e)
        {
            DeviceIndex = ComboBox_Device.SelectedIndex;

            controller = client.CreateXbox360Controller();
            controller.Connect();

            controllerReader = InputSource.ALL[DeviceIndex].BuildReader(ComboBox_Com.Text);
            controllerReader.ControllerStateChanged += ControllerReader_ControllerStateChanged;
            controllerReader.ControllerDisconnected += ControllerReader_ControllerDisconnected;

            Connected = true;
        }  

        private void Unplug_ButtonClicked(object sender, RoutedEventArgs e)
        {
            Disconnect();
        }
    }
}
