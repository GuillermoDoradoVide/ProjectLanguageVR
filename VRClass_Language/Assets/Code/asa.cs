﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class asa : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void laod() {
		Debug.Log ("ss");
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}
}
