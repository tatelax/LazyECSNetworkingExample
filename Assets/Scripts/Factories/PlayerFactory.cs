using Components;
using LazyECS;
using LazyECS.Entity;
using UnityEngine;

public static partial class Factories
{
	public static Entity CreatePlayer(IWorld world, string playerName)
	{
		Entity newEntity = world.CreateEntity();
		newEntity.Set<PlayerNameComponent>(playerName);
		newEntity.Set<PositionComponent>(new Vector3());
		newEntity.Set<SomeBoolComponent>(true);
		newEntity.Set<SomeFloatComponent>(69.1f);
		newEntity.Set<SomeIntComponent>(420);
		return newEntity;
	}
}