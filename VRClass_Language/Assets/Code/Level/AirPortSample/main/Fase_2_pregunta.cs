using UnityEngine;
using System.Collections;

public class Fase_2_pregunta : StateScript {
	public GameObject options;
	public CharacterManager characterManager;
	public AudioClip[] dialogs;

	private delegate void Steps();
	private Steps Step;

	void Start()
	{
	}

	// Update is called once per frame
	public override void atUpdate()
	{
		characterManager.doUpdate ();
		Step ();
	}

	public void givePassPort() {
		characterManager.characterAnimator.SetTrigger ("Pick");
		Invoke ("doChangeThisStateToFinished", 9);
	}

	private void first() {
		if(!characterManager.animationReference.getTalking()) {
			options.SetActive (true);
			Step = second;
		}
	}

	private void second () {
		
	}

	public override void atInit()
	{
		EventManager.startListening(Events.EventList.LEVEL_Activity_Completed, doChangeThisStateToFinished);
		characterManager.setDialogs (dialogs);
		characterManager.setTalking ();
		Step = first;
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
