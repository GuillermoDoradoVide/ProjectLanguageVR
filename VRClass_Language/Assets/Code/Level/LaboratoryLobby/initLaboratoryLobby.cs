using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class initLaboratoryLobby : StateScript {

    private UnityEvent listen;

	private void Start()
	{
        //listen.AddListener(interString);
        //EventManager.Instance.AddListener(listen);
        //EventManager.Instance.TriggerEvent(listen);
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
	}

	public override void atPause()
	{
		//throw new NotImplementedException();
	}

	public override void atReadyActiveState()
	{
		//throw new NotImplementedException();
	}

    public void interString()
    {
        Debugger.printErrorLog("Number: value > ");
    }
}
