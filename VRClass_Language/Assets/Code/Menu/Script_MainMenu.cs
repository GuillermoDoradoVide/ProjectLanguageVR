using UnityEngine;
using System.Collections;

public class Script_MainMenu : MonoBehaviour {
    public MenuAnimationController menuAnimationController;

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
    }

    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
    }

    private void showAnimation ()
    {
        Debug.Log("(" + gameObject.name + ") show animation");
        Debug.Log(Vector3.Distance(gameObject.transform.position, Vector3.zero));
        if (Vector3.Distance(gameObject.transform.position, Vector3.zero) > 7.5f)
        {
            menuAnimationController.animationIsPlaying = false;
        }
        else
        {
            gameObject.transform.Translate(0, 0.01f, 0);
        }
    }

    private void hideAnimation()
    {
        Debug.Log("(" + gameObject.name + ") close animation");
        Debug.Log(Vector3.Distance(gameObject.transform.position, Vector3.zero));
        if (Vector3.Distance(gameObject.transform.position, Vector3.zero) < 7.0f)
        {
            menuAnimationController.animationIsPlaying = false;
            closeThisMenu();
        }
        else
        {
            gameObject.transform.Translate(0, -0.01f, 0);
        }

    }

    private void closeThisMenu()
    {
        EventManager.triggerEvent(Events.EventList.MV_Hide);
    }
}
