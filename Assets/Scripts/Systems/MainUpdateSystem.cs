using System;
using System.Collections.Generic;
using LazyECS;
using LazyECS.Entity;
using Mirror;
using UnityEngine;
using Random = UnityEngine.Random;

public class MainUpdateSystem : IUpdateSystem
{
    private readonly MainWorld world;
    private readonly Group group;
    
    public MainUpdateSystem(MainWorld _world)
    {
        world = _world;
        group = world.CreateGroup(GroupType.All, new HashSet<Type>
        {
            typeof(PositionComponent)
        });
    }
    
    public void Update()
    {
        foreach (Entity entity in group.Entities)
        {
            if (NetworkServer.active)
            {
                Vector3 newPos = new Vector3();
                newPos = Random.insideUnitSphere * 5.0F;
                entity.Set<PositionComponent>(newPos);
            }

            if (!entity.Has<ViewComponent>())
                entity.Set<ViewComponent>(GameObject.CreatePrimitive(PrimitiveType.Cube));

            entity.Get<ViewComponent>().Value.transform.position = entity.Get<PositionComponent>().Value;
        }
    }
}
