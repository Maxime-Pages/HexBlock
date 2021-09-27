using System.Collections.Generic;
namespace HexBlock
{
    class Pathfinding
    {
        public static bool pathfind(bool player,Spot[,] grid)
        {
            List<Spot> Connected = new List<Spot>();
            List<Spot> Known = new List<Spot>();
            for (int i = 0; i < grid.GetLength(1); i++)
            {
                if( player ? grid[0,i].isBlue() : grid[i,0].isRed())
                {
                    Connected.Add(player ? grid[0,i] : grid[i,0]);
                }
            }
            Known.AddRange(Connected);
            while (Connected.Count != 0)
            {
                Spot current = Connected[0];
                Connected.RemoveAt(0);
                int x = current.getCoo().Item1;
                int y = current.getCoo().Item2;
                if(x == grid.GetLength(0))
                {
                    
                }
                if (!Known.Contains(grid[x,y+1]) && player ? grid[x,y+1].isBlue() : grid[x,y+1].isRed() )
                {
                    Connected.Add(grid[x,y+1]);
                    Known.Add(grid[x,y+1]);
                }
                // (0,1);
                if (!Known.Contains(grid[x,y-1]) &&player ? grid[x,y-1].isBlue() : grid[x,y-1].isRed())
                {
                    Connected.Add(grid[x,y-1]);
                    Known.Add(grid[x,y-1]);
                }
                // (0,-1):
                if (!Known.Contains(grid[x+1,y]) &&player ? grid[x+1,y].isBlue() : grid[x+1,y].isRed())
                {
                    Connected.Add(grid[x+1,y]);
                    Known.Add(grid[x+1,y]);
                }
                // (1,0):
                if (!Known.Contains(grid[x-1,y]) &&player ? grid[x-1,y].isBlue() : grid[x-1,y].isRed())
                {
                    Connected.Add(grid[x-1,y]);
                    Known.Add(grid[x-1,y]);
                }
                // (-1,0):
                if (!Known.Contains(grid[x-1,y+1]) &&player ? grid[x-1,y+1].isBlue() : grid[x-1,y+1].isRed())
                {
                    Connected.Add(grid[x-1,y+1]);
                    Known.Add(grid[x-1,y+1]);
                }
                // (-1,1):
                if (!Known.Contains(grid[x+1,y-1]) &&player ? grid[x+1,y-1].isBlue() : grid[x+1,y-1].isRed())
                {
                    Connected.Add(grid[x+1,y-1]);
                    Known.Add(grid[x+1,y-1]);
                }
                // (1,-1):
                if(System.Linq.Enumerable.Any(Connected,x => player ? x.getCoo().Item1==grid.GetLength(0) : x.getCoo().Item2==grid.GetLength(0) ))
                {
                    return true;
                }
            }
            return false;

        }
    }
}