using UnityEngine;
using System.Collections;

public class Fase_2_pregunta : StateScript {
	public GameObject options;
	public CharacterManager characterManager;
	public AudioClip[] dialogs;

	void Start()
	{
	}

	// Update is called once per frame
	public override void atUpdate()
	{
		characterManager.doUpdate ();
		if(!characterManager.talk ()) {
			if(!characterManager.animationReference.getTalking()) {
				options.SetActive (true);
			}
		}
	}

	public void givePassPort() {
		characterManager.characterAnimator.SetTrigger ("Pick");
		Invoke ("doChangeThisStateToFinished", 9);
	}

	public override void atInit()
	{
		EventManager.startListening(Events.EventList.LEVEL_Activity_Completed, doChangeThisStateToFinished);
		//characterManager.animationReference.setTalking ();
		characterManager.setDialogs (dialogs);
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
