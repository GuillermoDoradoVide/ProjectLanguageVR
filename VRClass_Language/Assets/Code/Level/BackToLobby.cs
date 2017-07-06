using UnityEngine;
using System.Collections;

public class BackToLobby : MonoBehaviour {

	public void backToLobby() {
        SoundManager.playSFX(sfxType.OnButtonClick);
        SessionManager.Instance.logOutUser();
	}
    private void changeSceneToLobby()
    {
        EventManager.triggerEvent(Events.EventList.PLAYER_FadeOut);
        EventManager.triggerEvent(Events.EventList.MENU_Hide);
        LevelManager.Instance.changeScene("UserLobby");
    }

    public void BackToLaboratory()
    {
        SoundManager.playSFX(sfxType.OnButtonClick);
        Debugger.printLog("back to lab");
        EventManager.triggerEvent(Events.EventList.PLAYER_FadeOut);
        EventManager.triggerEvent(Events.EventList.MENU_Hide);
        LevelManager.Instance.changeScene("laboratory");
    }
}
