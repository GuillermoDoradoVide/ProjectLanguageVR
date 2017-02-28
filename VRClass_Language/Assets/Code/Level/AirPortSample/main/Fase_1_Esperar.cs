using UnityEngine;
using System.Collections;

public class Fase_1_Esperar : StateScript {

	public CharacterManager characterManager;
	public CharacterManager.CharacterState[] steps;

	void Start()
	{
		characterManager.animationReference.setTalking ();
		characterManager.setCharacterNextStates (steps);
	}

	// Update is called once per frame
	public override void atUpdate()
	{
		characterManager.doUpdate ();
		if (!characterManager.animationReference.getTalking()) {
				Invoke ("doChangeThisStateToFinished", 2);
				Invoke ("disableCharacter",4);
		}
	}

	public void setTalkingFalse() {
		characterManager.animationReference.setTalking (false);
	}

	private void disableCharacter() {
		characterManager.gameObject.SetActive (false);
	}
		
	public override void atInit()
	{
		EventManager.startListening(Events.EventList.LEVEL_Activity_Completed, doChangeThisStateToFinished);
		Invoke ("setTalkingFalse",4);
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
