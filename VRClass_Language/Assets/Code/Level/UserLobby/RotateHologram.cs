using UnityEngine;
using System.Collections;

public class RotateHologram : MonoBehaviour {

	private Transform _T;
	private Vector3 rotationVector;
	public int rotationAngle;
	// Use this for initialization
	void Start () {
		_T = GetComponent<Transform> ();
		rotationVector = Vector3.up;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void rotateHologram () {
		_T.RotateAround (_T.position,rotationVector , rotationAngle * Time.deltaTime);
	}
}
