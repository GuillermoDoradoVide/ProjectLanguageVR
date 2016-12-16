using UnityEngine;
using System.Collections;

public class PlayerInteractions : MonoBehaviour {

    public Camera playerCamera;
    private RaycastHit hit;
    private ObjectLearingTextInterface toolTipObject;
    public bool displayToolTip = false;
    public ToolTipCanvasScript toolTipCanvas;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit))
        {
            toolTipObject = hit.transform.GetComponentInChildren<ObjectLearingTextInterface>();
            if (toolTipObject)
            {
                displayToolTip = true;
                toolTipCanvas.gameObject.SetActive(true);
                toolTipCanvas.transform.LookAt(playerCamera.transform);
                toolTipCanvas.transform.position = toolTipObject.toolTipDisplayPosition.position;
                toolTipCanvas.changeTextValue(toolTipObject.text);
                if (Vector3.Distance(playerCamera.transform.position, toolTipCanvas.transform.position) > 10)
                {
                    toolTipCanvas.changeSizeValuesFar();
                }
                else if (Vector3.Distance(playerCamera.transform.position, toolTipCanvas.transform.position) > 4)
                {
                    toolTipCanvas.changeSizeValuesMedium();
                }
                else
                {
                    toolTipCanvas.changeSizeValuesNear();
                }
            }
            else
            {
                displayToolTip = false;
            }
        }
        else
        {
            displayToolTip = false;
        }

    }
}
