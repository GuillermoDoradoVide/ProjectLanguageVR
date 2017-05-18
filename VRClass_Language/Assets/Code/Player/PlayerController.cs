using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	public GameObject menuCanvas;

	// Use this for initialization
	private void Start ()
	{
		menuCanvas = GameObject.Find ("[MENU]");
		menuCanvas.SetActive (false);
		EventManager.startListening (Events.EventList.STATE_Pause, activeMenu);
		EventManager.startListening (Events.EventList.STATE_Continue, disableMenu);
	}

	private void OnEnable() {
		EventManager.startListening (Events.EventList.STATE_Pause, activeMenu);
		EventManager.startListening (Events.EventList.STATE_Continue, disableMenu);
	}

	private void OnDisable() {
		EventManager.stopListening (Events.EventList.STATE_Pause, activeMenu);
		EventManager.stopListening (Events.EventList.STATE_Continue, disableMenu);
	}

	private void activeMenu() {
		menuCanvas.SetActive (true);
	}

	private void disableMenu() {
		menuCanvas.SetActive (false);
	}

}
