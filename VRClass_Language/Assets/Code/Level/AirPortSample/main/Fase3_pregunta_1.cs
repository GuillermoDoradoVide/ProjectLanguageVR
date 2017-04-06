using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Fase3_pregunta_1  : StateScript {

	public InteractionMenuController menuController;
	public AudioClip[] dialogsA;
	public AudioClip[] dialogsB;
	public AudioClip[] dialogsC;
	public AudioClip[] dialogsD;
	public AudioClip[] dialogsE;
	public CharacterManager characterManager;

	private delegate void Steps();
	private Steps Step;

	public UnityAction firstAction;
	public UnityAction secondAction;
	public UnityAction thirdAction;
	public UnityAction forthAction;
	public UnityAction fifthAction;

	void Start()
	{
	}

	// Update is called once per frame
	public override void atUpdate()
	{
		//characterManager.doUpdate ();
		Step ();
	}

	public void Optionrepeat() {
		characterManager.setDialogs (dialogsA);
		characterManager.setTalking ();
		Step = first;
	}

	public void OptionBarcelona() {
		characterManager.setDialogs (dialogsB);
		characterManager.setTalking ();
		Step = first;
	}

	public void Optionmiami() {
		characterManager.setDialogs (dialogsC);
		characterManager.setTalking ();
		Step = final;
	}

	public void OptionBoardingpass() {
		characterManager.setDialogs (dialogsD);
		characterManager.setTalking ();
		Step = first;
	}

	public void OptionDriverLicense() {
		characterManager.setDialogs (dialogsE);
		characterManager.setTalking ();
		Step = first;
	}

	private void first() {
		if(!characterManager.animationReference.getTalking()) {
			showPlayerAdessMenuOptions ();
			Step = characterWaitsForPlayer;
		}
	}

	private void final() {
		if(!characterManager.animationReference.getTalking()) {
			doChangeThisStateToFinished ();
		}
	}

	private void showPlayerAdessMenuOptions() {
		menuController.addDialogTriggerAction (0,"Say, 'I'm not sure I understand.'",firstAction);
		menuController.addDialogTriggerAction (1,"Say, 'I just tod you! I came from Barcelona!'",secondAction);
		menuController.addDialogTriggerAction (2,"Say, 'I live in Miami.'",thirdAction);
		menuController.addDialogTriggerAction (3,"Give the officer your boarding pass.",forthAction);
		menuController.addDialogTriggerAction (4,"Give the officer your Spanish driver's license.",fifthAction);
	}

	private void characterWaitsForPlayer() {}

	public override void atInit()
	{
		EventManager.startListening(Events.EventList.LEVEL_Activity_Completed, doChangeThisStateToFinished);
		Step = first;
		firstAction = new UnityAction (Optionrepeat);
		secondAction = new UnityAction (OptionBarcelona);
		thirdAction = new UnityAction (Optionmiami);
		forthAction = new UnityAction (OptionBoardingpass);
		fifthAction = new UnityAction (OptionDriverLicense);
	}

	public override void atEnd()
	{
		EventManager.stopListening(Events.EventList.LEVEL_Activity_Completed, doChangeThisStateToFinished);
	}

	public override void atPause()
	{
		characterManager.dialogScript.audioSource.Pause ();
	}

	public override void atReadyActiveState()
	{
		characterManager.dialogScript.audioSource.UnPause ();
	}
}
