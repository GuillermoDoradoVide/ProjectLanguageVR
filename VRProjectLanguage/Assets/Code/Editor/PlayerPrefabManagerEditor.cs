using UnityEngine;
using System.Collections;
using UnityEditor;
[CustomEditor(typeof(PlayerCreationPrefabManager))]
public class PlayerPrefabManagerEditor : Editor
{
    /*private Editor cacheEditor;

    public void OnEnable()
    {
        cacheEditor = null;
    }*/
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        PlayerCreationPrefabManager playerManager = (PlayerCreationPrefabManager)target;
        //if (cacheEditor == null) cacheEditor = Editor.CreateEditor(playerManager.playerData);
        //cacheEditor.DrawDefaultInspector();
        EditorGUILayout.LabelField("MenuMainController", playerManager.playerData.menuMainController.name);
        EditorGUILayout.LabelField("PlayerCamera", playerManager.playerData.playerCamera.name);

    }
}


