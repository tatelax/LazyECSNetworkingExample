using System;
using System.Collections.Generic;
using LazyECS;
using LazyECS.Entity;
using UnityEngine;

namespace Systems.Client
{
	public class ExampleEventSystem : IEventSystem
	{
		public ExampleEventSystem(IWorld world)
		{
			Group group = world.CreateGroup(GroupType.All, new HashSet<Type>
			{
				typeof(CoinValueComponent)
			});
			
			group.OnEntityAddedEvent += GroupOnOnEntityAddedEvent;
			group.OnEntityRemovedEvent += GroupOnOnEntityRemovedEvent;
			group.OnEntitySetEvent += GroupOnOnEntitySetEvent;
		}

		private void GroupOnOnEntitySetEvent(Entity entity)
		{
			Debug.Log($"Entity set! {entity.id}");
		}

		private void GroupOnOnEntityAddedEvent(Entity entity)
		{
			Debug.Log($"Entity added! {entity.id}");
		}

		private void GroupOnOnEntityRemovedEvent(Entity entity)
		{
			Debug.Log($"Entity removed! {entity.id}");
		}
	}
}
