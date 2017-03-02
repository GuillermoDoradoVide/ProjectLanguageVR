using UnityEngine;
using System.Collections;
[CreateAssetMenu(fileName ="ToolTipData", menuName ="ToolTip/Data", order=1)]
[System.Serializable]
public class ObjectToolTipData : ScriptableObject {

	public string objectName = "Object";

	public GameObject gameObject = null;

	public string description = "Description";

	public string[] atributes = null;
}
