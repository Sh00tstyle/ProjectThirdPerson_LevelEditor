﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelExporterScript))]
[CanEditMultipleObjects]
public class PlayfieldEditor : Editor {

    SerializedProperty fileNameProp;

    SerializedProperty playfieldHeightProp;
    SerializedProperty playfieldWidthProp;
    SerializedProperty tilePrefabProp;
    SerializedProperty tileSizeProp;
    SerializedProperty hintAmountProp;
    SerializedProperty triesPerHintProp;

    SerializedProperty sceneEnvironmentProp;

    SerializedProperty modelsAndTexturesProp;

    private LevelExporterScript _levelExporter;

    public void OnEnable() {
        fileNameProp = serializedObject.FindProperty("fileName");

        playfieldHeightProp = serializedObject.FindProperty("playfieldHeight");
        playfieldWidthProp = serializedObject.FindProperty("playfieldWidth");
        tilePrefabProp = serializedObject.FindProperty("tilePrefab");
        tileSizeProp = serializedObject.FindProperty("tileSize");
        hintAmountProp = serializedObject.FindProperty("hintAmount");
        triesPerHintProp = serializedObject.FindProperty("triesPerHint");

        sceneEnvironmentProp = serializedObject.FindProperty("sceneEnvironment");

        modelsAndTexturesProp = serializedObject.FindProperty("modelsAndTextures");

        _levelExporter = (LevelExporterScript)target;

        SceneView.onSceneGUIDelegate -= CustomUpdate;
        SceneView.onSceneGUIDelegate += CustomUpdate;
    }

    public override void OnInspectorGUI() {
        serializedObject.Update();

        EditorGUILayout.PropertyField(fileNameProp, new GUIContent("Filename"));

        EditorGUILayout.PropertyField(playfieldHeightProp, new GUIContent("Playfield Height"));
        EditorGUILayout.PropertyField(playfieldWidthProp, new GUIContent("Playfield Width"));
        EditorGUILayout.PropertyField(tilePrefabProp, new GUIContent("Tile Prefab"));
        EditorGUILayout.PropertyField(tileSizeProp, new GUIContent("Tile Size"));

        EditorGUILayout.PropertyField(hintAmountProp, new GUIContent("Hint Amount"));
        EditorGUILayout.PropertyField(triesPerHintProp, new GUIContent("Tries per Hint"));

        EditorGUILayout.PropertyField(sceneEnvironmentProp, new GUIContent("Scene Environment"));

        EditorGUILayout.PropertyField(modelsAndTexturesProp, new GUIContent("Model Exporter"));

        //apply changes
        serializedObject.ApplyModifiedProperties();

        if(GUILayout.Button("Create Playfield")) {
            _levelExporter.CreatePlayfield();
        }

        if(GUILayout.Button("Clear Playfield")) {
            _levelExporter.ClearPlayField();
        }

        if(GUILayout.Button("Apply Meshes and Textures")) {
            _levelExporter.ApplyMeshAndTextures();
        }

        if (GUILayout.Button("Create XML File")) {
            _levelExporter.CreateXMLFile();
        }
    }

    private void CustomUpdate(SceneView sceneView) {
        Event e = Event.current;

        //toggle tiles when rightclicking
        if(e.type == EventType.MouseDown && e.button == 1) {
            RaycastHit hit;

            if (Physics.Raycast(Camera.current.ScreenPointToRay(new Vector3(e.mousePosition.x, Camera.current.pixelHeight - e.mousePosition.y, 0)), out hit, Mathf.Infinity)) {
                GameObject hitObject = hit.collider.gameObject;
                TileScript tileScript = hitObject.GetComponent<TileScript>();

                if(tileScript.GetTileType() == TileType.Uncolored) {
                    tileScript.SetTileType(TileType.None);  
                } else {
                    tileScript.SetTileType(TileType.Uncolored);
                }
            }
        }
    }
}
