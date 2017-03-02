using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectToolTip : MonoBehaviour {
	public ToolTipManager TTmanager;

	void Start () {
	}

	public void sendInfo() {
		TTmanager.addInfoToPanel ();
	}       
}