﻿using UnityEngine;
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
        EventManager.startListening(Events.EventList.STATE_Next, nextState);
        EventManager.startListening(Events.EventList.STATE_Pause, pauseState);
        EventManager.startListening(Events.EventList.STATE_Continue, continueState);
    }

    public void doUpdate () {
        if (currentState != null)
        {
            currentState.doUpdate();
        }
    }

    public void nextState()
    {
        if (stackStateList.Count != 0)
        {
            stackStateList.Pop();
            currentState.atEnd();
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

    public void endState()
    {
        currentState.atEnd();
    }

    private void OnDisable()
    {
        EventManager.stopListening(Events.EventList.STATE_Next, nextState);
        EventManager.stopListening(Events.EventList.STATE_Pause, pauseState);
        EventManager.stopListening(Events.EventList.STATE_Continue, continueState);
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
