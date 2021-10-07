using System;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;

namespace HexBlock
{
    public enum Difficulty
    {
        EASY,
        MEDIUM,
        HARD,
        IMPOSSIBLE,
        NULL
    }
    partial class Board
    {
        #region Attributes

        


        private int size;
        private Spot[,] grid;
        private bool cturn;

        private int turn;
        private bool solo;
        private Difficulty difficulty = Difficulty.NULL;
        #endregion
        #region Getters
        public int GetSize()
        {
            return size;
        }

        public bool GetSolo()
        {
            return solo;
        }

        public Difficulty GetDifficulty()
        {
            return difficulty;
        }

        public bool GetCTurn()
        {
            return cturn; // true p1 || false p2
        }

        public int GetTurn()
        {
            return turn; // return the global turn of the game 
        }

        public Spot[,] GetGrid()
        {
            return grid;
        }
        #endregion
        
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
        */
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
        public Board(int size, bool solo = false,Difficulty diff = Difficulty.NULL)
        {
            if (!VerrifySize(size))
                throw new Exception("Invalid Size");
            this.size = size;
            this.grid = new Spot[size, size];
            this.cturn = true;
            this.turn = 1;
            this.solo = solo;
            this.difficulty = diff;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    grid[i,j] = new Spot(i,j);                    
                }
            }
        } 
        
        public bool VerrifySize(int size)
        {
            switch (size)
            {
                case 11:
                case 13:
                case 19:
                case 3:
                { 
                    return true;
                }
                default :
                {
                    return false;
                }
            }
        }
        public static bool StartGame(int size, bool solo, Difficulty difficulty = Difficulty.NULL)
        {
            if (solo) // if true == solo | false == player
            {
                Board board = new Board(size, solo, difficulty);
                board.Board_display();
                return board.GameSolo();
            }
            else
            {
                Board board = new Board(size);
                board.Board_display();
                return board.GameMulti();
            }
        }

        public bool GameSolo()
        {
            while (true)
            {
                if (cturn)
                {
                    (int, int) chosen;
                    do
                    {
                        chosen = InputCoo();
                    } while (!Play(chosen));
                }
                else
                {
                    AIPlay();
                }
                if (Haswon(cturn))
                {
                    return cturn;
                }

                this.Board_display();
                Console.ReadKey();
            }
        }

        private (int, int) InputCoo()
        {
            try
            {
                string[] strings = Console.ReadLine().Split(',');
                if (Int32.TryParse(strings[0], out int x) && Int32.TryParse(strings[1], out int y))
                {
                    return (x, y);
                }
                return (-1, -1);
            }
            catch (Exception e)
            {
                return (-1, -1);
            }
        }


        public bool GameMulti()
        {
            
            while (true)
            {
                (int, int) chosen;
                do
                {
                    chosen = InputCoo();
                } while (Play(chosen));
                if (Haswon(cturn))
                {
                    return cturn;
                }

                this.Board_display();
                Console.ReadKey();

            }
        }
        public bool Play((int, int) coo)
        {
            if (!ColorSpot(coo, cturn))
                return false;
            cturn = !cturn;
            if (cturn)
                turn++;
            return true;
        }

        public void AIPlay()
        {
            if (difficulty == Difficulty.EASY)
            {
                (int, int) chosen;
                do
                {
                    chosen = AI.RandomAI(size);
                } while (!Play(chosen));
            }
            else
            {
                Play(AI.GenerateAIMove(grid, difficulty));
            }
        }
    }
}
