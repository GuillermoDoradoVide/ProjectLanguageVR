using UnityEngine;
using System.Collections;

public class ObjectActionMenu : MonoBehaviour {

	public GameObject selectMenu;
	public GameObject pickMenu;
	public GameObject atrasMenu;
	// Use this for initialization
	void Start () {
	
	}

	public void activeAtrasMenu() {
		atrasMenu.SetActive (true);
		//atrasMenu.GetComponent<IElement> ().selectElement();
	}
	
	public void activeSelectMenu() {
		selectMenu.SetActive (true);
		//selectMenu.GetComponent<IElement> ().selectElement();
	}

	public void activePickMenu() {
		pickMenu.SetActive (true);
		//pickMenu.GetComponent<IElement> ().selectElement();
	}

	public void disableMenus() {
		if(selectMenu.activeSelf) {
			selectMenu.GetComponent<IElement> ().selectElement();
		}
			if(pickMenu.activeSelf) {
			pickMenu.GetComponent<IElement> ().selectElement();
		}
		atrasMenu.GetComponent<IElement> ().selectElement();
	}
 }
