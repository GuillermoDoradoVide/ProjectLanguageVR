using UnityEngine;
using System.Collections;

public class CharacterWaypointMovement : MonoBehaviour {

	public Transform[] waypoints;
	public Transform character;
	public Vector3 destinyPosition;

	public int currentWaypoint;

	[Range(0.1f,5f)]
	public float maxDesplacementDistance = 0.1f;
	[Range(0.1f,5f)]
	public float minDistanceToPointError = 0.3f;
	[Range(0.1f,5f)]
	public float maxRotationDistance  = 2f;

	private Vector3 characterTravelDirection;
	private Quaternion movementQuaternionRotation;
	private float diferenceWaypointToCharacter;

	// Use this for initialization
	void Start () {
		if (waypoints.Length != 0) destinyPosition = waypoints [0].position;
	}
	
	// Update is called once per frame
	void Update () {
		//moveCharacter ();
		rotateCharacter ();
		checkDestinyWaypoint ();
	}

	private void moveCharacter() {
		character.position = Vector3.MoveTowards (character.position, destinyPosition, Time.deltaTime * maxRotationDistance);
	}

	private void rotateCharacter() {
		characterTravelDirection = new Vector3(destinyPosition.x, 0, destinyPosition.z) - new Vector3 (character.position.x, 0, character.position.z);
		movementQuaternionRotation = Quaternion.LookRotation (characterTravelDirection);
		character.rotation = Quaternion.Slerp (character.rotation, movementQuaternionRotation, Time.deltaTime * maxRotationDistance);
	}

	private void checkDestinyWaypoint() {
		diferenceWaypointToCharacter = Mathf.Abs(character.position.sqrMagnitude - destinyPosition.sqrMagnitude);
		Debug.Log (diferenceWaypointToCharacter);
		if (diferenceWaypointToCharacter < minDistanceToPointError) {
			changeCurrentToNextWaypoint ();
		}
	}

	private void changeCurrentToNextWaypoint () {
		if (currentWaypoint < waypoints.Length - 1) {
			currentWaypoint++;
			destinyPosition = waypoints[currentWaypoint].position;
		}
	}
}
