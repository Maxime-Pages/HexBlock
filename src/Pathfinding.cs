using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

namespace HexBlock
{
    class Pathfinding
    {
        public static bool Pathfind(bool player, Spot[,] grid)
        {
            // return false;
            int l = grid.GetLength(0);
            List<(int,int)> Connected = InitList(grid,l,player);
            List<(int, int)> Known = new List<(int, int)>();
            Known.AddRange(Connected);
            while (Connected.Count != 0)
            {
                (int,int) current = Connected[0];
                Connected.RemoveAt(0);
                AddAdj(ref Known, ref Connected, current, l,player, grid);
                if (finished(Known,player,l))
                {
                    return true;
                }
            }
            return false;
        }

        public static List<(int,int)> GetAdj(int x, int y)
        {
            List<(int,int)> adj = new List<(int,int)>();
            adj.Add((x, y + 1));
            adj.Add((x, y - 1));
            adj.Add((x + 1, y));
            adj.Add((x - 1, y));
            adj.Add((x - 1, y + 1));
            adj.Add((x + 1, y - 1));
            return adj;
        }
        
        public static List<(int, int)> PruneColor( List<(int, int)> adj, bool player,Spot[,] grid)
        {
            return new List<(int, int)>(adj.Where(x => (!grid[x.Item1, x.Item2].IsEmpty()
                                                        && grid[x.Item1, x.Item2].GetColor() == player)));
        }

        public static List<(int, int)> PruneOOB(List<(int, int)> adj, int max)
        {
            return new List<(int, int)>(adj.Where(x => x.Item1 < max &&
                                                       x.Item1 > 0 &&
                                                       x.Item2 > 0 &&
                                                       x.Item2 < max));
        }


        public static List<(int, int)> PruneKnown(List<(int,int)> Known,List<(int,int)> adj)
        {
            return new List<(int, int)>(adj.Where(x => !Known.Contains(x)));
        }

        public static void AddAdj(ref List<(int, int)> Known, ref List<(int, int)> Connected, (int,int) current,int max,bool player,Spot[,] grid)
        {
            List<(int, int)> adj = GetAdj(current.Item1,current.Item2);
            adj = PruneOOB(adj, max);
            adj = PruneKnown(Known, adj);
            adj = PruneColor(adj, player, grid);
            Known.AddRange(adj);
            Connected.AddRange(adj);
        }

        public static bool finished(List<(int, int)> Known, bool player, int l)
        {
            return Known.Any(x => player ? x.Item1 == l - 1 : x.Item2 == l - 1);
        }

        public static List<(int, int)> InitList(Spot[,] grid, int l, bool player)
        {
            List<(int, int)> list = new List<(int, int)>();
            for (int i = 0; i < l; i++)
            {
                if (player ? !grid[0,i].IsEmpty() && grid[0, i].GetColor() : !grid[0, i].IsEmpty() && !grid[i, 0].GetColor())
                {
                    list.Add(player ? (0, i) : (i, 0));
                }
            }

            return list;
        }
    }
}