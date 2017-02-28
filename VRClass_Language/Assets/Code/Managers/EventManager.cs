using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class EventManager : SingletonComponent<EventManager>
{
    [SerializeField]
    public Dictionary<Events.EventList, UnityEvent> eventDictionary;
    public delegate void setAchievementUnlocked(AchievementKeysList.AchievementList key);
    static setAchievementUnlocked achievementUnlocked;
	public delegate void TeleportPlayer(Transform position);
	static TeleportPlayer teleportPlayer;

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
        Debug.Log("Start listening to event: " + eventName);
    }

    public static void stopListening (Events.EventList eventName, UnityAction listener)
    {
        if (instance == null) return;
        UnityEvent thisEvent = null;
        if(Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
        Debug.Log("Stop listening to event: " + eventName);
    }

    public static void triggerEvent(Events.EventList eventName)
    {
        UnityEvent thisEvent = null;
        if(Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke();
            Debug.Log("Trigger this event: " + eventName);
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
