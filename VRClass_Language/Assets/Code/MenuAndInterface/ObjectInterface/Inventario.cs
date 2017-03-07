using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventario : MonoBehaviour {

	public List<Item> items;

	public void addItem(Item newItem) {
		items.Add (newItem);
		EventManager.triggerEvent (Events.EventList.PLAYER_PickObject);
	}

	public void removeItem(Item itemToRemove) {
		items.Remove(itemToRemove);
	}

	public void clearInventory() {
		items.Clear ();
	}
}
