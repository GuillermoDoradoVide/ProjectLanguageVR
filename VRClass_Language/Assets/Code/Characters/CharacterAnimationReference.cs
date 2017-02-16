using UnityEngine;
using System.Collections;

public class CharacterAnimationReference : MonoBehaviour {

	public Animator characterAnimator;
	private static int walkingID;
	private static int idleID;
	private static int talkingID;
	private static int speedID;

	// Use this for initialization
	void Start () {
		characterAnimator = GetComponent<Animator> ();
		walkingID = Animator.StringToHash("Walking");
		idleID = Animator.StringToHash("Idle");
		talkingID = Animator.StringToHash("Talking");
		speedID = Animator.StringToHash("Speed");
			
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setWalking(bool walking = true, float speed = 1f) {
		characterAnimator.SetBool (walkingID, walking);
		characterAnimator.SetFloat (speedID, speed);
	}

	public void setTalking(bool talking = true, int animationType = 0) {
		characterAnimator.SetBool (talkingID, talking);
	}

	public void setAction(string actionName, bool action = true) {
		characterAnimator.SetBool(actionName, action);
	}
}
