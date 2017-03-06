using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class ItemModel : ItemAttribute {
	public Mesh mesh;
	public MeshRenderer renderer;
	#if UNITY_EDITOR
	public override void DOLayout() {
		mesh = (Mesh)EditorGUILayout.ObjectField (mesh, typeof(Mesh), false);
		renderer = (MeshRenderer)EditorGUILayout.ObjectField (renderer, typeof(MeshRenderer), false);
	}
	#endif
}
