using UnityEngine;
using System.Collections;

public class Fin : StateScript {
	void Start()
	{
	}

	// Update is called once per frame
	public override void atUpdate()
	{
	}

	public override void atInit()
	{
		EventManager.triggerEvent (Events.EventList.PLAYER_FadeOut);
		SceneController.Instance.loadScene ("Aeropuerto_Pasaportes");
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
