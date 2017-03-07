using UnityEngine;
using System.Collections;

public class ScriptSubMenuC : MonoBehaviour, IElement, IMenu
{

    public MenuAnimationController menuAnimationController;
    public float timer = 1.0f;

	public void closeMenu()
	{
		gameObject.SetActive(false);
	}

	public void hideMenu (){
	}
	public void selectMenu (){
	}
	public void hoverMenu(){
	}
	public void resetMenu(){
	}
    public void hoverElement()
    {

    }

    public void selectElement()
    {
        Debug.Log("select this menu element " + gameObject.name);
        EventManager.triggerEvent(Events.EventList.MV_SubMenuC_Active);
    }

    public void resetElement()
    {
        menuAnimationController.animationActions = MenuAnimationController.AnimationActions.Hide;
        menuAnimationController.animationIsPlaying = true;
    }
    //**********************************************************************

    private void Awake()
    {
        menuAnimationController = GetComponent<MenuAnimationController>();
        menuAnimationController.setShowAnimation = showAnimation;
        menuAnimationController.setHideAnimation = hideAnimation;
    }

    private void OnEnable()
    {
        Debug.Log("se lanza el metodo OnEnable del objeto: " + this.gameObject.name);
        menuAnimationController.animationActions = MenuAnimationController.AnimationActions.Show;
        menuAnimationController.animationIsPlaying = true;
        EventManager.startListening(Events.EventList.MV_SubMenuC_Hide, resetElement);
        EventManager.startListening(Events.EventList.MV_SubMenuA_Active, resetElement);
        EventManager.startListening(Events.EventList.MV_SubMenuB_Active, resetElement);
    }

    private void OnDisable()
    {
        EventManager.stopListening(Events.EventList.MV_SubMenuC_Hide, resetElement);
        EventManager.stopListening(Events.EventList.MV_SubMenuA_Active, resetElement);
        EventManager.stopListening(Events.EventList.MV_SubMenuB_Active, resetElement);
    }

	public void hoverEffect(){}

    private void showAnimation()
    {
        Debug.Log("(" + gameObject.name + ") show animation");
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
        Debug.Log("(" + gameObject.name + ") close animation");
        if (timer < 0)
        {
            menuAnimationController.animationIsPlaying = false;
            timer = 1.0f;
            closeMenu();
        }
        else
        {
            gameObject.transform.Translate(0, -0.01f, 0);
            timer -= Time.deltaTime;
        }

    }
}
