using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class FirstIteration  : StateScript {
	public CharacterManager characterManager;
	public CharacterManager.CharacterState[] stepsA;

	private delegate void Steps();
	private Steps Step;

	public InteractionMenuController menuController;
	public UnityAction firstAction;
	public UnityAction secondAction;

	void Start()
	{
	}

	// Update is called once per frame
	public override void atUpdate()
	{
		Step ();
	}

	private void repeatPlease() {
		
	}

	private void Answer() {

	}

	private void showOptionPanel() {
		Debug.Log ("show panel...");
		menuController.addDialogTriggerAction (0,"Say, 'Could you repeat the question?'", firstAction);
		menuController.addDialogTriggerAction (1,"Say, 'I was on vacation in Barcelona.'", secondAction);
	}

	private void first() {
		showOptionPanel ();
		Step = waitForPlayer;
	}

	private void waitForPlayer() {
		
	}

	public override void atInit()
	{
		EventManager.startListening(Events.EventList.LEVEL_Activity_Completed, doChangeThisStateToFinished);
		firstAction = new UnityAction (repeatPlease);
		secondAction = new UnityAction (Answer);
		Step = first;
	}

	public override void atEnd()
	{
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