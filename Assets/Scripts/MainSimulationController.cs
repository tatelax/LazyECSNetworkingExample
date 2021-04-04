using System.Collections.Generic;
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

	private void Start()
	{
		foreach (KeyValuePair<int,IWorld> world in Worlds)
		{
			world.Value.Start();
		}
	}

	private void Update()
	{
		foreach (KeyValuePair<int,IWorld> world in Worlds)
		{
			world.Value.Update();
			world.Value.Cleanup();
		}
	}

	private void OnDisable()
	{
		foreach (KeyValuePair<int,IWorld> world in Worlds)
		{
			world.Value.Teardown();
		}
	}
}