using UnityEngine;
using System.Collections;
using System;

public class SceneEventActivity : StateScript {

    public AudioClip[] dialogs;
    public int currentDialog;
    //public AudioClip firstDialog;
    //public AudioClip secondDialog;
    public GameObject pet;
    private DialogScript petDialogScript;

	// Use this for initialization
	void Start () {
        petDialogScript = pet.GetComponent<DialogScript>();
    }
	
	// Update is called once per frame
	public override void atUpdate() {
        Debug.Log("1");
        if(!petDialogScript.playUpdateDialog())
        {
            if (currentDialog < dialogs.Length)
            {
                EventManager.setNewDialogEvent(dialogs[currentDialog]);
                petDialogScript.initDialog();
                currentDialog++;
            }
            else
            {
                changeThisStateToFinished();
            }
        }
    }

    public override void atInit()
    {
        currentDialog = 0;
        EventManager.setNewDialogEvent(dialogs[currentDialog]);
        currentDialog++;
        petDialogScript.initDialog();
    }

    public override void atPause()
    {
        throw new NotImplementedException();
    }

    public override void readyActiveState()
    {
        throw new NotImplementedException();
    }

}
