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
            else
            {
                Console.Write($"{size}\n");
            }
            System.Console.WriteLine("→ Press any key to continue..");
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
                    Console.WriteLine("→ There was an error, please try again.\n");
                }
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("→ Welcome to the menu, before starting we would like to know which application do you want to use ?");
                Console.WriteLine("→ Type 'g' for graphical or 'c' for console");
                String choiceApp = Console.ReadLine();

                switch (choiceApp.ToLower())
                {
                    case "g":
                    case "graphical":
                    
                        errorApp = false;
                        System.Diagnostics.Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe"); // actually this open chrome but in the future this will open the application
                        Console.WriteLine("→ Game is starting... ");
                        Environment.Exit(1); // console shutdown
                        return;
                    

                    case "c":
                    case "console":

                        errorApp = false;
                        Console.Clear();
                        Console.WriteLine("→ You choosed the console version");
                        break;
                    
                    default:

                        errorApp = true;
                        break;
                }
            } 
            while (errorApp);
        }
        
        static int ChooseSize()
        {
            bool errorSize = false;
            while (true)
            {    
                if (errorSize)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("→ There was an error, please try again.\n");
                }
                
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("→ What about the size of the grid ? (11,13,19)");
                string choiceSize = Console.ReadLine();// set the choice in a string
                int.TryParse(choiceSize, out int size); // string containing a number

                switch (size)
                {
                    case 11 :
                    
                        errorSize = false;
                        Console.Clear(); // clear the console
                        Console.WriteLine("→ You choosed a grid of 11x11");
                        return size;
                            
                    case 13 :
                    
                        errorSize = false;
                        Console.Clear(); // clear the console
                        Console.WriteLine("→ You choosed a grid of 13x13");
                        return size;

                    case 19 :
                    
                        errorSize = false;
                        Console.Clear(); // clear the console
                        Console.WriteLine("→ You choosed a grid of 19x19");
                        return size;

                            
                    default:
                    
                        errorSize = true;
                        break;
                    
                }
            }
            
        }

        static Difficulty ChooseDifficulty()
        {
            bool errorDiff = false;
            while(true)
            {
                
                if (errorDiff)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("→ There was an error, please try again.\n");
                }

                Console.Clear(); // clear the console
                Console.WriteLine("→ Which difficulty do you want ? (1 for Easy to 4 IMPOSSIBLE)");
                string choiceDiff = Console.ReadLine();
                int.TryParse(choiceDiff, out int diff); // string containing a number


                switch (diff)
                {
                    case 1:
                        
                            errorDiff = false;
                            Console.Clear(); // clear the console
                            Console.Write("→ The game will be launched against an AI with a Easy difficulty and a size of board of ");
                            return Difficulty.EASY;
                        
                    case 2:
                        
                            errorDiff = false;
                            Console.Clear(); // clear the console
                            Console.Write("→ The game will be launched against an AI with a Normal difficulty and a size of board of ");
                            return Difficulty.MEDIUM;
                        
                    case 3:
                        
                            errorDiff = false;
                            Console.Clear(); // clear the console
                            Console.Write("→ The game will be launched against an AI with a Hard difficulty and a size of board of ");
                            return Difficulty.HARD;
                        
                    case 4:
                        
                            errorDiff = false;
                            Console.Clear(); // clear the console
                            Console.Write("→ The game will be launched against an AI with a IMPOSSIBLE difficulty and a size of board of ");
                            return Difficulty.IMPOSSIBLE;
                        
                    default:
                            errorDiff = true;
                            break;
                }
            }
        }
        static bool ChooseOpponnent()
        {
            bool errorOpp = false;

            while(true)
            {
                if (errorOpp)   
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("→ There was an error, please try again.\n");
                }

                Console.Clear(); // clear the console
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("→ Who do you want to play against ? (AI or Player)");
                Console.WriteLine("→ 'AI' or 'Player'");
                String choiceOpp = Console.ReadLine();

                switch (choiceOpp.ToLower())
                {
                    case "a":
                    case "ai":
                    {
                        Console.Clear(); // clear the console
                        Console.Write("→ You choose to play against an AI");
                        errorOpp = false;
                        return true;
                    }

                    case "p":
                    case "player":
                    {
                        Console.Clear(); // clear the console
                        Console.WriteLine("→ You choose to play against an another player");
                        Console.Write("→ The game will be launched against a player and a size of board of ");
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

