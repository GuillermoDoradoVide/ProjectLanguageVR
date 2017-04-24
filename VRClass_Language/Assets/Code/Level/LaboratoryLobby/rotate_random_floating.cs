using UnityEngine;
using System.Collections;

public class rotate_random_floating : MonoBehaviour {

	public float _XSPeed;
	public float _YSPeed;
	public float _ZSPeed;

	public float _XSRPeed;
	public float _YSRPeed;
	public float _ZSRPeed;

	public Transform _T;

	void Awake() {
		_T = GetComponent<Transform> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		calculatePosition ();
		calculateRotation ();
	}

	void calculatePosition () {
		_T.Translate (_XSPeed * Time.deltaTime, _YSPeed * Time.deltaTime, _ZSPeed * Time.deltaTime);
	}

	void calculateRotation() {

		_T.Rotate (_XSRPeed * Time.deltaTime, _YSRPeed * Time.deltaTime, _ZSRPeed * Time.deltaTime);
	
	}
}
