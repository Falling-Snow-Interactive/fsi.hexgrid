using System;

namespace fsi.hexgrid.Hexes
{
    [Serializable]
    public class AngleCoordinates
    {
        public int q;
        public int r;
        public int s;

        public AngleCoordinates(int q, int r)
        {
            this.q = q;
            this.r = r;
            s = -q - r;
        }

        public AngleCoordinates Add(AngleCoordinates other)
        {
            return new AngleCoordinates(q + other.q, r + other.r);
        }
        
        protected bool Equals(AngleCoordinates other)
        {
            return q == other.q && r == other.r && s == other.s;
        }
        
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((AngleCoordinates)obj);
        }
        
        public override int GetHashCode()
        {
            return HashCode.Combine(q, r, s);
        }

        public override string ToString()
        {
            return $"({q}, {r}, {s})";
        }
    }
}