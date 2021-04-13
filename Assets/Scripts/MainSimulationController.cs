using LazyECS;
using Mirror;
using UnityEngine;
using Worlds;

public class MainSimulationController : SimulationController
{
	[SerializeField] private LazyNetworkManager networkManager;
	
	protected override void Awake()
	{
		base.Awake();

		networkManager.OnClientConnectedEvent += OnConnect;
		networkManager.OnServerConnectedEvent += OnConnect;
	}

	private void OnConnect(NetworkConnection connection)
	{
		InitializeWorlds(new IWorld[]
		{
			new MainWorld(networkManager),
			new PlayerWorld()
		});
	}
}