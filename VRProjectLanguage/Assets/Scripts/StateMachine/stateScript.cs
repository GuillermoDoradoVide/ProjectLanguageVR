using UnityEngine;
using System.Collections;

public abstract class StateScript : MonoBehaviour {
    public bool isTriggerable { get; set; }
    public delegate void action();
    public action _CurrentAction;
    public abstract void doUpdate();
    public StateMachine _OwnwerStateMachine;

    public void init()
    {
        _CurrentAction = doUpdate;
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
