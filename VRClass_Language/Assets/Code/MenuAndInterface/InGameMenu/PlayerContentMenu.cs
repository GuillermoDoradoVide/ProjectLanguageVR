using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerContentMenu : MonoBehaviour {

	public LevelInfo levelInfo;
	public GameObject objectivesText;
	public GameObject infoText;
	public Text detailedInfo;

	private void Start() {
		levelInfo = LevelManager.Instance.levelInfo;
		showObjectives (); 
	}
	public void switchShowInfo() {
		if(objectivesText.activeSelf) {
			showInfo ();
		}
		else {
			showObjectives ();
		}
	}

	private void showObjectives() {
		string[] objectives;
		objectives = levelInfo.levelData.levelObjectives;
		objectivesText.SetActive (true);
		infoText.SetActive (false);
		detailedInfo.text = "";
		for(int i = 0; i < objectives.Length; i++ ) {
			detailedInfo.text += objectives[i];
		}

	}

	private void showInfo() {
		string[] info;
		info = levelInfo.levelData.levelInfo;
		objectivesText.SetActive (false);
		infoText.SetActive (true);
		detailedInfo.text = "";
		for(int i = 0; i < info.Length; i++ ) {
			detailedInfo.text += info[i];
		}
	}
}
