using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowMenuSection : MonoBehaviour {

	public Transform menuSection;
	public GameObject imageHighLight;
	public AudioClip changeMenu;
	public AudioClip hoverMenu;
	public Text title;
	// Use this for initialization
	void Start () {
		EventManager.startListening (Events.EventList.MV_Hide_Active, hideSection);
	}

	public void hoverThisMenu() {
		SoundManager.playSFX (hoverMenu);
	}

	public void showThisMenu() {
		EventManager.triggerEvent (Events.EventList.MV_Hide_Active);
		showSection ();
		imageHighLight.SetActive (true);
		SoundManager.playSFX (changeMenu);
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
