using UnityEngine;
using System.Collections;

public class SceneEventForth : StateScript {

	public GameObject pet;
	private DialogScript petDialogScript;    // Use this for initialization
	private CharacterAnimationReference characterAnimation;
	public bool completed = false;
	public Transform pointA;
	public Transform pointB;
	public Vector3 currentPoint;
	public int counter = 0;
	private Vector3 petDirection;
	void Start()
	{
		characterAnimation = pet.GetComponentInChildren<CharacterAnimationReference> ();
		currentPoint = pointA.position;
	}

	// Update is called once per frame
	public override void atUpdate()
	{
		if(!characterAnimation.characterAnimator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Walking")) {
			characterAnimation.setWalking ();
		}
		else {
			petDirection = new Vector3 (currentPoint.x - pet.transform.position.x, 0, currentPoint.z - pet.transform.position.z);
			pet.transform.rotation = Quaternion.Slerp (pet.transform.rotation, Quaternion.LookRotation(petDirection), 4f * Time.deltaTime);
			pet.transform.position = Vector3.MoveTowards (new Vector3(pet.transform.position.x, pet.transform.position.y, pet.transform.position.z), new Vector3(currentPoint.x, pet.transform.position.y, currentPoint.z), 1 * Time.deltaTime);
			if (Vector3.Distance (new Vector3(pet.transform.position.x, 0, pet.transform.position.z), new Vector3(currentPoint.x, 0, currentPoint.z)) < 0.3f) { 
				currentPoint = pointB.position;
				counter++;
			}
			if (counter == 2) {
				characterAnimation.setWalking (false);
				completed = true;
			}
		}
		if (completed)
		{
			doChangeThisStateToFinished();
		}
	}

	public override void atInit()
	{
		EventManager.startListening(Events.EventList.LEVEL_Activity_Completed, completeTask);
	}

	public override void atEnd()
	{
		EventManager.stopListening(Events.EventList.LEVEL_Activity_Completed, completeTask);
	}

	public override void atPause()
	{
		//throw new NotImplementedException();
	}

	public override void atReadyActiveState()
	{
		//throw new NotImplementedException();
	}

	private void completeTask()
	{
		completed = true;
	}
}
