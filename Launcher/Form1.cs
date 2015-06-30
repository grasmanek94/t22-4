using System.Windows.Forms;
using System.Diagnostics;

namespace Launcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            WindowState = FormWindowState.Normal;
            e.Cancel = true;
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {

        }

        private void server_Click(object sender, System.EventArgs e)
        {
            Process.Start("C:\\ITTF\\ITTF_Server.exe");
        }

        private void station_Click(object sender, System.EventArgs e)
        {
            Process.Start("C:\\ITTF\\ITTF_TrainStation.exe");
        }

        private void serverbind_Click(object sender, System.EventArgs e)
        {
            Process.Start("C:\\ITTF\\bind.txt");
        }

        private void stationip_Click(object sender, System.EventArgs e)
        {
            Process.Start("C:\\ITTF\\ip.txt");
        }

        private void update_Click(object sender, System.EventArgs e)
        {
            Process.Start("C:\\ITTF\\Update.bat");
        }

        private void editupdate_Click(object sender, System.EventArgs e)
        {
            Process.Start("notepad.exe", "C:\\ITTF\\Update.bat");
        }

        private void cmd_Click(object sender, System.EventArgs e)
        {
            Process.Start("cmd.exe");
        }

        private void shutdown_Click(object sender, System.EventArgs e)
        {
            Process.Start("shutdown", "-s -f /t 0");
        }
    }
}
