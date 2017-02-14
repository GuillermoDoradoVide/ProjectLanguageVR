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

			pet.transform.LookAt(new Vector3(pointA.position.x, pet.transform.position.y , pointA.position.z ));
		}
		else {
			currentPoint = new Vector3 (currentPoint.x,pet.transform.position.y, currentPoint.z);
			pet.transform.position = Vector3.MoveTowards (pet.transform.position,currentPoint, Time.deltaTime );
			if (Vector3.Distance (pet.transform.position, currentPoint) < 0.3f) {
				currentPoint = pointB.position;
				pet.transform.LookAt(new Vector3(currentPoint.x, pet.transform.position.y , currentPoint.z ));
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
