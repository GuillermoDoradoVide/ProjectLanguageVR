using UnityEngine;
using System.Collections;

public class Final_Seccion : StateScript {

	public InteractionMenuController menuController;
	public AudioClip incomingCall;
	public AudioClip staticOn;

	private delegate void Steps();
	private Steps Step;

	public AudioSource playerSource;
	public AudioClip congratulations;

	void Start()
	{
	}

	// Update is called once per frame
	public override void atUpdate()
	{
		Step ();
	}

	private void contactWithBriefing() {
		SoundManager.Instance.playSingleSFXSound (incomingCall);
		Step = makeContact;
	}

	private void makeContact() {
		if(!SoundManager.Instance.getSfxSoundFinished()) {
			SoundManager.Instance.playSingleSFXSound (staticOn);
			playerSource.Play ();
			Step = final;
		}
	}

	private void final() {
		if (!playerSource.isPlaying) {
			SoundManager.Instance.playSingleSFXSound (staticOn);
			doChangeThisStateToFinished ();
		}	
	}
		
	private void characterWaitsForPlayer() {}

	public override void atInit()
	{
		Step = characterWaitsForPlayer;
		Invoke("contactWithBriefing", 2);
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
