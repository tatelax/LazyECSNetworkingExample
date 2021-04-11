using LazyECS;

public class MainSimulationController : SimulationController
{
	protected override void Awake()
	{
		base.Awake();
		
		NetworkComponentMessageHandling.RegisterHandlers();

		InitializeWorlds(new IWorld[]
		{
			new MainWorld()
		});
	}
}