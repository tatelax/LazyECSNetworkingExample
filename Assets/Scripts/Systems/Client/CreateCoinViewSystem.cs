using System;
using System.Collections.Generic;
using Components;
using LazyECS;
using LazyECS.Entity;
using UnityEngine;

public class CreateCoinViewSystem : IUpdateSystem
{
	private readonly IWorld world;
	private readonly Group group;
	
	public CreateCoinViewSystem(IWorld world)
	{
		this.world = world;
		group = world.CreateGroup(GroupType.All, new HashSet<Type>
		{
			typeof(PositionComponent),
			typeof(CoinValueComponent)
		});
	}

	public void Update()
	{
		foreach (Entity entity in @group.Entities)
		{
			if (entity.Has<ViewComponent>())
				continue;
			
			entity.Set<ViewComponent>(GameObject.CreatePrimitive(PrimitiveType.Sphere));
		}
	}
}
