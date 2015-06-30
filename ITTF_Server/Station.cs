using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace ITTF_Server
{
    public class Station : IComparable<Station>
    {
        public string StationName { get; private set; } 
        public Train LastTrain { get; set; }
        public Train NextTrain { get; set; }
        public IPEndPoint Address { get; set; }

        public Station(string name) //make new station
        {
            if(name == null)
            {
                throw new ArgumentNullException("name");
            }
            StationName = name;
        }

        public int CompareTo(Station other) //sort stations in list
        {
            if (other == null)
            {
                return 1;   // All instances are greater than null
            }
            return StationName.CompareTo(other.StationName);
        }
    }
}
