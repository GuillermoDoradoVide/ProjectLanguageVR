using UnityEngine;
using System.Collections;

public class LaboratoryLobby : StateScript {

	public CharacterManager characterManager;
	public CharacterManager.CharacterState[] stepsA;
	public CharacterManager.CharacterState[] RotateB;
	public Transform[] rotateTo;
	public AudioClip[] firstAudio;


	private delegate void Steps();
	private Steps Step;

	public bool isIntro;

	void Start()
	{
	}

	// Update is called once per frame
	public override void atUpdate()
	{
		Step ();
	}

	public void loadAirPortLevel() {
		Debug.Log ("Load");
		EventManager.triggerEvent (Events.EventList.PLAYER_FadeOut);
		Invoke ("changeToAirportScene", 2);
	}

	private void changeToAirportScene() {
		SceneController.SwitchScene ("Aeropuerto_Pasaportes");
	}

	private void waitForPlayer() {
		
	}

	private void startIntro() {
		characterManager.setCharacterNextStates (stepsA);
		Step = first;
	}

	private void first () {
		if (characterManager.isStandBy()) {
			characterManager.setCharacterNextStates (RotateB);
			characterManager.setWaypoints (rotateTo);
			Step = second;
		}
	}

	private void second() {
		if (!characterManager.animationReference.getWalking()) {
			characterManager.setDialogs (firstAudio);
			Step = third;
		}
	}
	private void third() {
		
	}

	public override void atInit()
	{
		if(!isIntro) {
			Step = waitForPlayer;
		}
		else {
			Step = startIntro;
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
