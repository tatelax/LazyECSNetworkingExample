using Mirror;

public static class NetworkComponentMessageHandling
{
	public static void RegisterHandlers()
	{
		NetworkClient.ReplaceHandler<PositionComponentMessage>(OnReceivePositionComponent);
	}

	private static void OnReceivePositionComponent(NetworkConnection conn, PositionComponentMessage msg)
	{
		if (conn.connectionId == 0 && NetworkServer.active) // Check if we are the host
			return;
		
		SimulationController.Instance.GetWorld(msg.worldId).Entities[msg.entityID].Set<PositionComponent>(msg.Value);
	}
}