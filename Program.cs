﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using HexBlock;
namespace howto_hexagonal_grid
{
    static class Program
    {
        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            AllocConsole();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.Clear();
            ChooseApp();
        }

        static void StartGraphic()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static void StartConsole()
        {


            Console.WriteLine("→ Welcome to the HexGame : console edition");
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
            Board.PlayCursor();
        }
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
                System.Console.WriteLine(
                    "→ Welcome to the menu, before starting we would like to know which application do you want to use ?");
                System.Console.WriteLine("→ Type 'g' for graphical or 'c' for console");
                String choiceApp = Console.ReadLine();

                switch (choiceApp.ToLower())
                {
                    case "g":
                    case "graphical":
                        {
                            errorApp = false;
                            StartGraphic();
                            break;
                        }

                    case "c":
                    case "console":
                        {
                            errorApp = false;
                            Console.Clear();
                            System.Console.WriteLine("→ You choosed the console version");
                            StartConsole();
                            break;
                        }
                    default:
                        {
                            errorApp = true;
                            break;
                        }
                }
            } while (errorApp);
        }

        static int ChooseSize()
        {
            bool errorSize = false;
            bool success;
            int size;
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
                string choiceSize = Console.ReadLine(); // set the choice in a string
                success = Int32.TryParse(choiceSize, out size); // string containing a number

                switch (size)
                {
                    case 11:
                        {
                            errorSize = false;
                            Console.Clear(); // clear the console
                            System.Console.WriteLine("→ You choosed a grid of 11x11");
                            size = 11;
                            break;
                        }
                    case 13:
                        {
                            errorSize = false;
                            Console.Clear(); // clear the console
                            System.Console.WriteLine("→ You choosed a grid of 13x13");
                            size = 13;
                            break;

                        }
                    case 19:
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
            while (true)
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
                            System.Console.Write(
                                "The game will be launched against an AI with a Easy difficulty and a size of board of ");
                            return Difficulty.EASY;
                        }
                    case 2:
                        {
                            errorDiff = false;
                            Console.Clear(); // clear the console
                            System.Console.Write(
                                "The game will be launched against an AI with a Normal difficulty and a size of board of ");
                            return Difficulty.MEDIUM;
                        }
                    case 3:
                        {
                            errorDiff = false;
                            Console.Clear(); // clear the console
                            System.Console.Write(
                                "The game will be launched against an AI with a Hard difficulty and a size of board of ");
                            return Difficulty.HARD;
                        }
                    case 4:
                        {
                            errorDiff = false;
                            Console.Clear(); // clear the console
                            System.Console.Write(
                                "The game will be launched against an AI with a IMPOSSIBLE difficulty and a size of board of ");
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

            while (true)
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

        static bool ChooseMode()
        {
            bool solo = false;
            bool errorMode = false;

            while (true)
            {
                if (errorMode)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    System.Console.WriteLine("→ There was an error, please try again.\n");
                }

                System.Console.ForegroundColor = ConsoleColor.Black;
                System.Console.WriteLine("→ How do you want to play ? (with number or with cursor)");
                System.Console.WriteLine("→ 'Number' or 'Cursor'");
                String choiceMode = Console.ReadLine();

                switch (choiceMode.ToLower())
                {
                    case "n":
                    case "number":
                        {
                            Console.Clear(); // clear the console
                            System.Console.Write("→ You choose to play with coordinates");
                            return true;
                        }

                    case "c":
                    case "cursor":
                        {
                            Console.Clear(); // clear the console
                            System.Console.WriteLine("→ You choose to play with a cursor");
                            Board.PlayCursor();
                            solo = false;
                            errorMode = false;
                            return false;
                        }
                    default:
                        {
                            errorMode = true;
                            break;
                        }
                }
            }
        }
    }
}
