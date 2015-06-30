using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITTF_Server
{
    public class Route : IComparable<Route>
    {
        public int RouteNr { get; private set; }
        public List<Station> Stations { get; set; } 

        public Route(int routeNr) //constructor, make a route with a routenumber
        {
            if (routeNr < 1)
            {
                throw new ArgumentOutOfRangeException("routeNr < 1");
            }
            RouteNr = routeNr;
            Stations = new List<Station>(); //make a new list of stations
        }

        public int CompareTo(Route other) //sort list by routenumber
        {
            if (other == null)
            {
                return 1;   // All instances are greater than null
            }
            return RouteNr.CompareTo(other.RouteNr);
        }

        public override string ToString() //string for stations in route
        {
            string routeString = "";
            foreach (Station station in Stations)
            {
                routeString += (station.StationName + " , "); //set station name in string
            }
            if (routeString == "")
            {
                routeString = "No Stations available";
                return routeString;
            }
            return routeString.Remove(routeString.Length - 3); //removes the , on the end
        }

    }
}
