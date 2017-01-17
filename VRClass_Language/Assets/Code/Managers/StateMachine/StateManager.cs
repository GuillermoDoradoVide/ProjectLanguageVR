using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[AddComponentMenu("StateMachine/StateMachine")]
public class StateManager : ScriptableObject {
    private Stack<StateScript> stackStateList;
    private StateScript currentState;

   private void Awake ()
    {
        stackStateList = new Stack<StateScript>();
        initMachine();
    }

    public void  initMachine() {
        EventManager.startListening(Events.EventList.SV_nextState, nextState);
        EventManager.startListening(Events.EventList.SV_pauseState, pauseState);
        EventManager.startListening(Events.EventList.SV_continueState, continueState);
    }

    public void doUpdate () {
        if (currentState != null)
        {
            Debug.Log("state " + currentState.name);
            currentState.doUpdate();
        }
        Debug.Log("nada");
    }

    public void nextState()
    {
        if (stackStateList.Count != 0)
        {
            stackStateList.Pop();
            if (stackStateList.Count != 0)
            {
                currentState = stackStateList.Peek();
                currentState.atInit();
            }
        }
        
    }

    public void pauseState()
    {
        currentState.doPause();
    }

    public void continueState()
    {
        currentState.doContinue();
    }

    private void OnDisable()
    {
        EventManager.stopListening(Events.EventList.SV_nextState, nextState);
        EventManager.stopListening(Events.EventList.SV_pauseState, pauseState);
        EventManager.stopListening(Events.EventList.SV_continueState, continueState);
    }

    public void getLevelStateList(List<StateScript> levelList)
    {
        foreach (StateScript state in levelList)
        {
            stackStateList.Push(state);
        }
        currentState = stackStateList.Peek();
    }
}
