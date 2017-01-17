using UnityEngine;
using System.Collections;
using System;

public class SceneEventSecond : StateScript
{
    public GameObject pet;
    private DialogScript petDialogScript;    // Use this for initialization
    public bool completed = false;
    void Start()
    {
        EventManager.startListening(Events.EventList.LEVELV_activity_Completed, completeTask);
    }

    private void onDisable()
    {
        EventManager.stopListening(Events.EventList.LEVELV_activity_Completed, completeTask);
    }

    // Update is called once per frame
    public override void atUpdate()
    {
        Debug.Log("2");
        if (completed)
        {
            changeThisStateToFinished();
        }
    }

    public override void atInit()
    {
        throw new NotImplementedException();
    }

    public override void atPause()
    {
        throw new NotImplementedException();
    }

    public override void readyActiveState()
    {
        throw new NotImplementedException();
    }

    private void completeTask()
    {
        completed = true;
    }

}
