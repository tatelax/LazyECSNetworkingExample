using LazyECS;

public class SecondaryWorld : NetworkWorld
{
	public SecondaryWorld()
	{
		Features = new Feature[]
		{
			new MainFeature(this)
		};
	}
}