using Components;
using LazyECS;
using LazyECS.Entity;
using Mirror;
using UnityEngine;

public class CreateCoinSystem : IUpdateSystem
{
	public readonly IWorld world;

	private const float SpawnInterval = 5f;
	private const float SpawnRadius = 10F;
	
	private float timeSinceLastSpawn;
	
	public CreateCoinSystem(IWorld _world)
	{
		world = _world;
		timeSinceLastSpawn = SpawnInterval;
	}

	public void Update()
	{
		if (!NetworkServer.active) return;
		
		timeSinceLastSpawn -= Time.deltaTime;
		if (timeSinceLastSpawn > 0) return;
		timeSinceLastSpawn = SpawnInterval;

		Entity coinEntity = world.CreateEntity();
		coinEntity.Set<PositionComponent>(Random.insideUnitSphere * SpawnRadius);
		coinEntity.Set<CoinValueComponent>(100f);
	}
}
