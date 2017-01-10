using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerControllerInteraction : MonoBehaviour {

    RaycastHit hit;
    GameObject targetGazedObject;
    private Ray ray;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            targetGazedObject = hit.transform.gameObject;
            if (ExecuteEvents.CanHandleEvent<IElement>(targetGazedObject))
            {
                Debug.Log("SSSSSSSSSSSSSSSSSSSSSSS AAAAAAAAAAAAAAAAAAAAAAAAA" + targetGazedObject.name);
                ExecuteEvents.Execute(targetGazedObject, null, (IElement element, BaseEventData data) => element.selectElement());
                // si se selecciona el objeto se manda el evento > EventManager.triggerEvent(Events.EventList.MV_Active);
            }
        }

    }
}
