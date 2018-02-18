using System.Collections;
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

    SerializedProperty sceneEnvironmentProp;

    SerializedProperty tileModelProp; //tile model

    SerializedProperty playerModelProp; //player model

    SerializedProperty redPlayerTextureProp; //player model
    SerializedProperty bluePlayerTextureProp; //player model

    SerializedProperty uncoloredTileTexturesProp; //max. 5
    SerializedProperty redTileTexturesProp; //max. 5
    SerializedProperty blueTileTexturesProp; //max .5
    SerializedProperty redDestinationTileTextureProp;
    SerializedProperty blueDestinationTileTextureProp;
    SerializedProperty redPressurePlateTexturesProp; //1 or more
    SerializedProperty bluePressurePlateTexturesProp; //1 or more
    SerializedProperty redActivatableTileTexturesProp; //1 or more
    SerializedProperty blueActivatableTileTexturesProp; //1 or more
    SerializedProperty redColorSwitchTextureProp;
    SerializedProperty blueColorSwitchTextureProp;

    private LevelExporterScript _levelExporter;

    public void OnEnable() {
        fileNameProp = serializedObject.FindProperty("fileName");

        playfieldHeightProp = serializedObject.FindProperty("playfieldHeight");
        playfieldWidthProp = serializedObject.FindProperty("playfieldWidth");
        tilePrefabProp = serializedObject.FindProperty("tilePrefab");
        tileSizeProp = serializedObject.FindProperty("tileSize");

        sceneEnvironmentProp = serializedObject.FindProperty("sceneEnvironment");

        tileModelProp = serializedObject.FindProperty("tileModel");

        playerModelProp = serializedObject.FindProperty("playerModel");

        redPlayerTextureProp = serializedObject.FindProperty("redPlayerTexture");
        bluePlayerTextureProp = serializedObject.FindProperty("bluePlayerTexture");

        uncoloredTileTexturesProp = serializedObject.FindProperty("uncoloredTileTextures"); 
        redTileTexturesProp = serializedObject.FindProperty("redTileTextures"); 
        blueTileTexturesProp = serializedObject.FindProperty("blueTileTextures"); 
        redDestinationTileTextureProp = serializedObject.FindProperty("redDestinationTileTexture"); 
        blueDestinationTileTextureProp = serializedObject.FindProperty("blueDestinationTileTexture"); 
        redPressurePlateTexturesProp = serializedObject.FindProperty("redPressurePlateTextures"); 
        bluePressurePlateTexturesProp = serializedObject.FindProperty("bluePressurePlateTextures"); 
        redActivatableTileTexturesProp = serializedObject.FindProperty("redActivatableTileTextures"); 
        blueActivatableTileTexturesProp = serializedObject.FindProperty("blueActivatableTileTextures"); 
        redColorSwitchTextureProp = serializedObject.FindProperty("redColorSwitchTexture"); 
        blueColorSwitchTextureProp = serializedObject.FindProperty("blueColorSwitchTexture"); 

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

        EditorGUILayout.PropertyField(sceneEnvironmentProp, new GUIContent("Scene Environment"));

        EditorGUILayout.PropertyField(tileModelProp, new GUIContent("Tile Model"));

        EditorGUILayout.PropertyField(playerModelProp, new GUIContent("Player Model"));

        EditorGUILayout.PropertyField(redPlayerTextureProp, new GUIContent("Red Player Texture"));
        EditorGUILayout.PropertyField(bluePlayerTextureProp, new GUIContent("Blue Player Texture"));

        EditorGUILayout.PropertyField(uncoloredTileTexturesProp, new GUIContent("Uncolored Tile Textures"));

        //For arrays
        for (int i = 0; i < uncoloredTileTexturesProp.arraySize; i++) {
            EditorGUILayout.PropertyField(uncoloredTileTexturesProp.GetArrayElementAtIndex(i), new GUIContent("\tTexture " + (i + 1)));
        }

        EditorGUILayout.PropertyField(redTileTexturesProp, new GUIContent("Red Tile Textures"));

        for (int i = 0; i < redTileTexturesProp.arraySize; i++) {
            EditorGUILayout.PropertyField(redTileTexturesProp.GetArrayElementAtIndex(i), new GUIContent("\tTexture " + (i + 1)));
        }

        EditorGUILayout.PropertyField(blueTileTexturesProp, new GUIContent("Blue Tile Textures"));

        for (int i = 0; i < blueTileTexturesProp.arraySize; i++) {
            EditorGUILayout.PropertyField(blueTileTexturesProp.GetArrayElementAtIndex(i), new GUIContent("\tTexture " + (i + 1)));
        }

        EditorGUILayout.PropertyField(redDestinationTileTextureProp, new GUIContent("Red Destination Texture"));
        EditorGUILayout.PropertyField(blueDestinationTileTextureProp, new GUIContent("Blue Destination Texture"));

        EditorGUILayout.PropertyField(redPressurePlateTexturesProp, new GUIContent("Red Pressure Plate Textures"));

        for (int i = 0; i < redPressurePlateTexturesProp.arraySize; i++) {
            EditorGUILayout.PropertyField(redPressurePlateTexturesProp.GetArrayElementAtIndex(i), new GUIContent("\tTexture " + (i + 1)));
        }

        EditorGUILayout.PropertyField(bluePressurePlateTexturesProp, new GUIContent("Blue Pressure Plate Textures"));

        for (int i = 0; i < bluePressurePlateTexturesProp.arraySize; i++) {
            EditorGUILayout.PropertyField(bluePressurePlateTexturesProp.GetArrayElementAtIndex(i), new GUIContent("\tTexture " + (i + 1)));
        }

        EditorGUILayout.PropertyField(redActivatableTileTexturesProp, new GUIContent("Red Activatable Tile Textures"));

        for (int i = 0; i < redActivatableTileTexturesProp.arraySize; i++) {
            EditorGUILayout.PropertyField(redActivatableTileTexturesProp.GetArrayElementAtIndex(i), new GUIContent("\tTexture " + (i + 1)));
        }

        EditorGUILayout.PropertyField(blueActivatableTileTexturesProp, new GUIContent("Blue Activatable Tile Textures"));

        for (int i = 0; i < blueActivatableTileTexturesProp.arraySize; i++) {
            EditorGUILayout.PropertyField(blueActivatableTileTexturesProp.GetArrayElementAtIndex(i), new GUIContent("\tTexture " + (i + 1)));
        }

        EditorGUILayout.PropertyField(redColorSwitchTextureProp, new GUIContent("Red Color Switch Texture"));
        EditorGUILayout.PropertyField(blueColorSwitchTextureProp, new GUIContent("Blue Color Switch Texture"));

        

        //apply changes
        serializedObject.ApplyModifiedProperties();

        if(GUILayout.Button("Create Playfield")) {
            _levelExporter.CreatePlayfield();
        }

        if(GUILayout.Button("Clear Playfield")) {
            _levelExporter.ClearPlayField();
        }

        if(GUILayout.Button("Create XML File")) {
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
