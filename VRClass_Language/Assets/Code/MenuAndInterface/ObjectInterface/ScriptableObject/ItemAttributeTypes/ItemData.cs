using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class ItemData : ItemAttribute {
	public string name = "object";
	public string description = "Description";
	#if UNITY_EDITOR
	public override void DOLayout() {
		name = EditorGUILayout.TextField ("Name", name);
		description = EditorGUILayout.TextField ("Descripción", description);
	}
	#endif
}
