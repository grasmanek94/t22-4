using System.Collections.Generic;
using MessageService;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Net;
using System;

namespace ITTF_Server
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class CTrafficMessage : ITrafficMessage
    {
        private Administration administration;
        public TrainConnection trainConnection;
        private Dictionary<IPEndPoint, TrafficClient> trafficMessages;
        private Dictionary<string, IPEndPoint>[] receipentList;

        private IPEndPoint GetCurrentEndpoint()
        {
            OperationContext context = OperationContext.Current;
            MessageProperties prop = context.IncomingMessageProperties;
            RemoteEndpointMessageProperty endpoint =
                prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            return new IPEndPoint(IPAddress.Parse(endpoint.Address), endpoint.Port);
        }

        public CTrafficMessage()
        {
            administration = Program._Administration;

            trafficMessages = new Dictionary<IPEndPoint, TrafficClient>();
            int amountOfEnumValues = Enum.GetValues(typeof(ObjectType)).Length;

            receipentList = new Dictionary<string, IPEndPoint>[amountOfEnumValues];
            for (int i = 0; i < amountOfEnumValues; ++i)
            {
                receipentList[i] = new Dictionary<string, IPEndPoint>();
            }

            trainConnection = new TrainConnection(this);

            Program._CTrafficMessage = this;

            Console.WriteLine("CTrafficMessage Server initialized!");
        }

        public IPEndPoint GetID(ObjectType type, string name)
        {
            IPEndPoint outendpoint;
            if ((int)type >= receipentList.Length ||
                string.IsNullOrEmpty(name) ||
                string.IsNullOrWhiteSpace(name) ||
                !receipentList[(int)type].TryGetValue(name, out outendpoint))
            {
                return null;
            }
            return outendpoint;
        }

        public IPEndPoint ConnectMe(ObjectType type, string name)
        {
            if ((int)type >= receipentList.Length ||
                string.IsNullOrEmpty(name) ||
                string.IsNullOrWhiteSpace(name))
            {
                return null;
            }

            IPEndPoint id = GetCurrentEndpoint();
            IPEndPoint outendpoint;

            if (!receipentList[(int)type].TryGetValue(name, out outendpoint))//add new client
            {
                trafficMessages.Add(id, new TrafficClient());
                receipentList[(int)type].Add(name, id);
            }
            else if (outendpoint != id)//move client to new ip:port
            {
                TrafficClient client = trafficMessages[outendpoint];
                trafficMessages.Remove(outendpoint);
                trafficMessages.Add(id, client);
            }

            switch (type)
            {
                case ObjectType.Station:
                {
                    Station s = new Station(name);
                    s = administration.Add(s);
                    s.Address = id;
                }
                break;

                //case ObjectType.Train:
                //{
                //    administration.Add(new Train(name, 999));
                //}
                //break;
            }

            Console.WriteLine("ConnectMe(" + type.ToString() + ", " + name + ")::('" + id.ToString() + "');");
            return id;
        }

        public void Disconnect(ObjectType type, string name)
        {
            if ((int)type >= receipentList.Length ||
                string.IsNullOrEmpty(name) ||
                string.IsNullOrWhiteSpace(name))
            {
                return;
            }

            IPEndPoint id = GetCurrentEndpoint();

            bool rem_1 = receipentList[(int)type].Remove(name);
            bool rem_2 = trafficMessages.Remove(id);

            if(rem_1 || rem_2)
            {
                administration.Remove(new Station(name));
                //Console.WriteLine("Disconnect(" + type + ", " + name + ")::('" + id + "');");
            }
        }

        public bool SendMessage(ServerMessage message)
        {
            TrafficClient client;
            if (message == null || message.EndPoint == null || !trafficMessages.TryGetValue(message.EndPoint, out client))
            {
                return false;
            }

            IPEndPoint to = message.EndPoint;
            IPEndPoint id = GetCurrentEndpoint();
            message.EndPoint = id;
            client.Messages.Add(message);

            //Console.WriteLine("SendMessage::('" + id + "', '" + to + "', '" + System.Text.Encoding.ASCII.GetString(message.Data) + "');");
            return true;
        }

        public bool RetrieveMessage(out ServerMessage message)
        {
            IPEndPoint id = GetCurrentEndpoint();
            TrafficClient client;
            if (!trafficMessages.TryGetValue(id, out client) || client.Messages.Count == 0)
            {
                message = null;
                return false;
            }

            message = client.Messages[0];
            client.Messages.RemoveAt(0);

            //Console.WriteLine("RetrieveMessage::('" + id.ToString() + "');");
            return true;
        }

        public bool RetrieveAllMessages(out List<ServerMessage> messages)
        {
            IPEndPoint id = GetCurrentEndpoint();
            TrafficClient client;
            if (!trafficMessages.TryGetValue(id, out client) || client.Messages.Count == 0)
            {
                messages = null;
                return false;
            }

            messages = new List<ServerMessage>(client.Messages);
            client.Messages.Clear();

            //Console.WriteLine("RetrieveAllMessages::('" + id.ToString() + "');");
            return true;
        }

        public int MessagesAvailable()
        {
            IPEndPoint id = GetCurrentEndpoint();
            TrafficClient client;
        
            if (!trafficMessages.TryGetValue(id, out client))
            {
                return 0;
            }

            //Console.WriteLine("MessagesAvailable::('" + id.ToString() + "');");
            return client.Messages.Count;
        }

        public ClientStatus WhatIsMyConnectionStatus(ObjectType myType, string myName)
        {
            if ((int)myType >= receipentList.Length ||
                string.IsNullOrEmpty(myName) ||
                string.IsNullOrWhiteSpace(myName))
            {
                return ClientStatus.IdentificationError;
            }

            IPEndPoint id = GetCurrentEndpoint();
            IPEndPoint outendpoint;
            
            if (!receipentList[(int)myType].TryGetValue(myName, out outendpoint))//add new client
            {
                return ClientStatus.NotConnected;
            }
            else if (outendpoint != id)//move client to new ip:port
            {
                return ClientStatus.IPMismatch;
            }

            //Console.WriteLine("WhatIsMyConnectionStatus(" + myType.ToString() + ", " + myName + ")::('" + id.ToString() + "');");
            return ClientStatus.AllOK;
        }

        ///////////////// Local functions for arduino communication (trains)

        public IPEndPoint ConnectMeEx(ObjectType type, string name, IPEndPoint id)
        {
            if ((int)type >= receipentList.Length ||
                string.IsNullOrEmpty(name) ||
                string.IsNullOrWhiteSpace(name) ||
                id == null)
            {
                return null;
            }

            IPEndPoint outendpoint;

            if (!receipentList[(int)type].TryGetValue(name, out outendpoint))//add new client
            {
                trafficMessages.Add(id, new TrafficClient());
                receipentList[(int)type].Add(name, id);
            }
            else if (outendpoint != id)//move client to new ip:port
            {
                TrafficClient client = trafficMessages[outendpoint];
                trafficMessages.Remove(outendpoint);
                trafficMessages.Add(id, client);
            }

            switch(type)
            {
                case ObjectType.Station:
                {
                    administration.Add(new Station(name));
                }
                break;

                //case ObjectType.Train:
                //{
                //    administration.Add(new Train(name, 999));
                //}
                //break;
            }

            //Console.WriteLine("ConnectMeEx(" + type.ToString() + ", " + name + ")::('" + id.ToString() + "');");
            return id;
        }

        public bool SendMessageEx(ServerMessage message, IPEndPoint id)
        {
            TrafficClient client;
            if (id == null || message == null || message.EndPoint == null || !trafficMessages.TryGetValue(message.EndPoint, out client))
            {
                return false;
            }

            IPEndPoint to = message.EndPoint;
            message.EndPoint = id;
            client.Messages.Add(message);

            //Console.WriteLine("SendMessageEx::('" + id + "', '" + to + "', '" + System.Text.Encoding.ASCII.GetString(message.Data) + "');");
            return true;
        }

        public bool RetrieveMessageEx(out ServerMessage message, IPEndPoint id)
        {
            TrafficClient client;
            if (id == null || !trafficMessages.TryGetValue(id, out client) || client.Messages.Count == 0)
            {
                message = null;
                return false;
            }

            message = client.Messages[0];
            client.Messages.RemoveAt(0);

            //Console.WriteLine("RetrieveMessageEx::('" + id.ToString() + "');");
            return true;
        }

        public bool RetrieveAllMessagesEx(out List<ServerMessage> messages, IPEndPoint id)
        {
            TrafficClient client;
            if (id == null || !trafficMessages.TryGetValue(id, out client) || client.Messages.Count == 0)
            {
                messages = null;
                return false;
            }

            messages = new List<ServerMessage>(client.Messages);
            client.Messages.Clear();

            //Console.WriteLine("RetrieveAllMessagesEx::('" + id.ToString() + "');");
            return true;
        }

        public int MessagesAvailableEx(IPEndPoint id)
        {
            TrafficClient client;
            if (id == null || !trafficMessages.TryGetValue(id, out client))
            {
                return 0;
            }

            //Console.WriteLine("MessagesAvailableEx::('" + id.ToString() + "');");
            return client.Messages.Count;
        }

        public ClientStatus WhatIsMyConnectionStatusEx(ObjectType myType, string myName, IPEndPoint id)
        {
            if ((int)myType >= receipentList.Length ||
                string.IsNullOrEmpty(myName) ||
                string.IsNullOrWhiteSpace(myName) ||
                id == null)
            {
                return ClientStatus.IdentificationError;
            }

            IPEndPoint outendpoint;

            if (!receipentList[(int)myType].TryGetValue(myName, out outendpoint))//add new client
            {
                return ClientStatus.NotConnected;
            }
            else if (outendpoint != id)//move client to new ip:port
            {
                return ClientStatus.IPMismatch;
            }

            //Console.WriteLine("WhatIsMyConnectionStatusEx(" + myType.ToString() + ", " + myName + ")::('" + id.ToString() + "');");
            return ClientStatus.AllOK;
        }

        ////////////////////////////////
        public IPEndPoint MyEndPoint()
        {
            return GetCurrentEndpoint();
        }

        ////////////////////////////////
        public void Bye()
        {
            trainConnection.Dispose();
            //foreach(KeyValuePair<IPEndPoint, TrafficClient> connection in trafficMessages)
            //{
            //
            //}
        }
    }
}
