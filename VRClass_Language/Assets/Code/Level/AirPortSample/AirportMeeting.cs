﻿using UnityEngine;
using System.Collections;

public class AirportMeeting : StateScript {

	public AudioClip[] dialogs;
	public int currentDialog;
	public GameObject guard;
	private DialogScript guardDialogScript;
	private CharacterAnimationReference characterAnimation;

	// Use this for initialization
	void Start () {
		guardDialogScript = guard.GetComponent<DialogScript>();
		characterAnimation = guard.GetComponent<CharacterAnimationReference> ();
	}

	// Update is called once per frame
	public override void atUpdate() {
		characterAnimation.setTalking ();
		if(!guardDialogScript.playUpdateDialog())
		{
			if (currentDialog < dialogs.Length)
			{
				EventManager.setNewDialogEvent(dialogs[currentDialog]);
				guardDialogScript.initDialog();
				currentDialog++;
			}
			else
			{
				characterAnimation.setTalking (false);
				doChangeThisStateToFinished();
			}
		}
	}

	public override void atInit()
	{
		currentDialog = 0;
		EventManager.setNewDialogEvent(dialogs[currentDialog]);
		currentDialog++;
		guardDialogScript.initDialog();
	}

	public override void atEnd()
	{
		//throw new NotImplementedException();
	}

	public override void atPause()
	{
		guardDialogScript.pauseDialog();
	}

	public override void atReadyActiveState()
	{
		guardDialogScript.continueDialog();
	}

}
