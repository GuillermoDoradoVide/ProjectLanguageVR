using UnityEngine;
using System.Collections;
using System;

public class SceneEventActivity : StateScript {

    public AudioClip firstDialog;
    public AudioClip secondDialog;

	// Use this for initialization
	void Start () {
        EventManager.setNewDialogEvent(firstDialog);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void atInit()
    {
        throw new NotImplementedException();
    }

    public override void atPause()
    {
        throw new NotImplementedException();
    }


    public override void atUpdate()
    {
        throw new NotImplementedException();
    }

    public override void readyActiveState()
    {
        throw new NotImplementedException();
    }

}
