using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TileScript))]
[CanEditMultipleObjects]
public class TileEditor : Editor {

    SerializedProperty tileTypeProp;
    SerializedProperty plateIDProp;
    SerializedProperty colorProp;

    private TileScript _tileScript;

    public void OnEnable() {
        tileTypeProp = serializedObject.FindProperty("tileType");
        plateIDProp = serializedObject.FindProperty("plateID");
        colorProp = serializedObject.FindProperty("color");

        _tileScript = (TileScript)target;
    }

    public override void OnInspectorGUI() {
        serializedObject.Update();

        EditorGUILayout.PropertyField(tileTypeProp, new GUIContent("Tile Type"));

        TileType tileType = (TileType)tileTypeProp.enumValueIndex;

        //display option to enter an id for the pressure plate and its respective activatable
        switch(tileType) {
            case TileType.PressurePlate:
                EditorGUILayout.PropertyField(plateIDProp, new GUIContent("Pressure Plate ID"));
                EditorGUILayout.PropertyField(colorProp, new GUIContent("Needed Color"));
                break;

            case TileType.ActivatableTile:
                EditorGUILayout.PropertyField(plateIDProp, new GUIContent("Activatable Tile ID"));
                break;

            case TileType.PlayerSpawn:
                EditorGUILayout.PropertyField(colorProp, new GUIContent("Starting Color"));
                break;

            case TileType.Destination:
                EditorGUILayout.PropertyField(colorProp, new GUIContent("Destination Color"));
                break;

            default:
                break;
        }

        //apply changes
        serializedObject.ApplyModifiedProperties();

        _tileScript.ApplyType();
    }
}