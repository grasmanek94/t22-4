using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITTF_Server
{
    public class TrafficClient
    {
        public List<ServerMessage> Messages { get; set; }
        public ObjectType Type { get; set; }
        public string Name { get; set; }
        public TrafficClient()
        {
            Messages = new List<ServerMessage>();
        }
    }
}
