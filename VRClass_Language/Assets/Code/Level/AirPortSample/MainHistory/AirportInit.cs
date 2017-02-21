using UnityEngine;
using System.Collections;

public class AirportInit : StateScript
{
	public GameObject guard;
	private DialogScript guardDialogScript;    // Use this for initialization
	private CharacterAnimationReference characterAnimation;
	public bool completed = false;
	private CharacterWaypointMovement characterMovement;
	private CharacterPivotMovement characterPivot;
	void Start()
	{
		characterAnimation = guard.GetComponentInChildren<CharacterAnimationReference> ();
		characterMovement = GetComponent<CharacterWaypointMovement> ();
		characterPivot = GetComponent<CharacterPivotMovement> ();
	}

	// Update is called once per frame
	public override void atUpdate()
	{
		if(!characterAnimation.characterAnimator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Walking")) {
			if (!characterPivot.finished) {
				characterPivot.rotateCharacter ();
			}else {
				characterAnimation.setWalking ();
			}
		}
		else {
			if(characterMovement.move ()) {
				characterAnimation.setWalking (false);
				completed = true;
			}
		}
		if (completed)
		{
			doChangeThisStateToFinished();
		}
	}

	public override void atInit()
	{
		EventManager.startListening(Events.EventList.LEVEL_Activity_Completed, completeTask);
	}

	public override void atEnd()
	{
		EventManager.stopListening(Events.EventList.LEVEL_Activity_Completed, completeTask);
	}

	public override void atPause()
	{
		//throw new NotImplementedException();
	}

	public override void atReadyActiveState()
	{
		//throw new NotImplementedException();
	}

	private void completeTask()
	{
		completed = true;
	}
}
