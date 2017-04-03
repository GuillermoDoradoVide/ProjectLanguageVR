using UnityEngine;
using System.Collections;

public class ShowMenuSection : MonoBehaviour {

	public Transform menuSection;
	// Use this for initialization
	void Start () {
		EventManager.startListening (Events.EventList.MV_Hide_Active, hideSection);
	
	}

	public void showThisMenu() {
		EventManager.triggerEvent (Events.EventList.MV_Hide_Active);
		showSection ();
	}

	private void showSection() {
		menuSection.gameObject.SetActive (true);
	}

	private void hideSection() {
		menuSection.gameObject.SetActive (false);
	}
}
