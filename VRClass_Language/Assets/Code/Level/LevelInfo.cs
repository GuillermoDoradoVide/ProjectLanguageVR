using UnityEngine;
using System.Collections;

public class LevelInfo : MonoBehaviour {

    public SceneData sceneData;
	// Use this for initialization
	void Start () {
        if (sceneData == null)
        {
            Debug.Log("Current Scene doesn`t have a SceneData Scriptable.");
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
