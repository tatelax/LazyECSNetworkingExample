public class CoinValueComponent : INetworkComponent
{
	public float Value { get; private set; }

	public bool Set(object value)
	{
		Value = (float)value;
		return true;
	} 
	public object Get() => Value;
}