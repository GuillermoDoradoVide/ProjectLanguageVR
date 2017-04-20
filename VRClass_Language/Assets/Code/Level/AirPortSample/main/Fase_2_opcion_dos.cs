﻿using UnityEngine;
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

	public void Optionagree() {
		characterManager.setDialogs (dialogsB);
		characterManager.setTalking ();
		CurrentStep = first;
	}

	public void Optionmiami() {
		characterManager.setDialogs (dialogsC);
		characterManager.setTalking ();
		CurrentStep = first;
	}

	public void OptionDC() {
		characterManager.setDialogs (dialogsD);
		characterManager.setTalking ();
		CurrentStep = first;
	}

	public void OptionBarcelona() {
		characterManager.setDialogs (dialogsE);
		characterManager.setTalking ();
		CurrentStep = final;
	}

	private void first() {
		if(!characterManager.isTalking()) {
			showFlyFromMenuOptions ();
			CurrentStep = characterWaitsForPlayer;
		}
	}

	private void final() {
		if(!characterManager.isTalking()) {
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
		CurrentStep = first;
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
//		characterManager.dialogScript.audioSource.Pause ();
	}

	public override void atReadyActiveState()
	{
//		characterManager.dialogScript.audioSource.UnPause ();
	}
}
