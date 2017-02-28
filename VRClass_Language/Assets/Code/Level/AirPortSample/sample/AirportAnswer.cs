using UnityEngine;
using System.Collections;

public class AirportAnswer : StateScript {

	public AudioClip[] dialogs;
	public int currentDialog;
	public GameObject guard;
	private DialogScript guardDialogScript;
	private CharacterAnimationReference characterAnimation;
	private CharacterPivotMovement characterPivot;

	// Use this for initialization
	void Start () {
		guardDialogScript = guard.GetComponent<DialogScript>();
		characterAnimation = guard.GetComponent<CharacterAnimationReference> ();
		characterPivot = GetComponent<CharacterPivotMovement> ();
	}

	// Update is called once per frame
	public override void atUpdate() {
		if(!guardDialogScript.playUpdateDialog())
		{
			if (currentDialog < dialogs.Length)
			{
				//EventManager.setNewDialogEvent(dialogs[currentDialog]);
				guardDialogScript.initDialog();
				currentDialog++;
			} else
			{
				if (characterAnimation.characterAnimator.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.Idle.Idle0")) {
					if (!characterPivot.finished) {
						characterPivot.rotateCharacter ();
					} else {
						characterAnimation.setWalking ();
						doChangeThisStateToFinished();
					}
				}
			}
		}
	}

	public override void atInit()
	{
		currentDialog = 0;
		//EventManager.setNewDialogEvent(dialogs[currentDialog]);
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
