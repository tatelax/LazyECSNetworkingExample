using LazyECS.Component;
using UnityEngine;

public class ViewComponent : IComponent
{
	public GameObject Value { get; private set; }

	public bool Set(object value)
	{
		Value = (GameObject)value;
		return true;
	} 
	public object Get() => Value;
}