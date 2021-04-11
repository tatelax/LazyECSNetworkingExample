using Mirror;
using UnityEngine;

namespace Components
{
    public class PositionComponent : INetworkComponent
    {
        public Vector3 Value { get; private set; }

        public void Set(object value) => Value = (Vector3)value;
        public object Get() => Value;

        public void SendMessage(int _worldId, int _entityId, bool toClients, bool setFromNetworkMessage = false, NetworkConnection specificConnection = null)
        {
            PositionComponentMessage msg = new PositionComponentMessage
            {
                worldID = _worldId,
                entityID = _entityId,
                Value = Value
            };
            
            if (specificConnection != null)
            {
                specificConnection.Send(msg);
                return;
            }
        
            if(toClients)
                NetworkServer.SendToAll(msg);
            else if(!setFromNetworkMessage)
                NetworkClient.Send(msg);
        }
    }
}
