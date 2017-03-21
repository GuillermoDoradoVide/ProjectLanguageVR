using UnityEngine;
using System.Collections;

public class LevelManager : SingletonComponent<LevelManager>
{
    [SerializeField]
    private StateManager stateActivityManager;
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
        stateActivityManager.doUpdate();
    }

    private void generateStateActivityManager()
    {
        Debug.Log("crear stateManager");
        stateActivityManager = ScriptableObject.CreateInstance<StateManager>();
    }

    public void getLevelData()
    {
        levelInfo = GameObject.Find("LevelInfo").GetComponent<LevelInfo>();
    }

	public void restartLevel() {
		Debug.Log ("miau");
		EventManager.triggerEvent (Events.EventList.PLAYER_FadeOut);
		Invoke ("reloadScene", 2);
	}

	public void reloadScene() {
		SceneController.Instance.loadScene ("Aeropuerto_Pasaportes");
		//SceneController.Instance.resetScene ();
		//SceneController.SwitchScene("Aeropuerto_Pasaportes");
	}
}
