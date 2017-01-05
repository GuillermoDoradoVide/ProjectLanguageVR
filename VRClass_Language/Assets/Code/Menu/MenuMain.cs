using UnityEngine;
using System.Collections;

public class MenuMain : MonoBehaviour {

    private GameObject menus;
    private MenuAnimationController[] animationController;
    public delegate void AnimationManager();
    public static event AnimationManager animations;

    private bool active = false;

    private void Awake ()
    {
        animationController = menus.GetComponentsInChildren<MenuAnimationController>();
        foreach (MenuAnimationController animController in animationController)
        {
            animations += animController.playAnimation;
        }
    }

    private void OnDisable ()
    {
        foreach (MenuAnimationController animController in animationController)
        {
            animations -= animController.playAnimation;
        }
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
        EventManager.stopListening(Events.EventList.MV_Active, disableMenu);
    }
	
	// Update is called once per frame
	void Update () {
	if(active)
        {
            animations();
        }
	}

    private void activeMenu()
    {
        if (!menus.activeSelf)
        {
            menus.SetActive(true);
            active = true;
        }
        
    }

    private void disableMenu()
    {

    }
}
