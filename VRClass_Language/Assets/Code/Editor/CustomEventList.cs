using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
[CustomEditor(typeof(EventManager))]
public class CustomEventList : Editor {
    SerializedObject getTarget;
    SerializedProperty eventList;
    EventManager eventManager;

    private void Awake()
    {
        eventManager = target as EventManager;
        getTarget = new SerializedObject(eventManager);

    }

    private void OnEnable()
    {
        eventManager = target as EventManager;
        getTarget = new SerializedObject(eventManager);
        
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        getTarget.Update();
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Event list");

    }
}
