using UnityEngine;
using System.Collections;

public class ObjectToolTipData : MonoBehaviour {

	public string objectName = "Red cube";
	public Transform gameObjectTransform = null;
	public Vector3 position;
	public Quaternion rotation;
	public string description = "Description";
	public string[] atributes = null;
	public bool canBeSelected;
	public bool canBePicked;

	private void Awake() {
		gameObjectTransform = GetComponent<Transform> ();
		position = gameObjectTransform.position;
		rotation = gameObjectTransform.rotation;
	}
}
