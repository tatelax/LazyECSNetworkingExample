using LazyECS.Component;
using UnityEngine;

public class ViewComponent : IComponent
{
	public GameObject Value { get; private set; }
	public void Set(object value) => Value = (GameObject)value;
	public object Get() => Value;
}
