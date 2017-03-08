using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;


public class InteractionMenuController : MonoBehaviour {

	public Text dialog;
	public Image iconImage;
	public Button dialogButton;

	public Sprite dialogIcon;
	public Sprite objectsIcon;
	public Sprite interactionIcon;

	public GameObject interactionMenuObject;

	private static InteractionMenuController interactionMenu;

	public static InteractionMenuController Instance() {
		if(!interactionMenu) {
			interactionMenu = FindObjectOfType (typeof(InteractionMenuController)) as InteractionMenuController;
			if(!interactionMenu) {
				Debug.LogError("There is not an active InteractionMenuController GameObject in the scene");
			}
		}
		return interactionMenu;
	}

	//show dialog event action
	public void addDialogTriggerAction(string boxDialog, UnityAction dialogTriggerEvent) {
		interactionMenuObject.SetActive (true);
		dialogButton.onClick.RemoveAllListeners();
		dialogButton.onClick.AddListener (dialogTriggerEvent);
		dialogButton.onClick.AddListener (closeInteractionMenu);
		dialog.text = boxDialog;
		iconImage.sprite = dialogIcon;
	}

	private void closeInteractionMenu() {
		interactionMenuObject.SetActive (false);
	}
}
