using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using System.ServiceModel.Description;
using MessageService;
using System.Net;

namespace ITTF_Server
{
    public partial class ServerGUI : Form
    {
        public ServerGUI()
        {
            InitializeComponent();

			infoText.AppendText("Service ITrafficMessage successfully hosted at address: \r\n");
			infoText.AppendText("http://" + Program.ip + "/\r\n");

            // Get host name
            String strHostName = Dns.GetHostName();

            // Enumerate IP addresses
            foreach (IPAddress ipaddress in Dns.GetHostAddresses(strHostName))
            {
                infoText.AppendText("Found machine address: '" + ipaddress.ToString() + "'\r\n");
            }
        }
    }
}
