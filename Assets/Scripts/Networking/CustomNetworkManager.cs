using Mirror;
using UnityEngine;

public class CustomNetworkManager : NetworkManager
{
	[SerializeField] private CoreController coreController;

	public override void OnStartServer()
	{
		base.OnStartServer();
		
		coreController.gameObject.SetActive(true);
	}

	public override void OnClientConnect(NetworkConnection conn)
	{
		base.OnClientConnect(conn);
		
		coreController.gameObject.SetActive(true);
	}
}
