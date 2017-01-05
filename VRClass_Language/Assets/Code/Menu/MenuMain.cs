using UnityEngine;
using System.Collections;

public class MenuMain : MonoBehaviour, IElement {

    public GameObject menus;
	// Use this for initialization
	void Start () {
        
    }

    private void onEnable()
    {
        EventManager.startListening(Events.EventList.MV_Show, showMenu);
    }

    private void onDisable()
    {
        EventManager.stopListening(Events.EventList.MV_Show, hideMenu);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void hoverElement()
    {
        Debug.Log("(GameObject)" + name + "> is beeing looked at.");
    }

    public void selectElement()
    {

    }

    public void resetElement()
    {

    }

    private void showMenu()
    {
        if (!menus.activeSelf) menus.SetActive(true);
    }

    private void hideMenu()
    {

    }
}
