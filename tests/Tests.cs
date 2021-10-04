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
        /*
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
*/
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


        [TestCase(11,true)]
        public void Should_Return_true_when_playing_against_ai(int size, bool choice)
        {

            Board board = new Board(size);
            Assert.IsTrue(board.startGame(size, choice));
            
        }

        [TestCase(11, false)]
        public void Should_Return_true_when_playing_against_player(int size, bool choice)
        {
            Board board = new Board(size);
            Assert.IsFalse(board.startGame(size, choice));
        }

        [TestCase(true,difficulty.NULL)]
        public void Should_expected_same_difficulty(bool choice, difficulty diff)
        {
            Board board = new Board(11);

            Assert.AreEqual(diff,board.GetDifficulty());
        }

        [TestCase(true)]
        public void Should_return_current_turn(bool cturn)
        {
            Board board = new Board(11);
            //cturn = false;
            Assert.AreEqual(cturn,board.GetCTurn());
        }
        
        #endregion
        #region PathFinding



        #endregion
    }
}
