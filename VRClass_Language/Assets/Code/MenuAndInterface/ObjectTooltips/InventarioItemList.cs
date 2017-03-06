using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventarioItemList : MonoBehaviour {

	public Inventario inventario;
	public Transform itemListElement;
	public GameObject ui_item_interface;
	public GameObject reference;
	public Vector3 itemPos;
	public float currentOffset = 0;
	public float itemOffset;
	// Use this for initialization

	private void Awake () {
		EventManager.startListening (Events.EventList.PLAYER_PickObject, addItemToList);
	}
	private void OnDisable() {
		EventManager.stopListening (Events.EventList.PLAYER_PickObject, addItemToList);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addItemToList() {
		Item addedItem = inventario.items [inventario.items.Count - 1];
		Debug.Log ("empieza");
		GameObject newItemUI = Instantiate (ui_item_interface);
		GameObject objectTemplate = newItemUI.transform.GetChild (0).gameObject;
		objectTemplate.transform.parent = null;
		itemPos = new Vector3 (0, currentOffset ,0);
		newItemUI.transform.SetParent (itemListElement);
		newItemUI.transform.localPosition = itemPos;
		newItemUI.transform.localScale = Vector3.one;
		newItemUI.transform.localRotation = Quaternion.identity;
		//item data
		newItemUI.transform.GetComponentInChildren<Text> ().text = addedItem.getItemData().name;

	// item object
		objectTemplate.AddComponent<MeshRenderer> ();
		objectTemplate.GetComponent<MeshFilter>().mesh = Instantiate (addedItem.getItemModel());
		objectTemplate.GetComponent<Transform>().localScale = Vector3.one;
		objectTemplate.transform.parent = newItemUI.transform;
		objectTemplate.transform.localPosition = itemPos;
		objectTemplate.transform.localRotation = Quaternion.identity;
		Vector3 a = reference.GetComponent<Renderer> ().bounds.size;
		Vector3 b = objectTemplate.GetComponent<MeshRenderer> ().bounds.size;
		Vector3 scale = new Vector3(a.x / b.y, a.y / b.x, a.z / b.z);
		objectTemplate.transform.localScale = scale;
		Debug.Log ("A: " + a + ";;B: " + b + ">>>Scale: " + scale);

		currentOffset -= itemOffset;
	}

	public void clearInventoryObjects() {
		
	}
}
