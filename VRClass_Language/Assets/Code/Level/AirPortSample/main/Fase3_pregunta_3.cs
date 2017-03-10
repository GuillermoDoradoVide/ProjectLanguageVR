using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Fase3_pregunta_3 : StateScript {

	public InteractionMenuController menuController;
	public AudioClip[] dialogsA;
	public AudioClip[] dialogsB;
	public AudioClip[] dialogsC;
	public AudioClip[] dialogsD;
	public AudioClip[] dialogsE;
	public CharacterManager characterManager;

	private delegate void Steps();
	private Steps Step;

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
		characterManager.doUpdate ();
		Step ();
	}

	public void Optionrepeat() {
		characterManager.setDialogs (dialogsA);
		characterManager.setTalking ();
		Step = first;
	}

	public void OptionNotThatDoctor() {
		characterManager.setDialogs (dialogsB);
		characterManager.setTalking ();
		Step = final;
	}

	public void OptionGross() {
		characterManager.setDialogs (dialogsC);
		characterManager.setTalking ();
		Step = first;
	}

	public void OptionNotDocAgent() {
		characterManager.setDialogs (dialogsD);
		characterManager.setTalking ();
		Step = first;
	}

	public void OptionWereParrotLegendContinues() {
		characterManager.setDialogs (dialogsE);
		characterManager.setTalking ();
		Step = first;
	}

	private void first() {
		showPlayerAdessMenuOptions ();
		Step = characterWaitsForPlayer;
	}

	private void final() {
		if(!characterManager.animationReference.getTalking()) {
			doChangeThisStateToFinished ();
		}
	}

	private void showPlayerAdessMenuOptions() {
		menuController.addDialogTriggerAction (0,"Say, 'Wait, what?",firstAction);
		menuController.addDialogTriggerAction (1,"Say, 'I'm not that kind of doctor.'",secondAction);
		menuController.addDialogTriggerAction (2,"Say, 'Ew! Gross! What is wrong with you? I don't want to look at your disgusting back mole!'",thirdAction);
		menuController.addDialogTriggerAction (3, "I'm not a doctor! I'm a secret agent! I can't help you with your medical problems!", forthAction);
		menuController.addDialogTriggerAction (4,"You're definitely turning into a were-parrot. It's like a werewolf, except you turn into a giant bloodthirsty parrot.",fifthAction);
	}

	private void characterWaitsForPlayer() {}

	public override void atInit()
	{
		EventManager.startListening(Events.EventList.LEVEL_Activity_Completed, doChangeThisStateToFinished);
		Step = first;
		firstAction = new UnityAction (Optionrepeat);
		secondAction = new UnityAction (OptionNotThatDoctor);
		thirdAction = new UnityAction (OptionGross);
		forthAction = new UnityAction (OptionNotDocAgent);
		fifthAction = new UnityAction (OptionWereParrotLegendContinues);
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
