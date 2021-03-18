using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO.Ports;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
    
namespace BerryPackagingApplication.Controls
{
    public partial class ScaleControler : UserControl
    {
        private static new Scale_Communicator Scale;
        public string scaleCom { get; set; }
        public string Weight { get; set; }

        public ScaleControler()
        {
            Weight = "UNSTABLE";
            scaleCom = "COM1";

            InitializeComponent();
        }

        private bool testmode;
        int testState = 0;
        public void testMode()
        {
            testmode = true;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (testmode)
            {
                timer1.Interval = 5000;
                if (testState == 0)
                {
                    Weight = display.Text = "+ 1.550";
                    testState += 1;
                }
                else if (testState == 1)
                {
                    Weight = display.Text = "+ 13.200";
                    testState += 1;
                }
                else if (testState == 2)
                {
                    Weight = display.Text = "+ 4.501";
                    testState += 1;
                }
                else if (testState == 3)
                {
                    Weight = display.Text = "+ 5.501";
                    testState += 1;
                }
                else if (testState == 4)
                {
                    Weight = display.Text = "UNSTABLE";
                    testState = 0;
                }

            }
            else
            {
                updateDisplay();
            }
            

        }

        private void updateDisplay()
        {
            if (scaleActive)
            {
                try
                {
                    if (Scale.portExists)
                    {
                        string temp = Scale.message;
                        display.Text = temp.Substring(6, 8);

                        if (temp.Contains("ST"))
                        {
                            Weight = display.Text;
                            display.ForeColor = Color.Black;
                        }
                        else
                        {
                            Weight = "UNSTABLE";
                            display.ForeColor = Color.Red;
                        }
                    }
                    else
                    {
                        display.Text = scaleCom;
                        display.ForeColor = Color.Red;
                    }
                }
                catch { }
            }
            else
            {
                display.ForeColor = Color.Red;
                display.Text = "Paused";
            }

        }

        private bool scaleInstantiated = false;
        private bool scaleActive = false;
        public void Start()
        {
            if (!scaleInstantiated)
            {
                scaleInstantiated = true;
                Scale = new Scale_Communicator(scaleCom);
                Scale.Start();
            }
            scaleActive = true;
        }
        public void Stop()
        {
            scaleActive = false;
        }



        private void ZeroButton_Click(object sender, EventArgs e)
        {
            if (scaleActive) Scale.Zero();
        }

        private void TareButton_Click(object sender, EventArgs e)
        {
            if (scaleActive) Scale.Tare();
        }

        private void ScaleControler_FontChanged(object sender, EventArgs e)
        {
            Font font = ((Control)sender).Font;
            ZeroButton.Font = font;
            TareButton.Font = font;
            font = new Font(font.FontFamily, font.Size * (float)1.5, FontStyle.Bold);
            display.Font = font;

        }
    }



    class Scale_Communicator
    {
        private static SerialPort _serialPort;
        public string message { get; set; }
        private string Com;

        public Scale_Communicator(string com)
        {
            Com = com;
            message = "";
            
        }

        public void Start()
        {
            _serialPort = new SerialPort(Com, 9600, Parity.None, 8, StopBits.One);
            _serialPort.ReadTimeout = 300;
            _serialPort.WriteTimeout = 300;
            checkPortsThread = new Thread(checkPorts);
            checkPortsThread.IsBackground = true;
            checkPortsThread.Start();

        }

        public void Zero()
        {
            try
            {
                if (_serialPort.IsOpen)
                {
                    _serialPort.Write("z");
                }
            }
            catch { }
        }

        public void Tare()
        {
            try
            {
                if (_serialPort.IsOpen)
                {
                    _serialPort.Write("t");
                }
            }
            catch { }
        }

        // Controlls port status
        private static Thread checkPortsThread;
        private void checkPorts()
        {
            while (true)
            {
                isPort();
                openPort();
                Read();
            }
        }

        // read input from com only when port is open.
        // stores the read input in variable: message
        // if cannot read data, it equals: ---------------
        private void Read()
        {
            try
            {
                string temp = "";
                if (_serialPort.IsOpen)
                {
                    temp = _serialPort.ReadLine();
                }
                message = temp.Length == 19 ? temp : "-------------------";
            }
            catch
            {
                message = "-------------------";
            }
        }

        // Checks to see if port exists
        // If such port exists, sets portExists to true, else false. 
        public bool portExists { get; set; }
        private void isPort()
        {
            try
            {
                bool flag = false;
                string[] ports = SerialPort.GetPortNames();
                foreach (string port in ports)
                {
                    if (port == Com) flag = true;
                }
                portExists = flag ? true : false;
            }
            catch { }
        }
        // Tries to open serial port if such port exists
        // only tries to open if it is not already open
        private void openPort()
        {
            try
            {
                if (portExists && !_serialPort.IsOpen)
                {
                    _serialPort.Open();
                }
            }
            catch { }
        }
    }
}
