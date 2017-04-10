using UnityEngine;
using System.Collections;

public class Final_Seccion : StateScript {

	public InteractionMenuController menuController;
	public AudioClip incomingCall;
	public AudioClip staticOn;

	public AudioSource playerSource;
	public AudioClip congratulations;

	void Start()
	{
	}

	// Update is called once per frame
	public override void atUpdate()
	{
		CurrentStep ();
	}

	private IEnumerator contactWithBriefing() {
		yield return new WaitForSeconds (1);
		SoundManager.playSFX (incomingCall);
		Debugger.printLog ("CONTACT");
		yield return  new WaitForSeconds (incomingCall.length);
		Debugger.printLog ("END");
		CurrentStep = makeContact;
	}

	private void makeContact() {
			SoundManager.playSFX (staticOn);
			playerSource.Play ();
		CurrentStep = final;
	}

	private void final() {
		if (!playerSource.isPlaying) {
			SoundManager.playSFX (staticOn);
			doChangeThisStateToFinished ();
		}	
	}
		
	private void characterWaitsForPlayer() {}

	public override void atInit()
	{
		CurrentStep = characterWaitsForPlayer;
		StartCoroutine (contactWithBriefing());
		EventManager.startListening (Events.EventList.LEVEL_Activity_Completed, doChangeThisStateToFinished);
		playerSource.clip = congratulations;
	}

	public override void atEnd()
	{
		EventManager.stopListening(Events.EventList.LEVEL_Activity_Completed, doChangeThisStateToFinished);
	}

	public override void atPause()
	{
		playerSource.Pause ();
	}

	public override void atReadyActiveState()
	{
		playerSource.UnPause ();
	}
}
