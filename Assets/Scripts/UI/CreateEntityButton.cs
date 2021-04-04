using UnityEngine;
using UnityEngine.UI;

public class CreateEntityButton : MonoBehaviour
{
	public void Awake()
	{
		GetComponent<Button>().onClick.AddListener(() =>
		{
			Debug.Log(MainSimulationController.Instance);
			MainSimulationController.Instance.Worlds[0]
				.CreateEntity().Set<PositionComponent>(new Vector3());
		});
	}
}
