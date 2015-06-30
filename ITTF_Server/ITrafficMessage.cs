using System.Collections.Generic;
using System.ServiceModel;
using System.Net;
using ITTF_Server;

namespace MessageService
{
    [ServiceContract(Namespace = "MessageService")]
    public interface ITrafficMessage
    {
		[OperationContract]
        IPEndPoint ConnectMe(ObjectType myType, string myName);

		[OperationContract]
        IPEndPoint GetID(ObjectType type, string name);

        [OperationContract]
        bool SendMessage(ServerMessage message);

        [OperationContract]
		bool RetrieveMessage(out ServerMessage message);

        [OperationContract]
        bool RetrieveAllMessages(out List<ServerMessage> messages);

        [OperationContract]
		int MessagesAvailable();

        [OperationContract]
        ClientStatus WhatIsMyConnectionStatus(ObjectType myType, string myName);

        [OperationContract]
        void Disconnect(ObjectType type, string name);

        [OperationContract]
        IPEndPoint MyEndPoint();
    }
}
