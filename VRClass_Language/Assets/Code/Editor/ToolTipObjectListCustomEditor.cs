using UnityEngine;
using System.Collections;
using UnityEditor;
[CustomEditor(typeof(ObjectToolTipDataList))]
public class ToolTipObjectListCustomEditor : Editor {

	public override void OnInspectorGUI() {
		DrawDefaultInspector ();
		ObjectToolTipDataList toolTipDataList = (ObjectToolTipDataList)target;
		if (GUILayout.Button("Add ToolTipData")) {
			toolTipDataList.addObject ();
		}
		if (GUILayout.Button("Remove ToolTipData")) {
			toolTipDataList.deleteItem (0);
		}
	}
}


