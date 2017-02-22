using UnityEngine;
using System.Collections;

public class AirportEnd : StateScript {

	public GameObject guard;
	private CharacterAnimationReference characterAnimation;
	public bool completed = false;

	private CharacterWaypointMovement characterMovement;

	void Start()
	{
		characterAnimation = guard.GetComponentInChildren<CharacterAnimationReference> ();
		characterMovement = GetComponent<CharacterWaypointMovement> ();
	}

	// Update is called once per frame
	public override void atUpdate()
	{
		if (characterMovement.move ()) {
			characterAnimation.setWalking (false);
			completed = true;
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
