using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[CreateAssetMenu(fileName ="ToolTipList", menuName ="ToolTip/ToolTipList", order=1)]
public class ObjectToolTipDataList : ScriptableObject {

	public List<ObjectToolTipData> objectDataList;

	public void addObject () {
/*		ObjectToolTipData newObjectToolTipData = ScriptableObject.CreateInstance<ObjectToolTipData> ();
		newObjectToolTipData.objectName ="object";
		objectDataList.Add (newObjectToolTipData);*/
	}

	public void deleteItem(int index) {
		//objectDataList.RemoveAt (index);
	}
}
