using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using NUnit.Framework.Constraints;

namespace HexBlock
{
    class Program
    {
        static void Main(string[] args)
        {
                      
            Console.BackgroundColor = ConsoleColor.White;
            System.Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            ChooseApp();
            
            
            Console.Clear();
            System.Console.WriteLine("→ Welcome to the HexGame : console edition");
            int size = ChooseSize();

            bool solo = ChooseOpponnent();

            Difficulty diff = Difficulty.NULL;
            if (solo)
            {
                diff = ChooseDifficulty();
                Console.Write($"{size}\n");
            }
            System.Console.WriteLine("Press any key to continue ");
            Console.ReadLine();
            Board.StartGame(size,solo,diff); 
            

            

        static void ChooseApp()
        {
             bool errorApp = false;
            do
            {
                if (errorApp)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    System.Console.WriteLine("→ There was an error, please try again.\n");
                }
                System.Console.ForegroundColor = ConsoleColor.Black;
                System.Console.WriteLine("→ Welcome to the menu, before starting we would like to know which application do you want to use ?");
                System.Console.WriteLine("→ Type 'g' for graphical or 'c' for console");
                String choiceApp = Console.ReadLine();

                switch (choiceApp.ToLower())
                {
                    case "g":
                    case "graphical":
                    {
                        errorApp = false;
                        System.Diagnostics.Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe"); // actually this open chrome but in the future this will open the application
                        System.Console.WriteLine("→ Game is starting... ");
                        System.Environment.Exit(1); // console shutdown
                        break;
                   }

                    case "c":
                    case "console":
                    {
                        errorApp = false;
                        Console.Clear();
                        System.Console.WriteLine("→ You choosed the console version");
                        break;
                    }
                    default:
                    {
                        errorApp = true;
                        break;
                    }
                }
            } 
            while (errorApp);
        }

        static int ChooseSize()
        {
            bool errorSize = false;
            bool success;
            int size = 0;
            do
            {
                if (errorSize)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    System.Console.WriteLine("→ There was an error, please try again.\n");
                }
                
                System.Console.ForegroundColor = ConsoleColor.Black;
                System.Console.WriteLine("→ What about the size of the grid ? (11,13,19)");
                string choiceSize = Console.ReadLine();// set the choice in a string
                success = Int32.TryParse(choiceSize, out size); // string containing a number

                switch (size)
                {
                    case 11 :
                    {
                        errorSize = false;
                        Console.Clear(); // clear the console
                        System.Console.WriteLine("→ You choosed a grid of 11x11");
                        size = 11;
                        break;
                    }
                    case 13 :
                    {
                        errorSize = false;
                        Console.Clear(); // clear the console
                        System.Console.WriteLine("→ You choosed a grid of 13x13");
                        size = 13;
                        break;

                            }
                    case 19 :
                    {
                        errorSize = false;
                        Console.Clear(); // clear the console
                        System.Console.WriteLine("→ You choosed a grid of 19x19");
                        size = 19;
                        break;

                            }
                    default:
                    {
                        errorSize = true;
                        break;
                    }
                }
            } while (errorSize);
            return size;
        }

