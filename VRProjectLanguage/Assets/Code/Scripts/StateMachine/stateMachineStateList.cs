using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "stateList", menuName = "Assets/StateList", order = 3)]
public class stateMachineStateList : ScriptableObject {
    public StateScript[] stateList;
    public StateScript waitState;
    public int currentState = 0;

    public static StateScript[] StateList
    {
        get
        {
            return StateList;
        }
    }

    public int Length
    {
        get
        {
            return stateList.Length;
        }
    }

    public StateScript getCurrentState()
    {
        return stateList[currentState];
    }

    public StateScript getNextState()
    { 
        if (currentState < (stateList.Length - 1))
        {
            currentState++;
            return stateList[currentState];
        }
        else
        {
            return waitState;
        }
    }
}
