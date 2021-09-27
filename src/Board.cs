using System;
namespace HexBlock
{
    class Board
    {
        private int size;
        private Spot[,] grid;

        private bool cturn;
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
                    this.DisplayTemp();
                    legalspot = false;
                    cturn = !cturn;
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
            this.grid = new Spot[size,size];
            this.cturn = true;
            for(int i = 0;i<size;i++)
            {
                for(int j = 0;j<size;j++)
                {
                    grid[i,j] = new Spot(i,j);                    
                }
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