using UnityEngine;
using System.Collections;

public class Fin : StateScript {

	public FadeEffect fadeEffect;
	void Start()
	{
	}

	// Update is called once per frame
	public override void atUpdate()
	{
		if (fadeEffect.fadeOut()) {
			doChangeThisStateToFinished ();
		}
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
