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
		walkingID = Animator.StringToHash("Walking");
		talkingID = Animator.StringToHash("Talking");
		speedID = Animator.StringToHash("Speed");
	}

	public void setWalking(bool walking = true, float speed = 1f) {
		characterAnimator.SetBool (walkingID, walking);
		characterAnimator.SetFloat (speedID, speed);
	}

	public bool getWalking() {
		return characterAnimator.GetBool (walkingID);
	}

	public void setTalking(bool talking = true, int animationType = 0) {
		characterAnimator.SetBool (talkingID, talking);
	}

	public bool getTalking() {
		return characterAnimator.GetBool (talkingID);
	}

	public void setAction(string action) {
		characterAnimator.SetBool (action, true);
	}

	public void stopAction(string action) {
		characterAnimator.SetBool (action, false);
	}

	public void getAction(string action) {
		characterAnimator.GetBool (action);
	}
}
