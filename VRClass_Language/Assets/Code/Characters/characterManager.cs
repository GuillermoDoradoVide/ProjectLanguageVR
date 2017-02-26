using UnityEngine;
using System.Collections;

public class characterManager : MonoBehaviour {

	public CharacterWaypointMovement movement;
	public CharacterPivotMovement pivot;
	public Animator animator;
	public bool move = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (!pivot.finished && move) {
			pivot.rotateCharacter ();
		}else {
			if (move) {
				movement.move ();
			}
		}
	}
}
