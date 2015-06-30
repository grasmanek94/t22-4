using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ITTF_Server;

namespace ITTF_Server_Test
{
    [TestClass]
    public class Station_Test
    {
        [TestMethod]
        public void StationNameLong()
        {
            string longStationName = "He was a boy. She was a girl. Could I be anymore obvious? All around the world statues crumble for me."
            + "Why did this happen to me. I tried so hard, and got so far.But in the end it didn't even matter. I'm blue daba dee daba da. "
            + "Never gonna give you up. Never gonna let you down. What is love. Baby dont hurt me. Dont hurt me. No more.";
            Station station = new Station(longStationName);
            Assert.AreEqual(longStationName, station.StationName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StationNameIsNull()
        {
            Station station = new Station(null);
        }

        [TestMethod]
        public void LastStationTest()
        {
            Station station = new Station("test");
            Train lastTrain = new Train(1, 2);
            station.LastTrain = lastTrain;
            Assert.AreEqual(lastTrain, station.LastTrain);
            Assert.AreEqual(1, lastTrain.TrainUnit);
        }

        [TestMethod]
        public void NextStationTest()
        {
            Station station = new Station("test");
            Train nextTrain = new Train(1, 2);
            station.NextTrain = nextTrain;
            Assert.AreEqual(nextTrain, station.NextTrain);
            Assert.AreEqual(1, nextTrain.TrainUnit);
        }
    }
}
