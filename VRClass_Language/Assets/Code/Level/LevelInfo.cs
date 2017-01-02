using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelInfo : MonoBehaviour {

    public string levelName;
    private SceneData sceneData;
    public SceneData SceneData
    {
        get {
            return sceneData;
        }
     }

    private void Awake ()
    {
        sceneData = GetComponent<SceneData>();
        levelName = SceneManager.GetActiveScene().name;
    }
	// Use this for initialization
	void Start () {
        if (sceneData == null)
        {
            Debug.Log("Current Scene doesn`t have a SceneData Scriptable.");
        }
	}
}
