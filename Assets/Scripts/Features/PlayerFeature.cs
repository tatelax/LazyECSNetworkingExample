using LazyECS;

public class PlayerFeature : Feature
{
	public PlayerFeature(IWorld world)
	{
		Systems = new LazyECS.Systems()
			.Add(new CreatePlayerViewSystem(world));
	}
}
