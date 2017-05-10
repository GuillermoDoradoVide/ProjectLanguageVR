using UnityEngine;
using System.Collections;

public class UserLobby : StateScript {

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

	private void waitForPlayer() {
		if(isIntro) {
			SessionManager.sendEvent ("Scene", "watch intro");
			CurrentStep = startIntro;
			characterManager.gameObject.SetActive (true);
			characterManager.isActive = true;
		}
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

	public void loadlaboratory() {
		EventManager.triggerEvent (Events.EventList.PLAYER_FadeOut);
		Invoke ("changeToLaboratoryLobby", 2);
	}

	private void changeToLaboratoryLobby() {
		SceneController.Instance.SwitchScene ("Laboratory");
	}

	private void setIntroStart() {
		isIntro = true;
	}

	public override void atInit()
	{
		CurrentStep = waitForPlayer;
		EventManager.startListening (Events.EventList.NEW_USER, setIntroStart);
	}

	public override void atEnd()
	{
		EventManager.stopListening (Events.EventList.NEW_USER, startIntro);
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
