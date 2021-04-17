using LazyECS;
using UnityEngine;
using Worlds;

public class MainSimulationController : SimulationController
{
	[SerializeField] private LazyNetworkManager networkManager;
	
	protected void Start()
	{
		InitializeWorlds(new IWorld[]
		{
			new MainWorld(networkManager),
			new PlayerWorld()
		});
	}
}