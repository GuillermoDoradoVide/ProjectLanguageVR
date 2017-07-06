using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	public GameObject menuCanvas;
    public GameObject mainCamera;
    public bool touching;
    public Vector2 firstTouch;
    public Vector2 currentTouch;

	// Use this for initialization
	private void Start ()
	{
		menuCanvas = GameObject.Find ("[MENU]");
		menuCanvas.SetActive (false);
		EventManager.startListening (Events.EventList.STATE_Pause, activeMenu);
		EventManager.startListening (Events.EventList.STATE_Continue, disableMenu);
        EventManager.startListening (Events.EventList.MENU_Show, activeMenu);
        EventManager.startListening (Events.EventList.MENU_Hide, disableMenu);
            
        touching = false;

    }

	private void OnEnable() {
		EventManager.startListening (Events.EventList.STATE_Pause, activeMenu);
		EventManager.startListening (Events.EventList.STATE_Continue, disableMenu);
        EventManager.startListening (Events.EventList.MENU_Show, activeMenu);
        EventManager.startListening (Events.EventList.MENU_Hide, disableMenu);
    }

	private void OnDisable() {
		EventManager.stopListening (Events.EventList.STATE_Pause, activeMenu);
		EventManager.stopListening (Events.EventList.STATE_Continue, disableMenu);
        EventManager.stopListening (Events.EventList.MENU_Show, activeMenu);
        EventManager.stopListening (Events.EventList.MENU_Hide, disableMenu);
    }

	private void activeMenu() {
		menuCanvas.SetActive (true);
	}

	private void disableMenu() {
		menuCanvas.SetActive (false);
	}

    private void Update()
    {
        if(GvrController.IsTouching)
        {
            if (touching == false)
            {
                firstTouch = GvrController.TouchPos;
                touching = true;
            }
            else
            {
                currentTouch = GvrController.TouchPos;
                if (Vector2.Distance(firstTouch, currentTouch) > 0.55f)
                {
                    touching = false;
                    if (firstTouch.x > currentTouch.x)
                    {
                        mainCamera.transform.RotateAround(mainCamera.transform.position, Vector3.up, -45);
                    }
                    else
                    {
                        mainCamera.transform.RotateAround(mainCamera.transform.position, Vector3.up, 45);
                    }
                }
            }
        }
        else
        {
            touching = false;
        }
    }

}
