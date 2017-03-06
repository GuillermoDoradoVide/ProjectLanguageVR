using UnityEngine;
using UnityEditor;
public class ItemAsset  {
	[MenuItem("Assets/Create/Items/Item")]
	public static void CreateAsset() {
		ScriptableObjectUtility.CreateAsset<Item> ();
	}
	[MenuItem("Assets/Create/Items/Attributes/Data")]
	public static void CreateBasicData() {
		ScriptableObjectUtility.CreateAsset<ItemData> ();
	}
	[MenuItem("Assets/Create/Items/Attributes/Transform")]
	public static void CreateTransformData() {
		ScriptableObjectUtility.CreateAsset<ItemTransform> ();
	}
	[MenuItem("Assets/Create/Items/Attributes/Interactions")]
	public static void CreateinteractionData() {
		ScriptableObjectUtility.CreateAsset<ItemInteractions> ();
	}
	[MenuItem("Assets/Create/Items/Attributes/Model")]
	public static void CreateModelData() {
		ScriptableObjectUtility.CreateAsset<ItemModel> ();
	}
}
