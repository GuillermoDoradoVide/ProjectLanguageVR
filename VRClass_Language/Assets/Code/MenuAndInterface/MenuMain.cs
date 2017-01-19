using UnityEngine;
using System.Collections;

public class MenuMain : MonoBehaviour {

    public GameObject menus;
    public Script_MainMenu mainMenu;
    private bool active = false;
    

    private void Awake()
    {
        EventManager.startListening(Events.EventList.MENU_Active, activeMenu);
        EventManager.startListening(Events.EventList.MENU_Hide, disableMenu);
    }
	
	// Update is called once per frame
	void Update () {

        if(Input.anyKeyDown)
        {
            Debug.Log("tecla apretada");
            EventManager.triggerEvent(Events.EventList.MENU_Active);
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
        EventManager.triggerEvent(Events.EventList.GAMEMANAGER_Pause);
    }

    private void disableMenu()
    {
        active = false;
        if (menus.activeSelf)
        {
            menus.SetActive(false);
        }
        EventManager.triggerEvent(Events.EventList.GAMEMANAGER_Continue);
    }
}
