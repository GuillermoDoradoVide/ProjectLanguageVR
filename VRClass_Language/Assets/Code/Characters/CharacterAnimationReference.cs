using UnityEngine;
using System.Collections;

public class CharacterAnimationReference : MonoBehaviour {

	public Animator characterAnimator;
	private static int walkingID;
	private static int talkingID;
	private static int speedID;

	// Use this for initialization
	private void Start () {
		characterAnimator = GetComponent<Animator> ();
	}

	public void setWalking(bool walking = true, float speed = 1f) {
		characterAnimator.SetBool ("Walking", walking);
	}

	public bool getWalking() {
		return characterAnimator.GetBool ("Walking");
	}

	public void setTalking(bool talking = true, int animationType = 0) {
		characterAnimator.SetBool ("Talking", talking);
	}

	public bool getTalking() {
		return characterAnimator.GetBool ("Talking");
	}

	public void setAction(string action) {
		characterAnimator.SetBool (action, true);
	}

	public void stopAction(string action) {
		characterAnimator.SetBool (action, false);
	}

	public bool getAction(string action) {
		return characterAnimator.GetBool (action);
	}
}
