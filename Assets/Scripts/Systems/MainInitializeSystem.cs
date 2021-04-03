using LazyECS;
using UnityEngine;

public class MainInitializeSystem : IInitializeSystem
{
    private readonly MainWorld world;
    
    public MainInitializeSystem(MainWorld _world)
    {
        world = _world;
    }

    public void Initialize()
    {
        world.CreateEntity().Set<PositionComponent>(new Vector3());
    }
}
