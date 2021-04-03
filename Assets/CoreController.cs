using System;
using System.Collections.Generic;
using LazyECS;

public class CoreController : MonoBehaviourSingleton<CoreController>
{
	public Dictionary<Type, IWorld> Worlds { get; private set; }

	private void Awake()
	{
		base.Awake();
		
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