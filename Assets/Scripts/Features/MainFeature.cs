using LazyECS;

public class MainFeature : Feature
{
	public MainFeature(IWorld world)
	{
		Systems = new Systems()
			.Add(new MainUpdateSystem(world));
	}
}
