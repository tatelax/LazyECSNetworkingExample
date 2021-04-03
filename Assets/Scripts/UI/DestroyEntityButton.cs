using UnityEngine;
using UnityEngine.UI;

public class DestroyEntityButton : MonoBehaviour
{
	public void Awake()
	{
		GetComponent<Button>().onClick.AddListener(() =>
		{
			MainSimulationController.Instance.Worlds[typeof(MainWorld)].DestroyAllEntities();
		});
	}
}
