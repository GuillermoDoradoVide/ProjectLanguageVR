using UnityEngine;
using System.Collections;

public class LevelManager : SingletonComponent<LevelManager>
{
    [SerializeField]
    private StateManager stateActivityManager;
    public LevelInfo levelInfo;

    private void Awake ()
    {
		stateActivityManager = null;
        if (stateActivityManager == null)
        {
            generateStateActivityManager();
        }
        levelInfo = null;
    }
	// Use this for initialization
	private void Start () {
    }

	public void calculateLevelData () {
		getLevelData();
		if(levelInfo)
		{
			stateActivityManager.getLevelStateList(levelInfo.SceneData.sceneEventActivity);
		}
		else
		{
			Debugger.printLog(" Fallo al recoger la informacion del nivel.");
		}
		SoundManager.setMusicBox (levelInfo.levelData.music);
	}
	
	// Update is called once per frame
	void Update () {
        stateActivityManager.doUpdate();
    }

    private void generateStateActivityManager()
    {
		Debugger.printLog("crear stateManager");
        stateActivityManager = ScriptableObject.CreateInstance<StateManager>();
    }

    public void getLevelData()
    {
        levelInfo = GameObject.Find("LevelInfo").GetComponent<LevelInfo>();
    }

	public void restartLevel() {
		EventManager.triggerEvent (Events.EventList.PLAYER_FadeOut);
		Invoke ("reloadScene", 2);
	}

	public void backToLobby() {
		EventManager.triggerEvent (Events.EventList.PLAYER_FadeOut);
		Invoke ("loadLobbyScene", 2);
	}

	private void reloadScene() {
		SceneController.Instance.resetScene ();
	}

	private void loadLobbyScene() {
		SceneController.SwitchScene ("Boss_Oficce");
	}
}
