using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Assert.AreEqual(color, spot.GetColor());
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(200)]
        public void Spot_Return_X(int x)
        {
            Spot spot = new Spot(x, 0);
            Assert.AreEqual(x, spot.GetX());
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(200)]
        public void Spot_Return_y(int y)
        {
            Spot spot = new Spot(0, y);
            Assert.AreEqual(y, spot.GetY());
        }

        [TestCase(0, 0)]
        [TestCase(0, 1)]
        [TestCase(200, 200)]
        public void Spot_Return_Coo(int x, int y)
        {
            Spot spot = new Spot(x, y);
            Assert.AreEqual((x, y), spot.GetCoo());
        }

        #endregion

        #region Board

        [TestCase(11)]
        [TestCase(13)]

        public void Board_is_created_with_inputed_size(int size)
        {
            Board game = new Board(size);
            Assert.AreEqual(size, game.GetSize());
        }

        [TestCase(11)]
        [TestCase(13)]
        public void Board_is_created_with_a_correct_size(int size)
        {
            Board board = new Board(size);
            Assert.AreNotEqual(null, board);
        }

        [TestCase(1)]
        [TestCase(15)]
        [TestCase(-1)]

        public void Board_is_not_created_with_an_incorrect_size(int size)
        {
            Board board = null;
            var exception = Assert.Throws<Exception>(() => new Board(size));
            Assert.AreEqual("Invalid Size", exception.Message);
            Assert.AreEqual(null, board);
        }


        [TestCase(true)]
        [TestCase(false)]
        public void Board_solo_is_set_to_correct_value(bool solo)
        {

            Board board = new Board(11, solo);
            Assert.AreEqual(solo, board.GetOpponent());

        }

        [Test]
        public void difficulty_is_set_to_null_by_default()
        {
            Board board = new Board(11);
            Assert.AreEqual(difficulty.NULL, board.GetDifficulty());
            Assert.IsFalse(board.GetOpponent());
        }

        [TestCase(difficulty.EASY)]
        [TestCase(difficulty.MEDIUM)]
        [TestCase(difficulty.HARD)]
        [TestCase(difficulty.IMPOSSIBLE)]
        public void difficulty_is_set_to_right_value(difficulty diff)
        {
            Board board = new Board(11, true, diff);
            Assert.AreEqual(diff, board.GetDifficulty());
        }

        [Test]
        public void cturn_starts_true()
        {
            Board board = new Board(11);
            Assert.AreEqual(true, board.GetCTurn());
        }

        [Test]
        public void cturn_changes_after_playing()
        {
            Board board = new Board(11);
            board.Play((0, 0));
            Assert.IsFalse(board.GetCTurn());
        }

        [Test]
        public void cturn_changes_after_playing_twice()
        {
            Board board = new Board(11);
            board.Play((0, 0));
            board.Play((0, 1));
            Assert.IsTrue(board.GetCTurn());
        }

        [Test]
        public void Turn_starts_at_0()
        {
            Board board = new Board(11);
            Assert.AreEqual(0, board.GetGlobalTurn());
        }

        [Test]
        public void Turn_doesnt_increas_after_P1()
        {
            Board board = new Board(11);
            board.Play((0, 0));
            Assert.AreEqual(0, board.GetGlobalTurn());
        }

        [Test]
        public void Turn_increases_after_P2()
        {
            Board board = new Board(11);
            board.Play((0, 0));
            board.Play((1, 0));
            Assert.AreEqual(1, board.GetGlobalTurn());
        }

        [Test]
        public void All_Spot_areEmpty()
        {
            Board board = new Board(11);
            //Assert.IsEmpty(board.GetGrid().Cast<Spot>().ToList().Where(x => !x.IsEmpty()));
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (!board.GetGrid()[i, j].IsEmpty())
                        Assert.Fail();
                }
            }

            Assert.Pass();
        }


        [TestCase(0, 0)]
        [TestCase(1, 0)]
        [TestCase(0, 1)]
        public void Place_Valid_Spot(int x, int y)
        {
            Board board = new Board(11);
            Assert.IsTrue(board.Play((x, y)));
            Assert.IsFalse(board.GetGrid()[x, y].IsEmpty());
            Assert.IsTrue(board.GetGrid()[x, y].GetColor());
        }

        [TestCase(0, 100)]
        [TestCase(100, 0)]
        [TestCase(0, -1)]
        public void Place_Invalid_Spot(int x, int y)
        {
            Board board = new Board(11);
            Assert.IsFalse(board.Play((x, y)));
        }

        [TestCase(0, 0)]
        [TestCase(1, 0)]
        [TestCase(0, 1)]
        public void Place_2_Valid_Spot(int x, int y)
        {
            Board board = new Board(11);
            board.Play((10, 10));
            Assert.IsTrue(board.Play((x, y)));
            Assert.IsFalse(board.GetGrid()[x, y].IsEmpty());
            Assert.IsFalse(board.GetGrid()[x, y].GetColor());
        }



        #endregion

        #region PathFinding

        private static object[] Adj =
        {
            new object[] {0, 0, new List<(int, int)> {(0, 1), (0, -1), (1, 0), (-1, 0), (-1, 1), (1, -1)}},
            new object[] {1, 1, new List<(int, int)> {(1, 2), (1, 0), (2, 1), (0, 1), (0, 2), (2, 0)}},
            new object[]
                {100, 100, new List<(int, int)> {(100, 101), (100, 99), (101, 100), (99, 100), (99, 101), (101, 99)}}
        };

        [TestCaseSource(nameof(Adj))]
        public void Return_6_Adj_Hex(int x, int y, List<(int, int)> l)
        {
            List<(int, int)> adj = Pathfinding.GetAdj(x, y);
            Assert.AreEqual(l, adj);
        }


        #endregion

        #region Display

        [TestCase(" ")]

        public void Spaces_is_display(string spaces)
        {
            Assert.AreEqual(" ", spaces);
        }

        [TestCase("a")]

        public void Spaces_is_not_display(string spaces)
        {
            Board board = new Board(11);
            Assert.AreNotEqual(" ", spaces);
        }

        [TestCase("-")]
        public void banner_is_display(string barre)
        {
            Board board = new Board(11);
            Assert.AreEqual("-", barre);

        }

        [TestCase("a")]

        public void banner_is_not_display(string barre, int bannerSize)
        {
            Board board = new Board(11);
            Assert.AreNotEqual("-", barre);





        }
        #endregion
    }
}