using UnityEngine;
using System.Collections;

public class LaboratoryLobby : StateScript {

	public CharacterManager characterManager;
	public CharacterManager.CharacterState[] stepsA;
	public CharacterManager.CharacterState[] RotateB;
	public Transform[] rotateTo;
	public AudioClip[] firstAudio;

	public bool isIntro;

	void Start()
	{
	}

	// Update is called once per frame
	public override void atUpdate()
	{
		CurrentStep ();
       
	}

    public void BackToLaboratory()
    {
        Debugger.printLog("back to lab");
        EventManager.triggerEvent(Events.EventList.PLAYER_FadeOut);
        LevelManager.Instance.changeScene("laboratory");
    }

    public void backToLobby()
    {
        Debugger.printLog("back to lobby");
        EventManager.triggerEvent(Events.EventList.PLAYER_FadeOut);
        SessionManager.Instance.logOutUser();
        LevelManager.Instance.changeScene("UserLobby");
    }

    public void loadAirPortLevel() {
		Debugger.printLog ("Load");
        EventManager.triggerEvent(Events.EventList.PLAYER_FadeOut);
        LevelManager.Instance.changeScene("Aeropuerto_Pasaportes");
	}

    public void loadPickUpAirportLevel()
    {
        Debugger.printLog("Load");
        EventManager.triggerEvent(Events.EventList.PLAYER_FadeOut);
        LevelManager.Instance.changeScene("Aeropuerto_Recogida");
    }

    public void loadHotelReception()
    {
        Debugger.printLog("Load");
        EventManager.triggerEvent(Events.EventList.PLAYER_FadeOut);
        LevelManager.Instance.changeScene("Hotel_reception_A");
    }

    public void loadHotelBar()
    {
        Debugger.printLog("Load");
        EventManager.triggerEvent(Events.EventList.PLAYER_FadeOut);
        LevelManager.Instance.changeScene("Hotel_Bar");
    }

    public void loadStarbucks()
    {
        Debugger.printLog("Load");
        EventManager.triggerEvent(Events.EventList.PLAYER_FadeOut);
        LevelManager.Instance.changeScene("init_NotAStarbuck");
    }

    public void loadBriefing()
    {
        Debugger.printLog("Load");
        EventManager.triggerEvent(Events.EventList.PLAYER_FadeOut);
        LevelManager.Instance.changeScene("init_PrincipalBriefing");
    }

    private void waitForPlayer() {
		
	}

	private void startIntro() {
		characterManager.setCharacterNextStates (stepsA);
		CurrentStep = first;
	}

	private void first () {
		if (characterManager.isStandBy()) {
			characterManager.setCharacterNextStates (RotateB);
			characterManager.setWaypoints (rotateTo);
			CurrentStep = second;
		}
	}

	private void second() {
		if (!characterManager.animationReference.getWalking()) {
			characterManager.setDialogs (firstAudio);
			characterManager.setTalking ();
			CurrentStep = third;
		}
	}
	private void third() {
		if (!characterManager.animationReference.getTalking()) {
			doChangeThisStateToFinished();
		}
	}

	public override void atInit()
	{
		if(!isIntro) {
			CurrentStep = waitForPlayer;
		}
		else {
			CurrentStep = startIntro;
			characterManager.isActive = true;
		}
	}

	public override void atEnd()
	{
	}

	public override void atPause()
	{
		//throw new NotImplementedException();
	}

	public override void atReadyActiveState()
	{
		//throw new NotImplementedException();
	}
}
