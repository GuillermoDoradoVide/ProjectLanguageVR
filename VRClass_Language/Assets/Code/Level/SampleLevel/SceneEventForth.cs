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
	void Start()
	{
		petAnimator = pet.GetComponent<Animator> ();
		currentPoint = pointA.position;
	}

	// Update is called once per frame
	public override void atUpdate()
	{
		if(!petAnimator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Walking")) {
			petAnimator.SetBool ("Walking", true);
			pet.transform.RotateAround(pet.transform.position, new Vector3(0, 1, 0), -90);
		}
		else {
			pet.transform.position = Vector3.MoveTowards (pet.transform.position,currentPoint, Time.deltaTime );
			if (pet.transform.position == pointA.position) {
				currentPoint = pointB.position;
			}
			if (pet.transform.position == pointB.position) {
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
