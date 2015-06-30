using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO.Ports;
using Communication.Enumerators;
using Communication;

namespace Eindproject
{
    public partial class Form1 : Form
    {
        /// The speed of the serial connection (bytes per second).
        private const int connectionSpeed = 9600;

        /// Serial port used for the connection.
        private SerialPort serialPort;

        Arduino arduino;

        RP6Control __RP6Control;

        bool forwards;
        bool left;
        bool right;
        bool backwards;
        RP6_DIRECTION_ENUM lastState;
        

        public Form1()
        {
            InitializeComponent();
            arduino = new Arduino(1, "COM17", 9600);
            if (arduino.Connect())
            {
                __RP6Control = new RP6Control(arduino);
                controlTimer.Start();
            }
            else
            {
                MessageBox.Show("failed connecting");
            }
        }

        private void ArDangerComMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
                controlTimer.Stop();
            }
        }

        //Process keys (arrows keys and karma controller)
        #region
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left)
            {
                left = true;
                return true;
            }
            if (keyData == Keys.Right)
            {
                right = true;
                return true;
            }
            if (keyData == Keys.Up)
            {
                forwards = true;
                return true;
            }
            if (keyData == Keys.Down)
            {
                backwards = true;
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode){
                case Keys.X:
                    forwards = true;
                    break;
                case Keys.Z:
                    backwards = true;
                    break;
                case Keys.Left:
                    left = true;
                    break;
                case Keys.Right:
                    right = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.X:
                    forwards = false;
                    break;
                case Keys.Down:
                case Keys.Z:
                    backwards = false;
                    break;
                case Keys.Left:
                    left = false;
                    break;
                case Keys.Right:
                    right = false;
                    break;
            }
        }

        //Send message to arduino
        #region 
        

        private void controlTimer_Tick_1(object sender, EventArgs e)
        {
            if (forwards && !left && !right && lastState != RP6_DIRECTION_ENUM.RP6_FORWARD)
            {
                lastState = RP6_DIRECTION_ENUM.RP6_FORWARD;
                this.pictureBox1.Image = Properties.Resources.forwards;
                __RP6Control.SendMessage(RP6_DIRECTION_ENUM.RP6_FORWARD);
            }
            if (left && !forwards && !backwards && lastState != RP6_DIRECTION_ENUM.RP6_LEFT)
            {
                lastState = RP6_DIRECTION_ENUM.RP6_LEFT;
                this.pictureBox1.Image = Properties.Resources.left;
                __RP6Control.SendMessage(RP6_DIRECTION_ENUM.RP6_LEFT);
            }
            if (right && !forwards && !backwards && lastState != RP6_DIRECTION_ENUM.RP6_RIGHT)
            {
                lastState = RP6_DIRECTION_ENUM.RP6_RIGHT;
                this.pictureBox1.Image = Properties.Resources.right;
                __RP6Control.SendMessage(RP6_DIRECTION_ENUM.RP6_RIGHT);
            }
            if (backwards && !left && !right && lastState != RP6_DIRECTION_ENUM.RP6_BACKWARD)
            {
                lastState = RP6_DIRECTION_ENUM.RP6_BACKWARD;
                this.pictureBox1.Image = Properties.Resources.backwards;
                __RP6Control.SendMessage(RP6_DIRECTION_ENUM.RP6_BACKWARD);
            }
            if (forwards && left && lastState != RP6_DIRECTION_ENUM.RP6_FORWARD_LEFT)
            {
                lastState = RP6_DIRECTION_ENUM.RP6_FORWARD_LEFT;
                this.pictureBox1.Image = Properties.Resources.forwardsLeft;
                __RP6Control.SendMessage(RP6_DIRECTION_ENUM.RP6_FORWARD_LEFT);
            }
            if (forwards && right && lastState != RP6_DIRECTION_ENUM.RP6_FORWARD_RIGHT)
            {
                lastState = RP6_DIRECTION_ENUM.RP6_FORWARD_RIGHT;
                this.pictureBox1.Image = Properties.Resources.forwardsRight;
                __RP6Control.SendMessage(RP6_DIRECTION_ENUM.RP6_FORWARD_RIGHT);
            }
            if (backwards && left && lastState != RP6_DIRECTION_ENUM.RP6_BACKWARD_LEFT)
            {
                lastState = RP6_DIRECTION_ENUM.RP6_BACKWARD_LEFT;
                this.pictureBox1.Image = Properties.Resources.backwardsLeft;
                __RP6Control.SendMessage(RP6_DIRECTION_ENUM.RP6_BACKWARD_LEFT);
            }
            if (backwards && right && lastState != RP6_DIRECTION_ENUM.RP6_BACKWARD_RIGHT)
            {
                lastState = RP6_DIRECTION_ENUM.RP6_BACKWARD_RIGHT;
                this.pictureBox1.Image = Properties.Resources.backwardsRight;
                __RP6Control.SendMessage(RP6_DIRECTION_ENUM.RP6_BACKWARD_RIGHT);
            }
            if (!forwards && !backwards && !left && !right)
            {
                lastState = RP6_DIRECTION_ENUM.RP6_STOP;
                this.pictureBox1.Image = Properties.Resources.noMovement;
                __RP6Control.SendMessage(RP6_DIRECTION_ENUM.RP6_STOP);
            }
        }
        #endregion process key input (arrow keys and karma controller)
    #endregion
    }
}
