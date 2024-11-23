using System;
using System.Collections.Generic;
using Fsi.HexGrid.Hexes;
using UnityEngine;

namespace Fsi.HexGrid.Pathfinding
{
    public static class BreathFirstSearch<THex, TState>
        where THex : Hex<TState>, new()
        where TState : Enum
    {
        public static bool TryGetPath(HexGrid<THex, TState> hexGrid, THex start, THex end, List<TState> unwalkable, out List<THex> path)
        {
            path = new List<THex>();
            Dictionary<THex,THex> cameFrom = new();
            
            var frontier = new Queue<THex>();
            frontier.Enqueue(start);

            var reached = new HashSet<THex> { start };

            while (frontier.Count > 0)
            {
                var current = frontier.Dequeue();
                foreach (var next in hexGrid.GetNeighbors(current))
                {
                    if (!reached.Contains(next) && !unwalkable.Contains(current.state)) 
                    {
                        frontier.Enqueue(next);
                        reached.Add(next);
                        cameFrom[next] = current;
                    }
                }
            }

            THex curr = end;
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