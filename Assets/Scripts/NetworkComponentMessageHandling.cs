using Components;
using Mirror;

public static class NetworkComponentMessageHandling
{
	public static void RegisterHandlers()
	{
		NetworkClient.RegisterHandler<PositionComponentMessage>(OnReceivePositionComponent);
		NetworkServer.RegisterHandler<PositionComponentMessage>(OnReceivePositionComponent);
		
		NetworkClient.RegisterHandler<SomeIntMessage>(OnReceiveSomeIntComponent);
		NetworkServer.RegisterHandler<SomeIntMessage>(OnReceiveSomeIntComponent);
	}

	private static void OnReceiveSomeIntComponent(NetworkConnection conn, SomeIntMessage msg)
	{
		LazyNetworking.UpdateEntityFromNetworkMessage(conn.connectionId, msg.worldID, msg.entityID, ComponentLookup.Get(typeof(SomeIntComponent)), msg.Value);
	}

	private static void OnReceivePositionComponent(NetworkConnection conn, PositionComponentMessage msg)
	{
		LazyNetworking.UpdateEntityFromNetworkMessage(conn.connectionId, msg.worldID, msg.entityID, ComponentLookup.Get(typeof(PositionComponent)), msg.Value);
	}
}