        static Difficulty ChooseDifficulty()
        {
            bool errorOpp = false;
            bool errorDiff = false;
            while(true)
            {
                
                if (errorDiff)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    System.Console.WriteLine("→ There was an error, please try again.\n");
                }

                Console.Clear(); // clear the console
                System.Console.WriteLine("→ Which difficulty do you want ? (1 for Easy to 4 IMPOSSIBLE)");
                int diff;
                string choiceDiff = Console.ReadLine();
                bool successDiff = Int32.TryParse(choiceDiff, out diff); // string containing a number


                switch (diff)
                {
                    case 1:
                        {
                            errorDiff = false;
                            Console.Clear(); // clear the console
                            System.Console.Write("The game will be launched against an AI with a Easy difficulty and a size of board of ");
                            return Difficulty.EASY;
                        }
                    case 2:
                        {
                            errorDiff = false;
                            Console.Clear(); // clear the console
                            System.Console.Write("The game will be launched against an AI with a Normal difficulty and a size of board of ");
                            return Difficulty.MEDIUM;
                        }
                    case 3:
                        {
                            errorDiff = false;
                            Console.Clear(); // clear the console
                            System.Console.Write("The game will be launched against an AI with a Hard difficulty and a size of board of ");
                            return Difficulty.HARD;
                        }
                    case 4:
                        {
                            errorDiff = false;
                            Console.Clear(); // clear the console
                            System.Console.Write("The game will be launched against an AI with a IMPOSSIBLE difficulty and a size of board of ");
                            return Difficulty.IMPOSSIBLE;
                        }
                    default:
                        {
                            errorDiff = true;
                            break;
                        }
                }
            }
        }
        static bool ChooseOpponnent()
        {
            bool solo = false;
            bool errorOpp = false;

            while(true)
            {
                if (errorOpp)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    System.Console.WriteLine("→ There was an error, please try again.\n");
                }

                System.Console.ForegroundColor = ConsoleColor.Black;
                System.Console.WriteLine("→ Who do you want to play against ? (AI or Player)");
                System.Console.WriteLine("→ 'AI' or 'Player'");
                String choiceOpp = Console.ReadLine();

                switch (choiceOpp.ToLower())
                {
                    case "a":
                    case "ai":
                    {
                        Console.Clear(); // clear the console
                        System.Console.Write("→ You choose to play against an AI");
                        return true;
                    }

                    case "p":
                    case "player":
                    {
                        Console.Clear(); // clear the console
                        System.Console.WriteLine("→ You choose to play against an another player");
                        solo = false;
                        errorOpp = false;
                        return false;
                    }
                    default:
                    {
                        errorOpp = true;
                        break;
                    }
                }
            }
        }
        }
    }
}
            // Board.StartGame(11, true,Difficulty.EASY);
            /**
            
            if (args.Length != 0 && args[0] == "DEBUG")
            {
                Board board = new Board(5);
                board.Game(5);
                return;
            }

            bool errorChoiceApp = true; // true is a correct choice and false is an error
            System.Console.WriteLine("Welcome to the menu, before starting we would like to know");

            while (errorChoiceApp)
            {
                System.Console.WriteLine("Which application do you prefer ? (G for Graphical and C for Console)");
                String choiceApplication = Console.ReadLine();
                switch (choiceApplication.ToLower())
                {
                    case "g":
                    case "graphical":
                        {
                            errorChoiceApp = false;
                            System.Diagnostics.Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe"); // actually this open chrome but in the future this will open the application
                            System.Console.WriteLine("Game is starting... ");
                            Thread.Sleep(2000);
                            System.Environment.Exit(1); // console shutdown
                            break;
                        }
                    case "c":
                    case "console":
                        {
                            errorChoiceApp = false;
                            System.Console.WriteLine("You choosed the console game");
                            Thread.Sleep(2000);
                            break;
                        }
                    default:
                        {
                            errorChoiceApp = true;
                            Console.Clear();
                            System.Console.WriteLine("You didn't choose a valid choice, please try again");
                            break;
                        }
                }
            }

            Console.Clear();
            System.Console.WriteLine("Welcome to the HexGame : console edition");
            Thread.Sleep(1000); // do a pause between text
            bool errorOpp = true; // I fixed the boolean on true to be able to enter on the loop
            bool opponnent = false; // True for an AI, False for a player
            while (errorOpp == true) // verify if the opponent entered is valid
            {
                System.Console.WriteLine("Who do you want to play against ? (AI or Player)");
                String choiceOpponent = Console.ReadLine();
                switch (choiceOpponent.ToLower())
                {
                    case "a":
                    case "ai":
                    {
                            
                            errorOpp = false;
                            Console.Clear(); // clear the console
                            System.Console.WriteLine("You will play with an AI");
                            opponnent = true; // true = play against AI
                            break;
                        }
                    case "p":
                    case "player":
                        {
                            errorOpp = false;
                            Console.Clear(); // clear the console
                            System.Console.WriteLine("You will play against an another Player");
                            opponnent = false; // false = play against an another player
                            break;
                        }
                    default:
                        {
                            errorOpp = true;
                            Console.Clear();
                            System.Console.WriteLine("You didn't choose an (valid) opponent, please try again");
                            break;
                        }
                }
            }
            Thread.Sleep(2000);
            Console.Clear(); // clear the console
            bool errorSize = true;
            int size = 0;
            while (errorSize)
            {
                System.Console.WriteLine("What about the size of the grid ? (11,13,19)");
                bool success = false;
                while (!success)
                {
                    string s = Console.ReadLine(); // set the choice in a string
                    success = Int32.TryParse(s, out size); // string containing a number
                    while (!success)
                    {
                        Console.Clear();
                        System.Console.WriteLine("What about the size of the grid ? (11,13,19) please not a letter");
                        string a = Console.ReadLine(); // set the choice in a string
                        success = Int32.TryParse(a, out size);
                    }
                }
                switch (size)
                {
                    case 11:
                        {
                            errorSize = false; // no error
                            Console.Clear(); // clear the console
                            System.Console.WriteLine("You choose a grid of 11x11");
                            break;
                        }
                    case 13:
                        {
                            errorSize = false; // no error
                            Console.Clear(); // clear the console
                            System.Console.WriteLine("You choose a grid of 13x13");
                            break;
                        }
                    case 19:
                        {
                            errorSize = false; // no error
                            Console.Clear(); // clear the console
                            System.Console.WriteLine("You choose a grid of 19x19");
                            break;
                        }
                    default:
                        {
                            errorSize = true; // the size isn't correct
                            Console.Clear(); // clear the console
                            System.Console.WriteLine("The requested size of the board is wrong, please try again");
                            break;
                        }
                }
            }
            if (opponnent) // opponnent true = AI || false = player
            {
                int difficultyAI = 1;
                Thread.Sleep(2000); // set a pause
                Console.Clear(); // clear the console
                System.Console.WriteLine("Wich difficulty do you want ? (1 for Easy to 4 IMPOSSIBLE)");
                bool successAI = false;
                while (!successAI)
                {
                    string choiceDiff = Console.ReadLine(); // set the choice of the difficulty in a string
                    successAI = Int32.TryParse(choiceDiff, out difficultyAI); // string containing a number
                }
                switch (difficultyAI)
                {
                    case 1:
                        {
                            Console.Clear(); // clear the console
                            System.Console.WriteLine("The game will be launched against an AI with a Easy difficulty and a size of board of " + size);
                            Thread.Sleep(1000); // set a pause
                            System.Console.WriteLine("Press any key to continue ");
                            Console.ReadLine();
                            Board game = new Board(size); // create a new board with the choosed size
                            game.Game(size, true, difficulty.EASY);
                            break;
                        }
                    case 2:
                        {
                            Console.Clear(); // clear the console
                            System.Console.WriteLine("The game will be launched against an AI with a Medium difficulty and a size of board of " + size);
                            Thread.Sleep(1000); // set a pause
                            System.Console.WriteLine("Press any key to continue ");
                            Console.ReadLine();
                            Board game = new Board(size); // create a new board with the choosed size
                            game.Game(size, true, difficulty.MEDIUM);
                            break;
                        }
                    case 3:
                        {
                            Console.Clear(); // clear the console
                            System.Console.WriteLine("The game will be launched against an AI with a HARD difficulty and a size of board of " + size);
                            Thread.Sleep(1000); // set a pause
                            System.Console.WriteLine("Press any key to continue ");
                            Console.ReadLine();
                            Board game = new Board(size); // create a new board with the choosed size
                            game.Game(size, true, difficulty.HARD);
                            break;
                        }
                    case 4:
                        {
                            Console.Clear(); // clear the console
                            System.Console.WriteLine("The game will be launched against an AI with a IMPOSSIBLE difficulty and a size of board of " + size);
                            Thread.Sleep(1000); // set a pause
                            System.Console.WriteLine("Press any key to continue");
                            Console.ReadLine();
                            Board game = new Board(size); // create a new board with the choosed size
                            game.Game(size, true, difficulty.IMPOSSIBLE);
                            break;
                        }
                }
            }
            else
            {
                Console.Clear(); // clear the console
                System.Console.WriteLine("The game will be launched against a Player and a size of board of " + size);
                Thread.Sleep(1000); // set a pause
                System.Console.WriteLine("Press any key to continue ");
                Console.ReadLine();
                Board game = new Board(size); // create a new board with the choosed size
                game.Game(size, false);
            }*/

