using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ITTF_Server;

namespace ITTF_Server_Test
{
    [TestClass]
    public class Train_Test
    {

        #region TrainUnit
        [TestMethod]
        public void TrainUnitPositiveTest()
        {
            Train train = new Train(1, 1);
            Assert.AreEqual(1, train.TrainUnit);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TrainUnitZeroTest()
        {
            Train train = new Train(0, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TrainUnitNegativeTest()
        {
            Train train = new Train(-1, 1);
        }
        #endregion

        #region Comport

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ComportZeroTest()
        {
            Train train = new Train(1, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ComportNegativeTest()
        {
            Train train = new Train(1, -1);
        }

        #endregion

        #region ToString
        [TestMethod]
        public void ToStringWithoutWagonTest()
        {
            Train train = new Train(1, 1);
            Assert.AreEqual("No Wagons available", train.ToString());
        }

        [TestMethod]
        public void ToStringWithOneWagonTest()
        {
            Train train = new Train(1, 1);
            Wagon wagon = new Wagon(1, 1, 1);
            train.Add(wagon);
            Assert.AreEqual("1", train.ToString());
        }

        [TestMethod]
        public void ToStringWithMultipleWagonsTest()
        {
            Train train = new Train(1, 1);
            Wagon wagon1 = new Wagon(1, 1, 1);
            Wagon wagon2 = new Wagon(2, 1, 1);
            Wagon wagon3 = new Wagon(3, 1, 1);
            Wagon wagon4 = new Wagon(4, 1, 1);
            train.Add(wagon1);
            train.Add(wagon2);
            train.Add(wagon3);
            train.Add(wagon4);
            Assert.AreEqual("1 - 2 - 3 - 4", train.ToString());
        }
        #endregion

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddWagonNullTest()
        {
            Train train = new Train(1, 1);
            Wagon wagon1 = null;
            train.Add(wagon1);
        }

        [TestMethod]
        public void CalculateSeatsTest()
        {
            Train train = new Train(1, 1);
            Wagon wagon1 = new Wagon(1,25,10);
            Wagon wagon2 = new Wagon(2, 15, 4);
            train.Add(wagon1);
            train.Add(wagon2);
            Assert.AreEqual(40, train.TotalSeats);
        }

        [TestMethod]
        public void CalculateStandingSpotsTest()
        {
            Train train = new Train(1, 1);
            Wagon wagon1 = new Wagon(1, 25, 10);
            Wagon wagon2 = new Wagon(2, 15, 4);
            train.Add(wagon1);
            train.Add(wagon2);
            Assert.AreEqual(14, train.TotalStandingSpots);
        }

        [TestMethod]
        public void CompareToNullTest()
        {
            Train train = new Train(1, 1);
            Assert.AreEqual(1, train.CompareTo(null));
        }

        [TestMethod]
        public void CompareToTrainTest()
        {
            Train train = new Train(1, 1);
            Train train2 = new Train(2, 2);
            Assert.AreEqual(train.TrainUnit.CompareTo(train2.TrainUnit), train.CompareTo(train2));
        }

        [TestMethod]
        public void UpdateNextStationTest()
        {
            Program._Administration = new Administration();
            Administration admin = Program._Administration;
            Train train = new Train(1, 1);
            admin.Add(train);
            Route route = new Route(1);
            admin.Routes.Add(route);
            Station station1 = new Station("station1");
            Station station2 = new Station("station2");
            Station station3 = new Station("station3");
            admin.Add(station1);
            admin.Add(station2);
            admin.Add(station3);
            route.Stations.Add(station1);
            route.Stations.Add(station2);
            route.Stations.Add(station3);
            train.RouteNr = 1;

            train.UpdateNextStation();
            Assert.AreEqual(station1, train.CurrentStation);
            Assert.AreEqual(station2, train.NextStation);

            train.UpdateNextStation();
            Assert.AreEqual(station2, train.CurrentStation);
            Assert.AreEqual(station3, train.NextStation);

            train.UpdateNextStation();
            Assert.AreEqual(station3, train.CurrentStation);
            Assert.AreEqual(null, train.NextStation);

            train.UpdateNextStation();
            Assert.AreEqual(station3, train.CurrentStation);
            Assert.AreEqual(null, train.NextStation);

            train.UpdateNextStation();
            Assert.AreEqual(station3, train.CurrentStation);
            Assert.AreEqual(null, train.NextStation);
        }
    }
}
