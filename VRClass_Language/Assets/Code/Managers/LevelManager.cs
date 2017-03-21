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
			Debug.Log(" Fallo al recoger la informacion del nivel.");
		}
		SoundManager.Instance.setNewMusicBox (levelInfo.musicAndSounds.musics);
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
		EventManager.triggerEvent (Events.EventList.PLAYER_FadeOut);
		Invoke ("reloadScene", 2);
	}

	private void reloadScene() {
		SceneController.Instance.loadScene ("Aeropuerto_Pasaportes");
		//SceneController.Instance.resetScene ();
		//SceneController.SwitchScene("Aeropuerto_Pasaportes");
	}
}
