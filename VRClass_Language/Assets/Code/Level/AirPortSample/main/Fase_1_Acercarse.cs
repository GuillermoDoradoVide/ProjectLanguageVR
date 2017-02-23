using UnityEngine;
using System.Collections;

public class Fase_1_Acercarse : StateScript {
	public Transform player;
	public Transform teleportLocation;
	public bool start = false;

	void Start()
	{
	}

	// Update is called once per frame
	public override void atUpdate()
	{
		if (GvrController.AppButtonDown) {
			EventManager.teleportPlayerToPosition (teleportLocation);
		}
		if (start) {
			doChangeThisStateToFinished ();
		}
	}

	public override void atInit()
	{
		EventManager.startListening(Events.EventList.LEVEL_Activity_Completed, doChangeThisStateToFinished);
		teleportLocation.gameObject.SetActive (true);
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
