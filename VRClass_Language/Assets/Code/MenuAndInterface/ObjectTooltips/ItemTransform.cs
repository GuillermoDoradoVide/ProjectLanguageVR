using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class ItemTransform : ItemAttribute {
	public Transform transform = null;
	public Vector3 position;
	public Quaternion rotation;
	#if UNITY_EDITOR
	public override void DOLayout() {
		transform = (Transform)EditorGUILayout.ObjectField (transform, typeof(Transform), false);
		if (transform != null) {
			position = transform.position;
			rotation = transform.rotation;
		}
	}
	#endif
}
