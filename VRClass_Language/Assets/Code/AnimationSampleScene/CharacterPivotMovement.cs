using UnityEngine;
using System.Collections;

public class CharacterPivotMovement : MonoBehaviour {

	public Transform character;
	public Transform destinyDirection;

	[Range(0.1f,5f)]
	public float maxRotationDistance  = 2f;
	private Quaternion movementQuaternionRotation;
	private Vector3 characterTravelDirection;
	public bool finished = false;

	// Use this for initialization
	void Start () {
	}

	public void rotateCharacter() {
		characterTravelDirection = new Vector3(destinyDirection.position.x, 0, destinyDirection.position.z) - new Vector3 (character.position.x, 0, character.position.z);
		movementQuaternionRotation = Quaternion.LookRotation (characterTravelDirection);
		character.rotation = Quaternion.Slerp (character.rotation, movementQuaternionRotation, Time.deltaTime * maxRotationDistance);
		if (Vector3.Angle(character.forward, characterTravelDirection) < 10) {
			finished = true;
		}
	}
}
