using UnityEngine;
using System.Collections;

public class Fase_1_Acercarse : StateScript {
	public Transform player;
	public Transform teleportLocation;
	public CharacterManager characterManagerOfficer;

	void Start()
	{
	}

	// Update is called once per frame
	public override void atUpdate()
	{
		characterManagerOfficer.doUpdate ();
		if (Vector3.Distance(player.position, teleportLocation.position) < 1) {
			Invoke ("doChangeThisStateToFinished",3);
			teleportLocation.gameObject.SetActive (false);
			characterManagerOfficer.dialogScript.audioSource.Stop ();
		}
	}

	public override void atInit()
	{
		EventManager.startListening(Events.EventList.LEVEL_Activity_Completed, doChangeThisStateToFinished);
		teleportLocation.gameObject.SetActive (true);
	}

	public override void atEnd()
	{
		EventManager.stopListening(Events.EventList.LEVEL_Activity_Completed, doChangeThisStateToFinished);
	}

	public override void atPause()
	{
		//throw new NotImplementedException();
	}

	public override void atReadyActiveState()
	{
		//throw new NotImplementedException();
	}
}
