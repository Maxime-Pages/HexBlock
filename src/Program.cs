using System;

namespace HexBlock
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Bienvenue sur le jeu HEX");
            Console.ReadKey();
            Board game = new Board(11);
            game.Game(11,false);
        }
    }
}
