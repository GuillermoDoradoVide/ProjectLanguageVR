using UnityEngine;
using System.Collections;

public class InventarioItemList : MonoBehaviour {

	public Inventario inventario;
	public GameObject ui_item_interface;
	public Vector3 itemPos;
	public float currentOffset;
	public float itemOffset;
	// Use this for initialization
	void Start () {
		currentOffset = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnEnable() {
		for (int x = 0; x < inventario.items.Count; x ++) {
			GameObject newItemUI = Instantiate (ui_item_interface);
			itemPos = new Vector3 (0, currentOffset ,0);
			newItemUI.transform.SetParent (transform);
			newItemUI.transform.localPosition = itemPos;
			newItemUI.transform.localScale = Vector3.one;
			newItemUI.transform.localRotation = Quaternion.identity;
			currentOffset -= itemOffset;
			GameObject showObject = new GameObject ();
			showObject.AddComponent<MeshFilter> ();
			showObject.AddComponent<MeshRenderer> ();
			showObject.GetComponent<MeshFilter>().mesh = Instantiate (inventario.items[x].getItemModel());
			showObject.transform.SetParent (transform);
			showObject.transform.localPosition = itemPos;
			showObject.transform.localScale = Vector3.one;
			showObject.transform.localRotation = Quaternion.identity;
		}
	}
}
