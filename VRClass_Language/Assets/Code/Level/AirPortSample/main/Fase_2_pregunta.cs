using UnityEngine;
using System.Collections;

public class Fase_2_pregunta : StateScript {
	public GameObject options;
	void Start()
	{
	}

	// Update is called once per frame
	public override void atUpdate()
	{
		options.SetActive (true);
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
