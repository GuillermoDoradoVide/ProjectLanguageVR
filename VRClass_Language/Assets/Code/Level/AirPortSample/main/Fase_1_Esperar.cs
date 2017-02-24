using UnityEngine;
using System.Collections;

public class Fase_1_Esperar : StateScript {

	public characterManager characterManager;

	void Start()
	{
	}

	// Update is called once per frame
	public override void atUpdate()
	{
		characterManager.move = true;
		if (characterManager.pivot.finished) {
			characterManager.animator.SetBool ("Walking", true);
			Invoke ("doChangeThisStateToFinished", 2);
		}
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
