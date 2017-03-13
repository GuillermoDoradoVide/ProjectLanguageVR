﻿using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Fase3_pregunta_2 : StateScript {

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

	public void OptionSecretAgent() {
		characterManager.setDialogs (dialogsB);
		characterManager.setTalking ();
		Step = first;
	}

	public void OptioDC() {
		characterManager.setDialogs (dialogsC);
		characterManager.setTalking ();
		Step = first;
	}

	public void OptionLoveMiami() {
		characterManager.setDialogs (dialogsD);
		characterManager.setTalking ();
		Step = first;
	}

	public void OptionMedicalConference() {
		characterManager.setDialogs (dialogsE);
		characterManager.setTalking ();
		Step = final;
	}

	private void first() {
		if(!characterManager.animationReference.getTalking()) {
			showPlayerAdessMenuOptions ();
			Step = characterWaitsForPlayer;
		}
	}

	private void final() {
		if (!characterManager.animationReference.getTalking ()) {
			doChangeThisStateToFinished ();
		}
	}

	private void showPlayerAdessMenuOptions() {
		menuController.addDialogTriggerAction (0,"Say, 'Sorry, I didn't catch that last part.",firstAction);
		menuController.addDialogTriggerAction (1,"Say, 'I'm a secret agent. I've been sent here by a shadowy agency even I don't understand.'",secondAction);
		menuController.addDialogTriggerAction (2,"Say, 'Yeah, I'm heading to DC.'",thirdAction);
		menuController.addDialogTriggerAction (3,"I love Miami!",forthAction);
		menuController.addDialogTriggerAction (4,"I'm heading to a medical conference.",fifthAction);
	}

	private void characterWaitsForPlayer() {}

	public override void atInit()
	{
		EventManager.startListening(Events.EventList.LEVEL_Activity_Completed, doChangeThisStateToFinished);
		Step = first;
		firstAction = new UnityAction (Optionrepeat);
		secondAction = new UnityAction (OptionSecretAgent);
		thirdAction = new UnityAction (OptioDC);
		forthAction = new UnityAction (OptionLoveMiami);
		fifthAction = new UnityAction (OptionMedicalConference);
	}

	public override void atEnd()
	{
		EventManager.stopListening(Events.EventList.LEVEL_Activity_Completed, doChangeThisStateToFinished);
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
