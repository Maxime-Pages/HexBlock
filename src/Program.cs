using System;
using System.Windows;

namespace HexBlock
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue sur le jeu HEX");
            // Console.ReadKey();
            Board game = new Board(3);
            
            Console.WriteLine(game.Game(3,false) ? "P1 won" : "P2 won");
            game.DisplayTemp();
            Console.ReadKey();
            // Int32.TryParse(s, i)
        }
    }
}
