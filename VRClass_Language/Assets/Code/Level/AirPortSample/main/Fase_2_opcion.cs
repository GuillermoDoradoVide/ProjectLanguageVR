using UnityEngine;
using System.Collections;

public class Fase_2_opcion : StateScript {

	public GameObject[] options;
	public bool secondary;

	public AudioClip[] dialogs;
	public int currentDialog;
	public GameObject pet;
	private DialogScript petDialogScript;
	private CharacterAnimationReference characterAnimation;

	void Start()
	{
		petDialogScript = pet.GetComponent<DialogScript>();
		characterAnimation = pet.GetComponent<CharacterAnimationReference> ();
	}

	// Update is called once per frame
	public override void atUpdate()
	{
		if(!petDialogScript.playUpdateDialog())
		{
			if (currentDialog < dialogs.Length)
			{
				EventManager.setNewDialogEvent(dialogs[currentDialog]);
				petDialogScript.initDialog();
				currentDialog++;
			}
			else {
				characterAnimation.setTalking (false);
			}
		}
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
		characterAnimation.setTalking ();
		Invoke ("showOptions", 5);
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
