using LazyECS.Component;

public enum HelloEnum {
	hello,
	world
}

public class SomeEnumComponent : IComponent
{
	public HelloEnum Value { get; private set; }
	public void Set(object value) => Value = (HelloEnum)value;
	public object Get() => Value;
}
