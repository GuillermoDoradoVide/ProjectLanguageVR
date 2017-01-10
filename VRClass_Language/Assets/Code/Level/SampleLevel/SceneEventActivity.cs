using UnityEngine;
using System.Collections;
using System;

public class SceneEventActivity : StateScript {

    public AudioClip firstDialog;
    public AudioClip secondDialog;
    public GameObject pet;
    private DialogScript petDialogScript;

	// Use this for initialization
	void Start () {
        EventManager.setNewDialogEvent(firstDialog);
        petDialogScript = pet.GetComponent<DialogScript>();
        petDialogScript.initDialog();
    }
	
	// Update is called once per frame
	void Update () {
        if(!petDialogScript.playUpdateDialog())
        {
            EventManager.setNewDialogEvent(secondDialog);
            petDialogScript.initDialog();
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


    public override void atUpdate()
    {
        throw new NotImplementedException();
    }

    public override void readyActiveState()
    {
        throw new NotImplementedException();
    }

}
