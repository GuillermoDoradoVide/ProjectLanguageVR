using UnityEngine;
using System.Collections;

public class ToolTipManager : MonoBehaviour, IElement
{
    public Canvas toolTipCanvas;
    public ObjectToolTip objectToolTip;

    public void hoverElement()
    {
        if (!toolTipCanvas.gameObject.activeSelf)
        {
            toolTipCanvas.gameObject.SetActive(true);
        }
        objectToolTip.disableTooltip = false;
    }

    public void selectElement()
    {
    }

    public void resetElement()
    {
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
