using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Communication;
using Communication.Enumerators;

namespace ITTF_Server
{
    public class Train : IComparable<Train>
    {
        public int RouteNr { get; set; }
        public List<Wagon> Wagons { get; private set; }
        public int TrainUnit { get; private set; }
        public int TotalSeats //calculate TotalSeats of train
        {
            get
            {
                int totalSeats = 0;
                foreach (Wagon w in Wagons)
                {
                    totalSeats += w.Seats;
                }
                return totalSeats;
            }
        }
        public int TotalStandingSpots //calculate TotalStandingSpots of train
        {
            get
            {
                int totalStandingSpots = 0;
                foreach (Wagon w in Wagons)
                {
                    totalStandingSpots += w.StandingSpots;
                }
                return totalStandingSpots;
            }
        }

        private Station _CurrentStation;      
        public Station CurrentStation 
        {
            get
            {
                return _CurrentStation;
            }
            private set
            {
                _CurrentStation = value;
                if (arduino != null)
                {
                    if (_CurrentStation != null)
                    {
                        arduino.CurrentStation = _CurrentStation.Address;
                    }
                    else
                    {
                        arduino.CurrentStation = null;
                    }
                }
            }
        }

        private Station _NextStation;
        public Station NextStation
        {
            get
            {
                return _NextStation;
            }
            private set
            {
                _NextStation = value;
                if (arduino != null)
                {
                    if (_NextStation != null)
                    {
                        arduino.NextStation = _NextStation.Address;
                    }
                    else
                    {
                        arduino.NextStation = null;
                    }
                }
            }
        }

        private Arduino arduino;
        //int counter = 1; uncomment for demo

        public Train(int trainUnit, int comPort) //constructor, make train
        {
            if(trainUnit < 1)
            {
                throw new ArgumentOutOfRangeException("trainUnit < 1");
            }
            if (comPort < 1)
            {
                throw new ArgumentOutOfRangeException("comPort < 1");
            }
            TrainUnit = trainUnit;
            Wagons = new List<Wagon>(); //makes new list for wagons
            arduino = new Arduino(trainUnit, "COM" + comPort); 
        }

        public void Add(Wagon wagon) //Add a wagon to train
        {
            if (wagon != null)
            {
                Wagons.Add(wagon);
            }
            else
            {
                throw new ArgumentNullException("wagon");
            }
        }
        
        public void UpdateNextStation() //update current station en next station
        {
            CurrentStation = Program._Administration.Stations.Count > 0 ? Program._Administration.Stations[0] : null;
            NextStation = CurrentStation;
            
            /*uncomment this and comment above for demo

            Route find = Program._Administration.FindRoute(this.RouteNr);
            
            if (CurrentStation == null) //set current station
            {
                if (find.Stations.Count > 0)
                {
                    CurrentStation = find.Stations[0];
                }
            }
            
            if (find.Stations.Count > 0)
            {
                if (NextStation != null)
                {
                    CurrentStation = NextStation; //update currentstation
                }
                if (counter < find.Stations.Count)
                {
                    NextStation = find.Stations[counter]; //update nextstation
                    counter++;
                }
                else if (counter == find.Stations.Count)
                {
                    NextStation = null; //there is no next station
                }               
            }*/
        }

        public void RequestTrainData()
        {
            Message requestData = new Message((byte)Actions.REQUEST_TRAIN_TRAFFIC_UPDATE);
            arduino.Write(requestData);
        }

        public int CompareTo(Train other) //Sort list by number
        {
            if (other == null)
            {
                return 1;   // All instances are greater than null
            }
            return TrainUnit.CompareTo(other.TrainUnit);
        }

        public override string ToString() //string information wagons
        {
            string retstr = "";
            foreach (Wagon w in Wagons)
            {
                retstr += w.ToString() + " - "; //save the wagon number in string
            }
            if (retstr == "")
            {
                retstr = "No Wagons available";
                return retstr;
            }
            return retstr.Remove(retstr.Length - 3); //removes the - 
        }

    }
}
