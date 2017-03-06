using UnityEngine;
using UnityEditor;
using System;
using System.Reflection;
using System.Linq;
[CustomEditor(typeof(Item))]
public class ItemEditor : Editor {

	[MenuItem("Assets/Create/Item")]
	public static void CreateAsset() {
		ScriptableObjectUtility.CreateAsset<Item>();
	}

	private string[] m_attributTypeNames = new string[0];
	private int m_attributeTypeIndex = -1;

	private void OnEnable() {
		Type[] types = Assembly.GetAssembly (typeof(ItemAttribute)).GetTypes ();
		m_attributTypeNames = (from Type type in types where type.IsSubclassOf(typeof(ItemAttribute)) select type.FullName).ToArray();
	}

	public override void OnInspectorGUI() {
		var item = target as Item;
		int indexToDelete = -1;
		for (int i = 0; i < item.attributes.Count; i++) {
			EditorGUILayout.BeginVertical (EditorStyles.helpBox);
			if (item.attributes [i] != null)
				item.attributes [i].DOLayout ();
			if (GUILayout.Button ("Delete"))
				indexToDelete = i;
			EditorGUILayout.EndVertical ();
		}
		if (indexToDelete > -1)
			item.attributes.RemoveAt (indexToDelete);
		EditorGUILayout.BeginHorizontal ();
		m_attributeTypeIndex = EditorGUILayout.Popup (m_attributeTypeIndex, m_attributTypeNames);
		if(GUILayout.Button("Add")) {
			var newAttribute = CreateInstance (m_attributTypeNames [m_attributeTypeIndex]) as ItemAttribute;
			newAttribute.hideFlags = HideFlags.HideInHierarchy;
			AssetDatabase.AddObjectToAsset (newAttribute, item);
			AssetDatabase.ImportAsset (AssetDatabase.GetAssetPath(newAttribute));
			AssetDatabase.SaveAssets ();
			AssetDatabase.Refresh ();
			item.attributes.Add (newAttribute);
		}
		EditorGUILayout.EndHorizontal ();
		if(GUI.changed) EditorUtility.SetDirty(item);
	}


}
