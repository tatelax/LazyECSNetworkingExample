using LazyECS;

public class NetworkMessageFeature : Feature
{
	public NetworkMessageFeature(LazyNetworkManager networkManager, IWorld world)
	{
		Systems = new Systems()
			.Add(new NetworkMessageHandlerSystem(world, networkManager));
	}
}
