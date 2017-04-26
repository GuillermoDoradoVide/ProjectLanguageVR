using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class IntUnityEvent : UnityEvent<int> {}
[System.Serializable]
public class StringUnityEvent : UnityEvent<string> {}

public class EventManager : SingletonComponent<EventManager>
{
    [SerializeField]
    public Dictionary<Events.EventList, UnityEvent> eventDictionary;
    public delegate void setAchievementUnlocked(AchievementKeysList.AchievementList key);
    static setAchievementUnlocked achievementUnlocked;
	public delegate void TeleportPlayer(Transform position);
	static TeleportPlayer teleportPlayer;

    public delegate void EventGenericDelegate<T>(T e) where T : UnityEvent;
    private delegate void EventGenericDelegate(UnityEvent unityEvent);
	
	private Dictionary<System.Type, EventGenericDelegate> delegates = new Dictionary<System.Type, EventGenericDelegate>();
    private Dictionary<System.Delegate, EventGenericDelegate> delegateLookup = new Dictionary<System.Delegate, EventGenericDelegate>();
    private Dictionary<System.Delegate, System.Delegate> onceLookups = new Dictionary<System.Delegate, System.Delegate>();


    private void Awake()
    {
       eventDictionary = new Dictionary<Events.EventList, UnityEvent>();
    }

    private void Start()
    {
        initEvents();
    }

    private void initEvents()
    {

    }
	
	public void addListener<T> (EventGenericDelegate<T> del) where T : UnityEvent {

        // Early-out if we've already registered this delegate
        //if (delegateLookup.ContainsKey(del))
        //    return null;

        // Create a new non-generic delegate which calls our generic one.
        // This is the delegate we actually invoke.
        EventGenericDelegate internalDelegate = (e) => del((T)e);
        delegateLookup[del] = internalDelegate;

        EventGenericDelegate thisEvent = null;
        if (delegates.TryGetValue(typeof(T), out thisEvent)) {
            delegates[typeof(T)] = thisEvent += internalDelegate; 
        } else {
            delegates[typeof(T)] = internalDelegate;
        }
	}
    //Generic event EventManager
    public static void startListening (Events.EventList eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null;
        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            instance.eventDictionary.Add(eventName, thisEvent);
        }
		Debugger.printLog("Start listening to event: " + eventName);
    }

    public static void stopListening (Events.EventList eventName, UnityAction listener)
    {
        if (instance == null) return;
        UnityEvent thisEvent = null;
        if(Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
		Debugger.printLog("Stop listening to event: " + eventName);
    }

    public static void triggerEvent(Events.EventList eventName)
    {
        UnityEvent thisEvent = null;
        if(Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke();
			Debugger.printLog("Trigger this event: " + eventName);
        }
    }

    //achievements
    public static void addAchievementListener(setAchievementUnlocked method)
    {
        achievementUnlocked += method;
    }

    public static void removeAchievementListener(setAchievementUnlocked method)
    {
        achievementUnlocked -= method;
    }

    public static void unlockAchievementEvent(AchievementKeysList.AchievementList achievement)
    {
        if (achievementUnlocked != null) achievementUnlocked(achievement);
    }

	//teleport
	public static void addTeleportListener(TeleportPlayer method)
	{
		teleportPlayer += method;
	}

	public static void removeTeleportListener(TeleportPlayer method)
	{
		teleportPlayer -= method;
	}

	public static void teleportPlayerToPosition(Transform position)
	{
		if (teleportPlayer != null) teleportPlayer(position);
	}

}
