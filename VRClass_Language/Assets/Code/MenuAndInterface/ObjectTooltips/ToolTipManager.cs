using UnityEngine;
using System.Collections;

public class ToolTipManager : MonoBehaviour
{
    public Canvas toolTipCanvas;
	public ToolTipPanel toolTipPanel;
	public ObjectToolTip toolTipObject;
	public ObjectToolTipData toolTipData;
	public ObjectActionMenu actionMenu;
	public Transform viewPosition;
	public Vector3 originPos;
	public Quaternion originQuat;
	public Inventario inventario;
	public  enum SCALE_ACTION
	{
		SCALE_UP, SCALE_DOWN, SCALE_ORIGIN
	};

	SCALE_ACTION scaleType;

	public Vector3 scaleDown = new Vector3(0.5f, 0.5f, 0.5f);
	public Vector3 scaleUp = new Vector3(1.5f, 1.5f, 1.5f);
	public Vector3 scaleOrigin = new Vector3(1f, 1f, 1f);
	public Vector3 initScale;
	public Vector3 finalScale;
	public float translationSpeed;
	public float slerpTransitionRange;
	public float slerpScaleRange;

	private void Awake() {}

	public void getObjectInfo(ObjectToolTip newObjectTooltip) {
		toolTipObject = newObjectTooltip;
		toolTipData = toolTipObject.data;
		setInfoIntoToolTip ();
	}

	public void setInfoIntoToolTip() {
		if(toolTipData != null) {
			toolTipPanel.updatePanelInfo (toolTipData);
		}
	}

	public void viewMode() {
		if(toolTipData != null) {
			toolTipObject.disableTriggers ();
			toolTipPanel.setHidePanel ();
			originPos = toolTipData.transform.position;
			originQuat = toolTipData.transform.rotation;
			StartCoroutine (smoothTranslation(originPos, viewPosition.position));
			calculateViewSize ();
			actionMenu.activeAtrasMenu ();
			if(toolTipData.itemData.getItemInteractions()!=null) {
				if(toolTipData.itemData.getItemInteractions().canBePicked) {
					actionMenu.activePickMenu ();
				}
				if(toolTipData.itemData.getItemInteractions().canBeSelected) {
					actionMenu.activeSelectMenu ();
				}
			}
		}
	}

	public void pickObject() {
		if(toolTipData != null) {
			inventario.addItem (toolTipData.itemData);
		}
	}

	public void clearViewMode() {
		if(toolTipData != null) {
			StartCoroutine (smoothTranslation(viewPosition.position, originPos));
			toolTipData.transform.rotation = originQuat;
			scaleType = SCALE_ACTION.SCALE_ORIGIN;
			smoothScale ();
			toolTipObject.enableTriggers ();
			actionMenu.disableMenus ();
		}
	}

	public void clearInfo () {
		clearInfoOfToolTip ();
	}

	private void clearInfoOfToolTip() {
		toolTipData = null;
	}

	private void calculateViewSize() {
		Debug.Log ("size: > " + toolTipData.gameObject.GetComponent<Renderer> ().bounds.extents.sqrMagnitude);
		if (toolTipData.gameObject.GetComponent<Renderer>().bounds.extents.sqrMagnitude > 0.6f) {
			scaleType = SCALE_ACTION.SCALE_DOWN;
		}
		else if (toolTipData.gameObject.GetComponent<Renderer>().bounds.extents.sqrMagnitude < 0.4f) {
			scaleType = SCALE_ACTION.SCALE_UP;
		}
		smoothScale ();
	}

	private IEnumerator smoothTranslation(Vector3 initPos, Vector3 finalPos) {
		slerpTransitionRange = 0;
		while (toolTipData.transform.position != finalPos) {
			Debug.Log ("Calculando...position");
			toolTipData.transform.position = Vector3.Slerp (initPos, finalPos,  slerpTransitionRange);
			slerpTransitionRange += Time.deltaTime * translationSpeed;
			if (slerpTransitionRange > 1)
				slerpTransitionRange = 1;
			yield return null;
		}
	}

	private void smoothScale() {
		switch(scaleType) {
		case SCALE_ACTION.SCALE_UP : {
				initScale = scaleOrigin;
				finalScale = scaleUp;
				break;
			}
		case SCALE_ACTION.SCALE_DOWN : {
				initScale = scaleOrigin;
				finalScale = scaleDown;
				break;
			}
		case SCALE_ACTION.SCALE_ORIGIN : {
				initScale = toolTipData.transform.localScale;
				finalScale = scaleOrigin;
				break;
			}
		}
		StartCoroutine (calculateScale());
	}

	private IEnumerator calculateScale()  {
		slerpScaleRange = 0;
		while (toolTipData.transform.localScale != finalScale) {
			Debug.Log ("calculando scale...");
			toolTipData.transform.localScale = Vector3.Lerp (initScale, finalScale, slerpScaleRange);
			slerpScaleRange += Time.deltaTime * translationSpeed;
			if (slerpTransitionRange > 1)
				slerpTransitionRange = 1;
			yield return null;
		}
	}

}
