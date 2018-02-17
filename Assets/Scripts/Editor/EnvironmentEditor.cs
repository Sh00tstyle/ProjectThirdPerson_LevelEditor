using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnvironmentGenerator))]
[CanEditMultipleObjects]
public class EnvironmentEditor : Editor {

    SerializedProperty sceneObjectPrefabProp;
    SerializedProperty objectNameProp;

    private EnvironmentGenerator _environmentGenerator;

    public void OnEnable() {
        sceneObjectPrefabProp = serializedObject.FindProperty("sceneObjectPrefab");
        objectNameProp = serializedObject.FindProperty("objectName");

        _environmentGenerator = (EnvironmentGenerator)target;
    }

    public override void OnInspectorGUI() {
        serializedObject.Update();

        EditorGUILayout.PropertyField(sceneObjectPrefabProp, new GUIContent("Sceneobject Prefab"));
        EditorGUILayout.PropertyField(objectNameProp, new GUIContent("Object Name"));

        serializedObject.ApplyModifiedProperties();

        if (GUILayout.Button("Add Scene Object")) {
            _environmentGenerator.GenerateSceneObject();
        }
    }
}
