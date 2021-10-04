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

        #region Board

        [TestCase(11)]
        [TestCase(13)]
        [TestCase(17)]

        public void Board_is_created_with_inputed_size(int size)
        {
            Board game = new Board(size);
            Assert.AreEqual(size, game.GetSize());
        }

        [TestCase(11)]
        [TestCase(13)]
        //[TestCase(17)]

        public void Board_is_created_with_a_correct_size(int size)
        {
            Board board = new Board(size);
            Assert.IsTrue(board.VerrifySize(size));
        }
        [TestCase(1)]
        [TestCase(15)]
        [TestCase(-1)]

        public void Board_is_not_created_with_an_incorrect_size(int size)
        {
            Board board = null;
            var exception = Assert.Throws<Exception>( () => new  Board(size));
            Assert.AreEqual("Invalid Size",exception.Message);
            Assert.AreEqual(null,board);
        }


        [Test]
        public void Should_Return_true_when_playing_against_ai(int size, bool choice)
        {

            Board board = new Board(size);
            Assert.IsTrue(board.startGame(size, true));
            
        }

        [Test]
        public void Should_Return_true_when_playing_against_player()
        {

        }
        #endregion

        #region PathFinding

        private static object[] Adj =
        {
            new object[] {0,0, new List<(int, int)> {(0, 1), (0, -1), (1, 0), (-1, 0), (-1, 1), (1, -1)}},
            new object[] {1,1, new List<(int, int)> {(1, 2), (1, 0), (2, 1), (0, 1), (0, 2), (2, 0)}},
            new object[] {100,100, new List<(int, int)> {(100, 101), (100, 99), (101, 100), (99, 100), (99, 101), (101, 99)}}
        };

        [TestCaseSource(nameof(Adj))]
        public void Return_6_Adj_Hex(int x, int y,List<(int,int)> l)
        {
            List<(int, int)>  adj = Pathfinding.GetAdj(x, y);
            Assert.AreEqual(l,adj);
        }


        #endregion
    }
}
