using UnityEngine;
using System.Collections;

public class SceneEventForth : StateScript {

	public GameObject pet;
	private DialogScript petDialogScript;    // Use this for initialization
	private Animator petAnimator;
	public bool completed = false;
	public Transform pointA;
	public Transform pointB;
	public Vector3 currentPoint;
	public int counter = 0;
	private Vector3 petDirection;
	void Start()
	{
		petAnimator = pet.GetComponentInChildren<Animator> ();
		currentPoint = pointA.position;
	}

	// Update is called once per frame
	public override void atUpdate()
	{
		if(!petAnimator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Walking")) {
			petAnimator.SetBool ("Walking", true);
		}
		else {
			petDirection = new Vector3 (currentPoint.x - pet.transform.position.x, 0, currentPoint.z - pet.transform.position.z);
			pet.transform.rotation = Quaternion.Slerp (pet.transform.rotation, Quaternion.LookRotation(petDirection), 0.2f);
			pet.transform.Translate (pet.transform.forward * Time.deltaTime * 1.3f);
			if (Vector3.Distance (new Vector3(pet.transform.position.x, 0, pet.transform.position.z), new Vector3(currentPoint.x, 0, currentPoint.z)) < 0.3f) {
				currentPoint = pointB.position;
				counter++;
			}
			if (counter == 2) {
				petAnimator.SetBool ("Walking", false);
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
