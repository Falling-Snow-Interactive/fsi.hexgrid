using System;
using UnityEngine;

namespace Fsi.HexGrid.Hexes
{
    [Serializable]
    public class Hex<TState> : ISerializationCallbackReceiver
    where TState : Enum
    {
        [HideInInspector]
        [SerializeField]
        private string name;
        
        [HideInInspector]
        public AngleCoordinates coordinates;
        
        public TState state;
        
        public Hex(int q, int r)
        {
            coordinates = new AngleCoordinates(q, r);
        }

        protected Hex()
        {
            coordinates = new AngleCoordinates(0, 0);
        }

        #region Operators

        private bool Equals(Hex<TState> other)
        {
            return Equals(coordinates, other.coordinates);
        }
        
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Hex<TState>)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(coordinates);
        }

        public new string ToString()
        {
            return $"Hex: \n\t{coordinates}";
        }
        
        #endregion

        public void OnBeforeSerialize()
        {
            name = $"{coordinates} - {state}";
        }

        public void OnAfterDeserialize() { }
    }
}