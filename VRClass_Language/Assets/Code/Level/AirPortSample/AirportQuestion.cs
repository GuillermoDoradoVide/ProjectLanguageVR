using UnityEngine;
using System.Collections;

public class AirportQuestion: StateScript {
	public GameObject guard;
	private CharacterAnimationReference characterAnimation;

	// Use this for initialization
	void Start () {
		characterAnimation = guard.GetComponent<CharacterAnimationReference> ();
	}

	// Update is called once per frame
	public override void atUpdate() {
		
	}

	IEnumerator waitForPlayer() {
		yield return new WaitForSeconds (5);
		characterAnimation.setAction ("Pick");
		yield return new WaitForSeconds (1);
		doChangeThisStateToFinished();
	}

	public override void atInit()
	{
		StartCoroutine (waitForPlayer ());
	}

	public override void atEnd()
	{
	}

	public override void atPause()
	{
	}

	public override void atReadyActiveState()
	{
	}

}
