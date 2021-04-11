using LazyECS.Component;

public class SomeBoolComponent : IComponent
{
	private bool Value { get; set; }
	public void Set(object value) => Value = (bool)value;
	public object Get() => Value;
}
