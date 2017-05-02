using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Fase3_pregunta4 : StateScript {

	public InteractionMenuController menuController;
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

	public void OptionAgentBackpack() {
		characterManager.setDialogs (dialogsB);
		characterManager.setTalking ();
		CurrentStep = first;
	}

	public void OptionGreatness() {
		characterManager.setDialogs (dialogsC);
		characterManager.setTalking ();
		CurrentStep = first;
	}

	public void OptionMedicalConf() {
		characterManager.setDialogs (dialogsD);
		characterManager.setTalking ();
		CurrentStep = first;
	}

	public void OptionNope() {
		characterManager.setDialogs (dialogsE);
		characterManager.setTalking ();
        menuController.resetOptionStates();
        CurrentStep = final;
	}

	private void first() {
		if(!characterManager.animationReference.getTalking()) {
			showPlayerAdessMenuOptions ();
			CurrentStep = characterWaitsForPlayer;
		}
	}

	private void final() {
		if(!characterManager.animationReference.getTalking()) {
			doChangeThisStateToFinished ();
		}
	}

	private void showPlayerAdessMenuOptions() {
		menuController.addDialogTriggerAction (0,"Oh, sorry. I wasn't listening.",firstAction);
		menuController.addDialogTriggerAction (1,"Say, 'My backpack is full of super cool secret agent gadgets. Do i need to declare those?'",secondAction);
		menuController.addDialogTriggerAction (2,"Say, 'Only my greatness.'",thirdAction);
		menuController.addDialogTriggerAction (3, "I declare that I am on my way to a medical conference.", forthAction);
		menuController.addDialogTriggerAction (4,"Nope. Nothing to declare.",fifthAction);
	}

	private void characterWaitsForPlayer() {}

	public override void atInit()
	{
		EventManager.startListening(Events.EventList.LEVEL_Activity_Completed, doChangeThisStateToFinished);
		CurrentStep = first;
		firstAction = new UnityAction (Optionrepeat);
		secondAction = new UnityAction (OptionAgentBackpack);
		thirdAction = new UnityAction (OptionGreatness);
		forthAction = new UnityAction (OptionMedicalConf);
		fifthAction = new UnityAction (OptionNope);
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
