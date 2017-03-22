using UnityEngine;
using System.Collections;

public class LaboratoryLobby : StateScript {

	void Start()
	{
	}

	// Update is called once per frame
	public override void atUpdate()
	{
	}

	public void loadAirPortLevel() {
		Debug.Log ("Load");
		EventManager.triggerEvent (Events.EventList.PLAYER_FadeOut);
		Invoke ("changeToAirportScene", 2);
	}

	private void changeToAirportScene() {
		SceneController.SwitchScene ("Aeropuerto_Pasaportes");
	}

	public override void atInit()
	{
	}

	public override void atEnd()
	{
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
