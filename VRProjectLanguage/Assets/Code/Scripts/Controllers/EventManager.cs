using UnityEngine;
using System.Collections;
[AddComponentMenu("EventManager/StateEventManager")]
public class EventManager : SingletonComponent<EventManager>
{
    public delegate void MachineState();
    public static event MachineState nextMachineState;
    public delegate void StatesEvent();
    public static event StatesEvent statePaused;
    public static event StatesEvent stateContinue;

    private void Awake()
    {
    }

    private void Start()
    {
    }

    public void EventPause ()
    {
        if (statePaused != null) statePaused();
    }

    public void EventContinue () {
        if (stateContinue != null) stateContinue();
    }

    public void EventNextState()
    {
        if (nextMachineState != null) nextMachineState();
    }

}
