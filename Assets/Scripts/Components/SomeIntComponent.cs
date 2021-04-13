public class SomeIntComponent : INetworkComponent
{
	public int Value { get; private set; }

	public bool Set(object value)
	{
		Value = (int)value;
		return true;
	} 
	public object Get() => Value;
}