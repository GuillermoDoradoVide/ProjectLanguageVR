using UnityEngine;
using System.Collections;

public class GameManager : SingletonComponent<GameManager>
{
    private SceneController sceneController;
    private LevelManager levelManager;
    private EventManager eventManager;
    private SessionManager sessionManager;

    private void Awake()
    {
        initManagers();
    }

    private void Start () {
        initManagers();
    }
	
	// Update is called once per frame
	private void Update () {
	}

    private void initManagers()
    {
        sceneController = SceneController.Instance;
        levelManager = LevelManager.Instance;
        eventManager = EventManager.Instance;
    }

    private void OnEnable()
    {
        EventManager.startListening(Events.EventList.GM_Pause, pauseGame);
    }

    private void OnDisable()
    {
        EventManager.stopListening(Events.EventList.GM_Pause, pauseGame);
    }

    private void pauseGame()
    {
        Debug.Log("Pausa del juego. Abierto el menu.");
    }
}
