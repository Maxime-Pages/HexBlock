using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HexBlock.Tests
{
    class HexTests
    {
        #region Spot

        [Test]
        public void Spot_Start_Empty()
        {
            Spot spot = new Spot(0, 0);
            Assert.IsTrue(spot.IsEmpty());
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Spot_Get_Colored(bool color)
        {
            Spot spot = new Spot(0, 0);
            spot.Color(color);
            Assert.IsFalse(spot.IsEmpty());
            Assert.AreEqual(color,spot.GetColor());
        }
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(200)]
        public void Spot_Return_X(int x)
        {
            Spot spot = new Spot(x, 0);
            Assert.AreEqual(x,spot.GetX());
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(200)]
        public void Spot_Return_y(int y)
        {
            Spot spot = new Spot(0, y);
            Assert.AreEqual(y, spot.GetY());
        }

        [TestCase(0,0)]
        [TestCase(0,1)]
        [TestCase(200,200)]
        public void Spot_Return_Coo(int x,int y)
        {
            Spot spot = new Spot(x, y);
            Assert.AreEqual((x,y),spot.GetCoo());
        }
        #endregion

        #region PathFinding

        

        #endregion
    }
}
