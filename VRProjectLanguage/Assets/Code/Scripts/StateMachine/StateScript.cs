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
    public abstract void atContinue();
    public abstract void atInit();

    void Awake ()
    {
        Actions = new Action[(int)StateMode.Count]; // init array of delegates
        // Set each action delegate
        stateMode = StateMode.Active;
        Actions[(int)StateMode.Active] = atUpdate;
        Actions[(int)StateMode.Finished] = IHaveFinished;
        Actions[(int)StateMode.Paused] = atPause;
        Actions[(int)StateMode.Continue] = readyActive;
        EventManager.statePaused += doPause;
        EventManager.stateContinue += doContinue;
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
        Debug.Log("doPause");
        stateMode = StateMode.Paused;
    }

    public void doContinue()
    {
        stateMode = StateMode.Continue;
    }

    public void readyActive()
    {
        atContinue();
        stateMode = StateMode.Active;
    }

    public void changeThisStateToFinished()
    {
        stateMode = StateMode.Finished;
    }

    public void IHaveFinished()
    {
        EventManager.Instance.nextState(); 
    }

    public void OnDisable ()
    {
        EventManager.statePaused -= doPause;
        EventManager.stateContinue -= doContinue;
    }
}
