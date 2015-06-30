using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ITTF_Server;

namespace ITTF_Server_Test
{
    [TestClass]
    public class Route_Test
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RouteNumberIsZeroTest()
        {
            Route route = new Route(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RouteNumberIsNegativeTest()
        {
            Route route = new Route(-1);
        }

        [TestMethod]
        public void CompareToNullTest()
        {
            Route route = new Route(1);
            Assert.AreEqual(1, route.CompareTo(null));
        }

        [TestMethod]
        public void CompareToRouteTest()
        {
            Route route1 = new Route(1);
            Route route2 = new Route(2);
            Assert.AreEqual(-1, route1.CompareTo(route2));
        }

        [TestMethod]
        public void ToStringWithStationsTest()
        {
            Route route = new Route(1);
            Station station1 = new Station("station1");
            Station station2 = new Station("station2");
            Station station3 = new Station("station3");
            route.Stations.Add(station1);
            route.Stations.Add(station2);
            route.Stations.Add(station3);
            Assert.AreEqual("station1 , station2 , station3", route.ToString());
        }

        [TestMethod]
        public void ToStringWithoutStationsTest()
        {
            Route route = new Route(1);
            Assert.AreEqual("No Stations available", route.ToString());
        }
    }
}
