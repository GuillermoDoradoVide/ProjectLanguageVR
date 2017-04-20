using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;

public class InteractionMenuController : MonoBehaviour {

	public GameObject[] dialogGameObject;
	public Button[] dialogButton;
	public Text[] dialog;
	public Transform player;

	public GameObject interactionMenuObject;

	private static InteractionMenuController interactionMenu;

	public static InteractionMenuController Instance() {
		if(!interactionMenu) {
			interactionMenu = FindObjectOfType (typeof(InteractionMenuController)) as InteractionMenuController;
			if(!interactionMenu) {
				Debugger.printErrorLog("There is not an active InteractionMenuController GameObject in the scene");
			}
		}
		return interactionMenu;
	}

	private void Awake() {
		for (int x = 0; x < dialogGameObject.Length; x ++) {
			dialogButton[x] = dialogGameObject [x].GetComponentInChildren<Button> ();
			dialog[x] = dialogGameObject [x].GetComponentInChildren<Text> ();
		}
        EventManager.startListening(Events.EventList.STATE_Pause, pauseIsOn);
        EventManager.startListening(Events.EventList.STATE_Continue, pauseIsOff);
    }

	//show dialog event action
	public void addDialogTriggerAction(int optionNumber, string boxDialog, UnityAction dialogTriggerEvent) {
		interactionMenuObject.SetActive (true);
		dialogGameObject [optionNumber].SetActive (true);
		dialogButton[optionNumber].onClick.RemoveAllListeners();
		dialogButton [optionNumber].onClick.AddListener(dialogTriggerEvent);
		dialog[optionNumber].text = boxDialog;
	}

	public void closeInteractionMenu() {
		interactionMenuObject.SetActive (false);
	}

	public void movePanelTo(Transform newPosition) {
		if(newPosition != null)
			gameObject.transform.position = newPosition.position;
		/*transform.LookAt (player.position);
		transform.RotateAround (transform.position, Vector3.up, 180);*/
	}

    private void pauseIsOn()
    {
        interactionMenuObject.SetActive(false);
    }

    private void pauseIsOff()
    {
        interactionMenuObject.SetActive(true);
    }
}
