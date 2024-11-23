using System.Collections.Generic;
using fsi.hexgrid.Hexes;
using UnityEngine;

namespace fsi.hexgrid.Pathfinding
{
    public static class BreathFirstSearch
    {
        public static bool TryGetPath(HexGrid hexGrid, Hex start, Hex end, out List<Hex> path)
        {
            path = new List<Hex>();
            Dictionary<Hex,Hex> cameFrom = new();
            
            var frontier = new Queue<Hex>();
            frontier.Enqueue(start);

            var reached = new HashSet<Hex> { start };

            while (frontier.Count > 0)
            {
                var current = frontier.Dequeue();
                foreach (var next in hexGrid.GetNeighbors(current))
                {
                    if (!reached.Contains(next) && current.state == Hex.HexState.Walkable) 
                    {
                        frontier.Enqueue(next);
                        reached.Add(next);
                        cameFrom[next] = current;
                    }
                }
            }

            Hex curr = end;
            while (!curr.Equals(start))
            {
                path.Insert(0, curr);
                if (cameFrom.TryGetValue(curr, out var next))
                {
                    curr = next;
                }
                else
                {
                    path = null;
                    Debug.LogWarning("Path not found");
                    return false;
                }
            }

            path.Insert(0, start);
            path.Reverse();
            return path.Count > 0;
        }
    }
}