using UnityEngine;
using UnityEngine.UI;

public class CreateEntityButton : MonoBehaviour
{
	public void Awake()
	{
		GetComponent<Button>().onClick.AddListener(() =>
		{
			CoreController.Instance.Worlds[typeof(MainWorld)]
				.CreateEntity();
		});
	}
}
