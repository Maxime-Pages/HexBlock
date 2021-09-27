using System;
using System.Drawing;
namespace HexBlock
{
    partial class Board
    {
        private int size;
        private Spot[,] grid;

        private bool cturn;

        private int turn;

        public bool Game(int size, bool solo)
        {
            if (solo)
            {
                return true;
            }
            else
            {
                bool legalspot = false;
                (int,int) chosen = (0,0);
                while (true)
                {
                   while (!legalspot)
                    {
                        chosen = ChooseSpot();
                        legalspot = legal(chosen);
                    }
                    this.grid[chosen.Item1,chosen.Item2].Color(cturn);
                    if(Haswon(cturn))
                    {
                        return cturn;
                    }
                    this.drawBoard();
                    legalspot = false;
                    cturn = !cturn;
                    turn += cturn ? 1 : 0;
                    Console.ReadKey();
                }
            }
        }
        static public (int,int) ChooseSpot()
        {
            bool success = false;
            int x = 0;
            int y = 0;
            while(!success)
            {
                Console.Clear();
                System.Console.WriteLine("Enter x Coordinates:");
                string s = Console.ReadLine();
                success = Int32.TryParse(s, out x);
            }
            success = false;
            while(!success)
            {
                Console.Clear();
                System.Console.WriteLine("Enter y Coordinates:");
                string s = Console.ReadLine();
                success = Int32.TryParse(s, out y);
            }
            return (x,y);
        }
        
        private bool Haswon(bool player)
        {
            return Pathfinding.pathfind(player,this.grid);
        }

        private bool isadj(Spot a, Spot b)
        {
            return true;
        }

        private bool legal((int,int) cor)
        {
            return cor.Item1 < this.size &&
                cor.Item1 >= 0 &&
                cor.Item2 < this.size &&
                cor.Item2 >= 0 &&
                this.grid[cor.Item1,cor.Item2].isEmpty();
        }

        private bool putSpot(Spot spot, bool player)
        {
            return true;
        }

        public void DisplayTemp()
        {
            Console.Clear();
            foreach(Spot s in this.grid)
            {
                // Console.WriteLine(s.getCoo());
                // Console.WriteLine(s.isBlue());

                if (s.getCoo().Item2 == 0)
                {
                    Console.Write("\n");
                }
                Console.Write(s.isEmpty() ? "_" : s.isRed() ? "R" : "B");
            }

        }
        
        private void Display()
        {
            Console.Clear();
            foreach(Spot s in this.grid)
            {
                 Console.WriteLine(s.getCoo());
                 Console.WriteLine(s.isBlue());
                if (s.getCoo().Item2 == 0)
                {
                    Console.Write("\n");
                }
                Console.Write(s.isEmpty() ? "_" : s.isRed() ? "R" : "B");
            }

        }

        public Board(int size)
        {
            this.size = size;
            this.grid = new Spot[size,size];
            this.cturn = true;
            this.turn = 0;
            for(int i = 0;i<size;i++)
            {
                for(int j = 0;j<size;j++)
                {
                    grid[i,j] = new Spot(i,j);                    
                }
            }
        }
    }
}