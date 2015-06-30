using System;
using ITTF_TrainStation.TrafficMessage;
//using System.Timers;
using Communication.Enumerators;
using ITTF_Server;
using System.Net;
using Communication;
using Communication.LedControl;
using System.Drawing;
using System.IO;

namespace ITTF_TrainStation
{
	public class TrainStationProcessor
	{
		private TrafficMessageClient _service;
		public int WhoAmI { get; private set; }
		private ServerMessage _inMessage;
		private ServerMessage _outMessage;
        //private readonly Timer _timer;
        private readonly System.Windows.Forms.Timer _timer;
        private Arduino _arduino;
        private LedControl _ledControl;
        private ObjectType type;
        private string name;
        private string ip;
        private Random rand;
        private static readonly bool localOnly = false;

        public TrainStationProcessor(System.Windows.Forms.Label label)
		{
            rand = new Random();

            ip = "localhost:8000";

            if(!File.Exists("ip.txt"))
            {
                File.Create("ip.txt");
            }
            if(File.Exists("ip.txt"))
            {
                try
                {
                    string temp = File.ReadAllText("ip.txt");
                    if (!string.IsNullOrEmpty(temp) && !string.IsNullOrWhiteSpace(temp) && temp.Length > 2)
                    {
                        ip = temp;
                    }
                }
                catch(Exception)
                {

                }
            }

            if (!localOnly)
            {
                _service = new TrafficMessageClient("BasicHttpBinding_ITrafficMessage", "http://" + ip + "/MEX/MessageService");
                //_service = new TrafficMessageClient();

                _inMessage = new ServerMessage();
                _outMessage = new ServerMessage();
            }

            string[] comports = System.IO.Ports.SerialPort.GetPortNames();
            if (comports.Length > 0)
            {
                _arduino = new Arduino(0, System.IO.Ports.SerialPort.GetPortNames()[0]);
                _ledControl = new LedControl(_arduino, 6, 50);
                try
                {
                    _arduino.Connect();
                    _ledControl.InitializeLedStrip();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            //_timer = new Timer(500.0);
            //_timer.Elapsed += Tick;
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 127;
            _timer.Tick += _timer_Tick;
            _timer.Enabled = true;
			_timer.Start();
        }

        public IPEndPoint ConnectMe(ObjectType type, string name)
        {
            if(localOnly)
            {
                return new IPEndPoint(new IPAddress(0x7F000001), 1234);
            }

            this.type = type;
            this.name = name;
            return _service.ConnectMe(type, name);
        }

        public IPEndPoint ParseStringToIPEndpoint(string input)
        {
            int portStart = input.LastIndexOf(':');
            int port = int.Parse(input.Substring(portStart + 1));
            string ip = input.Substring(1, portStart - 2);
            return new IPEndPoint(IPAddress.Parse(ip), port);
        }

        public IPEndPoint GetMyIP()
        {
            if (localOnly)
            {
                return new IPEndPoint(new IPAddress(0x7F000001), 1234);
            }

            return _service.MyEndPoint();
        }

        public bool Send(string receiver, string data)
        {
            if (localOnly)
            {
                return false;
            }

            return _service.SendMessage(new ServerMessage(ParseStringToIPEndpoint(receiver), System.Text.Encoding.ASCII.GetBytes(data), null));
        }

        public bool Receive(out string sender, out string data)
        {
            if (localOnly)
            {
                sender = null;
                data = null;
                return false;
            }

            ServerMessage message;
            if(!_service.RetrieveMessage(out message))
            {
                message = null;
                sender = null;
                data = null;
                return false;
            }

            sender = message.EndPoint.ToString();
            data = System.Text.Encoding.ASCII.GetString(message.Data);
            return true;
        }

        private void _timer_Tick(object sender, EventArgs e)
        //public void Tick(Object source, ElapsedEventArgs args)
        {
            if (localOnly)
            {
                return;
            }
            try
            {
                if (_service.MessagesAvailable() > 0 &&
                    _service.RetrieveMessage(out _inMessage))
                {
                    Message tm = _inMessage.TrainMessage;
                    if (tm != null)
                    {
                        Console.Write("Received Train Message From '" + _inMessage.EndPoint + "', action: " + tm.Action + ", dataLen: " + tm.DataLen + "\n");
                        switch ((Actions)tm.Action)
                        {
                            case Actions.TRAIN_TRAFFIC_UPDATE:

                                int ledsPerWagon = 50 / tm.DataLen;

                                Color red = Color.Red;
                                Color orange = Color.Orange;
                                Color green = Color.Green;

                                Color set;

                                for (int i = 0; i < (tm.DataLen / 3); ++i)
                                {
                                    int wagonNumber = tm.Data[i * 3 + 0];
                                    int people = tm.Data[i * 3 + 1];
                                    int seatsTaken = tm.Data[i * 3 + 2];

                                    if (people >= seatsTaken)
                                    {
                                        set = red;
                                    }
                                    else if (people > 10)
                                    {
                                        set = orange;
                                    }
                                    else
                                    {
                                        set = green;
                                    }

                                    _ledControl.ChangeColor(wagonNumber * ledsPerWagon, (wagonNumber + 1) * ledsPerWagon, set);
                                }
                                break;
                        }
                    }
                    else
                    {
                        string message = System.Text.Encoding.ASCII.GetString(_inMessage.Data);
                        string[] lines = message.Split('\n');
                        Console.Write("Received Message From '" + _inMessage.EndPoint + "', content:\n-----\n" + message + "\n-----\n");
                    }
                }
            }
            catch(Exception)
            { }
		}

        public void RandomColors()
        {
            try
            {
                _ledControl.ChangeColor(0, 50, rand.Next(50, 120), rand.Next(50, 120), rand.Next(50, 120), 127);
            }
            catch(Exception)
            {
                //this is just a test button
            }
        }

        public void Dispose()
        {
            try
            {
                _arduino.Disconnect();
            }
            catch (Exception)
            {
                //we are closing, so we need to cleanup nicely!!!!!!!!!!!!!!
                //not crashy
            }

            if (localOnly)
            {
                return;
            }

            try
            {
                _service.Disconnect(type, name);
            }
            catch (Exception)
            {
                //we are closing, so we need to cleanup nicely!!!!!!!!!!!!!!
                //not crashy
            }
        }
	}
}
