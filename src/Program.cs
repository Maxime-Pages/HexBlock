using System;
using System.Threading;

namespace HexBlock
{
    class Program
    {
        static void Main(string[] args)
        {
            // Board game = new Board(3);
            // game.Game(3,false);

            System.Console.WriteLine("Welcome to the HexGame");
            Thread.Sleep(1500); // do a pause between text
            System.Console.WriteLine("Who do you want to play against ? (AI or Player)");
            String choiceOpponent = Console.ReadLine();
            switch (choiceOpponent)
            {
                case "A" :
                case "a" :  
                case "AI" : 
                {
                     System.Console.WriteLine("You will play with an AI");
                     break;
                }
                case "P" :
                case "p" :
                case "Player" : 
                {
                    System.Console.WriteLine("You will play against an another Player");
                    break;
                }

                default :
                {
                    System.Console.WriteLine("You didn't choose an opponent, please try again");
                    break;
                }
            }
            System.Console.WriteLine(choiceOpponent);
            Console.ReadKey();
        }
    }
}
