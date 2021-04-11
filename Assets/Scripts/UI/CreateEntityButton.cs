using Components;
using UnityEngine;
using UnityEngine.UI;

public class CreateEntityButton : MonoBehaviour
{
	public int worldId;
	
	public void Awake()
	{
		GetComponent<Button>().onClick.AddListener(() =>
		{
			MainSimulationController.Instance.Worlds[worldId]
				.CreateEntity().Set<PositionComponent>(Random.insideUnitSphere * 10f);
		});
	}
}
