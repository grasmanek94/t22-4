using System.Drawing;
using Communication.Enumerators;
using System.Net;
using ITTF_Server;
using Communication;

namespace ITTF_Server
{
    public class RP6Control
    {
        private ITTF_Server.ServerMessage _sMessage;
        private IPEndPoint endPoint;

        public RP6Control()
        {
            _sMessage = new ServerMessage(null, null, new Message());
            endPoint = new IPEndPoint(new IPAddress(0x7F000001), 9873 );
        }

        public byte MoveArduino(RP6_DIRECTION_ENUM direction)
        {
            if (Program._TrainConnection != null && 
                Program._TrainConnection._ARDUINO2IP != null && 
                Program._TrainConnection._ARDUINO2IP.Count > 0)
            {
                Arduino a = Program._TrainConnection.connectedTrains[0];

                _sMessage.EndPoint = Program._TrainConnection._ARDUINO2IP[a];

                _sMessage.TrainMessage.Action = (byte)Actions.RP6_MOVE;
                _sMessage.TrainMessage.Data[0] = (byte)direction;
                _sMessage.TrainMessage.DataLen = 1;

                Program._CTrafficMessage.SendMessageEx(_sMessage, endPoint);
                return (byte)1;
            }
            return (byte)0;
        }

        public byte NextStation()
        {
            if (Program._TrainConnection != null &&
                Program._TrainConnection._ARDUINO2IP != null &&
                Program._TrainConnection._ARDUINO2IP.Count > 0)
            {
                Arduino a = Program._TrainConnection.connectedTrains[0];
                Program._Administration.Trains[0].UpdateNextStation();

                _sMessage.EndPoint = Program._TrainConnection._ARDUINO2IP[a];

                _sMessage.TrainMessage.Action = (byte)Actions.TRAIN_I_AM_GOING_TO_NEXT_STATION;
                _sMessage.TrainMessage.DataLen = 0;

                Program._CTrafficMessage.SendMessageEx(_sMessage, endPoint);
                return (byte)1;
            }
            return (byte)0;
        }
    }
}
