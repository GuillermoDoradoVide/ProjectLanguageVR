using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventarioItemList : MonoBehaviour {

	public Inventario inventario;
	public Transform itemListElement;
	public GameObject ui_item_interface;
	public GameObject reference;
	public Vector3 itemPos;
	public float currentOffset = 0;
	public float itemOffset;
	public List<GameObject> itemListGameObjects;
	// Use this for initialization

	private void Awake () {
		itemListGameObjects = new List<GameObject> ();
		EventManager.startListening (Events.EventList.PLAYER_PickObject, addItemToList);
	}
	private void OnDisable() {
		EventManager.stopListening (Events.EventList.PLAYER_PickObject, addItemToList);
	}

	public void addItemToList() {
		Item addedItem = inventario.items [inventario.items.Count - 1];
		GameObject newItemUI = Instantiate (ui_item_interface);
		Transform newItemUITransform = newItemUI.GetComponent<Transform> ();
		itemListGameObjects.Add (newItemUI);
		GameObject objectTemplate = newItemUITransform.GetChild (0).gameObject;
		Transform objectTemplateTransform = objectTemplate.GetComponent<Transform> ();

		itemPos = new Vector3 (0, currentOffset ,0);
		newItemUITransform.SetParent (itemListElement);
		newItemUITransform.localPosition = itemPos;
		newItemUITransform.localScale = Vector3.one;
		newItemUITransform.localRotation = Quaternion.identity;
		//item data
		newItemUITransform.GetComponentInChildren<Text> ().text = addedItem.getItemData().name;
		// item object
		objectTemplate.AddComponent<MeshRenderer> ();
		objectTemplate.GetComponent<MeshFilter>().mesh = addedItem.getItemMesh();
		objectTemplate.GetComponent<MeshRenderer>().materials = addedItem.getItemMeshRenderer().materials;
		objectTemplateTransform.parent = null;
		objectTemplate.GetComponent<Transform>().localScale = Vector3.one;
		Vector3 a = reference.GetComponent<Renderer> ().bounds.size;
		Vector3 b = objectTemplate.GetComponent<MeshRenderer> ().bounds.size;
		Vector3 scale = new Vector3(a.x / b.y, a.y / b.x, a.z / b.z);
		objectTemplateTransform.parent = newItemUI.transform;
		objectTemplateTransform.localPosition = Vector3.zero;
		objectTemplateTransform.localRotation = Quaternion.identity;
		objectTemplateTransform.localScale = scale;
		Debug.Log ("(Scale)A: " + a + " || (Scale)B: " + b + " ; >(Scale)Final: " + scale);

		currentOffset -= itemOffset;
	}

	public void clearInventoryObjects() {
		
	}
}
