using LazyECS.Component;
using UnityEngine;

public class SomeBoolComponent : INetworkComponent
{
	public bool Value { get; private set; }

	public bool Set(object value)
	{
		Value = (bool)value;
		return true;
	} 
	public object Get() => Value;
}