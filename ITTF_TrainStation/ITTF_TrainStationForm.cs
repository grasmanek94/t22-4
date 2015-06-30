using System;
using System.Windows.Forms;
using ITTF_Server;

namespace ITTF_TrainStation
{
    public partial class ITTF_TrainStationForm : Form
    {
		TrainStationProcessor processor;
        public ITTF_TrainStationForm()
        {
            InitializeComponent();

			processor = new TrainStationProcessor(ServerLbl);

            try
            {
                string name = Environment.MachineName + "[" + processor.GetMyIP() + "]";

                tbWhoAmI.Text = processor.ConnectMe(ObjectType.Station, name).ToString();

                this.Text += "\"" + name + "\"";
            }
            catch(Exception ex)
            {
                MessageBox.Show("Startup error: ", ex.Message);
                processor.Dispose();
                Application.Exit();
            }

            ControlWriter consoleWriter = new ControlWriter(messagesBox);
            Console.SetOut(consoleWriter);
        }

        private void SendMessageBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (processor.Send(tbAddress.Text, messageTextBox.Text))
                {
                    messageTextBox.Text = "";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Exception occured: \n" + ex.Message);
            }
        }

        private void ITTF_TrainStationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                processor.Dispose();
            }
            catch(Exception)
            {
                //again, we want to shutdown, not crash the shit out of a computer ;)
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            processor.RandomColors();
        }
    }
}
