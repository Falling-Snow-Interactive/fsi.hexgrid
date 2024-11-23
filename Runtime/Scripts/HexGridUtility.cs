using System.Collections.Generic;
using Fsi.HexGrid.Hexes;
using UnityEngine;

namespace Fsi.HexGrid
{
    public static class HexGridUtility
    {
        public const int NumberOfSides = 6;
        
        public static float GetWidth(float size)
        {
            return size * 2f;
        }

        public static float GetHeight(float size)
        {
            return Mathf.Sqrt(3) * size;
        }

        public static float GetHorizontalDistance(float size)
        {
            return 3f / 2f * size;
        }

        public static float GetVerticalDistance(float size)
        {
            return GetHeight(size);
        }
        
        public static Vector3 GetCornerPosition(Vector3 center, float size, int index, Orientation.OrientationType orientation)
        {
            float deg = orientation == Orientation.OrientationType.Flat ? 60f * index : 60f * index + 30f;
            float rad = deg * Mathf.Deg2Rad;
            return new Vector3(center.x + size * Mathf.Cos(rad),
                               0,
                               center.z + size * Mathf.Sin(rad));
        }
        
        public static readonly List<AngleCoordinates> Directions = new List<AngleCoordinates>
                                                                  {
                                                                      new(1, 0),
                                                                      new(1, -1),
                                                                      new(0, -1),
                                                                      new(-1, 0),
                                                                      new(-1, 1),
                                                                      new(0, 1)
                                                                  };
        
        #if UNITY_EDITOR
        
        public static void DrawHexGizmos(Vector3 center, float size, Orientation.OrientationType orientation, Color color)
        {
            List<Vector3> corners = new();
            for (int i = 0; i < NumberOfSides; i++)
            {
                Vector3 c = GetCornerPosition(center, size, i, orientation);
                corners.Add(c);
            }

            Gizmos.color = color;
            Gizmos.DrawLineStrip(corners.ToArray(), true);
        }
        
        #endif
    }
}