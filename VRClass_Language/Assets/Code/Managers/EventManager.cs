using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class EventManager : SingletonComponent<EventManager>
{
    [SerializeField]
    private Dictionary<Events.EventList, UnityEvent> eventDictionary;
    public delegate void NewDialogEvent(AudioClip audioClip);
    static NewDialogEvent newDialog;

    private void Awake()
    {
        if(eventDictionary == null)
        {
            eventDictionary = new Dictionary<Events.EventList, UnityEvent>();
        }
    }

    private void Start()
    {
        initEvents();
    }

    private void initEvents()
    {

    }
    //Generic event EventManager
    public static void startListening (Events.EventList eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void stopListening (Events.EventList eventName, UnityAction listener)
    {
        if (instance == null) return;
        UnityEvent thisEvent = null;
        if(instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void triggerEvent(Events.EventList eventName)
    {
        UnityEvent thisEvent = null;
        if(instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }

    public static void addDialogListener(NewDialogEvent method)
    {
        newDialog += method;
    }

    public static void removeDialogListener(NewDialogEvent method)
    {
        newDialog -= method;
    }

    public static void setNewDialogEvent(AudioClip audioClip)
    {
        if (newDialog != null) newDialog(audioClip);
    }
}
