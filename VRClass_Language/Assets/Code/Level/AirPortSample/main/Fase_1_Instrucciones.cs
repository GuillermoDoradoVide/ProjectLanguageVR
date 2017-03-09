using UnityEngine;
using System.Collections;

public class Fase_1_Instrucciones : StateScript
{

	public Canvas instructions;

	private delegate void Steps ();

	private Steps Step;
	public AudioClip introduction;
	public AudioClip introduction2;
	public AudioClip introduction3;
	public AudioClip incomingCall;
	public AudioClip staticOn;
	public AudioSource playerSource;

	private Vector3[] angles;
	private int index;
	private Vector3 centerAngle;

	private bool yes = false;
	private bool no = false;

	void Start ()
	{
		resetGesture ();
	}

	// Update is called once per frame
	public override void atUpdate ()
	{
		Step ();
	}

	private void completeFase ()
	{
		instructions.enabled = false;
		doChangeThisStateToFinished ();
	}

	private void standBy() {
		
	}

	private void contactWithBriefing() {
		SoundManager.Instance.playSingleSFXSound (incomingCall);
		Step = makeContact;
	}

	private void makeContact() {
		if(!SoundManager.Instance.getSfxSoundFinished()) {
			SoundManager.Instance.playSingleSFXSound (staticOn);
			playerSource.Play ();
			Step = firstIntroduction;
		}
	}

	private void firstIntroduction ()
	{
		if (!playerSource.isPlaying) {
			headGestureRecognition ();
			if(yes) {
				playerSource.clip = introduction2;
				playerSource.Play ();
				Step = playerIdentity;
				yes = false;
			}
		}	
	}

	private void playerIdentity ()
	{
		if (!playerSource.isPlaying) {
			headGestureRecognition ();
			if(yes) {
				playerSource.clip = introduction3;
				playerSource.Play ();
				Step = goodLuck;
				yes = false;
			}
			else if (no) {
				playerSource.clip = introduction2;
				playerSource.Play ();
				no = false;
			}
		}	
	}

	private void goodLuck ()
	{
		if (!playerSource.isPlaying) {
			SoundManager.Instance.playSingleSFXSound (staticOn);
			doChangeThisStateToFinished ();
		}	
	}

	private void headGestureRecognition ()
	{
		angles [index] = GvrViewer.Instance.HeadPose.Orientation.eulerAngles;
		index++;
		if (index >= 80) {
			checkHeadGesture ();
			resetGesture ();
		}
	}

	private void checkHeadGesture ()
	{
		bool right = false, left = false, up = false, down = false;
		for (int x = 0; x < 80; x++) {
			if (angles [x].x < centerAngle.x - 20.0f && !up) {
				up = true;
			} else if (angles [x].x > centerAngle.x + 20.0f && !down) {
				down = true;
			}	
			if (angles [x].y < centerAngle.y - 20.0f && !left) {
				left = true;
			} else if (angles [x].y > centerAngle.y + 20.0f && !right) {
				right = true;
			}

			if(left && right && !(up && down)) {
				no = true;
			}

			if(up && down && !(left && right)) {
				yes = true;
			}
		}
	}

	private void resetGesture() {
		angles = new Vector3[80];
		index = 0;
		centerAngle = GvrViewer.Instance.HeadPose.Orientation.eulerAngles;
	}

	public override void atInit ()
	{
		Step = standBy;
		Invoke("contactWithBriefing", 2);
		EventManager.startListening (Events.EventList.LEVEL_Activity_Completed, doChangeThisStateToFinished);
		playerSource.clip = introduction;
	}

	public override void atEnd ()
	{
		EventManager.stopListening (Events.EventList.LEVEL_Activity_Completed, doChangeThisStateToFinished);
	}

	public override void atPause ()
	{
		//throw new NotImplementedException();
	}

	public override void atReadyActiveState ()
	{
		//throw new NotImplementedException();
	}
}
