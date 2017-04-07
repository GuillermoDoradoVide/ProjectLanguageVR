using UnityEngine;
using System.Collections;

public class Fase_1_Instrucciones : StateScript
{
	public InteractionMenuController menuController;
	public Canvas instructions;

	private delegate void Steps ();
	private Steps Step;

	public AudioClip introduction;
	public AudioClip introduction2;
	public AudioClip repeat;
	public AudioClip repeat2;
	public AudioClip introduction3;
	public AudioClip incomingCall;
	public AudioClip staticOn;
	public AudioSource playerSource;

	private Vector3[] angles;
	private int index;
	public int angleDetectorTime;
	private Vector3 centerAngle;
	public float headMovementMagnitude;
	public float headMagnitude;

	private bool yes = false;
	private bool no = false;
	public bool repeated = false;

	private void Start ()
	{
		resetGesture ();
	}

	private void OnDisable() {
		if (CurrentStep != null)
		{
			CurrentStep = null;
		}
	}

	// Update is called once per frame
	public override void atUpdate ()
	{
		CurrentStep ();
//		Step ();
	}

	private void completeFase ()
	{
		instructions.enabled = false;
		doChangeThisStateToFinished ();
	}

	private void standBy() {
	}

	private IEnumerator contactWithBriefing() {
		yield return new WaitForSeconds (2);
		SoundManager.playSFX (incomingCall);
		instructions.gameObject.SetActive (true);
		GetComponent<panelAlphaController> ().showPanel ();
		Debug.Log ("CONTACT");
		yield return  new WaitForSeconds (incomingCall.length);
		Debug.Log ("END");
		CurrentStep = makeContact;
	}


	private void makeContact() {
			SoundManager.playSFX (staticOn);
			playerSource.Play ();
		CurrentStep = firstIntroduction;
	}

	private void showMenuUnderstand() {
		menuController.addDialogTriggerAction (0,"You understand.Nod.",understand);
		if(!repeated) {
			menuController.addDialogTriggerAction (1,"You want her to repeat. Shake your head.",notUnderstand);
		}
		else {
			menuController.addDialogTriggerAction (1,"You want her to repeat it another time. Shake your head again.",notUnderstand2);
		}
	}

	private void firstIntroduction ()
	{
		if (!playerSource.isPlaying) {
//			menuController.addDialogTriggerAction (0,"You understand.Nod.",continueBriefing);
			//			CurrentStep = standBy;
			headGestureRecognition ();
			if(yes) {
				playerSource.clip = introduction2;
				playerSource.Play ();
				CurrentStep = playerIdentity;
				yes = false;
			}
		}	
	}

	private void continueBriefing() {
		playerSource.clip = introduction2;
		playerSource.Play ();
		CurrentStep = playerIdentity;
	}

	private void understand() {
		playerSource.clip = introduction3;
		playerSource.Play ();
		CurrentStep = goodLuck;
	}

	private void notUnderstand() {
		playerSource.clip = repeat;
		repeated = true;
		playerSource.Play ();
		CurrentStep = playerIdentity;
	}

	private void notUnderstand2() {
		playerSource.clip = repeat2;
		playerSource.Play ();
		CurrentStep = goodLuck;
	}

	private void playerIdentity ()
	{
		if (!playerSource.isPlaying) {
//			showMenuUnderstand ();
			//			CurrentStep = standBy;
			headGestureRecognition ();
			if(yes) {
				playerSource.clip = introduction3;
				playerSource.Play ();
				CurrentStep = goodLuck;
				yes = false;
			}
			else if (no) {
				if(!repeated){
					playerSource.clip = repeat;
					playerSource.Play ();
					no = false;
					repeated = true;
				}
				else {
					playerSource.clip = repeat2;
					playerSource.Play ();
					CurrentStep = goodLuck;
					yes = false;
				}
			}
		}	
	}

	private void goodLuck ()
	{
		if (!playerSource.isPlaying) {
			SoundManager.playSFX (staticOn);
			GetComponent<panelAlphaController> ().hidePanel ();
			doChangeThisStateToFinished ();
		}	
	}

	private void headGestureRecognition ()
	{
		initHeadGesture ();
		angles [index] = GvrViewer.Instance.HeadPose.Orientation.eulerAngles;
		index++;
		if (index >= angleDetectorTime) {
			checkHeadGesture ();
			resetGesture ();
		}
	}

	private void checkHeadGesture ()
	{
		bool right = false, left = false, up = false, down = false;
		for (int x = 0; x < angleDetectorTime; x++) {
			if (angles [x].x > (centerAngle.x + (headMovementMagnitude * headMagnitude)) && !down) {
				down = true;
			} else if ((angles [x].x < (centerAngle.x + (headMovementMagnitude * headMagnitude)/2)) && !up) {
				up = true;
			}

			if (angles [x].y < centerAngle.y - (headMovementMagnitude * headMagnitude) && !left) {
				left = true;
			} else if (angles [x].y > centerAngle.y + (headMovementMagnitude * headMagnitude) && !right) {
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

	private void initHeadGesture() {
		if (index == 0) {
			resetGesture ();
		}
	}

	private void resetGesture() {
		angles = new Vector3[angleDetectorTime];
		index = 0;
		centerAngle = GvrViewer.Instance.HeadPose.Orientation.eulerAngles;
	}

	private void showStartMissionMenu() {
		menuController.addDialogTriggerAction (0,"START MISSION!",startMission);
	}

	private void startMission() {
		Debug.Log ("start mission");
		StartCoroutine (contactWithBriefing());
		playerSource.clip = introduction;
		// temporal
		CurrentStep = standBy;
	}

	public override void atInit ()
	{
		CurrentStep = startMission;
		//		CurrentStep = standBy;
//		showStartMissionMenu ();
		EventManager.startListening (Events.EventList.LEVEL_Activity_Completed, doChangeThisStateToFinished);
	}

	public override void atEnd ()
	{
		EventManager.stopListening (Events.EventList.LEVEL_Activity_Completed, doChangeThisStateToFinished);
	}

	public override void atPause ()
	{
		playerSource.Pause ();
	}

	public override void atReadyActiveState ()
	{
		playerSource.UnPause ();
	}
}
