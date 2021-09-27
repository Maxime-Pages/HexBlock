using System;
using System.Drawing;
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
            string d = "";
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

           
            

            

        }
    private PointF[] HexToPoints(float height, float row, float col)
{
    // Start with the leftmost corner of the upper left hexagon.
    float width = HexWidth(height);
    float y = height / 2;
    float x = 0;

    // Move down the required number of rows.
    y += row * height;

    // If the column is odd, move down half a hex more.
    if (col % 2 == 1) y += height / 2;

    // Move over for the column number.
    x += col * (width * 0.75f);

    // Generate the points.
    return new PointF[]
        {
            new PointF(x, y),
            new PointF(x + width * 0.25f, y - height / 2),
            new PointF(x + width * 0.75f, y - height / 2),
            new PointF(x + width, y),
            new PointF(x + width * 0.75f, y + height / 2),
            new PointF(x + width * 0.25f, y + height / 2),
        };
}
private float HexWidth(float height)
{
    return (float)(4 * (height / 2 / Math.Sqrt(3)));
}
    }
}