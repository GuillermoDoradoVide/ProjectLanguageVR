using UnityEngine;
using System.Collections;

public class characterManager : MonoBehaviour {

	public CharacterWaypointMovement movement;
	public bool move = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (move) {
			movement.move ();
		}
	
	}
}
