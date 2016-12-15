using UnityEngine;
using System.Collections;

public class MainController : SingletonComponent<MainController> {

    public SceneController sceneController;

    protected override void doAtAwake()
    {
        sceneController = SceneController.Instance;
    }
	// Use this for initialization
	void Start () {
        SceneController.loadAditiveScene("PlayerScene");
	}
	
	// Update is called once per frame
	void Update () {
        sceneController.doUpdate();

    }
}
