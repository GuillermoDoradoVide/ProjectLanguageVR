using UnityEngine;
using System.Collections;

public class Script_MainMenu : MonoBehaviour, IElement, IMenu {
    public MenuAnimationController menuAnimationController;
    public float timer = 1.0f;
    public GameObject[] subMenus;

    private void Awake()
    {
        menuAnimationController = GetComponent<MenuAnimationController>();
        EventManager.startListening(Events.EventList.MENU_Active, activeSubMenus);
        EventManager.startListening(Events.EventList.MENU_Hide, closeSubMenus);
        menuAnimationController.setShowAnimation = showAnimation;
        menuAnimationController.setHideAnimation = hideAnimation;
    }

    private void Start(){}

    private void OnEnable()
    {
        Debug.Log("Se activa el objeto: [" + gameObject.name + "]");
        setShowAnimation();
    }

    private void OnDisable(){}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            EventManager.setNewUnlockedAchievementEvent("Sample");
            EventManager.triggerEvent(Events.EventList.ACHIEVEMENT_TriggerUnlocked_Achievement);
        }
    }

    //I interface implementation
    //**********************************
    public void closeThisMenu()
    {
        gameObject.SetActive(false);
    }

    public void hoverElement()
    {
    }

    public void selectElement()
    {
    }

    public void resetElement()
    {
        setHideAnimation();
    }
    //**********************************************************************

    private void setShowAnimation()
    {
        menuAnimationController.animationActions = MenuAnimationController.AnimationActions.Show;
        menuAnimationController.animationIsPlaying = true;
    }

    private void setHideAnimation()
    {
        menuAnimationController.animationActions = MenuAnimationController.AnimationActions.Hide;
        menuAnimationController.animationIsPlaying = true;
    }

    private void activeSubMenus()
    {
        foreach (GameObject gameObject in subMenus)
        {
            gameObject.SetActive(true);
        }
    }

    private void closeSubMenus()
    {
        foreach (GameObject gameObject in subMenus)
        {
            gameObject.GetComponent<IMenu>().closeThisMenu();
        }
        resetElement();
    }

    private void showAnimation ()
    {
        if (timer < 0)
        {
            menuAnimationController.animationIsPlaying = false;
            timer = 1.0f;
        }
        else
        {
            gameObject.transform.Translate(0, 0.01f, 0);
            timer -= Time.deltaTime;
        }
    }

    private void hideAnimation()
    {
        if (timer < 0)
        {
            menuAnimationController.animationIsPlaying = false;
            timer = 1.0f;
            closeThisMenu();
        }
        else
        {
            gameObject.transform.Translate(0, -0.01f, 0);
            timer -= Time.deltaTime;
        }
    }
}
