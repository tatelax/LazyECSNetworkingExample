using LazyECS;

public class MainUpdateSystem : IUpdateSystem
{
    private readonly MainWorld world;
    
    public MainUpdateSystem(MainWorld _world)
    {
        world = _world;
    }
    
    public void Update()
    {
        UnityEngine.Debug.Log("Hello");
    }
}
