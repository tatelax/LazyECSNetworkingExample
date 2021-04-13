using UnityEngine;

namespace Components
{
    public class PositionComponent : INetworkComponent
    {
        public Vector3 Value { get; set; }

        public bool Set(object value)
        {
            Value = (Vector3)value;
            return true;
        } 
        
        public object Get() => Value;
    }
}
