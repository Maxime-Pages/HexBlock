using System;

namespace HexBlock
{
    class Program
    {
        static void Main(string[] args)
        {
           Board game = new Board(3);
        game.Game(3,false);
        }
    }
}
