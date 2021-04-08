using LazyECS;
using LazyECS.Entity;
using Mirror;

public static class NetworkComponentMessageHandling
{
	public static void RegisterHandlers()
	{
		NetworkClient.RegisterHandler<PositionComponentMessage>(OnReceivePositionComponent);
		NetworkServer.RegisterHandler<PositionComponentMessage>(OnReceivePositionComponent);
	}

	private static void OnReceivePositionComponent(NetworkConnection conn, PositionComponentMessage msg)
	{
		if (conn.connectionId == 0 && NetworkServer.active) // Check if we are the host might not work for dedicated servers
			return;

		IWorld myWorld = SimulationController.Instance.GetWorld(msg.worldId);

		if (!myWorld.Entities.ContainsKey(msg.entityID)) return; // If the client destroys an entity locally and the server is still changing it....we will get an error that the entity wasnt found
		
		Entity entity = myWorld.Entities[msg.entityID];

		if (!entity.Has<PositionComponent>()) return; // The client removed the component but the server tried to set it.
		
		if (entity.Get<PositionComponent>().Value == msg.Value) return;
		
		entity.Set<PositionComponent>(msg.Value, true);
	}
}