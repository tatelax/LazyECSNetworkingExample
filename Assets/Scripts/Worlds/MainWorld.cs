using LazyECS;

public class MainWorld : NetworkWorld
{
	public override void Init()
	{
		base.Init();
		
		features = new Feature[]
		{
			new MainFeature()
		};
	}
}