using UnityEngine;
using System.Collections;

public class GameManager : SingletonComponent<GameManager>
{
    private SceneController sceneController;
    private LevelManager levelManager;
    private EventManager eventManager;
    private SessionManager sessionManager;
    public SoundManager soundManager;
	public EffectManager effectManager;

    private void Awake()
    {
        initManagers();
        initEventTriggers();
		QualitySettings.antiAliasing = 4;
		Application.targetFrameRate = 60;
		QualitySettings.vSyncCount = 0;
    }

    private void OnDisable()
    {
        EventManager.stopListening(Events.EventList.GAMEMANAGER_Pause, pauseGame);
        EventManager.stopListening(Events.EventList.GAMEMANAGER_Continue, continueGame);
    }

    private void initManagers()
    {
        sceneController = SceneController.Instance;
        levelManager = LevelManager.Instance;
        eventManager = EventManager.Instance;
        soundManager = SoundManager.Instance;
		effectManager = EffectManager.Instance;
    }

    private void initEventTriggers()
    {
        EventManager.startListening(Events.EventList.GAMEMANAGER_Pause, pauseGame);
        EventManager.startListening(Events.EventList.GAMEMANAGER_Continue, continueGame);
    }
    //*************************
    private void Update()
    {
    }
    //*************************
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
