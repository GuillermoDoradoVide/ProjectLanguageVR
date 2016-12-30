using UnityEngine;
using System.Collections;

public class PlayerCreationPrefabManager : MonoBehaviour {

    public PlayerScriptable playerData;
    private PlayerInteractions playerInteractions;
    private GameObject menuMainControllerPrefab;
    private GameObject playerVRCameraPrefab;

	// Use this for initialization
	void Start () {
        menuMainControllerPrefab = Instantiate(playerData.menuMainController);
        playerVRCameraPrefab = Instantiate(playerData.playerCamera);
        menuMainControllerPrefab.GetComponent<menuMainController>().playerCamera = playerVRCameraPrefab.GetComponentInChildren<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
