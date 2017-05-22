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
        SoundManager.playMusic(levelInfo.levelData.music[0], true);
    }
	
	// UPDATE ****************
	private void Update () {
        stateMachineActivity.doUpdate();
    }
    // ********************
	public void restartLevel() {
        EventManager.triggerEvent(Events.EventList.PLAYER_FadeOut);
        SoundManager.Instance.stopMusicAndSounds(true, 2);
        Invoke("reloadCurrentLevel", 2);
    }

    private void reloadCurrentLevel()
    {
        SceneController.Instance.resetScene();
    }

    public void changeScene(string sceneName)
    {
        EventManager.triggerEvent(Events.EventList.PLAYER_FadeOut);
        SoundManager.Instance.stopMusicAndSounds(true, 2);
        StartCoroutine(loadNewScene(sceneName));
        
    }

    private IEnumerator loadNewScene(string sceneName)
    {
        yield return new WaitForSeconds(2.0f);
        SceneController.Instance.SwitchScene(sceneName);
    }
}
