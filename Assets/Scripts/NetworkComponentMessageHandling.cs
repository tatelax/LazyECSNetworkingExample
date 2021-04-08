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
		UpdateEntityFromNetworkMessage(conn.connectionId, msg.worldId, msg.entityID, ComponentLookup.Get(typeof(PositionComponent)), msg.Value);
	}

	private static void UpdateEntityFromNetworkMessage(int connectionId, int worldId, int entityId, int componentId, object componentValue)
	{
		if (connectionId == 0 && NetworkServer.active) // Check if we are the host might not work for dedicated servers
			return;
		
		IWorld myWorld = SimulationController.Instance.GetWorld(worldId);

		if (!myWorld.Entities.ContainsKey(entityId)) return; // If the client destroys an entity locally and the server is still changing it....we will get an error that the entity wasnt found

		Entity entity = myWorld.Entities[entityId];

		if (!entity.Has(componentId)) return; // The client removed the component but the server tried to set it.
		if (entity.Get(componentId).Get().Equals(componentValue)) return;

		entity.Set(ComponentLookup.Get(typeof(PositionComponent)), componentValue, true);
	}
}