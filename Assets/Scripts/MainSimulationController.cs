using System;
using System.Collections.Generic;
using LazyECS;

public class MainSimulationController : SimulationController
{
	private void Awake()
	{
		base.Awake();
		
		// TODO: Make it so you dont have to do this
		ComponentLookup.Init(new []
		{
			typeof(PositionComponent),
			typeof(ViewComponent)
		});
		
		Worlds = new Dictionary<Type, IWorld>
		{
			{typeof(MainWorld), new MainWorld()}
		};
			
		// TODO: make this happen automatically as part of the ecs framework
		foreach (KeyValuePair<Type,IWorld> world in Worlds)
		{
			world.Value.Init();
		}
	}

	private void Start()
	{
		foreach (KeyValuePair<Type,IWorld> world in Worlds)
		{
			world.Value.Start();
		}
	}

	private void Update()
	{
		foreach (KeyValuePair<Type,IWorld> world in Worlds)
		{
			world.Value.Update();
			world.Value.Cleanup();
		}
	}

	private void OnDisable()
	{
		foreach (KeyValuePair<Type,IWorld> world in Worlds)
		{
			world.Value.Teardown();
		}
	}
}