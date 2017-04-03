using UnityEngine;
using System.Collections;

public class ActiveChildren : MonoBehaviour {

	public Transform[] children;

	private void Start() {
		
	}

	private void OnEnable() {
		for (int i = 0; i < children.Length; i++) {
			if(children[i] != null) {
				children [i].gameObject.SetActive (true);
			}
		}
	}

	private void OnDisable() {
		for (int i = 0; i < children.Length; i++) {
			if(children[i] != null) {
				children [i].gameObject.SetActive (false);
			}
		}
	}
}
