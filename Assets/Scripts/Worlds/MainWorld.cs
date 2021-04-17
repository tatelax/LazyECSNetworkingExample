using LazyECS;

namespace Worlds
{
	public class MainWorld : NetworkWorld
	{
		private readonly LazyNetworkManager networkManager;
		
		public MainWorld(LazyNetworkManager _networkManager)
		{
			networkManager = _networkManager;
		}

		public override void Initialize()
		{
			base.Initialize();
			
			Features = new Feature[]
			{
				new PlayerFeature(this),
				new GameplayFeature(this), 
				new NetworkMessageFeature(networkManager, this)
			};
		}
	}
}