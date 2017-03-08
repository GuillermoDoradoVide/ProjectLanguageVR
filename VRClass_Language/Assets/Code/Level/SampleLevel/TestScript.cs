using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class TestScript : StateScript {

	private InteractionMenuController interaction;
	private delegate void Steps();
	private Steps Step;
	private UnityAction dialogOptionA;
	private UnityAction dialogOptionB;

	void Start()
	{
		interaction = InteractionMenuController.Instance();
	}

	// Update is called once per frame
	public override void atUpdate()
	{
		Step ();
	}

	private void showInteractionMenu() {
		interaction.addDialogTriggerAction ("No estoy seguro...", dialogOptionB);
		interaction.addDialogTriggerAction ("*Dar pasaporte.", dialogOptionA);
		Step = waitPlayerAnswer;
	}

	private void waitPlayerAnswer() {
		
	}

	private void goodAnswer() {
		Debug.Log ("Good answer!");
	}

	private void badAnswer() {
		Debug.Log ("Bad answer!");
	}

	public override void atInit()
	{
		Step = showInteractionMenu;
		dialogOptionA = new UnityAction (goodAnswer);
		dialogOptionB = new UnityAction (badAnswer);
		//throw new NotImplementedException();
	}

	public override void atEnd()
	{
		//throw new NotImplementedException();
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
