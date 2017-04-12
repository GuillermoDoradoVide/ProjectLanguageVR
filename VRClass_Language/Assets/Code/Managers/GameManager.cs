using UnityEngine;
using System.Collections;

public class GameManager : SingletonComponent<GameManager>
{
    private SceneController sceneController;
	public LevelManager levelManager;
    private EventManager eventManager;
    private SessionManager sessionManager;
    public SoundManager soundManager;

	[Header("Pause Setting")]
	public float pauseTriggerTimer = 3.0f;
	public float currentPauseTimer;
	public bool isPaused = false;
	public LevelMusicAndSounds managerSounds;

    private void Awake()
    {
        initManagers();
        initEventTriggers();
    }

	private void Start() {
		QualitySettings.antiAliasing = 4;
		Application.targetFrameRate = 60;
		QualitySettings.vSyncCount = 0;
	}

	public static void resetGameManager() {
		GameManager.instance.isPaused = false;
	}

    private void OnDisable()
    {
        EventManager.stopListening(Events.EventList.GAMEMANAGER_Pause, pauseGame);
        EventManager.stopListening(Events.EventList.GAMEMANAGER_Continue, continueGame);
    }

	private void OnDestroy()
	{
		EventManager.stopListening(Events.EventList.GAMEMANAGER_Pause, pauseGame);
		EventManager.stopListening(Events.EventList.GAMEMANAGER_Continue, continueGame);
	}

    private void initManagers()
    {
        sceneController = SceneController.Instance;
		eventManager = EventManager.Instance;
		soundManager = SoundManager.Instance;
        levelManager = LevelManager.Instance;
    }

    private void initEventTriggers()
    {
        EventManager.startListening(Events.EventList.GAMEMANAGER_Pause, pauseGame);
        EventManager.startListening(Events.EventList.GAMEMANAGER_Continue, continueGame);
    }
    //*************************
    private void Update()
    {
		if (GvrController.AppButton) {
			Debug.Log ("click");
			SoundManager.playSFX (managerSounds.sounds[0]);
			checkPause ();
		}
		else {
			currentPauseTimer = 0;
		}
    }
    //*************************

	private void checkPause ()
	{
		if (currentPauseTimer >= pauseTriggerTimer) {
			currentPauseTimer = 0;
			isPaused = !isPaused;
			if(isPaused) {
				triggerPause();
			}
			else {
				triggerUnPause();
			}
		}
		currentPauseTimer += Time.deltaTime;
	}

	private void triggerPause() {
		isPaused = true;
		SoundManager.playMusic(managerSounds.musics[0], true);
		SoundManager.playSFX (managerSounds.sounds[0]);
		EventManager.triggerEvent(Events.EventList.GAMEMANAGER_Pause);
	}

	private void triggerUnPause() {
		isPaused = false;
		SoundManager.playMusic (LevelManager.Instance.levelInfo.levelData.music[0], true);
		SoundManager.playSFX (managerSounds.sounds[0]);
		EventManager.triggerEvent(Events.EventList.GAMEMANAGER_Continue);
	}

    private void pauseGame()
    {
        EventManager.triggerEvent(Events.EventList.STATE_Pause);
		Debugger.printLog("Pausa del juego. abriendo el menu.");
    }

    private void continueGame()
    {
        EventManager.triggerEvent(Events.EventList.STATE_Continue);
		Debugger.printLog("Reanudar el juego.");
    }
}
