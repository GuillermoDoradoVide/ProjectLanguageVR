using UnityEngine;
using System.Collections;

public class ObjectToolTipData : MonoBehaviour {
	public Item itemData;
	//inicializa los datos del objeto DE la escena en el scriptableObject 
	private void Start () {
		itemData.setItemModel (GetComponent<MeshFilter>().mesh, GetComponent<MeshRenderer>());
		itemData.setItemTransform (GetComponent<Transform> ());
	}
}
