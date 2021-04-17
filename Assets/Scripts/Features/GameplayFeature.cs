using Systems.Client;
using LazyECS;

public class GameplayFeature : Feature
{
	public GameplayFeature(IWorld world)
	{
		Systems = new LazyECS.Systems()
			.Add(new CreateCoinSystem(world))
			.Add(new CreateCoinViewSystem(world))
			.Add(new PositionViewSystem(world))
			.Add(new ExampleEventSystem(world));
	}
}