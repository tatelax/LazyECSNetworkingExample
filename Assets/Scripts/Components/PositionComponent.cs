using Mirror;
using UnityEngine;

public class PositionComponent : INetworkComponent
{
    public Vector3 Value { get; private set; }

    public void Set(object value) => Value = (Vector3)value;
    
    public void SendMessage(int _worldId, int _entityId, bool toClients)
    {
        PositionComponentMessage msg = new PositionComponentMessage
        {
            worldId = _worldId,
            entityID = _entityId,
            Value = Value
        };
        
        if(toClients)
            NetworkServer.SendToAll(msg);
        else
            NetworkClient.Send(msg);
    }
}
