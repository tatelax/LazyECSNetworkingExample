using System.Linq;
using LazyECS.Entity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IncreaseDecreaseSomeInt : MonoBehaviour
{
	public Button increaseButton;
	public Button decreaseButton;
	public TextMeshProUGUI someIntText;

	public void Awake()
	{
		increaseButton.onClick.AddListener(() => DoOperation(true));
		decreaseButton.onClick.AddListener(() => DoOperation(false));
	}
	
	private void DoOperation(bool increase)
	{
		if (SimulationController.Instance.Worlds[0].Entities.Count == 0)
		{
			Debug.Log("Create an entity first!");
			return;
		}
		
		Entity entity = SimulationController.Instance.Worlds[0].Entities.First().Value;
		
		int currValue = 0;

		if (entity.Has<SomeIntComponent>())
		{
			currValue = entity.Get<SomeIntComponent>().Value;
		}

		entity.OnComponentSet += (entity1, component, message) => {
			if(!(component is SomeIntComponent))
				return;

			SomeIntComponent cmp = (SomeIntComponent)component;
			someIntText.text = cmp.Value.ToString();
		};

		if (increase)
		{
			currValue++;
		}
		else
		{
			currValue--;
		}
		
		entity.Set<SomeIntComponent>(currValue);

		someIntText.text = currValue.ToString();
	}
}
