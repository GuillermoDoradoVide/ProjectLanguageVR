using UnityEngine;
using System.Collections;

public class MenuMain : MonoBehaviour, IElement {

	// Use this for initialization
	void Start () {
	
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
}
