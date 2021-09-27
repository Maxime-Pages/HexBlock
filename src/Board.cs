using System;
namespace HexBlock
{
    class Board
    {
        private int size;
        private Spot[,] grid;

        private bool cturn;

        private bool win;

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
                    this.grid[chosen.Item1,chosen.Item2].Color(true);
                    if(Haswon(true))
                    {
                        return true;
                    }
                    legalspot = false;
                    while (!legalspot)
                    {
                        chosen = ChooseSpot();
                        legalspot = legal(chosen);
                    }
                    this.grid[chosen.Item1,chosen.Item2].Color(false);
                    if(Haswon(false))
                    {
                        return false;
                    }
                    this.DisplayTemp();
                    Console.ReadKey();
                }
            }
        }
        static public (int,int) ChooseSpot()
        {
            System.Console.WriteLine("Enter x Coordinates:");
            int x = int.Parse(System.Console.ReadLine());
            System.Console.WriteLine("Enter y Coordinates:");
            int y = int.Parse(System.Console.ReadLine());
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

        private void DisplayTemp()
        {
            Console.Clear();
            foreach(Spot s in this.grid)
            {
                 Console.WriteLine("les coordonnées du spot sont",s.getCoo());
                 Console.WriteLine("le spot est bleu",s.isBlue());
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
                 Console.WriteLine("les coordonnées du spot sont",s.getCoo());
                 Console.WriteLine("le spot est bleu",s.isBlue());
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
            this.grid = new Spot[size+2,size+2];
            this.cturn = true;
            this.win = false;
            for(int i = 0;i<=size+1;i++)
            {
                for(int j = 0;j<=size+1;j++)
                {
                    grid[i,j] = new Spot(i,j);
                    if (j==0 || j == size+1)
                    {
                        grid[i,j].Color(true);
                    }
                    
                }
                grid[i,0].Color(false);
                grid[i,size+1].Color(false);
            }

            // switch (a,b)
            // {
            //     case (0,1):
            //     case (0,-1):
            //     case (1,0):
            //     case (-1,0):
            //     case (-1,1):
            //     case (1,-1):
            //         adj = true;
            //     default:
            //         adj = false;
            // }
            

            

        }

    }
}