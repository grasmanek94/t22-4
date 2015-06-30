using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using System.ComponentModel.Design;

namespace Communication
{
    public partial class TrainDrukteForm : Form
    {
        public Arduino _arduino;
        private LedControl.LedControl _ledControl;
        private readonly ByteViewer _byteViewer;
        private readonly TrackBar[] _trackBars;
        private Color[] _trafficStates;
        private readonly Color[] _colorCodes;

        public List<Message> Messages;

        private void SetBarsState(bool state)
        {
            foreach (TrackBar bar in _trackBars)
            {
                bar.Enabled = state;
            }
        }

        private void UpdateBarStateValues()
        {
            for(int i = 0; i < 6; ++i)
            {
                _trafficStates[i] = _colorCodes[_trackBars[i].Value];
            }
        }

        public TrainDrukteForm()
        {
            InitializeComponent();
            timer1.Start();

            _arduino = null;
            _ledControl = null;

            _byteViewer = new ByteViewer();
            _byteViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(_byteViewer);

            _trackBars = new TrackBar[6]{ tb1, tb2, tb3, tb4, tb5, tb6 };
            _colorCodes = new Color[3] { Color.White, Color.Green, Color.Red };

            SetBarsState(false);

            foreach (TrackBar bar in _trackBars)
            {
                bar.ValueChanged += bars_ValueChanged;
            }

            _trafficStates = new Color[6];

            Messages = new List<Message>();

            cbCom.Items.AddRange(SerialPort.GetPortNames());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           if(_ledControl != null) 
           {
               Message message = new Message();
               if(_arduino.Read(message) > 0)
               {
                   listBox1.Items.Add(message);
                   Messages.Add(message);
               }
           }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;
            Message message = (Message)listBox1.SelectedItem;
            byte[] viewer = new byte[message.DataLen];
            for (int i = 0; i < message.DataLen; ++i )
            {
                viewer[i] = (byte)message.Data[i];
            }
            _byteViewer.SetBytes(viewer);
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            if (_ledControl != null)
            {
                _ledControl.ChangeColor((byte)nup_start.Value, (byte)nup_to.Value, (byte)nup_red.Value, (byte)nup_green.Value, (byte)nup_blue.Value, (byte)nup_bright.Value);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            nup_red.Value = colorDialog1.Color.R;
            nup_green.Value = colorDialog1.Color.G;
            nup_blue.Value = colorDialog1.Color.B;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_arduino != null)
            {
                _arduino.Disconnect();
            }
            Application.Exit();
        }

        private void bars_ValueChanged(object sender, EventArgs e)
        {
            UpdateBarStateValues();
            if (_ledControl != null)
            {
                for(int i = 0; i < 6; ++i)
                {
                    _ledControl.ChangeColor((i * 8), ((i + 1) * 8), _trafficStates[i]);
                }
            }
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            if (_ledControl != null)
            {
                _ledControl.ChangeColor(0, 50, 0xFFFFFFFF);
            }
        }

        private void btSet1_Click(object sender, EventArgs e)
        {
            if (_arduino != null)
            {
                if (_ledControl != null)
                {
                    _ledControl.ChangeColor(0, 14, Color.Red);
                    _ledControl.ChangeColor(14, 20, Color.Green);
                    _ledControl.ChangeColor(20, 35, Color.Orange);
                    _ledControl.ChangeColor(35, 44, Color.Red);
                }
            }
        }

		private void connectbutton_Click(object sender, EventArgs e)
		{
			if (_ledControl == null)
			{
				try
				{
					_arduino = new Arduino(0, cbCom.SelectedItem.ToString());
					_ledControl = new LedControl.LedControl(_arduino, 6, (byte)maxLedsNUP.Value);
				}
				catch (IOException exception)
				{
					MessageBox.Show(exception.Message);
				}
				catch (InvalidOperationException exception)
				{
					MessageBox.Show(exception.Message);
				}
				if (_arduino != null)
				{
					_arduino.Connect();
				}
				_ledControl.InitializeLedStrip();
			}

			if (_arduino != null && _ledControl != null && _arduino.IsConnected)
			{
				SetBarsState(true);
				MessageBox.Show("Connected");
			}
		}

        private void btSet2_Click(object sender, EventArgs e)
        {
            if (_ledControl != null)
            {
                _ledControl.ChangeColor(0, 14, Color.Red);
                _ledControl.ChangeColor(14, 28, Color.Green);
                _ledControl.ChangeColor(0, 14, Color.White);
                _ledControl.ChangeColor(0, 14, Color.Orange);
            }
        }
    }
}
