using UnityEngine;
using System.Collections;

public class ToolTipManager : MonoBehaviour
{
    public Canvas toolTipCanvas;
	public ToolTipPanel toolTipPanel;
	public ObjectToolTipData toolTipData;

	public GameObject actionMenu;
	public Transform viewPosition;
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

	public void addInfoToPanel(ObjectToolTipData data) {
		toolTipData = data;
		setInfoIntoToolTip ();
		viewMode ();
	}

	private void setInfoIntoToolTip() {
		
	}

	public void viewMode() {
		if(toolTipData != null) {
			StartCoroutine (smoothTranslation(toolTipData.position, viewPosition.position));
			Debug.Log ("size: > " + toolTipData.gameObjectTransform.GetComponent<Renderer> ().bounds.extents.sqrMagnitude);
			if (toolTipData.gameObjectTransform.GetComponent<Renderer>().bounds.extents.sqrMagnitude > 0.5f) {
				smoothScale (SCALE_ACTION.SCALE_DOWN);
			}
			actionMenu.SetActive (true);
		}
	}

	public void clearViewMode() {
		if(toolTipData != null) {
			StartCoroutine (smoothTranslation(viewPosition.position, toolTipData.position));
			toolTipData.gameObjectTransform.rotation = toolTipData.rotation;
			smoothScale (SCALE_ACTION.SCALE_ORIGIN);
			toolTipData.gameObjectTransform.parent = null;
			actionMenu.SetActive (false);
		}
	}

	public void clearInfo () {
		clearInfoOfToolTip ();
	}

	private void clearInfoOfToolTip() {
		toolTipData = null;
	}

	private IEnumerator smoothTranslation(Vector3 initPos, Vector3 finalPos) {
		slerpTransitionRange = 0;
		while (toolTipData.gameObjectTransform.position != finalPos) {
			Debug.Log ("Calculando...position");
			toolTipData.gameObjectTransform.position = Vector3.Slerp (initPos, finalPos,  slerpTransitionRange);
			slerpTransitionRange += Time.deltaTime * translationSpeed;
			if (slerpTransitionRange > 1)
				slerpTransitionRange = 1;
			yield return null;
		}
	}

	private void smoothScale(SCALE_ACTION scale_action) {

		switch(scale_action) {
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
				initScale = toolTipData.gameObjectTransform.localScale;
				finalScale = scaleOrigin;
					break;
				}
		}
		StartCoroutine (calculateScale());
	}

	private IEnumerator calculateScale()  {
		slerpScaleRange = 0;
		while (toolTipData.gameObjectTransform.localScale != finalScale) {
			Debug.Log ("calculando scale...");
			toolTipData.gameObjectTransform.localScale = Vector3.Lerp (initScale, finalScale, slerpScaleRange);
			slerpScaleRange += Time.deltaTime * translationSpeed;
			if (slerpTransitionRange > 1)
				slerpTransitionRange = 1;
			yield return null;
		}
		
	}

}
