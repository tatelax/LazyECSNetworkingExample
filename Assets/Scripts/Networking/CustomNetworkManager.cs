using Mirror;
using UnityEngine;

public class CustomNetworkManager : NetworkManager
{
	[SerializeField] private MainSimulationController mainSimulationController;

	public override void OnStartServer()
	{
		base.OnStartServer();
		
		mainSimulationController.gameObject.SetActive(true);
	}

	public override void OnClientConnect(NetworkConnection conn)
	{
		base.OnClientConnect(conn);
		
		mainSimulationController.gameObject.SetActive(true);
	}
}
