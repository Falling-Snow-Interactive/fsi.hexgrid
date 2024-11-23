using System;
using System.Collections.Generic;
using fsi.hexgrid.Hexes;
using UnityEngine;

namespace fsi.hexgrid
{
    [Serializable]
    public class HexGrid
    {
        public int size;
        public List<Hex> hexes;
        
        public void Reset()
        {
            hexes = new List<Hex>();
            for(int q = -size + 1; q < size; q++)
                for (int r = -size + 1; r < size; r++)
                {
                    if (Mathf.Abs(q) >= size 
                        || Mathf.Abs(r) >= size 
                        || Mathf.Abs(-q - r) >= size)
                    {
                        continue;
                    }
                    
                    Hex hex = new Hex(q, r);
                    hexes.Add(hex);
                }
        }

        public void Refresh()
        {
            List<Hex> refreshed = new();
            
            for(int q = -size + 1; q < size; q++)
                for (int r = -size + 1; r < size; r++)
                {
                    if (Mathf.Abs(q) >= size 
                        || Mathf.Abs(r) >= size 
                        || Mathf.Abs(-q - r) >= size)
                    {
                        continue;
                    }

                    if (!TryGetHex(q, r, out Hex hex))
                    {
                        hex = new Hex(q, r);
                    }
                    
                    refreshed.Add(hex);
                }
            
            hexes = refreshed;
        }

        public bool TryGetHex(int q, int r, out Hex hex)
        {
            foreach (Hex h in hexes)
            {
                if (h.coordinateses.q == q && h.coordinateses.r == r)
                {
                    hex = h;
                    return true;
                }
            }

            hex = null;
            return false;
        }

        public bool TryGetHex(AngleCoordinates coordinates, out Hex hex)
        {
            return TryGetHex(coordinates.q, coordinates.r, out hex);
        }

        public List<Hex> GetNeighbors(Hex hex)
        {
            List<Hex> neighbors = new();

            foreach (AngleCoordinates direction in HexGridUtility.Directions)
            {
                AngleCoordinates n = hex.coordinateses.Add(direction);
                if (Mathf.Abs(n.q) > size
                    || Mathf.Abs(n.r) > size
                    || Mathf.Abs(n.s) > size)
                {
                    continue;
                }
                
                if (TryGetHex(n.q, n.r, out Hex h))
                {
                    neighbors.Add(h);
                }
            }
            
            return neighbors;
        }
    }
}