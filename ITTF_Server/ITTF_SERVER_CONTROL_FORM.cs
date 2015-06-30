using System;
using Communication.Enumerators;
using Communication;
using RawInput;

namespace ITTF_Server
{
    public partial class ITTF_SERVER_CONTROL_FORM : System.Windows.Forms.Form
    {
        bool forwards;
        bool left;
        bool right;
        bool backwards;
        bool nextStation;
        RP6_DIRECTION_ENUM lastState;
        private RP6Control _RP6Control;
        public ITTF_SERVER_CONTROL_FORM()
        {
            InitializeComponent();
            controlTimer.Start();
            _RP6Control = new RP6Control();
            comboBox1.Items.Add("NONE");
        }
        
        //Process keys (arrows keys and karma controller)
        #region
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            /*if (keyData == System.Windows.Forms.Keys.Left)
            {
                left = true;
                return true;
            }
            if (keyData == System.Windows.Forms.Keys.Right)
            {
                right = true;
                return true;
            }
            if (keyData == System.Windows.Forms.Keys.Up)
            {
                forwards = true;
                return true;
            }
            if (keyData == System.Windows.Forms.Keys.Down)
            {
                backwards = true;
                return true;
            }*/
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ITTF_SERVER_CONTROL_FORM_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            /*switch (e.KeyCode){
                case System.Windows.Forms.Keys.X:
                    forwards = true;
                    break;
                case System.Windows.Forms.Keys.Z:
                    backwards = true;
                    break;
                case System.Windows.Forms.Keys.Y:
                    nextStation = true;
                    break;
                case System.Windows.Forms.Keys.Left:
                    left = true;
                    break;
                case System.Windows.Forms.Keys.Right:
                    right = true;
                    break;
            }*/
        }

