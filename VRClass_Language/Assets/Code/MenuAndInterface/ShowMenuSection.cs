using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowMenuSection : MonoBehaviour {

	public Transform menuSection;
	public GameObject imageHighLight;
	public Text title;
	// Use this for initialization
	void Start () {
		EventManager.startListening (Events.EventList.MV_Hide_Active, hideSection);
	}

	public void playUISFX(AudioClip clip) {
		SoundManager.playSFX (clip);
	}

	public void showThisMenu() {
		EventManager.triggerEvent (Events.EventList.MV_Hide_Active);
		showSection ();
		imageHighLight.SetActive (true);
		title.text = gameObject.name.ToUpper();
	}

	private void showSection() {
		menuSection.gameObject.SetActive (true);
	}

	private void hideSection() {
		imageHighLight.SetActive (false);
		menuSection.gameObject.SetActive (false);
	}
}
