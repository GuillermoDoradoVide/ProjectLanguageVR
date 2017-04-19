using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EditUserID : MonoBehaviour {

	public Text idValue;
	public int currentValue;

	// Use this for initialization
	void Start () {
		currentValue = 0;
		idValue.text = currentValue.ToString();
	}
	
	public void incrementValue() {
		currentValue++;
		if(currentValue > 9) {
			currentValue = 0;
		}
		idValue.text = currentValue.ToString();
	}

	public void decrementValue() {
		currentValue--;
		if(currentValue < 0) {
			currentValue = 9;
		}
		idValue.text = currentValue.ToString();
	}
}
