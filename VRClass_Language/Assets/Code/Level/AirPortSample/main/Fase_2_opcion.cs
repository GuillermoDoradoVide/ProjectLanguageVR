using UnityEngine;
using System.Collections;

public class Fase_2_opcion : StateScript {

	public GameObject[] options;
	public bool secondary;

	void Start()
	{
	}

	// Update is called once per frame
	public override void atUpdate()
	{
		if (secondary) {
			
		}
	}

	private void showOptions() {
		foreach(GameObject menuOption in options) {
			menuOption.SetActive (true);
		}
	}

	public override void atInit()
	{
		EventManager.startListening(Events.EventList.LEVEL_Activity_Completed, doChangeThisStateToFinished);
		Invoke ("showOptions", 2);
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
