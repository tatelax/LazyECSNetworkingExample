using LazyECS;

public class NetworkMessageFeature : Feature
{
	public NetworkMessageFeature(LazyNetworkManager networkManager, IWorld world)
	{
		Systems = new LazyECS.Systems()
			.Add(new NetworkMessageHandlerSystem(world, networkManager));
	}
}
