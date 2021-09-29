using System.Collections.Generic;
namespace HexBlock
{
    class Pathfinding
    {
        public static bool pathfind(bool player,Spot[,] grid)
        {
            // return false;
            int l = grid.GetLength(0);
            List<Spot> Connected = new List<Spot>();
            List<Spot> Known = new List<Spot>();
            for (int i = 0; i < l; i++)
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
                if (y < l-1 && !Known.Contains(grid[x,y+1]) && (player ? grid[x,y+1].isBlue() : grid[x,y+1].isRed() ))
                {
                    Connected.Add(grid[x,y+1]);
                    Known.Add(grid[x,y+1]);
                }
                // (0,1);
                if (y > 0 && !Known.Contains(grid[x,y-1]) &&(player ? grid[x,y-1].isBlue() : grid[x,y-1].isRed()))
                {
                    Connected.Add(grid[x,y-1]);
                    Known.Add(grid[x,y-1]);
                }
                // (0,-1):
                if (x < l-1 && !Known.Contains(grid[x+1,y]) &&(player ? grid[x+1,y].isBlue() : grid[x+1,y].isRed()))
                {
                    Connected.Add(grid[x+1,y]);
                    Known.Add(grid[x+1,y]);
                }
                // (1,0):
                if (x > 0 && !Known.Contains(grid[x-1,y]) &&(player ? grid[x-1,y].isBlue() : grid[x-1,y].isRed()))
                {
                    Connected.Add(grid[x-1,y]);
                    Known.Add(grid[x-1,y]);
                }
                // (-1,0):
                if (x > 0 && y < l-1 && !Known.Contains(grid[x-1,y+1]) &&(player ? grid[x-1,y+1].isBlue() : grid[x-1,y+1].isRed()))
                {
                    Connected.Add(grid[x-1,y+1]);
                    Known.Add(grid[x-1,y+1]);
                }
                // (-1,1):
                if (x < l-1 && y > 0 && !Known.Contains(grid[x+1,y-1]) &&(player ? grid[x+1,y-1].isBlue() : grid[x+1,y-1].isRed()))
                {
                    Connected.Add(grid[x+1,y-1]);
                    Known.Add(grid[x+1,y-1]);
                }
                // (1,-1):
                if(System.Linq.Enumerable.Any(Connected,x => player ? x.getCoo().Item1== l-1 : x.getCoo().Item2== l-1 ))
                {
                    return true;
                }
            }
            return false;
            
        }
    }
}