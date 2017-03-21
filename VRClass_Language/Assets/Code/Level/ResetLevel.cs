using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ResetLevel : MonoBehaviour {

	public void resetLevel() {
		LevelManager.Instance.restartLevel ();
	}
}
