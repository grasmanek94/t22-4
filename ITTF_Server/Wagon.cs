using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITTF_Server
{

    public class Wagon : IComparable<Wagon>
    {
        public int WagonNumber { get; private set; }
        public int Seats { get; private set; }
        public int SeatsTaken { get; private set; }
        public int StandingSpots { get; private set; }
        public int StandingSpotsTaken { get; private set; }

        private Train connectedTo;

        public Wagon(int wagonNumber, int numberOfSeats, int numberOfStandingSpots) //constructor make wagon
        {
            if (wagonNumber < 1)
            {
                throw new ArgumentOutOfRangeException("wagonNumber < 1");
            }
            if (numberOfSeats < 1)
            {
                throw new ArgumentOutOfRangeException("numberOfSeats < 1");
            }
            if (numberOfStandingSpots < 1)
            {
                throw new ArgumentOutOfRangeException("numberofStandingspots < 1");
            }
            Seats = numberOfSeats;
            StandingSpots = numberOfStandingSpots;
            WagonNumber = wagonNumber;
        }

        public void AddWagonTo(Train train)
        {
            if (train == null)
            {
                throw new ArgumentNullException("train");
            }
            train.Wagons.Add(this); //add wagon to train
            connectedTo = train; //connect to train
        }

        public void RemoveWagonFromTrain() //remove wagon from train
        {
            connectedTo = null;
        }

        public int CompareTo(Wagon other) //sort list wagons
        {
            if (other == null)
            {
                return 1;   // All instances are greater than null
            }
            return WagonNumber.CompareTo(other.WagonNumber);
        }

        public override string ToString() //gives the number of wagon in a string
        {
            return WagonNumber.ToString();
        }

    }
}
