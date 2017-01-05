using UnityEngine;
using System.Collections;

public class MenuMain : MonoBehaviour {

    public GameObject menus;
    public Script_MainMenu mainMenu;
    private bool active = false;

    private void Awake ()
    {
    }

    private void OnDisable ()
    {
    }

	// Use this for initialization
	void Start () {
    }

    private void onEnable()
    {
        EventManager.startListening(Events.EventList.MV_Active, activeMenu);
    }

    private void onDisable()
    {
        EventManager.stopListening(Events.EventList.MV_Active, activeMenu);
    }
	
	// Update is called once per frame
	void Update () {
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
        EventManager.triggerEvent(Events.EventList.SV_continueState);
        //menus.SetActive(false);
    }
}
