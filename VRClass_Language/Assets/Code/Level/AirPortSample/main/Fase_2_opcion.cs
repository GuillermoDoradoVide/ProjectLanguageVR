using UnityEngine;
using System.Collections;

public class Fase_2_opcion : StateScript {

	public GameObject[] options;
	public bool secondary;

	public AudioClip[] dialogs;
	public CharacterManager characterManager;

	void Start()
	{
	}

	// Update is called once per frame
	public override void atUpdate()
	{
		characterManager.doUpdate ();
		if (secondary) {
			Invoke ("doChangeThisStateToFinished", 3);
		}
	}
	public void answer() {
		secondary = true;
	}

	private void showOptions() {
		foreach(GameObject menuOption in options) {
			menuOption.SetActive (true);
		}
	}

	public override void atInit()
	{
		EventManager.startListening(Events.EventList.LEVEL_Activity_Completed, doChangeThisStateToFinished);
		characterManager.setDialogs (dialogs);
		characterManager.setTalking ();
		Invoke ("showOptions", 7);
	}

	public override void atEnd()
	{
		EventManager.stopListening(Events.EventList.LEVEL_Activity_Completed, doChangeThisStateToFinished);
		foreach(GameObject menuOption in options) {
			menuOption.SetActive (false);
		}
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
