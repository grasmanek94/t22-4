using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ITTF_Server;

namespace ITTF_Server_Test
{
    [TestClass]
    public class Administration_Test
    {
        #region AddMethods

        #region AddStation
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddStationNullTest()
        {
            Administration admin = new Administration();
            Station station = null;
            admin.Add(station);          
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddStationEmptyStringTest()
        {
            Administration admin = new Administration();
            Station station = new Station("");
            admin.Add(station);
        }

        [TestMethod]
        public void AddNewStationTest()
        {
            Administration admin = new Administration();
            Station station = new Station("station1");
            Assert.AreEqual(station, admin.Add(station));
        }

        [TestMethod]
        public void AddExistingStationTest()
        {
            Administration admin = new Administration();
            Station station = new Station("station1");
            admin.Add(station);
            Assert.AreEqual(station, admin.Add(station));
        }

        [TestMethod]
        public void AddedStationCanBeFoundTest()
        {
            Administration admin = new Administration();
            Station station = new Station("station1");
            admin.Add(station);
            Station foundStation = admin.FindStation("station1");
            Assert.AreEqual(foundStation, station);
        }
        #endregion

        #region AddWagon
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddWagonNullTest()
        {
            Administration admin = new Administration();
            Wagon wagon = null;
            admin.Add(wagon);
        }

        [TestMethod]
        public void AddNewWagonTest()
        {
            Administration admin = new Administration();
            Wagon wagon = new Wagon(1,20,10);
            Assert.AreEqual(true, admin.Add(wagon));
        }

        [TestMethod]
        public void AddExistingWagonTest()
        {
            Administration admin = new Administration();
            Wagon wagon = new Wagon(1, 20, 10);
            admin.Add(wagon);
            Assert.AreEqual(false, admin.Add(wagon));
        }

        [TestMethod]
        public void AddedWagonCanBeFoundTest()
        {
            Administration admin = new Administration();
            Wagon wagon = new Wagon(1, 20, 10);
            admin.Add(wagon);
            Wagon foundWagon = admin.FindWagon(1);
            Assert.AreEqual(foundWagon, wagon);
        }
        #endregion

        #region AddTrain
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddTrainNullTest()
        {
            Administration admin = new Administration();
            Train train = null;
            admin.Add(train);
        }

        public void AddNewTrainTest()
        {
            Administration admin = new Administration();
            Train train = new Train(1, 1);
            Assert.AreEqual(true, admin.Add(train));
        }

        [TestMethod]
        public void AddExistingTrainTest()
        {
            Administration admin = new Administration();
            Train train = new Train(1, 1);
            admin.Add(train);
            Assert.AreEqual(false, admin.Add(train));
        }

        [TestMethod]
        public void AddedTrainCanBeFoundTest()
        {
            Administration admin = new Administration();
            Train train = new Train(1, 1);
            admin.Add(train);
            Train foundTrain = admin.FindTrain(1);
            Assert.AreEqual(foundTrain, train);
        }
        #endregion

        #region AddRoute

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddRouteNullTest()
        {
            Administration admin = new Administration();
            Route route = null;
            admin.Add(route);
        }

        public void AddNewRouteTest()
        {
            Administration admin = new Administration();
            Route route = new Route(1);
            Assert.AreEqual(true, admin.Add(route));
        }

        [TestMethod]
        public void AddExistingRouteTest()
        {
            Administration admin = new Administration();
            Route route = new Route(1);
            admin.Add(route);
            Assert.AreEqual(false, admin.Add(route));
        }

        [TestMethod]
        public void AddedRouteCanBeFoundTest()
        {
            Administration admin = new Administration();
            Route route = new Route(1);
            admin.Add(route);
            Route foundRoute = admin.FindRoute(1);
            Assert.AreEqual(foundRoute, route);
        }
        #endregion
        #endregion

        #region FindMethods

        #region FindStation
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindStationNullTest()
        {
            Administration admin = new Administration();
            admin.FindStation(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FindStationEmptyNameTest()
        {
            Administration admin = new Administration();
            admin.FindStation("");
        }

        [TestMethod]
        public void FindStationTest()
        {
            Administration admin = new Administration();
            Station station1 = new Station("station1");
            Station station2 = new Station("station2");
            Station station3 = new Station("station3");
            admin.Add(station1);
            admin.Add(station2);
            admin.Add(station3);
            Assert.AreEqual(station3, admin.FindStation("station3"));
            Assert.AreEqual(station2, admin.FindStation("station2"));
            Assert.AreEqual(station1, admin.FindStation("station1"));
        }

        [TestMethod]
        public void FindNotExistingStationTest()
        {
            Administration admin = new Administration();
            Assert.AreEqual(null, admin.FindStation("station"));
        }
        #endregion

        #region FindWagon
        [TestMethod]
        public void FindWagonTest()
        {
            Administration admin = new Administration();
            Wagon wagon1 = new Wagon(1, 1, 1);
            Wagon wagon2 = new Wagon(2, 1, 1);
            Wagon wagon3 = new Wagon(3, 1, 1);
            admin.Add(wagon1);
            admin.Add(wagon2);
            admin.Add(wagon3);
            Assert.AreEqual(wagon3, admin.FindWagon(3));
            Assert.AreEqual(wagon2, admin.FindWagon(2));
            Assert.AreEqual(wagon1, admin.FindWagon(1));
        }

        [TestMethod]
        public void FindNotExistingWagonTest()
        {
            Administration admin = new Administration();
            Assert.AreEqual(null, admin.FindWagon(1));
        }
        #endregion

        #region FindTrain

        [TestMethod]
        public void FindTrainTest()
        {
            Administration admin = new Administration();
            Train train1 = new Train(1, 1);
            Train train2 = new Train(2, 2);
            Train train3 = new Train(3, 3);
            admin.Add(train1);
            admin.Add(train2);
            admin.Add(train3);
            Assert.AreEqual(train1, admin.FindTrain(1));
            Assert.AreEqual(train2, admin.FindTrain(2));
            Assert.AreEqual(train3, admin.FindTrain(3));
        }

        [TestMethod]
        public void FindNotExistingTrainTest()
        {
            Administration admin = new Administration();
            Assert.AreEqual(null, admin.FindTrain(1));
        }
        #endregion

        #region FindRoute

        [TestMethod]
        public void FindRouteTest()
        {
            Administration admin = new Administration();
            Route route1 = new Route(1);
            Route route2 = new Route(2);
            Route route3 = new Route(3);
            admin.Add(route1);
            admin.Add(route2);
            admin.Add(route3);
            Assert.AreEqual(route1, admin.FindRoute(1));
            Assert.AreEqual(route2, admin.FindRoute(2));
            Assert.AreEqual(route3, admin.FindRoute(3));
        }

        [TestMethod]
        public void FindNotExistingRouteTest()
        {
            Administration admin = new Administration();
            Assert.AreEqual(null, admin.FindRoute(1));
        }
        #endregion
        #endregion

        #region RemoveMethods

        #region RemoveStation
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveStationNullTest()
        {
            Administration admin = new Administration();
            Station station = null;
            admin.Remove(station);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveStationWithoutNameTest()
        {
            Administration admin = new Administration();
            Station station = new Station("");
            admin.Remove(station);
        }

        [TestMethod]
        public void RemoveStationTest()
        {
            Administration admin = new Administration();
            Station station1 = new Station("station1");
            Station station2 = new Station("station2");
            Station station3 = new Station("station3");
            admin.Add(station1);
            admin.Add(station2);
            admin.Add(station3);
            Assert.AreEqual(true, admin.Remove(station3));
            Assert.AreEqual(true, admin.Remove(station2));
            Assert.AreEqual(true, admin.Remove(station1));
        }

        [TestMethod]
        public void RemoveNotExistinStationTest()
        {
            Administration admin = new Administration();
            Station station1 = new Station("station1");
            Assert.AreEqual(false, admin.Remove(station1));
        }
        #endregion

        #region RemoveWagon

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveWagonNullTest()
        {
            Administration admin = new Administration();
            Wagon wagon = null;
            admin.Remove(wagon);
        }

        [TestMethod]
        public void RemoveWagonTest()
        {
            Administration admin = new Administration();
            Wagon wagon1 = new Wagon(1, 1, 1);
            Wagon wagon2 = new Wagon(2, 1, 1);
            Wagon wagon3 = new Wagon(3, 1, 1);
            admin.Add(wagon1);
            admin.Add(wagon2);
            admin.Add(wagon3);
            Assert.AreEqual(true, admin.Remove(wagon3));
            Assert.AreEqual(true, admin.Remove(wagon2));
            Assert.AreEqual(true, admin.Remove(wagon1));
        }

        [TestMethod]
        public void RemoveNotExistinWagonTest()
        {
            Administration admin = new Administration();
            Wagon wagon = new Wagon(1, 1, 1);
            Assert.AreEqual(false, admin.Remove(wagon));
        }
        #endregion

        #region RemoveTrain

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveTrainNullTest()
        {
            Administration admin = new Administration();
            Train train = null;
            admin.Remove(train);
        }

        [TestMethod]
        public void RemoveTrainTest()
        {
            Administration admin = new Administration();
            Train train1 = new Train(1, 1);
            Train train2 = new Train(2, 2);
            Train train3 = new Train(3, 3);
            admin.Add(train1);
            admin.Add(train2);
            admin.Add(train3);
            Assert.AreEqual(true, admin.Remove(train1));
            Assert.AreEqual(true, admin.Remove(train2));
            Assert.AreEqual(true, admin.Remove(train3));
        }

        [TestMethod]
        public void RemoveNotExistinTrainTest()
        {
            Administration admin = new Administration();
            Train train = new Train(1, 1);
            Assert.AreEqual(false, admin.Remove(train));
        }
        #endregion

        #region RemoveRoute

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveRouteNullTest()
        {
            Administration admin = new Administration();
            Route route = null;
            admin.Remove(route);
        }

        [TestMethod]
        public void RemoveRouteTest()
        {
            Administration admin = new Administration();
            Route route1 = new Route(1);
            Route route2 = new Route(2);
            Route route3 = new Route(3);
            admin.Add(route1);
            admin.Add(route2);
            admin.Add(route3);
            Assert.AreEqual(true, admin.Remove(route1));
            Assert.AreEqual(true, admin.Remove(route2));
            Assert.AreEqual(true, admin.Remove(route3));
        }

        [TestMethod]
        public void RemoveNotExistinRouteTest()
        {
            Administration admin = new Administration();
            Route route = new Route(1);
            Assert.AreEqual(false, admin.Remove(route));
        }
        #endregion

        #endregion
    }
}
