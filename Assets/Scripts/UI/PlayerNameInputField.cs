using System.Collections.Generic;
using LazyECS;
using LazyECS.Entity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Worlds;

public class PlayerNameInputField : MonoBehaviour
{
	[SerializeField] private GameObject nameFieldParent;
	[SerializeField] private TMP_InputField nameField;
	[SerializeField] private Button acceptButton;
	[SerializeField] private TextMeshProUGUI acceptButtonText;

	private void Awake()
	{
		acceptButton.interactable = false;
		
		acceptButton.onClick.AddListener(AcceptButtonClicked);
		
		nameField.onValueChanged.AddListener(CheckNameField);
	}

	private void CheckNameField(string arg0)
	{
		acceptButton.interactable = arg0.Length > 0;
	}

	private void AcceptButtonClicked()
	{
		acceptButtonText.text = "Creating...";

		Factories.CreatePlayer(SimulationController.Instance.GetWorld<MainWorld>(), nameField.text);

		IWorld mainWorld = SimulationController.Instance.GetWorld<MainWorld>();
		
		List<Entity> entities = mainWorld.GetEntities<PlayerNameComponent>();
		List<Entity> tatelaxEntities = mainWorld.GetEntities<PlayerNameComponent>("tatelax");
		
		Debug.Log($"Entities with playernamecomponent {entities.Count}");
		Debug.Log($"Entities with playernamecomponent value asd {tatelaxEntities.Count}");
		
		nameFieldParent.SetActive(false);
	}
}
