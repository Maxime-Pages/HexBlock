using System;
using System.Threading;


namespace HexBlock
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.BackgroundColor=ConsoleColor.White;
            System.Console.ForegroundColor=ConsoleColor.Black;
            Console.Clear();
            System.Console.WriteLine("Welcome to the HexGame");
            Thread.Sleep(1000); // do a pause between text
            bool errorOpp = true; // I fixed the boolean on true to be able to enter on the loop
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
                            break;
                        }
                        case "p" :
                        case "player" : 
                        {
                            errorOpp = false;
                            System.Console.WriteLine("You will play against an another Player");
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
            while(errorSize == true)
            {
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
                        errorSize = false;
                        System.Console.WriteLine("You choose a grid of 11x11");
                        Board game = new Board(11);
                        game.Game(11,false);
                        break;
                    }
                    case 13 :
                    {
                        errorSize = false;
                        System.Console.WriteLine("You choose a grid of 13x13");
                        Board game = new Board(size);
                        game.Game(size,false);
                        break;
                    }
                    case 19 :
                    {
                        
                        errorSize = false;
                        System.Console.WriteLine("You choose a grid of 19x19");
                        Board game = new Board(size);
                        game.Game(size,false);
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
        }         

    }
}
