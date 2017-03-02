using UnityEngine;
using System.Collections;

public class ToolTipManager : MonoBehaviour
{
    public Canvas toolTipCanvas;
	public ToolTipPanel toolTipPanel;

	public void addInfoToPanel() {
		setInfoIntoToolTip ();
		toolTipPanel.setShowPanel ();

	}

	private void setInfoIntoToolTip() {
		
	}

	public void clearInfo () {
		clearInfoOfToolTip ();
		toolTipPanel.setHidePanel ();
	}

	private void clearInfoOfToolTip() {
		
	}

}
