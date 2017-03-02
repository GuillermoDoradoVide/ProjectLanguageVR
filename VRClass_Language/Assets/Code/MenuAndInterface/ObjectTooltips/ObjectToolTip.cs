using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectToolTip : MonoBehaviour {
	public ToolTipManager TTmanager;
	public ObjectToolTipData data;

	void Start () {
	}

	public void sendInfo() {
		TTmanager.addInfoToPanel (data);
	}       
}