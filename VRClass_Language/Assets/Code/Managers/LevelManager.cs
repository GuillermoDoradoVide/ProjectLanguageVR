using UnityEngine;
using System.Collections;

public class LevelManager : SingletonComponent<LevelManager>
{
    public StateManager stateMachineActivity;
    public LevelInfo levelInfo;

    private void Awake ()
    {
        stateMachineActivity = null;
        if (stateMachineActivity == null)
        {
            generateStateActivityManager();
        }
        levelInfo = null;
    }
	// Use this for initialization
	private void Start () {
    }

    private void generateStateActivityManager()
    {
        Debugger.printLog("crear stateManager");
        stateMachineActivity = ScriptableObject.CreateInstance<StateManager>();
    }

    public void initLevelData()
    {
        getLevelData();
        calculateLevelData();
        loadLevelMusicAndSounds();
    }

    public void getLevelData()
    {
        levelInfo = GameObject.Find("LevelInfo").GetComponent<LevelInfo>();
    }

    private void calculateLevelData () {
		
		if(levelInfo)
		{
            stateMachineActivity.getLevelStateList(levelInfo.SceneData.sceneEventActivity);
		}
		else
		{
			Debugger.printLog(" Fallo al recoger la informacion del nivel.");
		}
	}

    private void loadLevelMusicAndSounds()
    {
        SoundManager.setMusicBox(levelInfo.levelData.music);
    }
	
	// UPDATE ****************
	private void Update () {
        stateMachineActivity.doUpdate();
    }
    // ********************
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
		SceneController.Instance.SwitchScene ("UserLobby");
	}
}
