using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
[CustomEditor(typeof(LevelManager))]
public class CustomLevelManager : Editor {

    SerializedObject getTarget;
    SerializedProperty currentState;
    LevelManager levelManager;

    private void Awake()
    {
        levelManager = target as LevelManager;
        getTarget = new SerializedObject(levelManager);

    }

    private void OnEnable()
    {
        levelManager = target as LevelManager;
        getTarget = new SerializedObject(levelManager);

    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        getTarget.Update();
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("State Current");
        SerializedProperty aux = getTarget.FindProperty("stateActivityManager");
        //EditorGUILayout.LabelField(aux.FindPropertyRelative("currentState").name);

    }
}
