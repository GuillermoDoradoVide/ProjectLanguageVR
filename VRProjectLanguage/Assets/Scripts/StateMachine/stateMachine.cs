using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StateMachine : MonoBehaviour {
    public static Stack<StateScript> _ActionsStack;
    public StateScript[] _listOfState;
    public StateScript _CurrentState;

   void Start ()
    {
        _ActionsStack = new Stack<StateScript>();
        foreach (StateScript _state in _listOfState)
        {
            _state._OwnwerStateMachine = this;
            newState(_state);
        }
        _CurrentState = _ActionsStack.Peek();
    }
    void Update () {
        _CurrentState.doAtUpdate();
	}

    public void nextState()
    {
        popState();
        getCurrentState();
    }

    public void popState()
    {
        if (_ActionsStack.Count != 0)
        {
            _ActionsStack.Pop();
        }
    }

    public void getCurrentState()
    {
        if (_ActionsStack.Count != 0)
        {
            _CurrentState = _ActionsStack.Peek();
            if (_CurrentState.GetComponent<SampleDialogScript>())
            {
                _CurrentState.GetComponent<SampleDialogScript>().StartSound();
            }
        }  
    }

    public void newState(StateScript _newState)
    {
        _newState._OwnwerStateMachine = this;
        _ActionsStack.Push(_newState);
    }

    void OnDestroy ()
    {
        _ActionsStack.Clear();
    }
}
