using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Fase_2_opcion_dos : StateScript {

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
		characterManager.doUpdate ();
		Step ();
	}

	public void Optionrepeat() {
		characterManager.setDialogs (dialogsA);
		characterManager.setTalking ();
		Step = first;
	}

	public void Optionagree() {
		characterManager.setDialogs (dialogsB);
		characterManager.setTalking ();
		Step = first;
	}

	public void Optionmiami() {
		characterManager.setDialogs (dialogsC);
		characterManager.setTalking ();
		Step = first;
	}

	public void OptionDC() {
		characterManager.setDialogs (dialogsD);
		characterManager.setTalking ();
		Step = first;
	}

	public void OptionBarcelona() {
		characterManager.setDialogs (dialogsE);
		characterManager.setTalking ();
		Step = final;
	}

	private void first() {
		if(!characterManager.animationReference.getTalking()) {
			showFlyFromMenuOptions ();
			Step = characterWaitsForPlayer;
		}
	}

	private void final() {
		if(!characterManager.animationReference.getTalking()) {
			doChangeThisStateToFinished ();
		}
	}

	private void showFlyFromMenuOptions() {
		menuController.addDialogTriggerAction (0,"Say, 'Sorry, I din't hear you. What was that?'",firstAction);
		menuController.addDialogTriggerAction (1,"Say, 'Yes! I totally agree!'",secondAction);
		menuController.addDialogTriggerAction (2,"Say, 'I flew in from Miami.'",thirdAction);
		menuController.addDialogTriggerAction (3,"Say, 'I'm going to Washington DC.'",forthAction);
		menuController.addDialogTriggerAction (4,"Say, 'I was on vacation in Barcelona.'",fifthAction);
	}

	private void characterWaitsForPlayer() {}

	public override void atInit()
	{
		EventManager.startListening(Events.EventList.LEVEL_Activity_Completed, doChangeThisStateToFinished);
		Step = first;
		firstAction = new UnityAction (Optionrepeat);
		secondAction = new UnityAction (Optionagree);
		thirdAction = new UnityAction (Optionmiami);
		forthAction = new UnityAction (OptionDC);
		fifthAction = new UnityAction (OptionBarcelona);
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
