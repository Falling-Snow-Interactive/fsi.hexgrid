using System;
using System.Collections.Generic;
using Fsi.HexGrid.Hexes;
using UnityEngine;

namespace Fsi.HexGrid
{
    [Serializable]
    public class HexGrid<THex, TState> 
        where THex : Hex<TState>, new()
        where TState : Enum
    {
        public int size;
        public List<THex> hexes;
        
        public void Reset()
        {
            hexes = new List<THex>();
            for(int q = -size + 1; q < size; q++)
                for (int r = -size + 1; r < size; r++)
                {
                    if (Mathf.Abs(q) >= size 
                        || Mathf.Abs(r) >= size 
                        || Mathf.Abs(-q - r) >= size)
                    {
                        continue;
                    }
                    
                    THex hex = new THex
                               {
                                   coordinates =
                                   {
                                       q = q,
                                       r = r,
                                   }
                               };
                    hexes.Add(hex);
                }
        }

        public void Refresh()
        {
            List<THex> refreshed = new();
            
            for(int q = -size + 1; q < size; q++)
                for (int r = -size + 1; r < size; r++)
                {
                    if (Mathf.Abs(q) >= size 
                        || Mathf.Abs(r) >= size 
                        || Mathf.Abs(-q - r) >= size)
                    {
                        continue;
                    }

                    if (!TryGetHex(q, r, out THex hex))
                    {
                        hex = new THex
                                  {
                                      coordinates =
                                      {
                                          q = q,
                                          r = r,
                                      }
                                  };
                    }
                    
                    refreshed.Add(hex);
                }
            
            hexes = refreshed;
        }

        public bool TryGetHex(int q, int r, out THex hex)
        {
            foreach (THex h in hexes)
            {
                if (h.coordinates.q == q && h.coordinates.r == r)
                {
                    hex = h;
                    return true;
                }
            }

            hex = null;
            return false;
        }

        public bool TryGetHex(AngleCoordinates coordinates, out THex hex)
        {
            return TryGetHex(coordinates.q, coordinates.r, out hex);
        }

        public List<THex> GetNeighbors(THex hex)
        {
            List<THex> neighbors = new();

            foreach (AngleCoordinates direction in HexGridUtility.Directions)
            {
                AngleCoordinates n = hex.coordinates.Add(direction);
                if (Mathf.Abs(n.q) > size
                    || Mathf.Abs(n.r) > size
                    || Mathf.Abs(n.s) > size)
                {
                    continue;
                }
                
                if (TryGetHex(n.q, n.r, out THex h))
                {
                    neighbors.Add(h);
                }
            }
            
            return neighbors;
        }
    }
}