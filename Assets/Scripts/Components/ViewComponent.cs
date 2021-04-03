using LazyECS.Component;
using LazyECS.Entity;
using UnityEngine;

public class ViewComponent : IComponent
{
	public GameObject Value { get; private set; }

	public Entity Entity { get; set; }

	public event ComponentChanged OnComponentChanged;

	public void Set(object value)
	{
		Value = (GameObject)value;
	}
}
