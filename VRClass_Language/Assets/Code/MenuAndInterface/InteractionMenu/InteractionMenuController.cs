﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;


public class InteractionMenuController : MonoBehaviour {

	public GameObject[] dialogGameObject;
	public Button[] dialogButton;
	public Text[] dialog;
	public Image[] iconImage;

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

	private void Awake() {
		for (int x = 0; x < dialogGameObject.Length - 1; x ++) {
			dialogButton[x] = dialogGameObject [x].GetComponentInChildren<Button> ();
			dialog[x] = dialogGameObject [x].GetComponentInChildren<Text> ();
			iconImage [x] = dialogGameObject [x].GetComponentInChildren<Image> ();
		}
	}

	//show dialog event action
	public void addDialogTriggerAction(int optionNumber, string boxDialog, UnityAction dialogTriggerEvent) {
		interactionMenuObject.SetActive (true);
		dialogGameObject [optionNumber].SetActive (true);
		dialogButton[optionNumber].onClick.RemoveAllListeners();
		dialogButton [optionNumber].onClick.AddListener(dialogTriggerEvent);
		dialog[optionNumber].text = boxDialog;
		//iconImage[optionNumber].sprite = dialogIcon;
	}

	public void closeInteractionMenu() {
		interactionMenuObject.SetActive (false);
	}
}
