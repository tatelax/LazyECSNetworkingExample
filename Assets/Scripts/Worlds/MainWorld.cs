using LazyECS;

public class MainWorld : NetworkWorld
{
	public MainWorld()
	{
		Features = new Feature[]
		{
			new MainFeature(this)
		};
	}
}