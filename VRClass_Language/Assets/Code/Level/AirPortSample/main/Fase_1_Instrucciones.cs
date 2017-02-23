using UnityEngine;
using System.Collections;

public class Fase_1_Instrucciones : StateScript {

	public Canvas instructions;

	void Start()
	{
	}

	// Update is called once per frame
	public override void atUpdate()
	{
		Invoke ("completeFase", 2);
	}

	private void completeFase() {

		instructions.enabled = false;
		doChangeThisStateToFinished ();
	}

	public override void atInit()
	{
		EventManager.startListening(Events.EventList.LEVEL_Activity_Completed, doChangeThisStateToFinished);
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
