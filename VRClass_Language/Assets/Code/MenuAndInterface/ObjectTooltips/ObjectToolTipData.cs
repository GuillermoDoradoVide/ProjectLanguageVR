using UnityEngine;
using System.Collections;
[CreateAssetMenu(fileName ="ToolTipData", menuName ="ToolTip/Data", order=1)]
[System.Serializable]
public class ObjectToolTipData : MonoBehaviour {

	public string objectName = "Object";

	public Transform gameObjectTransform = null;

	public Vector3 position;
	public Quaternion rotation;

	public string description = "Description";

	public string[] atributes = null;

	private void Awake() {
		gameObjectTransform = GetComponent<Transform> ();
		position = gameObjectTransform.position;
		rotation = gameObjectTransform.rotation;
	}
}
