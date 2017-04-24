using UnityEngine;
using System.Collections;

public class OptionsContentMenu : MonoBehaviour {
    public GameObject resetButton;
    public GameObject returnToLaboratory;
	// Use this for initialization
	private void Start () {
        string Scenename = SceneController.getCurrentScene().name;
        if(Scenename.CompareTo("UserLobby") == 0 || Scenename.CompareTo("Laboratory") == 0)
        {
            resetButton.SetActive(false);
            returnToLaboratory.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
