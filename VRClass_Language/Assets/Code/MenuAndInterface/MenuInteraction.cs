using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class MenuInteraction : MonoBehaviour {

	public Slider[] sliders;
	// Use this for initialization
	void Start () {
		sliders = GetComponentsInChildren<Slider> ();
	}
	
	public void changeMusicVolume() {
		SoundManager.setMusicVolume (sliders[1].value);
	}

	public void changeVolume() {
		SoundManager.setGlobalVolume (sliders[0].value);
	}
}
