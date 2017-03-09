using UnityEngine;
using System.Collections;

public class BeaconIdle : MonoBehaviour {

	public Vector3 initPos;
	public Vector3 finalPos;
	public float speed;
	public float range;
	public bool idle = true;
	public bool down = false;
	public Transform player;


	// Use this for initialization
	void Start () {
		init ();
	}

	private void init() {
		transform.LookAt (player.position);
		transform.RotateAround (transform.position, Vector3.up, 180);
		range = 0;
		initPos = transform.position;
		finalPos = new Vector3 (initPos.x, initPos.y + 0.1f, initPos.z);
	}

	private void OnEnable() {
		init ();
	}
	
	// Update is called once per frame
	void Update () {
		if (idle) idleBeacon ();
	}

	public void setIdle(bool value) {
		idle = value;
	}

	public void teleportPlayerToBeacon() {
		EventManager.teleportPlayerToPosition (transform);
	}

	private void idleBeacon() {
		if(range > 1) {
			down = true;
		} else if (range <= 0) {
			down = false;
		}
		transform.position = Vector3.Slerp(initPos, finalPos, range);
		if(!down) {
			range += Time.deltaTime * speed;
		}
		else {
			range -= Time.deltaTime * speed;
		}
	}
}
