using LazyECS;

public class MainFeature : Feature
{
	public override void Setup()
	{
		MainWorld mainWorld = MainSimulationController.Instance.Worlds[typeof(MainWorld)] as MainWorld;		
		Systems = new Systems()
			.Add(new MainUpdateSystem(mainWorld));
	}
}
