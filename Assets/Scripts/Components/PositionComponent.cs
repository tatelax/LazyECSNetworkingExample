using Mirror;
using UnityEngine;

public class PositionComponent : INetworkComponent
{
    public PositionComponent()
    {
        NetworkClient.RegisterHandler<PositionComponentMessage>(OnMessageRecieve);
    }
    
    public Vector3 Value { get; private set; }

    public void OnMessageRecieve(NetworkConnection conn, PositionComponentMessage msg)
    {
        Debug.Log($"New pos recieved! {msg.Value}");
        Value = msg.Value;
    }

    public void Set(object value) => Value = (Vector3)value;
    
    public void SendMessage(bool toClients)
    {
        PositionComponentMessage msg = new PositionComponentMessage {Value = Value};
        
        if(toClients)
            NetworkServer.SendToAll(msg);
        else
            NetworkClient.Send(msg);
    }

    public struct PositionComponentMessage : NetworkMessage
    {
        public Vector3 Value;
    }
}
