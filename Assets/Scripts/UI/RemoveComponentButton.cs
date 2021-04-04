using System.Collections.Generic;
using LazyECS.Entity;
using UnityEngine;
using UnityEngine.UI;

public class RemoveComponentButton : MonoBehaviour
{
	public void Awake()
	{
		GetComponent<Button>().onClick.AddListener(() =>
		{
			foreach (KeyValuePair<int,Entity> entity in MainSimulationController.Instance.Worlds[0].Entities)
			{
				entity.Value.Remove(0);
			}
		});
	}
}
