﻿using UnityEngine;
using System.Collections;

public class GameManager : SingletonComponent<GameManager>
{
    private SceneController sceneController;
	private LevelManager levelManager;
    private EventManager eventManager;
    private SessionManager sessionManager;
    private SoundManager soundManager;

	[Header("Pause Setting")]
	public float pauseTriggerTimer = 3.0f;
    [ReadOnly]
	public float currentPauseTimer;
	public bool isPaused = false;
	public LevelMusicAndSounds managerSounds;

    private void Awake()
    {
        initGameGrpahicsRenderOptions();
        initEventTriggers();
    }

	private void Start() {
        initManagers();
    }

    private void OnDisable()
    {
        EventManager.stopListening(Events.EventList.GAMEMANAGER_Pause, pauseGame);
        EventManager.stopListening(Events.EventList.GAMEMANAGER_Continue, continueGame);
    }

    private void OnApplicationQuit()
    {
        MonoBehaviour[] scripts = FindObjectsOfType<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
        {
            script.enabled = false;
        }
    }

    /* INIT METHODS */

    private void initEventTriggers()
    {
        EventManager.startListening(Events.EventList.GAMEMANAGER_Pause, pauseGame);
        EventManager.startListening(Events.EventList.GAMEMANAGER_Continue, continueGame);
    }

    public void initManagers()
    {
        resetGameManager();
        sceneController = SceneController.Instance;
		eventManager = EventManager.Instance;
		soundManager = SoundManager.Instance;
        soundManager.initSoundManager();
        levelManager = LevelManager.Instance;
        /*Level restart and load scripts*/
        levelManager.initLevelData();
        sessionManager = SessionManager.Instance;
        /*Session user reload user list*/
        sessionManager.initAnalytics();
    }

    private void resetGameManager()
    {
        isPaused = false;
    }

    // UPDATE *************************
    private void Update()
    {
		if (GvrController.AppButtonDown || Input.GetKeyDown(KeyCode.P)) {
			if(isPaused) {
				isPaused = false;
			}else {
				isPaused = true;
			}
//			isPaused = !isPaused;
			if(isPaused) {
				triggerPause();
			}
			else {
				triggerUnPause();
			}
//			checkPause ();
		}
		else {
			currentPauseTimer = 0;
		}
    }
    //*************************

    public void initGameGrpahicsRenderOptions()
    {
        QualitySettings.antiAliasing = 4;
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
    }

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
//		SoundManager.playMusic(managerSounds.musics[0], true);
//		SoundManager.playSFX (managerSounds.sounds[0]);
		EventManager.triggerEvent(Events.EventList.GAMEMANAGER_Pause);
	}

	private void triggerUnPause() {
		isPaused = false;
//		SoundManager.playMusic (LevelManager.Instance.levelInfo.levelData.music[0], true);
//		SoundManager.playSFX (managerSounds.sounds[0]);
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
