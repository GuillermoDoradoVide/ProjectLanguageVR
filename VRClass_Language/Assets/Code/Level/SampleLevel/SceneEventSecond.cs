using UnityEngine;
using System.Collections;
using System;

public class SceneEventSecond : StateScript
{
    public GameObject pet;
    private DialogScript petDialogScript;    // Use this for initialization
	private Animator petAnimator;
    public bool completed = false;
    void Start()
    {
		petAnimator = pet.GetComponentInChildren<Animator> ();
    }

    // Update is called once per frame
    public override void atUpdate()
    {
		if(petAnimator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.GetUp")) {
			if(petAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime>=1) {
				EventManager.triggerEvent (Events.EventList.LEVEL_Activity_Completed);
				petAnimator.SetBool ("GetUp", false);
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
