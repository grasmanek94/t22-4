using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using Communication;
using Communication.Enumerators;
using System.Timers;

namespace ITTF_Server
{
    public class TrainConnection
    {
        private Administration administration;
        private CTrafficMessage TrafficMessage { get; set; }
        public List<Arduino> connectedTrains;

        public Dictionary<IPEndPoint, Arduino> _IP2ARDUINO;
        public Dictionary<Arduino, IPEndPoint> _ARDUINO2IP;
        public Dictionary<int, Arduino> _ID2ARDUINO;
        public Dictionary<Arduino, int> _ARDUINO2ID;
        public Dictionary<Arduino, Train> _ARDUINO2TRAIN;

        //private readonly Timer _timer;
        private readonly System.Windows.Forms.Timer _timer;

        private void AddArduino(IPEndPoint endPoint, Arduino arduino, Train train)
        {
            _IP2ARDUINO.Add(endPoint, arduino);
            _ARDUINO2IP.Add(arduino, endPoint);
            _ID2ARDUINO.Add(arduino.Id, arduino);
            _ARDUINO2ID.Add(arduino, arduino.Id);
            _ARDUINO2TRAIN.Add(arduino, train);
        }

        private int ArduinoIdToIPAddress(int id)
        {
            return ((id / 254) << 8) | (1 + (id % 254));//00FE .. 0101 ... 01FE .. 0201
        }

        public TrainConnection(CTrafficMessage trafficMessage)
        {
            administration = Program._Administration;

            TrafficMessage = trafficMessage;

            connectedTrains = new List<Arduino>();
            _IP2ARDUINO = new Dictionary<IPEndPoint, Arduino>();
            _ARDUINO2IP = new Dictionary<Arduino, IPEndPoint>();
            _ID2ARDUINO = new Dictionary<int, Arduino>();
            _ARDUINO2ID = new Dictionary<Arduino, int>();
            _ARDUINO2TRAIN = new Dictionary<Arduino, Train>();

            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            int id = 1;
            foreach(string port in ports)
            {
                IPEndPoint endpoint = new IPEndPoint(new IPAddress(0xA9FE0000+ArduinoIdToIPAddress(id)), 3333);//169.254.0.0+id:3333
                Arduino a = new Arduino(id, port);
                Train arduinoTrain = new Train(id, int.Parse(port.Remove(0, 3)));

                connectedTrains.Add(a);
                AddArduino(endpoint, a, arduinoTrain);

                try
                {
                    a.Connect();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                id++;
            }

            //_timer = new Timer(1000.0);
            //_timer.Elapsed += Tick;
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 127;
            _timer.Tick += _timer_Tick; ;
            _timer.Enabled = true;
            _timer.Start();

            Program._TrainConnection = this;
        }

        //private void Tick(Object source, ElapsedEventArgs args)
        private void _timer_Tick(object sender, EventArgs e)
        {
            foreach(KeyValuePair<Arduino, IPEndPoint> train in new Dictionary<Arduino, IPEndPoint>(_ARDUINO2IP))
            {
                try
                {
                    IPEndPoint endpoint = _ARDUINO2IP[train.Key];
                    Train realTrain = _ARDUINO2TRAIN[train.Key];

                    if (train.Key.IsConnected)
                    {
                        //retrieve serial messages
                        {
                            Message message = new Message();
                            while (train.Key.Read(message) > 0)
                            {
                                //perform connection of arduino to the system
                                switch ((Actions)message.Action)
                                {
                                    case Actions.TRAIN_CONNECTME:
                                    {
                                        string name = System.Text.Encoding.ASCII.GetString(message.Data).Replace("\0", "");
                                        IPEndPoint connection = TrafficMessage.ConnectMeEx(ObjectType.Train, name, train.Value);
                                        if (connection != null)
                                        {
                                            _ARDUINO2IP[train.Key] = connection;
                                            endpoint = connection;
                                            train.Key.Write(new Message((byte)Actions.TRAIN_CONNECTIONOK));

                                            administration.Add(realTrain);
                                        }
                                        else
                                        {
                                            train.Key.Write(new Message((byte)Actions.TRAIN_CONNECTIONFAIL));
                                        }
                                    }
                                    break;

                                    case Actions.TRAIN_I_AM_GOING_TO_NEXT_STATION:
                                        realTrain.UpdateNextStation();
                                    break;
                                    //TODO case for whatsmyconnectionstatus

                                    default:
                                    //else if not connection just send the message to the next station
                                    {
                                        ServerMessage sm = new ServerMessage();
                                        if (realTrain.NextStation != null && realTrain.NextStation.Address != null)
                                        {
                                            sm.EndPoint = realTrain.NextStation.Address;
                                            sm.TrainMessage = message;
                                            TrafficMessage.SendMessageEx(sm, train.Value);
                                        }
                                    }
                                    break;
                                }
                                message = new Message();
                            }
                        }
                        //send new messages to arduino (train)
                        {
                            List<ServerMessage> messages = new List<ServerMessage>();
                            if (TrafficMessage.RetrieveAllMessagesEx(out messages, train.Value))
                            {
                                foreach (ServerMessage sm in messages)
                                {
                                    if (sm.TrainMessage != null)
                                    {
                                        train.Key.Write(sm.TrainMessage);
                                    }
                                }
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void Dispose()
        {
            foreach(Arduino arduino in connectedTrains)
            {
                try
                {
                    administration.Remove(new Train(arduino.Id, int.Parse(arduino.ComPort.Remove(0, 3))));
                    arduino.Disconnect();
                }
                catch(Exception)
                {

                }
            }
        }
    }
}
