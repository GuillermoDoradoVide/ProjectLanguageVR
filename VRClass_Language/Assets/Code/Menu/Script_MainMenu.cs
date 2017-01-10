using UnityEngine;
using System.Collections;

public class Script_MainMenu : MonoBehaviour, IElement {
    public MenuAnimationController menuAnimationController;
    public float timer = 1.0f;
    public GameObject[] subMenus;

    //IElement interface implementation
    //**********************************
    public void closeThisMenu() // deberia llamarse para desactivar el objeto principal del menu una vez el resto de 
                                //elementos esten desactivados o reseteados
    {
        EventManager.triggerEvent(Events.EventList.MV_Hide);
    }

    public void hoverElement()
    {

    }

    public void selectElement()
    {
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
        EventManager.startListening(Events.EventList.MV_Active, activeSubMenus);
        //activeSubMenus();
    }

    private void activeSubMenus()
    {

        Debug.Log("Se activa bien asi que deberia ir...");
        foreach (GameObject gameObject in subMenus)
        {
            gameObject.SetActive(true);
        }
    }

    private void OnEnable()
    {
        Debug.Log("se lanza el metodo OnEnable del objeto: " + this.gameObject.name);
        menuAnimationController.animationActions = MenuAnimationController.AnimationActions.Show;
        menuAnimationController.animationIsPlaying = true;
        EventManager.startListening(Events.EventList.MV_Active, activeSubMenus);
    }

    private void OnDisable()
    {
        EventManager.stopListening(Events.EventList.MV_Active, activeSubMenus);
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
        Debug.Log(Vector3.Distance(gameObject.transform.position, Vector3.zero));
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
