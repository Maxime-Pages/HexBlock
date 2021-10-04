using System;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;

namespace HexBlock
{
    public enum difficulty
    {
        EASY,
        MEDIUM,
        HARD,
        IMPOSSIBLE,
        NULL
    }
    partial class Board
    {
        private int size;
        private Spot[,] grid;
        private bool cturn;

        private int turn;
        private bool solo;
        private difficulty difficulty = difficulty.NULL;


      /*  public bool Game(int size, bool solo = false, difficulty diff = difficulty.NULL)
        {
            if (solo)
            {

            }
            else
            {

            }
        }
        /*
        public (int,int) ChooseSpot()
        {
            bool success = false;
            int x = 0;
            int y = 0;
            while (!success)
            {
                Console.Clear();
                Console.WriteLine("Player " + (this.cturn ? "1" : "2"));
                System.Console.WriteLine("Enter x Coordinates:");
                string s = Console.ReadLine();
                success = Int32.TryParse(s, out x);
                while (!success)
                {
                    System.Console.WriteLine("Pls can you ReEnter x Coordinates not a letter:");
                    string a = Console.ReadLine();
                    success = Int32.TryParse(a, out x);
                }
                while (x >= size)
                {
                    Console.Clear();
                    System.Console.WriteLine("Pls can you ReEnter x Coordinates the maximum is " + (size - 1) + " :");
                    string a = Console.ReadLine();
                    success = Int32.TryParse(a, out x);
                }

            }
            success = false;
            while (!success)
            {
                Console.Clear();
                Console.WriteLine("Player " + (this.cturn ? "1" : "2"));
                System.Console.WriteLine("Enter y Coordinates:");
                string s = Console.ReadLine();
                success = Int32.TryParse(s, out y);
                while (!success)
                {
                    System.Console.WriteLine("Pls can you ReEnter y Coordinates not a letter:");
                    string a = Console.ReadLine();
                    success = Int32.TryParse(a, out y);
                }
                while (y >= size)
                {
                    System.Console.WriteLine("Pls can you ReEnter y Coordinates the maximum is " + (size - 1) + " :");
                    string a = Console.ReadLine();
                    success = Int32.TryParse(a, out y);
                }
            }
            return (x, y);
        }

        private bool Haswon(bool player)
        {
            return Pathfinding.pathfind(player, this.grid);
        }
        private bool Legal((int, int) cor)
        {
            return cor.Item1 < this.size &&
                cor.Item1 >= 0 &&
                cor.Item2 < this.size &&
                cor.Item2 >= 0 &&
                this.grid[cor.Item1, cor.Item2].IsEmpty();
        }

        public bool ColorSpot((int, int) cor,bool player)
        {
            if (Legal(cor))
            {
                grid[cor.Item1,cor.Item2].Color(player);
                return true;
            }

            return false;
        }
      */
        public Board(int size, bool solo = false,difficulty diff = difficulty.NULL)
        {
            if (!VerrifySize(size))
                throw new Exception("Invalid Size");
            this.size = size;
            this.grid = new Spot[size, size];
            this.cturn = true;
            this.turn = 0;
            this.solo = solo;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    grid[i,j] = new Spot(i,j);                    
                }
            }
        } 
        public int GetSize()
        {
            return size;
        }
        
        public bool VerrifySize(int size)
        {
            switch (size)
            {
                case 11:
                case 13:
                case 19:
                { 
                    return true;
                }
                default :
                {
                    return false;
                }
            }
        }

        public bool startGame(int size, bool choice, difficulty diff = difficulty.NULL)
        {
            if (choice) // if true == solo | false == player
            {
                return gameSolo(diff);
            }
            else
            {
                return gameMulti();
            }
        }

        public bool gameSolo(difficulty diff = difficulty.NULL)
        {
            
            bool legalspot = false;
            (int, int) chosen = (0, 0);
            while (true)
            {
                if (cturn)
                {
                    while (!legalspot)
                    {
                        chosen = this.ChooseSpot();
                        legalspot = legal(chosen);
                    }
                }
                else
                {
                    switch (diff)
                    {
                        case difficulty.EASY:
                            while (!legalspot)
                            {
                                chosen = AI.RandomAI(this.size);
                                legalspot = legal(chosen);
                            }
                            break;
                        case difficulty.MEDIUM:
                            while (!legalspot)
                            {
                                chosen = AI.RandomAI(this.size);
                                legalspot = legal(chosen);
                            }
                            break;
                        case difficulty.HARD:
                            while (!legalspot)
                            {
                                chosen = AI.RandomAI(this.size);
                                legalspot = legal(chosen);
                            }
                            break;
                        case difficulty.IMPOSSIBLE:
                            while (!legalspot)
                            {
                                chosen = AI.RandomAI(this.size);
                                legalspot = legal(chosen);
                            }
                            break;
                    }
                }
                this.grid[chosen.Item1, chosen.Item2].Color(cturn);
                if (Haswon(cturn))
                {
                    return cturn;
                }
                this.drawBoard();
                legalspot = false;
                cturn = !cturn;
                turn += cturn ? 1 : 0;
                Console.ReadKey(); 
            return true;
        }
            

        public bool gameMulti()
        {
            
            bool legalspot = false;
            (int, int) chosen = (0, 0);
            while (true)
            {
                while (!legalspot)
                {
                    chosen = ChooseSpot();
                    legalspot = legal(chosen);
                }
                this.grid[chosen.Item1, chosen.Item2].Color(cturn);
                if (Haswon(cturn))
                {
                    return cturn;
                }
                this.drawBoard();
                legalspot = false;
                cturn = !cturn;
                turn += cturn ? 1 : 0;
                Console.ReadKey();

            }
            
            return false;
        }

        public bool GetOpponent()
        {
            return solo;
        }

        public difficulty GetDifficulty()
        {
            return difficulty;
        }

        public bool GetCTurn()
        {
            return cturn; // true p1 || false p2
        }

        public int GetGlobalTurn()
        {
            return turn; // return the global turn of the game 
        }

    }
}
