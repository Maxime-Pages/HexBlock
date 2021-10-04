/*using System;
using System.Collections.Generic;
using System.Linq;
namespace HexBlock
{
    class AI
    {
        public static (int, int) RandomAI(int max)
        {
            Random r = new Random();
            return (r.Next() % max, r.Next() % max);
        }

        public static (int, int) NormalAI(Spot[,] grid, int maxRecursion)
        {
            return (0, 0);
        }

        /*private static int Heuristic(Spot[,] grid, bool player)
        {
            int l = grid.GetLength(0);
            List<Spot> lspot = grid.Cast<Spot>().ToList();
            int max = int.MinValue;
            List<Spot> Connected = new List<Spot>();
            List<Spot> Known = new List<Spot>();
            foreach (Spot item in lspot.Where(x => player ? x.isBlue() : x.isRed()))
            {
                if (Known.Contains(item)) continue;
                Connected = new List<Spot>();
                Connected.Add(item);
                Known.Add(item);
            }
            while (Connected.Count != 0)
            {
                Spot current = Connected[0];
                Connected.RemoveAt(0);
                int x = current.getCoo().Item1;
                int y = current.getCoo().Item2;
                if (y < l - 1 & !Known.Contains(grid[x, y + 1]) && (player ? grid[x, y + 1].isBlue() : grid[x, y + 1].isRed()))
                {
                    Connected.Add(grid[x, y + 1]);
                    Known.Add(grid[x, y + 1]);
                }
                // (0,1);
                if (y > 0 && !Known.Contains(grid[x, y - 1]) && (player ? grid[x, y - 1].isBlue() : grid[x, y - 1].isRed()))
                {
                    Connected.Add(grid[x, y - 1]);
                    Known.Add(grid[x, y - 1]);
                }
                // (0,-1):
                if (x < l - 1 && !Known.Contains(grid[x + 1, y]) && (player ? grid[x + 1, y].isBlue() : grid[x + 1, y].isRed()))
                {
                    Connected.Add(grid[x + 1, y]);
                    Known.Add(grid[x + 1, y]);
                }
                // (1,0):
                if (x > 0 && !Known.Contains(grid[x - 1, y]) && (player ? grid[x - 1, y].isBlue() : grid[x - 1, y].isRed()))
                {
                    Connected.Add(grid[x - 1, y]);
                    Known.Add(grid[x - 1, y]);
                }
                // (-1,0):
                if (x > 0 && y < l - 1 && !Known.Contains(grid[x - 1, y + 1]) && (player ? grid[x - 1, y + 1].isBlue() : grid[x - 1, y + 1].isRed()))
                {
                    Connected.Add(grid[x - 1, y + 1]);
                    Known.Add(grid[x - 1, y + 1]);
                }
                // (-1,1):
                if (x < l - 1 && y > 0 && !Known.Contains(grid[x + 1, y - 1]) && (player ? grid[x + 1, y - 1].isBlue() : grid[x + 1, y - 1].isRed()))
                {
                    Connected.Add(grid[x + 1, y - 1]);
                    Known.Add(grid[x + 1, y - 1]);
                }
                // (1,-1):
                if (System.Linq.Enumerable.Any(Connected, x => player ? x.getCoo().Item1 == l - 1 : x.getCoo().Item2 == l - 1))
                {
                    return max;
                }
            }
            return 0;
        }
    }
}*/