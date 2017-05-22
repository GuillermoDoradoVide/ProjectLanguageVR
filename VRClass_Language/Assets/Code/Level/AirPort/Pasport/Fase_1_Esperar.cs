using UnityEngine;
using System.Collections;

public class Fase_1_Esperar : StateScript {

	public CharacterManager characterManager;
	public CharacterManager.CharacterState[] stepsA;
	public CharacterManager characterManagerOfficer;
	public AudioClip[] nextPlease;

	void Start()
	{
		characterManager.animationReference.setTalking ();
	}

	public override void atUpdate()
	{
		CurrentStep();
	}

	public void setTalkingFalse() {
		characterManager.animationReference.setTalking (false);
	}

	private void disableCharacter() {
        characterManager.disableCharacter();
        characterManager.gameObject.SetActive (false);
		doChangeThisStateToFinished ();
	}

	private void first() {
		if (!characterManager.isTalking()) {
			Invoke ("disableCharacter", 3);
			characterManagerOfficer.setWaitTalking (4, 2);
            CurrentStep = second;
        }
	}

	private void second() {}

	public override void atInit()
	{
		EventManager.startListening(Events.EventList.LEVEL_Activity_Completed, doChangeThisStateToFinished);
		Invoke ("setTalkingFalse", 4);
		characterManagerOfficer.activeCharacter();
        characterManager.activeCharacter();
		characterManagerOfficer.setDialogs (nextPlease);
        characterManager.setCharacterNextStates (stepsA);
		CurrentStep = first;
	}

	public override void atEnd()
	{
		EventManager.stopListening(Events.EventList.LEVEL_Activity_Completed, doChangeThisStateToFinished);
	}

	public override void atPause()
	{
//		characterManagerOfficer.dialogScript.audioSource.Pause ();
	}

	public override void atReadyActiveState()
	{
//		characterManagerOfficer.dialogScript.audioSource.UnPause ();
	}
}
