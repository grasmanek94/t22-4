using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Communication;

namespace ITTF_Server
{
	public class ServerMessage
	{
        public IPEndPoint EndPoint { get; set; }
		public byte[] Data { get; set; }
        public Message TrainMessage { get; set; }

        public ServerMessage()
        {
            EndPoint = new IPEndPoint(1, 1);
            Data = null;
            TrainMessage = null;
        }

        public ServerMessage(IPEndPoint endpoint, byte[] data, Message trainMessage)
        {
            //EndPoint = new IPEndPoint(endpoint.Address, endpoint.Port);
            EndPoint = endpoint;
            Data = data;
            TrainMessage = trainMessage;
        }
    }
}
