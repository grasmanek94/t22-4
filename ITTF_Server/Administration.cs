using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITTF_Server
{
    public class Administration
    {
        public delegate void TrainHandler(object sender, Train train, bool add);
        public delegate void StationHandler(object sender, Station station, bool add);
        public delegate void WagonHandler(object sender, Wagon wagon, bool add);
        public delegate void RouteHandler(object sender, Route route, bool add);

        public event TrainHandler OnTrainUpdate;
        public event StationHandler OnStationUpdate;
        public event WagonHandler OnWagonUpdate;
        public event RouteHandler OnRouteUpdate;

        public List<Station> Stations { get; set; } //list with stations
        public List<Wagon> Wagons { get; set; } //list with wagons
        public List<Train> Trains { get; set; } //list with trains
        public List<Route> Routes { get; set; } //list with routes

        public Administration()
        {
            Stations = new List<Station>(); //make new list
            Wagons = new List<Wagon>(); //make new list
            Trains = new List<Train>(); //make new list
            Routes = new List<Route>(); //make new list
        }


        #region Add Methods

        public Station Add(Station station) //add station
        {
            if (station == null)
            {
                throw new ArgumentNullException("station");
            }
            if (station.StationName == "")
            {
                throw new ArgumentException("station");
            }

            Station s = FindStation(station.StationName);
            if (s == null)
            {
                Stations.Add(station); //add to list 

                if(OnStationUpdate != null)
                {
                    OnStationUpdate(this, station, true);
                }
                return station;
            }
            return s;
        }

        public bool Add(Wagon wagon) //add wagon
        {
            if (wagon == null)
            {
                throw new ArgumentNullException("wagon");
            }

            Wagon w = FindWagon(wagon.WagonNumber);
            if (w == null)
            {
                Wagons.Add(wagon); //add to list

                if (OnWagonUpdate != null)
                {
                    OnWagonUpdate(this, wagon, true);
                }
                return true;
            }
            return false;
        }

        public bool Add(Train train) //add train
        {
            if (train == null)
            {
                throw new ArgumentNullException("train");
            }

            Train t = FindTrain(train.TrainUnit);
            if (t == null)
            {
                Trains.Add(train); //add to list
                if (OnTrainUpdate != null)
                {
                    OnTrainUpdate(this, train, true);
                }
                return true;
            }
            return false;
        }

        public bool Add(Route route) //add route
        {
            if (route == null)
            {
                throw new ArgumentNullException("route");
            }

            Route r = FindRoute(route.RouteNr);
            if (r == null)
            {
                Routes.Add(route); //add to list
                if (OnRouteUpdate != null)
                {
                    OnRouteUpdate(this, route, true);
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Find Methods

        public Station FindStation(string stationName) 
        {
            if (stationName == null)
            {
                throw new ArgumentNullException("stationName");
            }
            if (stationName == "")
            {
                throw new ArgumentException("stationName");
            }

            foreach (Station s in Stations) //look in list
            {
                if (s.StationName == stationName)
                {
                    return s; //found
                }
            }
            return null;
        }

        public Wagon FindWagon(int wagonNumber)
        {
            foreach (Wagon w in Wagons) //look in list
            {
                if (w.WagonNumber == wagonNumber)
                {
                    return w; //found
                }
            }
            return null;
        }

        public Train FindTrain(int trainNumber) 
        {
            foreach (Train t in Trains) //look in list
            {
                if (t.TrainUnit == trainNumber)
                {
                    return t; //found
                }
            }
            return null;
        }

        public Route FindRoute(int routeNr)
        {
            foreach (Route r in Routes) //look in list
            {
                if (r.RouteNr == routeNr)
                {
                    return r; //found
                }
            }
            return null;
        }

        #endregion

        #region Remove Methods

        public bool Remove(Station station) //remove station
        {
            if (station == null)
            {
                throw new ArgumentNullException("station");
            }
            if (station.StationName == "")
            {
                throw new ArgumentException("station");
            }

            Station s = FindStation(station.StationName);
            if (s != null)
            {
                Stations.Remove(s); //remove from list
                if (OnStationUpdate != null)
                {
                    OnStationUpdate(this, s, false);
                }
                return true;
            }
            return false;
        }

        public bool Remove(Wagon wagon) // remove wagon
        {
            if (wagon == null)
            {
                throw new ArgumentNullException("wagon");
            }

            Wagon w = FindWagon(wagon.WagonNumber);
            if (w != null)
            {
                Wagons.Remove(w); //remove from list
                if (OnWagonUpdate != null)
                {
                    OnWagonUpdate(this, w, false);
                }
                return true;
            }
            return false;
        }

        public bool Remove(Train train) //remove train
        {
            if (train == null)
            {
                throw new ArgumentNullException("train");
            }

            Train t = FindTrain(train.TrainUnit);
            if (t != null)
            {
                Trains.Remove(t); //remove from list
                if (OnTrainUpdate != null)
                {
                    OnTrainUpdate(this, t, false);
                }
                return true;
            }
            return false;
        }

        public bool Remove(Route route) //remove route
        {
            if (route == null)
            {
                throw new ArgumentNullException("route");
            }

            Route r = FindRoute(route.RouteNr);
            if (r != null)
            {
                Routes.Remove(r); //remove from list
                if (OnRouteUpdate != null)
                {
                    OnRouteUpdate(this, r, false);
                }
                return true;
            }
            return false;
        }
        #endregion
    }
}
