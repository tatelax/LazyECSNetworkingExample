using LazyECS;

public class MainFeature : Feature
{
	public MainFeature(MainWorld world)
	{
		Systems = new Systems()
			.Add(new MainUpdateSystem(world));
	}
}
