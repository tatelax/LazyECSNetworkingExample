using LazyECS;

namespace Worlds
{
	public class MainWorld : World
	{
		public MainWorld(LazyNetworkManager networkManager)
		{
			Features = new Feature[]
			{
				new NetworkMessageFeature(networkManager, this)
			};
		}
	}
}