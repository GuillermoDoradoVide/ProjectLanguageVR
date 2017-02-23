using UnityEngine;
using System.Collections;

public class MenuMain : MonoBehaviour {

    public GameObject menus;
    public Script_MainMenu mainMenu;
	public bool isMenuActive = false;

    private void Awake()
    {
    }
	
	// Update is called once per frame
	void Update () {
	}

	public void enableMenu() {
		isMenuActive = !isMenuActive;
		if (isMenuActive) {
			showMenu ();
		}
		else {
			hideMenu ();
		}	
	}

    private void showMenu()
    {
		EventManager.triggerEvent(Events.EventList.MENU_Active);
        if (!menus.activeSelf)
        {
            menus.SetActive(true);
        }
        EventManager.triggerEvent(Events.EventList.GAMEMANAGER_Pause);
    }

    private void hideMenu()
    {
		EventManager.triggerEvent(Events.EventList.MENU_Hide);
        if (menus.activeSelf)
        {
            menus.SetActive(false);
        }
        EventManager.triggerEvent(Events.EventList.GAMEMANAGER_Continue);
    }
}
