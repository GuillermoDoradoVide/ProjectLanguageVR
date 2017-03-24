using UnityEngine;
using System.Collections;

public class CharacterManager : MonoBehaviour {

	public CharacterMovement characterMovement;
	public CharacterAnimationReference animationReference;
	public Animator characterAnimator;
	public DialogScript dialogScript;
	public AudioClip[] dialogs;
	public int currentDialog;
	public int currentStep = 0;

	public enum CharacterState { Idle, Move, Turn, Action, StandBy, Count };
	public CharacterState stateMode;
	public CharacterState nextStateMode;
	public delegate void CharacterDisplacement();
	public CharacterDisplacement[]Movements;
	public delegate void CharacterAction();
	public CharacterAction Actions;
	public CharacterState[] StatesSteps;

	private bool talking = false;
	public float counterWaitTalk;
	public float timer;
	public float timerWaitTalk;
	public int maxRangeRandom;
	[Header("Sounds")]
	public AudioClip stepsSound;
	public AudioSource sound;

	// Use this for initialization
	void Start () {
		dialogScript = GetComponent<DialogScript>();
		characterAnimator = GetComponent<Animator>();
		Movements = new CharacterDisplacement[(int)CharacterState.Count]; // init array of delegates
		// Set each action delegate
		stateMode = CharacterState.StandBy;
		nextStateMode = CharacterState.StandBy;
		Movements[(int)CharacterState.Idle] = idle;
		Movements[(int)CharacterState.Move] = moveCharacter;
		Movements [(int)CharacterState.Turn] = rotateCharacterTowards;
		Movements[(int)CharacterState.StandBy] = standBy;
	}

	protected void OnDestroy()
	{
		if (Actions != null)
		{
			Actions -= talk;
			Actions = null;
		}
		if (Movements != null)
		{
			for (int x = 0; x < (int)CharacterState.Count; x++)
			{
				Movements[x] = null;
			}
			Movements = null;
		}
	}

	public void doUpdate()
	{
		if (Movements[(int)stateMode] != null)
		{
			checkState();
			Movements[(int)stateMode]();
		}
		if (Actions != null) {
			Actions ();
		}
	}

	private void checkState() {
		if(nextStateMode == CharacterState.StandBy) {
			nextState ();
		}
		if (stateMode != nextStateMode) {
			stateTransition ();
		}
	}

	private void stateTransition() {
		stateMode = nextStateMode;
		checkAnimation ();
	}

	private void checkAnimation() {
		switch(stateMode) {
		case CharacterState.Move : {
				animationReference.setWalking (true);
				break;
			} 
		}
	}
		
	private void nextState() {
		if (StatesSteps.Length > currentStep) {
			nextStateMode = StatesSteps[currentStep];
			currentStep++;
		}
		else {
			nextStateMode = CharacterState.Idle;
		}
	}

	public void setCharacterState(CharacterState newState) {
		nextStateMode = newState;
	}

	public void setCharacterNextStates(CharacterState[] newStatesSteps) {
		StatesSteps = newStatesSteps;
		currentStep = 0;
		nextStateMode = StatesSteps[currentStep];
	}

	private void standBy() {}
	private void idle() {}

	private void moveCharacter() {
		if(characterMovement.move ()) {
			nextStateMode = CharacterState.StandBy;
			animationReference.setWalking (false);
		}
	}

	private void rotateCharacterTowards() {
		if (characterMovement.turnCharacter ()) {
			nextStateMode = CharacterState.StandBy;
		}
	}

	private void talk()  {
		if(!dialogScript.playUpdateDialog())
		{
			if (currentDialog < dialogs.Length)
			{
				dialogScript.setNewAudioClip (dialogs[currentDialog]);
				dialogScript.initDialog();
				currentDialog++;
			}
			else {
				talking = false;
				Actions -= talk;
			}
		}
	}

	public void waitForPlayerTalk() {
		if(!dialogScript.playUpdateDialog())
		{
			counterWaitTalk += Time.deltaTime;
			if(counterWaitTalk >= timerWaitTalk) {
				timerWaitTalk = timer;
				timerWaitTalk += Random.Range (-maxRangeRandom, maxRangeRandom);
				if( timerWaitTalk < 0) {
					timerWaitTalk = 0;
				}
				counterWaitTalk = 0;
				if (currentDialog < dialogs.Length)
				{
					dialogScript.setNewAudioClip (dialogs[Random.Range(0, dialogs.Length)]);
					dialogScript.initDialog();
				}
				else {
					talking = false;
					Actions -= waitForPlayerTalk;
				}
			}
		}
	}

	public void setDialogs(AudioClip[] audios) {
		dialogs = audios;
		currentDialog = 0;
	}

	public bool isTalking() {
		return talking;
	}

	public void setTalking() {
		talking = true;
		Actions += talk;
	}

	public void stopTalking() {
		if(Actions != null) {
			Actions -= talk;
			Actions -= waitForPlayerTalk;
			dialogScript.audioSource.Stop ();
		}
	}

	public void setWaitTalking(float time, int maxRange) {
		talking = true;
		timer = time;
		timerWaitTalk = timer;
		maxRangeRandom = maxRange;
		dialogScript.setNewAudioClip (dialogs[currentDialog]);
		dialogScript.initDialog();
		Actions += waitForPlayerTalk;
	}

	public void triggerAction () {
		
	}

	public void stepSound() {
		sound.pitch = Random.Range (0.9f, 1.2f);
		sound.PlayOneShot (stepsSound);
	}
}
