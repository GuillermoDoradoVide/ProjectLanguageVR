using UnityEngine;
using System.Collections;

public class Fase_2_pregunta : StateScript {
	public GameObject options;
	public Animator animator;
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
				if(!options.activeInHierarchy) {
					options.SetActive (true);
				}
			}
		}
	}

	public void givePassPort() {
		animator.SetTrigger ("Pick");
		Invoke ("doChangeThisStateToFinished", 6);
	}

	public override void atInit()
	{
		EventManager.startListening(Events.EventList.LEVEL_Activity_Completed, doChangeThisStateToFinished);
		characterAnimation.setTalking (true);
	}

	public override void atEnd()
	{
		EventManager.stopListening(Events.EventList.LEVEL_Activity_Completed, doChangeThisStateToFinished);
		options.SetActive (false);
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
