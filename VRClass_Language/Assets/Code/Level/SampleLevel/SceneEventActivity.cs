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
	private Animator petAnimator;

	// Use this for initialization
	void Start () {
        petDialogScript = pet.GetComponent<DialogScript>();
		petAnimator = pet.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	public override void atUpdate() {
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
				petAnimator.SetBool ("GetUp", true);
                doChangeThisStateToFinished();
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

    public override void atEnd()
    {
        //throw new NotImplementedException();
    }

    public override void atPause()
    {
        petDialogScript.pauseDialog();
    }

    public override void atReadyActiveState()
    {
        petDialogScript.continueDialog();
    }

}
