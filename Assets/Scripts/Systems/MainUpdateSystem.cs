using System;
using System.Collections.Generic;
using Components;
using LazyECS;
using LazyECS.Entity;
using Mirror;
using UnityEngine;

public class MainUpdateSystem : IUpdateSystem
{
    private readonly IWorld world;
    private readonly Group group;
    
    public MainUpdateSystem(IWorld _world)
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
                Vector3 newPos = entity.Get<PositionComponent>().Value;
                
                if (newPos.x < 10)
                {
                    newPos = new Vector3(newPos.x + 0.01f, newPos.y, newPos.z);
                }
                
                entity.Set<PositionComponent>(newPos);
            }
        
            if (!entity.Has<ViewComponent>())
                entity.Set<ViewComponent>(GameObject.CreatePrimitive(PrimitiveType.Cube));
        
            // Make the gameobject.pos = entity pos
            entity.Get<ViewComponent>().Value.transform.position = entity.Get<PositionComponent>().Value;
        }
    }
}
