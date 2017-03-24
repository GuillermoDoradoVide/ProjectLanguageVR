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

	private IEnumerator contactWithBriefing() {
		yield return new WaitForSeconds (1);
		SoundManager.playSFX (incomingCall);
		Debug.Log ("CONTACT");
		yield return  new WaitForSeconds (incomingCall.length);
		Debug.Log ("END");
		Step = makeContact;
	}

	private void makeContact() {
			SoundManager.playSFX (staticOn);
			playerSource.Play ();
			Step = final;
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
		Step = characterWaitsForPlayer;
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
