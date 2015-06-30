using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Communication;
using Communication.Enumerators;

namespace Eindproject
{
    class RP6Control
    {
        private readonly Arduino _arduino;
        private readonly MMessage _moveMessage;

        public RP6Control(Arduino arduino)
        {
            _arduino = arduino;
            _moveMessage = new MMessage();
        }
        public byte SendMessage(RP6_DIRECTION_ENUM direction)
        {
            _moveMessage.Action = (byte)Actions.RP6_MOVE;
            _moveMessage.Data[0] = (byte)direction;
            _moveMessage.DataLen = 1;

            return _arduino.Write(_moveMessage);
        }
    }
}
