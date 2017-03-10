﻿using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Fase_2_pregunta : StateScript {
	public InteractionMenuController menuController;
	public Transform menuPosition;
	public GameObject options;
	public CharacterManager characterManager;
	public AudioClip[] dialogs;
	public AudioClip[] dialogs2;
	public AudioClip[] dialogs3;
	public AudioClip[] dialogs4;
	public AudioClip[] dialogs5;
	public AudioClip[] dialogs6;

	public UnityAction firstAction;
	public UnityAction secondAction;
	public UnityAction thirdAction;
	public UnityAction forthAction;
	public UnityAction fifthAction;

	private delegate void Steps();
	private Steps Step;

	void Start()
	{
	}

	// Update is called once per frame
	public override void atUpdate()
	{
		characterManager.doUpdate ();
		Step ();
	}
		
	public void OptionrepeatQuestion() {
		characterManager.setDialogs (dialogs3);
		characterManager.setTalking ();
		Step = first;
	}

	public void OptiontellAboutBarcelona() {
		characterManager.setDialogs (dialogs4);
		characterManager.setTalking ();
		Step = first;
	}

	public void OptiongiveBoardingPass() {
		characterManager.setDialogs (dialogs5);
		characterManager.setTalking ();
		Step = first;
	}

	public void OptionhightFive() {
		characterManager.setDialogs (dialogs6);
		characterManager.setTalking ();
		Step = first;
	}

	public void OptiongivePassPort() {
		characterManager.characterAnimator.SetTrigger ("Pick");
		Invoke ("askName", 3);
	}

	public void askName() {
		characterManager.setDialogs (dialogs2);
		characterManager.setTalking ();
		Step = third;
	}

	private void showMenuGivePassPort() {
		menuController.addDialogTriggerAction (0,"Say, 'Could you repeat the question?'",firstAction);
		menuController.addDialogTriggerAction (1,"Say, 'I was on vacation in Barcelona.'",secondAction);
		menuController.addDialogTriggerAction (2,"Hand the officer your passport.",thirdAction);
		menuController.addDialogTriggerAction (3,"Hand the officer your boarding pass.",forthAction);
		menuController.addDialogTriggerAction (4,"High-five the officer.",fifthAction);
	}

	private void first() {
		if(!characterManager.animationReference.getTalking()) {
			showMenuGivePassPort ();
			Step = second;
		}
	}

	private void second () {
		
	}

	private void third() {
		if(!characterManager.animationReference.getTalking()) {
			doChangeThisStateToFinished ();
		}
	}

	public override void atInit()
	{
		EventManager.startListening(Events.EventList.LEVEL_Activity_Completed, doChangeThisStateToFinished);
		characterManager.setDialogs (dialogs);
		characterManager.setTalking ();
		menuController.movePanelTo (menuPosition);
		firstAction = new UnityAction (OptionrepeatQuestion);
		secondAction = new UnityAction (OptiontellAboutBarcelona);
		thirdAction = new UnityAction (OptiongivePassPort);
		forthAction = new UnityAction (OptiongiveBoardingPass);
		fifthAction = new UnityAction (OptionhightFive);
		Step = first;
	}

	public override void atEnd()
	{
		EventManager.stopListening(Events.EventList.LEVEL_Activity_Completed, doChangeThisStateToFinished);
		options.SetActive (false);
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
