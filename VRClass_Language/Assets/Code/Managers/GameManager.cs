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
	public float pauseTriggerTimer = 1f;
	public float currentPauseTimer;
	public bool isPaused = false;
	public LevelMusicAndSounds managerSounds;
	public GameObject menuCanvas;
//	public enum PauseState {PAUSED, UNPAUSED, Count};
//	public PauseState pauseState;
//	public delegate void GamePaused ();
//	public GamePaused[] PauseActionState;

    private void Awake()
    {
        initManagers();
        initEventTriggers();
		QualitySettings.antiAliasing = 4;
		Application.targetFrameRate = 60;
		QualitySettings.vSyncCount = 0;
		menuCanvas = GameObject.Find ("MenuCanvas");
		menuCanvas.SetActive (false);
//		PauseActionState = new GamePaused[(int)PauseState.Count]; // init array of delegates
//		// Set each action delegate
//		pauseState = PauseState.UNPAUSED;
//		PauseActionState[(int)PauseState.PAUSED] = triggerPause;
//		PauseActionState[(int)PauseState.UNPAUSED] = triggerUnPause;
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
//				pauseState = PauseState.PAUSED;
				triggerPause();
			}
			else {
//				pauseState = PauseState.UNPAUSED;
				triggerUnPause();
			}
//			PauseActionState ();
		}
		currentPauseTimer += Time.deltaTime;
	}

	private void triggerPause() {
		isPaused = true;
		menuCanvas.SetActive (true);
		SoundManager.playMusic(managerSounds.musics[0], true);
		SoundManager.playSFX (managerSounds.sounds[0]);
		EventManager.triggerEvent(Events.EventList.GAMEMANAGER_Pause);
	}

	private void triggerUnPause() {
		isPaused = false;
		menuCanvas.SetActive (false);
		SoundManager.playMusic (LevelManager.Instance.levelInfo.musicAndSounds.musics[0], true);
		SoundManager.playSFX (managerSounds.sounds[0]);
		EventManager.triggerEvent(Events.EventList.GAMEMANAGER_Continue);
	}

    private void pauseGame()
    {
        EventManager.triggerEvent(Events.EventList.STATE_Pause);
        Debug.Log("Pausa del juego. abriendo el menu.");
    }

    private void continueGame()
    {
        EventManager.triggerEvent(Events.EventList.STATE_Continue);
        Debug.Log("Reanudar el juego.");
    }
}
