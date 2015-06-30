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
using System.IO;
using RawInput;

namespace ITTF_Server
{
    public static class Program
    {
        static public CTrafficMessage _CTrafficMessage;
        static public TrainConnection _TrainConnection;
        static public Administration _Administration;
        static public string ip;

        static public CRawInput _rawinput;
        const bool CaptureOnlyInForeground = false;
        static public ITTF_SERVER_CONTROL_FORM _ITTF_SERVER_CONTROL_FORM;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Program._Administration = new Administration();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ip = "localhost:8000";

            if (!File.Exists("bind.txt"))
            {
                File.Create("bind.txt");
            }
            if (File.Exists("bind.txt"))
            {
                try
                {
                    string temp = File.ReadAllText("bind.txt");
                    if (!string.IsNullOrEmpty(temp) && !string.IsNullOrWhiteSpace(temp) && temp.Length > 2)
                    {
                        ip = temp;
                    }
                }
                catch(Exception)
                {

                }
            }

            ServerGUI gui = new ServerGUI();

            ControlWriter consoleWriter = new ControlWriter(gui.infoText);
            Console.SetOut(consoleWriter);

            // creeer een host proces voor de TrafficMessageService
            ServiceHost host = new ServiceHost(typeof(CTrafficMessage));

            // creeer een zgn. end-point voor de service
            Type contract = typeof(ITrafficMessage);
			BasicHttpBinding binding = new BasicHttpBinding();
            string baseAddress = "http://" + ip + "/MEX";
			Uri address = new Uri(baseAddress + "/MessageService");
			host.AddServiceEndpoint(contract, binding, address);

			// creeer een zgn. mex endpoint om de wsdl van de service te hosten
			host.Description.Behaviors.Add(new ServiceMetadataBehavior());
			EndpointAddress endPointAddress = new EndpointAddress(baseAddress + "/MEX");
			ServiceEndpoint mexEndpoint = new ServiceMetadataEndpoint(endPointAddress);
			host.AddServiceEndpoint(mexEndpoint);

            ServiceDebugBehavior debug = host.Description.Behaviors.Find<ServiceDebugBehavior>();

            // if not found - add behavior with setting turned on 
            if (debug == null)
            {
                host.Description.Behaviors.Add(
                     new ServiceDebugBehavior() { IncludeExceptionDetailInFaults = true });
            }
            else
            {
                // make sure setting is turned ON
                if (!debug.IncludeExceptionDetailInFaults)
                {
                    debug.IncludeExceptionDetailInFaults = true;
                }
            }

            // start de service
            host.Open();

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            _ITTF_SERVER_CONTROL_FORM = new ITTF_SERVER_CONTROL_FORM();
            _ITTF_SERVER_CONTROL_FORM.Show();

            _rawinput = new CRawInput(gui.Handle, CaptureOnlyInForeground);

            _rawinput.AddMessageFilter();   // Adding a message filter will cause keypresses to be handled

            _rawinput.KeyPressed += OnKeyPressed;

            new AdministrationForm().Show();
            Application.Run(gui);

            _CTrafficMessage.Bye();
        }

        private static void OnKeyPressed(object sender, RawInputEventArg e)
        {
            _ITTF_SERVER_CONTROL_FORM.ProcessKeyInput(e);
        }

        private static void Keyboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            _rawinput.KeyPressed -= OnKeyPressed;
        }

        private static void CurrentDomain_UnhandledException(Object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception;

            if (null == ex) return;

            // Log this error. Logging the exception doesn't correct the problem but at least now
            // you may have more insight as to why the exception is being thrown.
            Console.WriteLine("Unhandled Exception: " + ex.Message);
            Console.WriteLine("Unhandled Exception: " + ex);
            //MessageBox.Show(ex.Message);
        }
    }
}
