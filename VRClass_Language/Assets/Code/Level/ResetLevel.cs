using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ResetLevel : MonoBehaviour {
	int x = 0;
	public void resetLevel() {
        //SoundManager.playSFX(sfxType.OnButtonClick);
        EventManager.triggerEvent (Events.EventList.STATE_Pause);
        EventManager.triggerEvent(Events.EventList.MENU_Hide);
        LevelManager.Instance.restartLevel ();
	}

	public void pauseUnPause() {
		if (x == 0) {
			EventManager.triggerEvent(Events.EventList.GAMEMANAGER_Pause);
			x++;
		}
		else {
			x = 0;
			EventManager.triggerEvent(Events.EventList.GAMEMANAGER_Continue);
		}
	}
}
