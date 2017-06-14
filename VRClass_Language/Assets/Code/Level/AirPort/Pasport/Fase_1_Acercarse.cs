using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Fase_1_Acercarse : StateScript {
	public Transform player;
	public Transform teleportLocation;
	public CharacterManager characterManagerOfficer;

    public UnityAction firstAction;
    public InteractionMenuController menuController;

    private void Start()
	{
		teleportLocation = GameObject.Find ("Beacon").GetComponent<Transform> ();
		teleportLocation.gameObject.SetActive (false);
	}

	// Update is called once per frame
	public override void atUpdate()
	{
		if (Vector3.Distance(player.position, teleportLocation.position) < 1) {
			characterManagerOfficer.animationReference.setTalking (false);
			characterManagerOfficer.stopTalking ();
			teleportLocation.gameObject.SetActive (false);
			if(!characterManagerOfficer.animationReference.getTalking()) {
				doChangeThisStateToFinished ();
			}
		}
	}

    private void showMenuGivePassPort()
    {
        menuController.addDialogTriggerAction(0, "Check in your passport.", firstAction);
    }

    private void showTeleport()
    {
        EventManager.teleportPlayerToPosition(teleportLocation);
    }

    public override void atInit()
	{
		EventManager.startListening(Events.EventList.LEVEL_Activity_Completed, doChangeThisStateToFinished);
		teleportLocation.gameObject.SetActive (true);
        firstAction = new UnityAction(showTeleport);
        showMenuGivePassPort();
    }

	public override void atEnd()
	{
		EventManager.stopListening(Events.EventList.LEVEL_Activity_Completed, doChangeThisStateToFinished);
	}

	public override void atPause()
	{
//		characterManagerOfficer.dialogScript.audioSource.Pause ();
	}

	public override void atReadyActiveState()
	{
//		characterManagerOfficer.dialogScript.audioSource.UnPause ();
	}
}
