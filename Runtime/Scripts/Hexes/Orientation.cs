using System;
using UnityEngine;

namespace fsi.hexgrid.Hexes
{
    public class Orientation
    {
        public enum OrientationType
        {
            Flat,
            Pointy,
        }
        
        public float F0 { get; }
        public float F1 { get; }
        public float F2 { get; }
        public float F3 { get; }
        public float B0 { get; }
        public float B1 { get; }
        public float B2 { get; }
        public float B3 { get; }
        public float StartAngle { get; }
        
        public Orientation(float f0, float f1, float f2, float f3, float b0, float b1, float b2, float b3, float start_angle)
        {
            this.F0 = f0;
            this.F1 = f1;
            this.F2 = f2;
            this.F3 = f3;
            this.B0 = b0;
            this.B1 = b1;
            this.B2 = b2;
            this.B3 = b3;
            this.StartAngle = start_angle;
        }
        
        public static Orientation Pointy = new(Mathf.Sqrt(3f),
                                               Mathf.Sqrt(3f) / 2f,
                                               0f,
                                               3f / 2f, 
                                               Mathf.Sqrt(3f) / 3f, 
                                               -1f / 3f, 
                                               0f, 
                                               2f / 3f, 
                                               0.5f);
        
        public static Orientation Flat = new(3f / 2f, 
                                             0f, 
                                             Mathf.Sqrt(3f) / 2f, 
                                             Mathf.Sqrt(3f), 
                                             2f / 3f, 
                                             0f, 
                                             -1f / 3f, 
                                             Mathf.Sqrt(3f) / 3f, 
                                             0f);

        public static Orientation GetOrientation(OrientationType type)
        {
            switch (type)
            {
                case OrientationType.Flat:
                    return Flat;
                case OrientationType.Pointy:
                    return Pointy;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}