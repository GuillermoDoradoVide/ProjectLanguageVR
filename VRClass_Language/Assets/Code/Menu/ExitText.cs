using UnityEngine;
using System.Collections;

public class ExitText : MonoBehaviour {

    public bool triggerBool = false;

    private void OnEnable()
    {
        Debug.Log("se lanza el metodo OnEnable del objeto: " + this.gameObject.name);
    }

    private void OnDisable()
    {

    }

    private void exitMenu()
    {
        EventManager.triggerEvent(Events.EventList.MV_SubMenuA_Hide);
        triggerBool = false;
        gameObject.SetActive(false);
    }

    private void Awake()
    {
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(triggerBool)
        {
            exitMenu();
        }
	
	}
}
