using UnityEngine;
using System.Collections;

public class Script_MainMenu : MonoBehaviour, IElement, IMenu {
    public MenuAnimationController menuAnimationController;
    public float timer = 1.0f;

    private void Awake()
    {
        menuAnimationController = GetComponent<MenuAnimationController>();
        menuAnimationController.setShowAnimation = showAnimation;
        menuAnimationController.setHideAnimation = hideAnimation;
    }

	public void hoverEffect(){}

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
			EventManager.unlockAchievementEvent(AchievementKeysList.AchievementList.FIRST_LOGGIN);
            EventManager.triggerEvent(Events.EventList.ACHIEVEMENT_TriggerUnlocked_Achievement);
        }
    }

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

    private void showAnimation ()
    {
		menuAnimationController.animationIsPlaying = false;
    }

    private void hideAnimation()
    {
		menuAnimationController.animationIsPlaying = false;
    }
}
