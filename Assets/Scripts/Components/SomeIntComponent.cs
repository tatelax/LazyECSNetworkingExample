using Mirror;

public class SomeIntComponent : INetworkComponent
{
	public int Value { get; private set; }
	public void Set(object value) => Value = (int)value;
	public object Get() => Value;

	public void SendMessage(int _worldId, int _entityId, bool toClients, bool setFromNetworkMessage = false)
	{
		SomeIntMessage msg = new SomeIntMessage
		{
			worldID = _worldId,
			entityID = _entityId,
			Value = Value
		};
        
		if(toClients)
			NetworkServer.SendToAll(msg);
		else if(!setFromNetworkMessage)
			NetworkClient.Send(msg);
	}
}
