using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerGazeInteraction : MonoBehaviour {
    private RaycastHit hit;
    public Transform playerPosition;
    public GameObject targetGazedObject;
    private void Awake()
    {
        playerPosition = GetComponent<Transform>();
        targetGazedObject = null;
    }
	// Use this for initialization
	private void Start () {
	
	}
	
	// Update is called once per frame
	private void Update () {
        drawGaze();
        playerGaze();
        playerGazeAngle();
	}

    private void playerGaze()
    {
        if (Physics.Raycast(playerPosition.position, playerPosition.forward, out hit))
        {
            targetGazedObject = hit.transform.gameObject;
            if (ExecuteEvents.CanHandleEvent<IElement>(targetGazedObject))
            {
                ExecuteEvents.Execute(targetGazedObject, null, (IElement element, BaseEventData data) => element.hoverElement());
                // si se selecciona el objeto se manda el evento > EventManager.triggerEvent(Events.EventList.MV_Active);
            }
        }
    }

    private void drawGaze()
    {
        Debug.DrawRay(playerPosition.position, playerPosition.forward, Color.red);
        Debug.DrawLine(playerPosition.position, playerPosition.forward, Color.green);
    }

    private void playerGazeAngle()
    {
        if (GvrController.Orientation.x < 80 && GvrController.Orientation.x > 10)
        {
            EventManager.triggerEvent(Events.EventList.MV_Active);
        }
    }
}
