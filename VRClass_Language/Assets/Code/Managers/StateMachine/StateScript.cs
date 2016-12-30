using UnityEngine;
using System.Collections;
[AddComponentMenu("StateMachine/StateScript")]
public abstract class StateScript : MonoBehaviour {
    private enum StateMode { Active, Finished, Paused, Continue, Count };
    private StateMode stateMode;
    public delegate void Action();
    public Action[]Actions;
    public abstract void atUpdate();
    public abstract void atPause();
    public abstract void readyActiveState();
    public abstract void atInit();

    private void Awake ()
    {
        Actions = new Action[(int)StateMode.Count]; // init array of delegates
        // Set each action delegate
        stateMode = StateMode.Active;
        Actions[(int)StateMode.Active] = atUpdate;
        Actions[(int)StateMode.Finished] = stateFinished;
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

    public void changeThisStateToFinished()
    {
        stateMode = StateMode.Finished;
    }

    private void atContinue()
    {
        readyActiveState();
        stateMode = StateMode.Active;
    }

    private void stateFinished()
    {
        EventManager.Instance.EventNextState(); 
    }
}
