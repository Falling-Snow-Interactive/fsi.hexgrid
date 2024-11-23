using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace fsi.hexgrid.Hexes
{
    [Serializable]
    public class Hex : ISerializationCallbackReceiver
    {
        [HideInInspector]
        [SerializeField]
        private string name;
        
        [FormerlySerializedAs("coordinates")]
        public AngleCoordinates coordinateses;
        public HexState state = HexState.Walkable;

        public enum HexState
        {
            None = 0,
            Walkable = 1,
            Tower = 2
        }
        
        public Hex(int q, int r)
        {
            coordinateses = new AngleCoordinates(q, r);
        }
        
        #region Operators

        private bool Equals(Hex other)
        {
            return Equals(coordinateses, other.coordinateses);
        }
        
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Hex)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(coordinateses);
        }

        public new string ToString()
        {
            return $"Hex: \n\t{coordinateses}";
        }
        
        #endregion

        public void OnBeforeSerialize()
        {
            name = $"{coordinateses} - {state}";
        }

        public void OnAfterDeserialize() { }
    }
}