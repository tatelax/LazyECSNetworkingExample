public class PlayerNameComponent : INetworkComponent
{
	private string Value { get; set; }

	public bool Set(object value)
	{
		Value = (string) value;
		return true;
	}

	public object Get()
	{
		return Value;
	} 
}
