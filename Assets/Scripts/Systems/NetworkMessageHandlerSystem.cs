using LazyECS;
using Mirror;

public class NetworkMessageHandlerSystem : IInitializeSystem
{
    private readonly IWorld world;
    private readonly LazyNetworkManager networkManager;

    public NetworkMessageHandlerSystem(IWorld world, LazyNetworkManager networkManager)
    {
        this.world = world;
        this.networkManager = networkManager;
    }
    
    public void Initialize()
    {
        networkManager.OnServerConnectedEvent += OnServerConnectedEvent;

        // We're a host
        if (NetworkServer.active && NetworkClient.active)
            OnServerConnectedEvent(NetworkClient.connection);
    }

    private void OnServerConnectedEvent(NetworkConnection connection)
    {
    }
}
