using UnityEngine;
using System.Collections;

public class initGame : MonoBehaviour {

	public GameManager gameManager;

	// Use this for initialization
	private void Awake () {
		gameManager = GameManager.Instance;
        gameManager.initGameGrpahicsRenderOptions();
    }

	private void Start() {
        gameManager.initManagers();
    }
}
