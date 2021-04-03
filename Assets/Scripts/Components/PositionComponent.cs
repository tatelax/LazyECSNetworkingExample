using UnityEngine;

public class PositionComponent : INetworkComponent
{
    private Vector3 Value;
    
    public void Set(object value)
    {
        Value = (Vector3)value;
    }

    public void SendMessage()
    {
        throw new System.NotImplementedException();
    }
}
