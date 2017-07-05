using UnityEngine;
using System.Collections;

public class BackToLobby : MonoBehaviour {

	public void backToLobby() {
        SessionManager.Instance.logOutUser();
        EventManager.triggerEvent(Events.EventList.PLAYER_FadeOut);
        LevelManager.Instance.changeScene ("UserLobby");
	}

    public void BackToLaboratory()
    {
        Debugger.printLog("back to lab");
        EventManager.triggerEvent(Events.EventList.PLAYER_FadeOut);
        LevelManager.Instance.changeScene("laboratory");
    }
}
