using System;
using System.Collections.Generic;
using LazyECS;
using LazyECS.Entity;
using UnityEngine;

public class CreatePlayerViewSystem : IUpdateSystem
{
    private readonly IWorld world;
    private readonly Group group;
    
    public CreatePlayerViewSystem(IWorld _world)
    {
        world = _world;
        group = world.CreateGroup(GroupType.All, new HashSet<Type>
        {
            typeof(PlayerNameComponent)
        });
    }
    
    public void Update()
    {
        foreach (Entity entity in group.Entities)
        {
            if (entity.Has<ViewComponent>()) return;

            GameObject newPlayerView = GameObject.CreatePrimitive(PrimitiveType.Cube);
            newPlayerView.name = (string)entity.Get<PlayerNameComponent>().Get();
            
            entity.Set<ViewComponent>(newPlayerView);
        }
    }
}
