using UnityEngine;
using System.Collections;

public class LevelManager : SingletonComponent<LevelManager>
{
    StateManager stateActivityManager;
    private LevelInfo levelInfo;

    private void Awake ()
    {
        if (stateActivityManager == null)
        {
            generateStateActivityManager();
        }
        levelInfo = null;
    }
	// Use this for initialization
	void Start () {
        getLevelData();
        if(levelInfo)
        {
            stateActivityManager.getLevelStateList(levelInfo.SceneData.sceneEventActivity);
        }
        else
        {
            Debug.Log(" Fallo al recoger la informacion del nivel.");
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private void generateStateActivityManager()
    {
        stateActivityManager = ScriptableObject.CreateInstance<StateManager>();
    }

    public void getLevelData()
    {
        levelInfo = GameObject.Find("LevelInfo").GetComponent<LevelInfo>();
    }
}
