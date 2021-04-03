using LazyECS;

public class MainFeature : Feature
{
	public override void Setup()
	{
		MainWorld mainWorld = CoreController.Instance.Worlds[typeof(MainWorld)] as MainWorld;		
		Systems = new Systems()
			.Add(new MainInitializeSystem(mainWorld))
			.Add(new MainUpdateSystem(mainWorld));
	}
}
