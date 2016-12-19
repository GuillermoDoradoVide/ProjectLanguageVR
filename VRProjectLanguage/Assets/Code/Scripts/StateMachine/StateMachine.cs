using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[AddComponentMenu("StateMachine/StateMachine")]
public class StateMachine : MonoBehaviour {
    public Stack<StateScript> ActionsStack;
    public StateScript[] listOfState;
    public StateScript CurrentState;

   void Start ()
    {
        ActionsStack = new Stack<StateScript>();
        foreach (StateScript state in listOfState)
        {
            addState(state);
        }
        CurrentState = ActionsStack.Peek();
        EventManager.nextMachineState = nextState;
    }
    void Update () {
        CurrentState.doUpdate();
	}

    public void nextState()
    {
        popState();
        getCurrentState();
    }

    public void popState()
    {
        if (ActionsStack.Count != 0)
        {
            ActionsStack.Pop();
        }
    }

    public void getCurrentState()
    {
        if (ActionsStack.Count != 0)
        {
            CurrentState = ActionsStack.Peek();
            CurrentState.atInit();
        }  
    }

    public void addState(StateScript newState)
    {
        ActionsStack.Push(newState);
    }

    public void clearStack()
    {
        ActionsStack.Clear();
    }
}
