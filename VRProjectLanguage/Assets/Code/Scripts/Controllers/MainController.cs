using UnityEngine;
using System.Collections;

public class MainController : MonoBehaviour {

    public SceneController sceneController;

    protected void Awake()
    {
        sceneController = SceneController.Instance;
    }
	// Use this for initialization
	void Start () {
        SceneController.loadAditiveScene("PlayerScene");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDisable()
    {
        DestroyImmediate(sceneController);
    }
}
