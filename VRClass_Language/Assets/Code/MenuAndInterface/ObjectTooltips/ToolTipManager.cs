using UnityEngine;
using System.Collections;

public class ToolTipManager : MonoBehaviour
{
    public Canvas toolTipCanvas;
	public Transform viewPosition;
	public ToolTipPanel toolTipPanel;
	public ObjectToolTipData toolTipData;
	public GameObject viewModeObject;
	public GameObject actionMenu;

	public void addInfoToPanel(ObjectToolTipData data) {
		toolTipData = data;
		setInfoIntoToolTip ();
		toolTipPanel.setShowPanel ();

	}

	private void setInfoIntoToolTip() {
		/*GameObject obj = Instantiate (toolTipData.gameObject);
		obj.transform.position = viewPosition.position;
		obj.transform.localScale = new Vector3 (0.3f, 0.3f, 0.3f);*/

	}

	public void viewMode() {
		if(toolTipData != null) {
			viewModeObject = Instantiate (toolTipData.gameObject);
			viewModeObject.transform.position = viewPosition.position;
			viewModeObject.transform.SetParent (viewPosition);
			viewModeObject.transform.localScale = new Vector3 (0.3f, 0.3f, 0.3f);
			actionMenu.SetActive (true);
		}
	}

	public void clearInfo () {
		clearInfoOfToolTip ();
		toolTipPanel.setHidePanel ();
	}

	private void clearInfoOfToolTip() {
		
	}

}
