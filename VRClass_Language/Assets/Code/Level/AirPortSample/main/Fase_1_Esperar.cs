using UnityEngine;
using System.Collections;

public class Fase_1_Esperar : StateScript {

	public CharacterManager characterManager;
	public CharacterManager.CharacterState[] stepsA;

	private delegate void Steps();
	private Steps Step;

	void Start()
	{
		characterManager.animationReference.setTalking ();
	}

	// Update is called once per frame
	public override void atUpdate()
	{
		characterManager.doUpdate ();
		Step ();
	}

	public void setTalkingFalse() {
		characterManager.animationReference.setTalking (false);
	}

	private void disableCharacter() {
		characterManager.gameObject.SetActive (false);
	}

	private void first() {
		if (!characterManager.animationReference.getTalking()) {
			Invoke ("doChangeThisStateToFinished", 2);
			Invoke ("disableCharacter", 4);
		}
	}

	public override void atInit()
	{
		EventManager.startListening(Events.EventList.LEVEL_Activity_Completed, doChangeThisStateToFinished);
		Invoke ("setTalkingFalse", 4);
		characterManager.setCharacterNextStates (stepsA);
		Step = first;
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
