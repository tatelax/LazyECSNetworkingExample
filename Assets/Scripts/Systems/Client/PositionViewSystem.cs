using System;
using System.Collections.Generic;
using Components;
using LazyECS;
using LazyECS.Entity;
using Mirror;

/// <summary>
/// Aligns entity's gameobjects position with their entity position components
/// </summary>
public class PositionViewSystem : IUpdateSystem
{
	private readonly Group group;

	public PositionViewSystem(IWorld world)
	{
		group = world.CreateGroup(GroupType.All, new HashSet<Type>
		{
			typeof(ViewComponent),
			typeof(PositionComponent)
		});
	}
	
	public void Update()
	{
		foreach (Entity groupEntity in @group.Entities)
		{
			groupEntity.Get<ViewComponent>().Value.transform.position = groupEntity.Get<PositionComponent>().Value;
		}
	}
}
