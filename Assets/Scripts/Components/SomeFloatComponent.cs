using LazyECS.Component;

public class SomeFloatComponent : IComponent
{
	public float Value { get; private set; }
	public void Set(object value) => Value = (float)value;
	public object Get() => Value;
}
