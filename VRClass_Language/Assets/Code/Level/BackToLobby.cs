using UnityEngine;
using System.Collections;

public class BackToLobby : MonoBehaviour {

	public void backToLobby() {
        SessionManager.Instance.logOutUser();
		LevelManager.Instance.changeScene ("UserLobby");
	}
}
