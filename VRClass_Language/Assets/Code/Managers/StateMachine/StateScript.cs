using UnityEngine;
using System.Collections;
[AddComponentMenu("StateMachine/StateScript")]
public abstract class StateScript : MonoBehaviour {
    public enum StateMode { Active, Finished, Paused, Continue, Count };
    public StateMode stateMode;
	public delegate void StateSteps ();
	/// <summary>
	/// Static delegate method.
	/// </summary>
	public StateSteps CurrentStep;
    public delegate void Action();
    public Action[]Actions;
    public abstract void atUpdate();
    public abstract void atPause();
    public abstract void atReadyActiveState();
    public abstract void atInit();
    public abstract void atEnd();

    private void Awake ()
    {
		initState ();
    }

	private void OnDisable() {
		clearState ();
	}

	private void OnEnable() {
		initState ();
	}

	private void initState() {
		Actions = new Action[(int)StateMode.Count]; // init array of delegates
		// Set each action delegate
		stateMode = StateMode.Active;
		Actions[(int)StateMode.Active] = atUpdate;
		Actions[(int)StateMode.Finished] = atStateFinished;
		Actions[(int)StateMode.Paused] = atPause;
		Actions[(int)StateMode.Continue] = atContinue;
	}

	private void clearState() {
		if (Actions != null)
		{
			for (int x = 0; x < (int)StateMode.Count; x++)
			{
				Actions[x] = null;
			}
			Actions = null;
		}
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
		#if UNITY_EDITOR
		Debug.Log ("doChangeThisStateToFinished: " + name);
		#endif
        stateMode = StateMode.Finished;
    }

    private void atContinue()
    {
        atReadyActiveState();
        stateMode = StateMode.Active;
    }

    private void atStateFinished()
    {
		#if UNITY_EDITOR
		Debug.Log("State " + gameObject.name +" finished.");
		#endif
        EventManager.triggerEvent(Events.EventList.STATE_Next);
    }
}
