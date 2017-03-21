using UnityEngine;
using System.Collections;

public class Fase_1_Acercarse : StateScript {
	public Transform player;
	public Transform teleportLocation;
	public CharacterManager characterManagerOfficer;

	private void Start()
	{
		teleportLocation = GameObject.Find ("Beacon").GetComponent<Transform> ();
		teleportLocation.gameObject.SetActive (false);
	}

	// Update is called once per frame
	public override void atUpdate()
	{
		characterManagerOfficer.doUpdate ();
		if (Vector3.Distance(player.position, teleportLocation.position) < 1) {
			characterManagerOfficer.animationReference.setTalking (false);
			characterManagerOfficer.stopTalking ();
			teleportLocation.gameObject.SetActive (false);
			if(!characterManagerOfficer.animationReference.getTalking()) {
				doChangeThisStateToFinished ();
			}
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
