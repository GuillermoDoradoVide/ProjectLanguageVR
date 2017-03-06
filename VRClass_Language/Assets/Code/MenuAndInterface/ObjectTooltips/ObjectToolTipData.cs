using UnityEngine;
using System.Collections;

public class ObjectToolTipData : MonoBehaviour {
	public Item itemData;

	private void Start () {
		itemData.setItemModel (GetComponent<Mesh>(), GetComponent<MeshRenderer>());
	}
}
