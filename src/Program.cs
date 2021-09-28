using System;
using System.Threading;


namespace HexBlock
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Welcome to the HexGame");
            Thread.Sleep(1000); // do a pause between text
            bool errorOpp = true; // I fixed the boolean on true to be able to enter on the loop
            bool opponnent = false ; // True for an AI, False for a player
            while(errorOpp == true) // verify if the opponent entered is valid
            {
                System.Console.WriteLine("Who do you want to play against ? (AI or Player)");
                String choiceOpponent = Console.ReadLine(); 
                switch (choiceOpponent.ToLower())
                    {
                        case "a" :  
                        case "ai" : 
                        {
                            errorOpp = false;
                            System.Console.WriteLine("You will play with an AI");
                            opponnent = true;
                            break;
                        }
                        case "p" :
                        case "player" : 
                        {
                            errorOpp = false;
                            System.Console.WriteLine("You will play against an another Player");
                            opponnent = false;
                            break;
                        }

                        default :
                        {
                            errorOpp = true;
                            Console.Clear();
                            System.Console.WriteLine("You didn't choose an (valid) opponent, please try again");
                            break;
                        }
                    }
            }
            Thread.Sleep(1000);
            bool errorSize = true;
            int size = 0;
            while(errorSize)
            {
                System.Console.WriteLine("What about the size of the grid ? (11,13,19)");
                bool success = false;
                while(!success)
                {
                    string s = Console.ReadLine();
                    success = Int32.TryParse(s, out size);
                }
                switch(size)
                {
                    case 11 :
                    {
                        errorSize = false;

                        System.Console.WriteLine("You choose a grid of 11x11");
                        break;
                    }
                    case 13 :
                    {
                        errorSize = false;
                        System.Console.WriteLine("You choose a grid of 13x13");
                        break;
                    }
                    case 19 :
                    {
                        errorSize = false;
                        System.Console.WriteLine("You choose a grid of 19x19");
                        break;
                    }
                    default :
                    {
                        errorSize = true;
                        Console.Clear();
                        System.Console.WriteLine("The requested size of the board is wrong, please try again");
                        break;
                    }
                }     
            }
                if(opponnent)
                {
                    Console.Clear();
                    System.Console.WriteLine("The game will be launched against an AI and a size of board of "+size);
                    Thread.Sleep(1000);
                    System.Console.WriteLine("Press any key to continue ");
                    Console.ReadLine(); 
                    Board game = new Board(size);
                    game.Game(size,false);
                }
                else
                {
                    Console.Clear();
                    System.Console.WriteLine("The game will be launched against a Player and a size of board of "+size);
                    Thread.Sleep(1000);
                    System.Console.WriteLine("Press any key to continue ");
                    Console.ReadLine(); 
                    Board game = new Board(size);
                    game.Game(size,false);
                }
        }         
    }
}
