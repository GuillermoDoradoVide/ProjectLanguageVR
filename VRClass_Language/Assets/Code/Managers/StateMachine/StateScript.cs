using UnityEngine;
using System.Collections;
[AddComponentMenu("StateMachine/StateScript")]
public abstract class StateScript : MonoBehaviour {
    public enum StateMode { Active, Finished, Paused, Continue, Count };
    public StateMode stateMode;
    public delegate void Action();
    public Action[]Actions;
    public abstract void atUpdate();
    public abstract void atPause();
    public abstract void atReadyActiveState();
    public abstract void atInit();
    public abstract void atEnd();

    private void Awake ()
    {
        Actions = new Action[(int)StateMode.Count]; // init array of delegates
        // Set each action delegate
        stateMode = StateMode.Active;
        Actions[(int)StateMode.Active] = atUpdate;
        Actions[(int)StateMode.Finished] = atStateFinished;
        Actions[(int)StateMode.Paused] = atPause;
        Actions[(int)StateMode.Continue] = atContinue;
    }

    public void doUpdate()
    {
        //_Actions[(int)stateActions]?.Invoke(); alternativa que no me deja no se porque.
        if (Actions[(int)stateMode] != null)
        {
            Actions[(int)stateMode]();
        }
    }

    public void doPause()
    {
        stateMode = StateMode.Paused;
    }

    public void doContinue()
    {
        stateMode = StateMode.Continue;
    }

    public void doChangeThisStateToFinished()
    {
		Debug.Log ("doChangeThisStateToFinished: " + name);
        stateMode = StateMode.Finished;
    }

    private void atContinue()
    {
        atReadyActiveState();
        stateMode = StateMode.Active;
    }

    private void atStateFinished()
    {
        Debug.Log("State " + gameObject.name +" finished.");
        EventManager.triggerEvent(Events.EventList.STATE_Next);
    }
}
