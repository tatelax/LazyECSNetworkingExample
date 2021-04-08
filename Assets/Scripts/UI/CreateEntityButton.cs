using Components;
using UnityEngine;
using UnityEngine.UI;

public class CreateEntityButton : MonoBehaviour
{
	public void Awake()
	{
		GetComponent<Button>().onClick.AddListener(() =>
		{
			MainSimulationController.Instance.Worlds[0]
				.CreateEntity().Set<PositionComponent>(Random.insideUnitSphere * 10f);
		});
	}
}
