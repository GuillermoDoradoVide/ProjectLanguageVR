using UnityEngine;
using System.Collections;

public class CharacterManager : MonoBehaviour
{
	[Header("References")]
	public CharacterMovement characterMovement;
	public CharacterAnimationReference animationReference;
	public Animator characterAnimator;
	public DialogScript dialogScript;
	public AudioClip[] dialogs;
	[Header("AudioClipsInfo")]
	public int currentDialog;
	public int currentStep = 0;


	public enum CharacterState
	{
		Idle,
		Move,
		Turn,
		Action,
		StandBy,
		Count}
	;
	[Header("Character States")]
	public CharacterState stateMode;
	public CharacterState nextStateMode;

	public delegate void CharacterDisplacement ();

	public CharacterDisplacement[] Movements;

	public delegate void CharacterAction ();

	public CharacterAction Actions;
	public CharacterState[] StatesSteps;
//	public bool isPaused = false;
	private bool talking = false;
    public bool wasActive = false;
	public bool isActive = false;
	public float counterWaitTalk;
	public float timer;
	public float timerWaitTalk;
	public int maxRangeRandom;
	[Header ("Sounds")]
	public AudioClip stepsSound;
	public AudioSource sound;

	// Use this for initialization
	private void Start ()
	{
		dialogScript = GetComponent<DialogScript> ();
		characterAnimator = GetComponent<Animator> ();
		Movements = new CharacterDisplacement[(int)CharacterState.Count]; // init array of delegates
		// Set each action delegate
		stateMode = CharacterState.StandBy;
		nextStateMode = CharacterState.StandBy;
		Movements [(int)CharacterState.Idle] = idle;
		Movements [(int)CharacterState.Move] = move;
		Movements [(int)CharacterState.Turn] = rotateCharacterTowards;
		Movements [(int)CharacterState.StandBy] = standBy;
		EventManager.startListening (Events.EventList.STATE_Pause, pauseThisCharacterManager);
		EventManager.startListening (Events.EventList.STATE_Continue, continueThisCharacterManager);
	}

	private void OnDisable() {
		EventManager.stopListening (Events.EventList.STATE_Pause, pauseThisCharacterManager);
		EventManager.stopListening (Events.EventList.STATE_Continue, continueThisCharacterManager);
	}

	public bool isStandBy() {
		return (stateMode == CharacterState.StandBy) ? true : false;
	}

	protected void OnDestroy ()
	{
		if (Actions != null) {
			Actions -= talk;
			Actions = null;
		}
		if (Movements != null) {
			for (int x = 0; x < (int)CharacterState.Count; x++) {
				Movements [x] = null;
			}
			Movements = null;
		}
	}

	public void setCharacterState (CharacterState newState)
	{
		nextStateMode = newState;
	}

	public void setCharacterNextStates (CharacterState[] newStatesSteps)
	{
		StatesSteps = newStatesSteps;
		currentStep = 0;
		nextStateMode = StatesSteps [currentStep];
	}

	public void setWaypoints (Transform[] waypoints)
	{
		characterMovement.setNewWaypoints (waypoints);
	}

	private void Update() {
		if (isActive) {
			checkState ();
			if (Movements [(int)stateMode] != null) {
				Movements [(int)stateMode] ();
			}
			if (Actions != null) {
                if(!GameManager.Instance.isPaused)
                {
                    Actions();
                }
			}
		}
	}

	private void checkState ()
	{
		if (stateMode != nextStateMode) {
			stateMode = nextStateMode;
		}
	}

	private void standBy ()
	{
		nextState ();
	}

	private void nextState ()
	{
		if (StatesSteps.Length > currentStep) {
			nextStateMode = StatesSteps [currentStep];
			currentStep++;
		} else {
			nextStateMode = CharacterState.Idle;
		}
	}

	private void idle ()
	{
		animationReference.setWalking (false);
	}

	private void move ()
	{
		animationReference.setWalking (true);
		if (characterMovement.move ()) {
			nextStateMode = CharacterState.StandBy;
			animationReference.setWalking (false);
		}
	}

	private void rotateCharacterTowards ()
	{
		if (characterMovement.turnCharacter ()) {
			nextStateMode = CharacterState.StandBy;
		}
	}

	public void setDialogs (AudioClip[] audios)
	{
		dialogs = audios;
		currentDialog = 0;
	}

	private void talk ()
	{
		if (!dialogScript.playUpdateDialog ()) {
			if (currentDialog < dialogs.Length) {
				dialogScript.setNewAudioClip (dialogs [currentDialog]);
				dialogScript.initDialog ();
				currentDialog++;
			} else {
				talking = false;
				Actions -= talk;
			}
		}
	}

	public void waitForPlayerTalk ()
	{
		if (!dialogScript.playUpdateDialog ()) {
			counterWaitTalk += Time.deltaTime;
			if (counterWaitTalk >= timerWaitTalk) {
				timerWaitTalk = timer;
				timerWaitTalk += Random.Range (-maxRangeRandom, maxRangeRandom);
				if (timerWaitTalk < 0) {
					timerWaitTalk = 0;
				}
				counterWaitTalk = 0;
				if (currentDialog < dialogs.Length) {
					dialogScript.setNewAudioClip (dialogs [Random.Range (0, dialogs.Length)]);
					dialogScript.initDialog ();
				} else {
					talking = false;
					Actions -= waitForPlayerTalk;
				}
			}
		}
	}

	public bool isTalking ()
	{
		return talking;
	}

	public void setTalking ()
	{
		talking = true;
		Actions += talk;
	}

	public void stopTalking ()
	{
		if (Actions != null) {
			Actions -= talk;
			Actions -= waitForPlayerTalk;
			dialogScript.audioSource.Stop ();
		}
	}

	public void setWaitTalking (float time, int maxRange)
	{
		talking = true;
		timer = time;
		timerWaitTalk = timer;
		maxRangeRandom = maxRange;
		Actions += waitForPlayerTalk;
	}

	public void setAction(string actionName) {
		animationReference.setAction (actionName);
	}

	public void stopAction(string actionName) {
		animationReference.stopAction (actionName);
	}

	public void stepSound ()
	{
		sound.pitch = Random.Range (0.85f, 1.2f);
		sound.PlayOneShot (stepsSound);
	}

    public void activeCharacter()
    {
        isActive = true;
        wasActive = true;
    }

    public void disableCharacter()
    {
        isActive = false;
        wasActive = false;
    }

    private void pauseThisCharacterManager() {
        if (dialogScript != null) {
			dialogScript.pauseDialog();
		}
		animationReference.setWalking (false);
	}

	private void continueThisCharacterManager() {
        if (dialogScript != null) {
			dialogScript.continueDialog ();
		}
	}
}
