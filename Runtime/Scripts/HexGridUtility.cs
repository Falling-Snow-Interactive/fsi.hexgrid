using System.Collections.Generic;
using Fsi.HexGrid.Hexes;
using UnityEditor;
using UnityEngine;

namespace Fsi.HexGrid
{
    public static class HexGridUtility
    {
        private const int NUMBER_OF_SIDES = 6;
        
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
        
        public static Vector3 GetCornerPosition(Vector3 center, float size, int index, OrientationType orientation)
        {
            float deg = orientation == OrientationType.Flat ? 60f * index : 60f * index + 30f;
            float rad = deg * Mathf.Deg2Rad;
            return new Vector3(center.x + size * Mathf.Cos(rad),
                               0,
                               center.z + size * Mathf.Sin(rad));
        }
        
        public static readonly List<AngleCoordinates> directions = new List<AngleCoordinates>
                                                                  {
                                                                      new(1, 0),
                                                                      new(1, -1),
                                                                      new(0, -1),
                                                                      new(-1, 0),
                                                                      new(-1, 1),
                                                                      new(0, 1)
                                                                  };
        
        #if UNITY_EDITOR
        
        public static void DrawHexHandles(Vector3 center, float size, float thickness, OrientationType orientation)
        {
            for (int i = 0; i < NUMBER_OF_SIDES - 1; i++)
            {
                Vector3 c0 = GetCornerPosition(center, size, i, orientation);
                Vector3 c1 = GetCornerPosition(center, size, i + 1, orientation);
                
                Handles.DrawLine(c0, c1, thickness);
            }

            Handles.DrawLine(GetCornerPosition(center, size, 0, orientation),
                             GetCornerPosition(center, size, NUMBER_OF_SIDES - 1, orientation),
                             thickness);
        }
        
        public static void DrawHexGizmos(Vector3 center, float size, OrientationType orientation)
        {
            List<Vector3> corners = new();
            for (int i = 0; i < NUMBER_OF_SIDES; i++)
            {
                Vector3 c = GetCornerPosition(center, size, i, orientation);
                corners.Add(c);
            }

            Gizmos.DrawLineStrip(corners.ToArray(), true);
        }
        
        #endif
    }
}