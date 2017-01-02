using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SceneData : MonoBehaviour {

    public List<StateScript> sceneEventActivity;
    private StateScript[] eventList;
    void Awake()
    {
        sceneEventActivity = null;
        sceneEventActivity = new List<StateScript>();
        eventList = null;
    }
	// Use this for initialization
	void Start () {
        searchLevelStates();
        createLevelEventList();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void searchLevelStates()
    {
        eventList = GetComponentsInChildren<StateScript>();
    }

    private void createLevelEventList()
    { 
        foreach (StateScript state in eventList)
        {
            Debug.Log("Añadida la fase: " + state.name);
            sceneEventActivity.Add(state);
        }
    }
}
