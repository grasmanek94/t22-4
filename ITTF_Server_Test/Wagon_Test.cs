using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ITTF_Server;


namespace ITTF_Server_Test
{
    [TestClass]
    public class Wagon_Test
    {
        #region WagonNumber 
        [TestMethod]
        public void WagonNumberPositiveTest()
        {
            Wagon wagon = new Wagon(1, 1, 1);
            Assert.AreEqual(1, wagon.WagonNumber);
            Wagon wagon2 = new Wagon(999999, 1, 1);
            Assert.AreEqual(999999, wagon2.WagonNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WagonNumberZeroTest()
        {
            Wagon wagon = new Wagon(0, 1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WagonNumberNegativeTest()
        {
            Wagon wagon = new Wagon(-1, 1, 1);
            Wagon wagon2 = new Wagon(-999999, 1, 1);
        }

        #endregion

        #region numberOfSeats

        [TestMethod]
        public void NumberOfSeatsPositiveTest()
        {
            Wagon wagon = new Wagon(1, 1, 1);
            Assert.AreEqual(1, wagon.Seats);
            Wagon wagon2 = new Wagon(1, 999999, 1);
            Assert.AreEqual(999999, wagon2.Seats);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NumberOfSeatsZeroTest()
        {
            Wagon wagon = new Wagon(0, 1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NumberOfSeatsNegativeTest()
        {
            Wagon wagon = new Wagon(-1, 1, 1);
            Wagon wagon2 = new Wagon(-999999, 1, 1);
        }

        #endregion

        #region numberOfStandingSpots

        [TestMethod]
        public void StandingSpotsPositiveTest()
        {
            Wagon wagon = new Wagon(1, 1, 1);
            Assert.AreEqual(1, wagon.StandingSpots);
            Wagon wagon2 = new Wagon(1, 1, 999999);
            Assert.AreEqual(999999, wagon2.StandingSpots);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StandingSpotsZeroTest()
        {
            Wagon wagon = new Wagon(1, 1, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StandingSpotsNegativeTest()
        {
            Wagon wagon = new Wagon(1, 1, -1);
            Wagon wagon2 = new Wagon(1, 1, -999999);
        }

        #endregion

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddWagonWhenNullTest()
        {
            Wagon wagon = new Wagon(1, 1, 1);
            wagon.AddWagonTo(null);
        }
    }
}
