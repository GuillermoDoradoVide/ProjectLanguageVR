using UnityEngine;
using System.Collections;

public class DataContentMenu : MonoBehaviour {

	public GameObject dataButton;
	public GameObject AchievementButton;
	public GameObject backButton;

	private void Start() {
	}

	public void returnToDataMenu() {
		dataButton.SetActive (true);
		AchievementButton.SetActive (true);
		backButton.SetActive (false);
	}

	private void setMenuInterfaceButtons() {
		dataButton.SetActive (false);
		AchievementButton.SetActive (false);
		backButton.SetActive (true);
	}

	public void showData() {
		setMenuInterfaceButtons ();
	}

	public void showAchievements() {
		setMenuInterfaceButtons ();
	}

	public void playUISFX(AudioClip clip) {
		SoundManager.playSFX (clip);
	}
}
