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
	public delegate void CharacterAction();
	public CharacterAction[]Actions;

	public CharacterState[] StatesSteps;

	private bool talking = false;

	// Use this for initialization
	void Start () {
		dialogScript = GetComponent<DialogScript>();
		characterAnimator = GetComponent<Animator>();
		Actions = new CharacterAction[(int)CharacterState.Count]; // init array of delegates
		// Set each action delegate
		stateMode = CharacterState.StandBy;
		nextStateMode = CharacterState.StandBy;
		Actions[(int)CharacterState.Idle] = idle;
		Actions[(int)CharacterState.Move] = moveCharacter;
		Actions [(int)CharacterState.Turn] = rotateCharacterTowards;
		Actions[(int)CharacterState.Action] = moveCharacter;
		Actions[(int)CharacterState.StandBy] = standBy;
	}

	protected void OnDestroy()
	{
		if (Actions != null)
		{
			for (int x = 0; x < (int)CharacterState.Count; x++)
			{
				Actions[x] = null;
			}
			Actions = null;
		}
	}

	public void doUpdate()
	{
		//Debug.Log (gameObject + ".doUpdate()");
		//_Actions[(int)stateActions]?.Invoke(); alternativa que no me deja no se porque.
		if (Actions[(int)stateMode] != null)
		{
			checkStateTransition ();
			Actions[(int)stateMode]();
		}
	}

	private void checkStateTransition() {
		if(nextStateMode == CharacterState.StandBy) {
			nextState ();
		}
		if (stateMode != nextStateMode) {
			stateMode = nextStateMode;
		}
	}

	private void standBy() {}
	private void idle() {}

	public void setCharacterState(CharacterState newState) {
		nextStateMode = newState;
	}

	public void setCharacterNextStates(CharacterState[] newStatesSteps) {
		StatesSteps = newStatesSteps;
		currentStep = 0;
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

	private void moveCharacter() {
		animationReference.setWalking (true);
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

	public bool talk()  {
		if(!dialogScript.playUpdateDialog())
		{
			if (currentDialog < dialogs.Length)
			{
				dialogScript.setNewAudioClip (dialogs[currentDialog]);
				dialogScript.initDialog();
				currentDialog++;
			}
			else {
				return false;
			}
		}
		return true;
	}

	public void setDialogs(AudioClip[] audios) {
		dialogs = audios;
		currentDialog = 0;
	}

	public bool isTalking() {
		return talking;
	}
}
