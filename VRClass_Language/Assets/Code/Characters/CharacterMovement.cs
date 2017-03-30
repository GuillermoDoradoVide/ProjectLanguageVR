using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	public Transform[] waypoints;
	public Transform character;
	public Vector3 destinyWaypoint;

	public int currentWaypoint;

	[Range(0.1f,5f)]
	public float maxDesplacementDistance = 0.1f;
	[Range(0.1f,5f)]
	public float minDistanceToPointError = 0.3f;
	[Range(0.1f,5f)]
	public float maxRotationDistance  = 2f;

	private Vector3 characterTravelDirection;
	private Quaternion movementQuaternionRotation;
	private Vector3 diferenceWaypointToCharacter;
	private bool finished = false;

	private void Start () {
		if (waypoints.Length != 0) {
			checkWaypoints ();
		}
	}

	private void checkWaypoints() {
		if (waypoints.Length != 0) {
			destinyWaypoint = waypoints [0].position;
		}
		else {
			throw new UnityException(">The waypoint array is empty.");
		}
	}

	public bool move() {
		rotateCharacter ();
		checkDestinyWaypoint ();
		return finished;
	}

	private void rotateCharacter() {
		characterTravelDirection = new Vector3(destinyWaypoint.x, 0, destinyWaypoint.z) - new Vector3 (character.position.x, 0, character.position.z);
		movementQuaternionRotation = Quaternion.LookRotation (characterTravelDirection);
		character.rotation = Quaternion.Slerp (character.rotation, movementQuaternionRotation, Time.deltaTime * maxRotationDistance);
	}

//	private void moveCharacter() {
//		character.position = Vector3.MoveTowards (character.position, destinyWaypoint, Time.deltaTime * maxRotationDistance);
//	}

	private void checkDestinyWaypoint() {
		diferenceWaypointToCharacter = character.position - destinyWaypoint;
		diferenceWaypointToCharacter.y = 0;
		if (diferenceWaypointToCharacter.magnitude < minDistanceToPointError) {
			changeCurrentToNextWaypoint ();
		}
	}

	private void changeCurrentToNextWaypoint () {
		if (currentWaypoint < waypoints.Length - 1) {
			currentWaypoint++;
			destinyWaypoint = waypoints[currentWaypoint].position;
			finished = false;
		}
		else {
			finished = true;
		}
	}

	public bool turnCharacter() {
		characterTravelDirection = new Vector3(destinyWaypoint.x, 0, destinyWaypoint.z) - new Vector3 (character.position.x, 0, character.position.z);
		movementQuaternionRotation = Quaternion.LookRotation (characterTravelDirection);
		character.rotation = Quaternion.Slerp (character.rotation, movementQuaternionRotation, Time.deltaTime * maxRotationDistance);
		if (Vector3.Angle(character.forward, characterTravelDirection) < 10) {
			return true;
		}
		else {
			return false;
		}
	}
		
	public void setNewWaypoints(Transform[] newWaypoints) {
		waypoints = newWaypoints;
		checkWaypoints ();
	}
}
