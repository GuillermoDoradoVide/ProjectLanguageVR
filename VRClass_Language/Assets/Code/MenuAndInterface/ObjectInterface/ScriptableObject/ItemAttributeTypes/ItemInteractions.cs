using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class ItemInteractions : ItemAttribute {
	public bool canBeSelected;
	public bool canBePicked;
	#if UNITY_EDITOR
	public override void DOLayout() {
		canBeSelected = EditorGUILayout.Toggle ("Es seleccionable", canBeSelected);
		canBePicked = EditorGUILayout.Toggle ("Se puede recoger", canBePicked);
	}
	#endif
}
