namespace HexBlock
{
    class Grid
    {
        private int size;
        private Spot[][] grid;

        private bool cturn;

        private bool win;

        static public bool Game(int size, bool solo)
        {
            return true;
        }
        
        static private bool Haswon(bool player)
        {
            return true;
        }

        static private bool isadj(Spot a, Spot b)
        {
            return true;
        }

        static private bool legal(Spot s, bool player)
        {
            return true;
        }

        static private bool putSpot(Spot spot, bool player)
        {
            return true;
        }

        static private void Display()
        {
            return;
        }

        public Grid(int size)
        {
            this.size = size;
            this.grid = Spot[size+2][size+2];
            this.cturn = true;
            this.win = false;
            for(int i = 0;i<= size+2;i++)
            {
                for(int j = 0;j<=size+2;j++)
                {
                    grid[i][j] = new Spot();
                    if (j==0 || j == size+2)
                    {
                        grid[i][j].Color(true);
                    }
                }
                grid[i][0].Color(false);
                grid[i][size+2].Color(false);
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