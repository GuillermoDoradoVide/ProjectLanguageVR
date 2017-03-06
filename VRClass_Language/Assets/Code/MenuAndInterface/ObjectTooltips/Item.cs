using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Item : ScriptableObject {
	public List<ItemAttribute> attributes = new List<ItemAttribute>();
	public ItemInteractions getItemInteractions() {
		return (ItemInteractions)attributes.Find (attribute => attribute.GetType() == typeof(ItemInteractions));
		
	}

	public Mesh getItemModel() {
		ItemModel aux = (ItemModel)attributes.Find (attribute => attribute.GetType () == typeof(ItemModel));
		return aux.mesh;
	}

	public void setItemModel(Mesh mesh, MeshRenderer renderer) {
		((ItemModel)attributes.Find (attribute => attribute.GetType () == typeof(ItemModel))).mesh = mesh;
		((ItemModel)attributes.Find (attribute => attribute.GetType () == typeof(ItemModel))).renderer = renderer;
	}
}
