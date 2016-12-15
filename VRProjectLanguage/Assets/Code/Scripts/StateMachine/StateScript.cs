using UnityEngine;
using System.Collections;

public abstract class StateScript : MonoBehaviour {
    public bool isTriggerable { get; set; }
    private enum StateActions { Active, Finished, Count };
    private StateActions stateActions;
    public delegate void _Action();
    public _Action[] _Actions;
    public abstract void doUpdate();
    public abstract void doAtStart();
    public StateMachine _OwnwerStateMachine;

    void Awake ()
    {
        _Actions = new _Action[(int)StateActions.Count]; // init array of delegates
        // Set each action delegate
        stateActions = StateActions.Active;
        _Actions[(int)StateActions.Active] = doUpdate;
        _Actions[(int)StateActions.Finished] = IHaveFinished;
    }

     void Start()
    {
        init();
        doAtStart();
    }

    public void doAtUpdate()
    {
        //_Actions[(int)stateActions]?.Invoke(); alternativa que no me deja no se porque.
        if (_Actions[(int)stateActions] != null)
        {
            _Actions[(int)stateActions]();
        }
    }

    void init()
    {
        isTriggerable = false;
    }

    public void changeThisStateToFinished()
    {
        stateActions = StateActions.Finished;
    }

    public void IHaveFinished()
    {
        _OwnwerStateMachine.nextState();
    }
}
