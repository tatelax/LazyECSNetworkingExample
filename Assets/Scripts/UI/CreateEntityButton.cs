using UnityEngine;
using UnityEngine.UI;

public class CreateEntityButton : MonoBehaviour
{
	public void Awake()
	{
		GetComponent<Button>().onClick.AddListener(() =>
		{
			MainSimulationController.Instance.Worlds[typeof(MainWorld)]
				.CreateEntity().Set<PositionComponent>(new Vector3());
		});
	}
}
