using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Fase_2_pregunta : StateScript {
	public InteractionMenuController menuController;
	public Transform menuPosition;
	public CharacterManager characterManager;
	public AudioClip[] dialogs;
	public AudioClip[] dialogs2;
	public AudioClip[] dialogs3;
	public AudioClip[] dialogs4;
	public AudioClip[] dialogs5;
	public AudioClip[] dialogs6;

	public UnityAction firstAction;
	public UnityAction secondAction;
	public UnityAction thirdAction;
	public UnityAction forthAction;
	public UnityAction fifthAction;

    void Start()
	{
	}

	// Update is called once per frame
	public override void atUpdate()
	{
		//characterManager.doUpdate ();
		CurrentStep ();
	}
		
	public void OptionrepeatQuestion() {
		characterManager.setDialogs (dialogs3);
		characterManager.setTalking ();
		CurrentStep = first;
	}

	public void OptiontellAboutBarcelona() {
		characterManager.setDialogs (dialogs4);
		characterManager.setTalking ();
		CurrentStep = first;
	}

	public void OptiongiveBoardingPass() {
		characterManager.setDialogs (dialogs5);
		characterManager.setTalking ();
		CurrentStep = first;
	}

	public void OptionhightFive() {
		characterManager.setDialogs (dialogs6);
		characterManager.setTalking ();
		CurrentStep = first;
	}

	public void OptiongivePassPort() {
		characterManager.characterAnimator.SetTrigger ("Pick");
		Invoke ("askName", 3);
	}

	public void askName() {
		characterManager.setDialogs (dialogs2);
		characterManager.setTalking ();
		CurrentStep = final;
	}

	private void showMenuGivePassPort() {
		menuController.addDialogTriggerAction (0,"Say, 'Could you repeat the question?'",firstAction);
		menuController.addDialogTriggerAction (1,"Say, 'I was on vacation in Barcelona.'",secondAction);
		menuController.addDialogTriggerAction (2,"Hand the officer your passport.",thirdAction);
		menuController.addDialogTriggerAction (3,"Hand the officer your boarding pass.",forthAction);
		menuController.addDialogTriggerAction (4,"High-five the officer.",fifthAction);
	}

	private void first() {
		if(!characterManager.isTalking()) {
			showMenuGivePassPort ();
			CurrentStep = characterWaitsForPlayer;
		}
	}

	private void final() {
		if(!characterManager.isTalking()) {
			doChangeThisStateToFinished ();
		}
	}

	private void characterWaitsForPlayer() {
	}

	public override void atInit()
	{
		EventManager.startListening(Events.EventList.LEVEL_Activity_Completed, doChangeThisStateToFinished);
		characterManager.setDialogs (dialogs);
		characterManager.setTalking ();
		menuController.movePanelTo (menuPosition);
		firstAction = new UnityAction (OptionrepeatQuestion);
		secondAction = new UnityAction (OptiontellAboutBarcelona);
		thirdAction = new UnityAction (OptiongivePassPort);
		forthAction = new UnityAction (OptiongiveBoardingPass);
		fifthAction = new UnityAction (OptionhightFive);
		CurrentStep = first;
        EventManager.startListening(Events.EventList.NPC_DIALOG_FINISHED, showMenuGivePassPort);
    }

	public override void atEnd()
	{
		EventManager.stopListening(Events.EventList.LEVEL_Activity_Completed, doChangeThisStateToFinished);
        EventManager.stopListening(Events.EventList.NPC_DIALOG_FINISHED, showMenuGivePassPort);
    }

	public override void atPause()
	{
//		characterManager.dialogScript.audioSource.Pause ();
	}

	public override void atReadyActiveState()
	{
//		characterManager.dialogScript.audioSource.UnPause ();
	}
}
