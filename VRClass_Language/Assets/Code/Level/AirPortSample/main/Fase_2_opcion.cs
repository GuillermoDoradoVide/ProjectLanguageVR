﻿using UnityEngine;
using System.Collections;

public class Fase_2_opcion : StateScript {

	public GameObject option;
	public bool secondary;

	public AudioClip[] dialogsA;
	public AudioClip[] dialogsB;
	public AudioClip[] dialogsC;
	public AudioClip[] dialogsD;
	public AudioClip[] dialogsE;
	public CharacterManager characterManager;

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

	public void repeat() {
		characterManager.setDialogs (dialogsA);
		characterManager.setTalking ();
	}

	public void SayName() {
		characterManager.setDialogs (dialogsB);
		characterManager.setTalking ();
		Step = second;
	}

	public void SaySpecialAgent() {
		characterManager.setDialogs (dialogsC);
		characterManager.setTalking ();
	}

	public void SaySpanish() {
		characterManager.setDialogs (dialogsD);
		characterManager.setTalking ();
	}

	public void SayFromFlorida() {
		characterManager.setDialogs (dialogsE);
		characterManager.setTalking ();
	}

	private void first() {
	}

	private void second() {
		if(!characterManager.animationReference.getTalking()) {
			doChangeThisStateToFinished ();
		}
	}

	private void showOptions() {
		option.SetActive (true);
	}

	public override void atInit()
	{
		EventManager.startListening(Events.EventList.LEVEL_Activity_Completed, doChangeThisStateToFinished);
		Step = first;
		Invoke ("showOptions", 2);
	}

	public override void atEnd()
	{
		EventManager.stopListening(Events.EventList.LEVEL_Activity_Completed, doChangeThisStateToFinished);
		option.SetActive (false);
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
