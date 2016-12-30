using UnityEngine;
using System.Collections;

public class LevelManager : SingletonComponent<LevelManager>
{
    StateManager stateActivityManager;

    private void Awake ()
    {
        if (stateActivityManager == null)
        {
            generateStateActivityManager();
        }
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void generateStateActivityManager()
    {
        stateActivityManager = ScriptableObject.CreateInstance<StateManager>();
    }

    public void getLevelDate()
    {

    }


}
