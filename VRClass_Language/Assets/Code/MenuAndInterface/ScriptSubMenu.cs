using UnityEngine;
using System.Collections;

public class ScriptSubMenu : MonoBehaviour, IElement, IMenu
{
    public MenuAnimationController menuAnimationController;
    public float timer = 1.0f;
    public GameObject exit3DText;

    private void Awake()
    {
        menuAnimationController = GetComponent<MenuAnimationController>();
        menuAnimationController.setShowAnimation = showAnimation;
        menuAnimationController.setHideAnimation = hideAnimation;
    }

    private void OnEnable()
    {
        Debug.Log("Se activa el objeto: [" + gameObject.name + "]");
        EventManager.startListening(Events.EventList.MV_SubMenuA_Hide, resetElement);
        EventManager.startListening(Events.EventList.MV_SubMenuB_Active, resetElement);
        EventManager.startListening(Events.EventList.MV_SubMenuC_Active, resetElement);
        setShowAnimation();
    }

    private void OnDisable()
    {
        Debug.Log("Se DESactiva el objeto: [" + gameObject.name + "]");
        EventManager.stopListening(Events.EventList.MV_SubMenuA_Hide, resetElement);
        EventManager.stopListening(Events.EventList.MV_SubMenuB_Active, resetElement);
        EventManager.stopListening(Events.EventList.MV_SubMenuC_Active, resetElement);
    }

    void Start()
    {
    }

    void Update()
    {
    }

    //IElement interface implementation
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
        EventManager.triggerEvent(Events.EventList.MV_SubMenuA_Active);
        exit3DText.SetActive(true);
    }

    public void resetElement()
    {
        exit3DText.SetActive(false);
        EventManager.triggerEvent(Events.EventList.MENU_Active);
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

    private void showAnimation()
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
        }
        else
        {
            gameObject.transform.Translate(0, -0.01f, 0);
            timer -= Time.deltaTime;
        }
    }
}
