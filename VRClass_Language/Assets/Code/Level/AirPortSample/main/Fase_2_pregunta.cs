﻿using UnityEngine;
using System.Collections;

public class Fase_2_pregunta : StateScript {
	public GameObject options;
	public CharacterManager characterManager;
	public AudioClip[] dialogs;
	public AudioClip[] dialogs2;
	public AudioClip[] dialogs3;
	public AudioClip[] dialogs4;
	public AudioClip[] dialogs5;
	public AudioClip[] dialogs6;

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
		
	public void repeatQuestion() {
		characterManager.setDialogs (dialogs3);
		characterManager.setTalking ();
		//Step = first;
	}

	public void tellAboutBarcelona() {
		characterManager.setDialogs (dialogs4);
		characterManager.setTalking ();
		//Step = first;
	}

	public void giveBoardingPass() {
		characterManager.setDialogs (dialogs5);
		characterManager.setTalking ();
		//Step = first;
	}

	public void hightFive() {
		characterManager.setDialogs (dialogs6);
		characterManager.setTalking ();
		//Step = first;
	}

	public void givePassPort() {
		characterManager.characterAnimator.SetTrigger ("Pick");
		Invoke ("askName", 3);
	}

	public void askName() {
		characterManager.setDialogs (dialogs2);
		characterManager.setTalking ();
		Step = third;
	}

	private void first() {
		if(!characterManager.animationReference.getTalking()) {
			options.SetActive (true);
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
