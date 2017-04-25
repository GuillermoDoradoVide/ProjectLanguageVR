using UnityEngine;
using System.Collections;

public class initGame : MonoBehaviour {

	public GameManager gameManager;

	// Use this for initialization
	private void Awake () {
		QualitySettings.antiAliasing = 4;
		Application.targetFrameRate = 60;
		QualitySettings.vSyncCount = 0;
		gameManager = GameManager.Instance;
	}

	private void Start() {
		GameManager.Instance.levelManager.calculateLevelData ();
        GameManager.Instance.sessionManager.initAnalytics();

        GameManager.resetGameManager ();
	}
}
