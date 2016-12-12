using UnityEngine;
using System.Collections;

public class MainController : SingletonComponent<MainController> {

    private SceneController sceneController;

    protected override void doAtAwake()
    {
        //Init managers
        sceneController = GetComponentInChildren<SceneController>();
    }
	// Use this for initialization
	void Start () {
        SceneController.loadAditiveScene("PlayerScene");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
