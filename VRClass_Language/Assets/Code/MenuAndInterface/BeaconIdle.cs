using UnityEngine;
using System.Collections;

public class BeaconIdle : MonoBehaviour {

	private Vector3 rotateAxis;
	public float speed = 1;
	public bool rotate = false;

	// Use this for initialization
	void Start () {

		rotateAxis.Set (0, 1, 0);
	
	}
	
	// Update is called once per frame
	void Update () {
		if (rotate) idleBeacon ();
	}

	public void setRotate(bool value) {
		rotate = value;
	}

	public void teleportPlayerToBeacon() {
		EventManager.teleportPlayerToPosition (transform);
	}

	private void idleBeacon() {
		transform.RotateAround (transform.position, rotateAxis, speed);
	}


}