        private void ITTF_SERVER_CONTROL_FORM_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            /*switch (e.KeyCode)
            {
                case System.Windows.Forms.Keys.Up:
                case System.Windows.Forms.Keys.X:
                    forwards = false;
                    break;
                case System.Windows.Forms.Keys.Down:
                case System.Windows.Forms.Keys.Z:
                    backwards = false;
                    break;
                case System.Windows.Forms.Keys.Y:
                    nextStation = false;
                    break;
                case System.Windows.Forms.Keys.Left:
                    left = false;
                    break;
                case System.Windows.Forms.Keys.Right:
                    right = false;
                    break;
            }*/
        }

        public void ProcessKeyInput(RawInputEventArg e)
        {
            //e.KeyPressEvent.DeviceHandle;
            //e.KeyPressEvent.DeviceType;
            //e.KeyPressEvent.DeviceName;
            //e.KeyPressEvent.Name;
            //e.KeyPressEvent.VKey.ToString(CultureInfo.InvariantCulture);
            //_rawinput.NumberOfKeyboards.ToString(CultureInfo.InvariantCulture);
            //e.KeyPressEvent.VKeyName;
            //e.KeyPressEvent.Source;
            //e.KeyPressEvent.KeyPressState;
            //string.Format("0x{0:X4} ({0})", e.KeyPressEvent.Message);
            lastKeyPressLabel.Text = e.KeyPressEvent.Source;
            if(!comboBox1.Items.Contains(e.KeyPressEvent.Source))
            {
                comboBox1.Items.Add(e.KeyPressEvent.Source);
            }

            if (e.KeyPressEvent.Source == (string)comboBox1.SelectedItem)
            {
                switch (e.KeyPressEvent.VKeyName)
                {
                    case "UP":
                    case "X":
                        forwards = e.KeyPressEvent.KeyPressState == "MAKE";
                        break;
                    case "DOWN":
                    case "Z":
                        backwards = e.KeyPressEvent.KeyPressState == "MAKE";
                        break;
                    case "Y":
                        nextStation = e.KeyPressEvent.KeyPressState == "MAKE";
                        break;
                    case "LEFT":
                        left = e.KeyPressEvent.KeyPressState == "MAKE";
                        break;
                    case "RIGHT":
                        right = e.KeyPressEvent.KeyPressState == "MAKE";
                        break;
                }
            }
        }
        //Send message to arduino
        #region 
        private void controlTimer_Tick(object sender, EventArgs e)
        {
            if (_RP6Control != null)
            {
                if (nextStation)
                {
                    nextStation = false;
                    _RP6Control.NextStation();
                }
                if (forwards && !left && !right && lastState != RP6_DIRECTION_ENUM.RP6_FORWARD)
                {
                    lastState = RP6_DIRECTION_ENUM.RP6_FORWARD;
                    this.controlPictureBox.Image = Properties.Resources.forwards;
                    _RP6Control.MoveArduino(RP6_DIRECTION_ENUM.RP6_FORWARD);
                }
                if (left && !forwards && !backwards && lastState != RP6_DIRECTION_ENUM.RP6_LEFT)
                {
                    lastState = RP6_DIRECTION_ENUM.RP6_LEFT;
                    this.controlPictureBox.Image = Properties.Resources.left;
                    _RP6Control.MoveArduino(RP6_DIRECTION_ENUM.RP6_LEFT);
                }
                if (right && !forwards && !backwards && lastState != RP6_DIRECTION_ENUM.RP6_RIGHT)
                {
                    lastState = RP6_DIRECTION_ENUM.RP6_RIGHT;
                    this.controlPictureBox.Image = Properties.Resources.right;
                    _RP6Control.MoveArduino(RP6_DIRECTION_ENUM.RP6_RIGHT);
                }
                if (backwards && !left && !right && lastState != RP6_DIRECTION_ENUM.RP6_BACKWARD)
                {
                    lastState = RP6_DIRECTION_ENUM.RP6_BACKWARD;
                    this.controlPictureBox.Image = Properties.Resources.backwards;
                    _RP6Control.MoveArduino(RP6_DIRECTION_ENUM.RP6_BACKWARD);
                }
                if (forwards && left && lastState != RP6_DIRECTION_ENUM.RP6_FORWARD_LEFT)
                {
                    lastState = RP6_DIRECTION_ENUM.RP6_FORWARD_LEFT;
                    this.controlPictureBox.Image = Properties.Resources.forwardsLeft;
                    _RP6Control.MoveArduino(RP6_DIRECTION_ENUM.RP6_FORWARD_LEFT);
                }
                if (forwards && right && lastState != RP6_DIRECTION_ENUM.RP6_FORWARD_RIGHT)
                {
                    lastState = RP6_DIRECTION_ENUM.RP6_FORWARD_RIGHT;
                    this.controlPictureBox.Image = Properties.Resources.forwardsRight;
                    _RP6Control.MoveArduino(RP6_DIRECTION_ENUM.RP6_FORWARD_RIGHT);
                }
                if (backwards && left && lastState != RP6_DIRECTION_ENUM.RP6_BACKWARD_LEFT)
                {
                    lastState = RP6_DIRECTION_ENUM.RP6_BACKWARD_LEFT;
                    this.controlPictureBox.Image = Properties.Resources.backwardsLeft;
                    _RP6Control.MoveArduino(RP6_DIRECTION_ENUM.RP6_BACKWARD_LEFT);
                }
                if (backwards && right && lastState != RP6_DIRECTION_ENUM.RP6_BACKWARD_RIGHT)
                {
                    lastState = RP6_DIRECTION_ENUM.RP6_BACKWARD_RIGHT;
                    this.controlPictureBox.Image = Properties.Resources.backwardsRight;
                    _RP6Control.MoveArduino(RP6_DIRECTION_ENUM.RP6_BACKWARD_RIGHT);
                }
                if (!forwards && !backwards && !left && !right && lastState != RP6_DIRECTION_ENUM.RP6_STOP)
                {
                    lastState = RP6_DIRECTION_ENUM.RP6_STOP;
                    this.controlPictureBox.Image = Properties.Resources.noMovement;
                    _RP6Control.MoveArduino(RP6_DIRECTION_ENUM.RP6_STOP);
                }
            }
        }

        #endregion process key input (arrow keys and karma controller)

        #endregion

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
