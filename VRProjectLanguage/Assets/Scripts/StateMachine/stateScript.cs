using UnityEngine;
using System.Collections;

public abstract class StateScript : MonoBehaviour {
    public bool isTriggerable { get; set; }
    public delegate void action();
    public action _CurrentAction;
    public abstract void doUpdate();
    public abstract void doAtStart();
    public StateMachine _OwnwerStateMachine;

     void Start()
    {
        init();
        doAtStart();
    }

    void init()
    {
        _CurrentAction = doUpdate;
        isTriggerable = false;
    }

    public void changeThisStateToFinished()
    {
        _CurrentAction = IHaveFinished;
    }

    public void IHaveFinished()
    {
        _OwnwerStateMachine.nextState();
    }
}
