using UnityEngine;
using System.Collections;

public class MenuMain : MonoBehaviour {

    public GameObject menus;
    public Script_MainMenu mainMenu;
    private bool active = false;

    private void Awake ()
    {
    }

	// Use this for initialization
	void Start () {
    }

    private void OnEnable()
    {
        EventManager.startListening(Events.EventList.MV_Active, activeMenu);
        EventManager.startListening(Events.EventList.MV_Hide, disableMenu);
    }

    private void OnDisable()
    {
        EventManager.stopListening(Events.EventList.MV_Active, activeMenu);
        EventManager.stopListening(Events.EventList.MV_Hide, disableMenu);
    }
	
	// Update is called once per frame
	void Update () {

        if(Input.anyKeyDown)
        {
            EventManager.triggerEvent(Events.EventList.MV_Active);
        }
	if(active)
        {
        }
	}

    private void activeMenu()
    {
        if (!menus.activeSelf)
        {
            menus.SetActive(true);
        }
        active = true;
        EventManager.triggerEvent(Events.EventList.SV_pauseState);
    }

    private void disableMenu()
    {
        active = false;
        if (menus.activeSelf)
        {
            menus.SetActive(false);
        }
        EventManager.triggerEvent(Events.EventList.SV_continueState);
    }
}
