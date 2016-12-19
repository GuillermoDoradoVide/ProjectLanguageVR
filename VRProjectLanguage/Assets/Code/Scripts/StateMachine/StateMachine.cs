using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[AddComponentMenu("StateMachine/StateMachine")]
public class StateMachine : MonoBehaviour {
    //public stateMachineStateList stateList;
    public List<StateScript> stateList;
    public Stack<StateScript> stackStateList;
    [SerializeField]
    private StateScript currentState;

   private void Start ()
    {
        initMachine();
        stackStateList = new Stack<StateScript>();
    foreach (StateScript state in stateList)
        {
            stackStateList.Push(state);
        }
        currentState = stackStateList.Peek();
        /*if (stateList && stateList.Length != 0)
        {
            currentState = stateList.getCurrentState();
        }
        else
        {
            Debug.Log("[StateMachine]: " + gameObject.name + " has an EMPTY/NULL StateList.");
        }*/
    }

    private void  initMachine() {
        EventManager.nextMachineState += nextState;
        EventManager.statePaused += pauseState;
        EventManager.stateContinue += continueState;
    }

    private void Update () {
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
        }
        currentState = stackStateList.Peek();
        //currentState = stateList.getNextState();
        currentState.atInit();
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
        EventManager.statePaused -= pauseState;
        EventManager.stateContinue -= continueState;
        EventManager.nextMachineState -= continueState;
    }
}
