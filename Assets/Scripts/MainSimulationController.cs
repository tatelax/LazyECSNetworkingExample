using LazyECS;

public class MainSimulationController : NetworkSimulationController
{
	protected override void Awake()
	{
		base.Awake();
		
		NetworkComponentMessageHandling.RegisterHandlers();

		InitializeWorlds(new IWorld[]
		{
			new MainWorld(),
			new SecondaryWorld()
		});
	}
}