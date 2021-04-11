using LazyECS.Component;

public class SomeStringComponent : IComponent
{
	public string Value { get; private set; }
	public void Set(object value) => Value = (string)value;
	public object Get() => Value;
}
