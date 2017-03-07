using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ObjectToolTip : MonoBehaviour {
	public ToolTipManager TTmanager;
	public ObjectToolTipData data;
	private ObjectToolTip objectTooltip;
	private EventTrigger eventTrigger;

	void Start () {
		data = GetComponentInParent<ObjectToolTipData> ();
		eventTrigger = GetComponent<EventTrigger> ();
		objectTooltip = GetComponent<ObjectToolTip> ();
	}

	public void sendInfo() {
		TTmanager.getObjectInfo (objectTooltip);
	}

	public void disableTriggers () {
		eventTrigger.enabled = false;
	}

	public void enableTriggers() {
		eventTrigger.enabled = true;
	}
}