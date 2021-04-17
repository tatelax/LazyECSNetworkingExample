using LazyECS.Component;

public class ExampleFlagComponent : IComponent
{
	public bool Set(object value = null)
	{
		return true;
	}

	public object Get()
	{
		return true;
	}
}
