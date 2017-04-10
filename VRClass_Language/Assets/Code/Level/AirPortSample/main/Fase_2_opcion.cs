using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Fase_2_opcion : StateScript {
	public InteractionMenuController menuController;
	public bool secondary;

	public AudioClip[] dialogsA;
	public AudioClip[] dialogsB;
	public AudioClip[] dialogsC;
	public AudioClip[] dialogsD;
	public AudioClip[] dialogsE;
	public CharacterManager characterManager;

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
		CurrentStep ();
	}

	public void Optionrepeat() {
		characterManager.setDialogs (dialogsA);
		characterManager.setTalking ();
		CurrentStep = first;
	}

	public void OptionSayName() {
		characterManager.setDialogs (dialogsB);
		characterManager.setTalking ();
		CurrentStep = final;
	}

	public void OptionSaySpecialAgent() {
		characterManager.setDialogs (dialogsC);
		characterManager.setTalking ();
		CurrentStep = first;
	}

	public void OptionSaySpanish() {
		characterManager.setDialogs (dialogsD);
		characterManager.setTalking ();
		CurrentStep = first;
	}

	public void OptionSayFromFlorida() {
		characterManager.setDialogs (dialogsE);
		characterManager.setTalking ();
		CurrentStep = first;
	}

	private void showTellnameMenuOptions() {
		menuController.addDialogTriggerAction (0,"Say, 'Can you repeat that?'",firstAction);
		menuController.addDialogTriggerAction (1,"Say, 'I'm Dr.Francis.'",secondAction);
		menuController.addDialogTriggerAction (2,"Say, 'I'm Special Agent Francis.'",thirdAction);
		menuController.addDialogTriggerAction (3,"Say, 'I'm Spanish'",forthAction);
		menuController.addDialogTriggerAction (4,"Say, 'I'm from Florida.'",fifthAction);
	}

	private void first() {
		if(!characterManager.animationReference.getTalking()) {
			showTellnameMenuOptions ();
			CurrentStep = characterWaitsForPlayer;
		}
	}

	private void characterWaitsForPlayer() {}

	private void final() {
		if(!characterManager.animationReference.getTalking()) {
			doChangeThisStateToFinished ();
		}
	}

	public override void atInit()
	{
		EventManager.startListening(Events.EventList.LEVEL_Activity_Completed, doChangeThisStateToFinished);
		CurrentStep = first;
		firstAction = new UnityAction (Optionrepeat);
		secondAction = new UnityAction (OptionSayName);
		thirdAction = new UnityAction (OptionSaySpecialAgent);
		forthAction = new UnityAction (OptionSaySpanish);
		fifthAction = new UnityAction (OptionSayFromFlorida);
	}

	public override void atEnd()
	{
		EventManager.stopListening(Events.EventList.LEVEL_Activity_Completed, doChangeThisStateToFinished);
	}

	public override void atPause()
	{
//		characterManager.dialogScript.audioSource.Pause ();
	}

	public override void atReadyActiveState()
	{
//		characterManager.dialogScript.audioSource.UnPause ();
	}
}
