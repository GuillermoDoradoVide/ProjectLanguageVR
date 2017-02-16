using UnityEngine;
using System.Collections;

public class characterTalking : MonoBehaviour {


	public bool talking;
	public Animator animator;
	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (talking) {
			animator.SetLayerWeight (1, 0.8f);
		}else {
			animator.SetLayerWeight (1, 0.0f);
		}
	}
}
