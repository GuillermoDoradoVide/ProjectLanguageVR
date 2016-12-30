using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SceneData : MonoBehaviour {

    public List<StateScript> sceneEventActivity;

    void Awake()
    {

    }
	// Use this for initialization
	void Start () {
        sceneEventActivity.Add(GetComponent<StateScript>());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
