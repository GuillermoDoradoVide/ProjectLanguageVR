﻿using UnityEngine;
using System.Collections;

public class initCitizenShip : StateScript {

	void Start()
	{
	}

	// Update is called once per frame
	public override void atUpdate()
	{
	}

	public override void atInit()
	{
		EventManager.triggerEvent (Events.EventList.PLAYER_FadeIn);
		doChangeThisStateToFinished ();
	}

	public override void atEnd()
	{
		SoundManager.playRandomMusic ();
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
