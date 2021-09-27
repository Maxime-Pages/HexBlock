using System;
using System.Threading;


namespace HexBlock
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Bienvenue sur le jeu HEX");
            // Console.ReadKey();
            //Board game = new Board(3);
            
            //Console.WriteLine(game.Game(3,false) ? "P1 won" : "P2 won");
            //game.DisplayTemp();
            //Console.ReadKey();
            // Int32.TryParse(s, i)
        
            

            System.Console.WriteLine("Welcome to the HexGame");
            Thread.Sleep(1000); // do a pause between text
            System.Console.WriteLine("Who do you want to play against ? (AI or Player)");
            String choiceOpponent = Console.ReadLine();
            bool error = false;
    
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
            
            // System.Console.WriteLine(choiceOpponent);
            // Console.ReadKey();
            Thread.Sleep(1000);
            System.Console.WriteLine("What about the size of the grid ? (11,13,19)");
            bool success = false;
            int size = 0;

            while(!success)
            {
                string s = Console.ReadLine();
                success = Int32.TryParse(s, out size);
            }

            switch(size)
            {
                case 11 :
                {
                    System.Console.WriteLine("You choose a grid of 11x11");
                    Board game = new Board(size);
                    game.Game(size,false);
                    break;
                }
                case 13 :
                {
                    System.Console.WriteLine("You choose a grid of 13x13");
                    Board game = new Board(size);
                    game.Game(size,false);
                    break;
                }
                case 19 :
                {
                    System.Console.WriteLine("You choose a grid of 19x19");
                    Board game = new Board(size);
                    game.Game(size,false);
                    break;
                }
                default :
                {
                    System.Console.WriteLine("The requested size of the board is wrong, please try again");
                    Console.ReadKey();
                    break;
                }
            }        
        }         

    }
}
