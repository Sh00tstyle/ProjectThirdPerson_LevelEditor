using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ModelExporterScript))]
[CanEditMultipleObjects]
public class ModelEditor : Editor {

    SerializedProperty normalTileModelProp;
    SerializedProperty destinationTileModelProp;
    SerializedProperty pressurePlateModelProp;
    SerializedProperty activatableTileModelProp;
    SerializedProperty colorSwitchModelProp;

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
    SerializedProperty redActivatableTileActiveTexturesProp; //1 or more
    SerializedProperty redActivatableTileInactiveTexturesProp; //1 or more
    SerializedProperty blueActivatableTileActiveTexturesProp; //1 or more
    SerializedProperty blueActivatableTileInactiveTexturesProp; //1 or more
    SerializedProperty redColorSwitchTextureProp;
    SerializedProperty blueColorSwitchTextureProp;

    private ModelExporterScript _modelExporter;

    public void OnEnable() {
        normalTileModelProp = serializedObject.FindProperty("normalTileModel");
        destinationTileModelProp = serializedObject.FindProperty("destinationTileModel");
        pressurePlateModelProp = serializedObject.FindProperty("pressurePlateModel");
        activatableTileModelProp = serializedObject.FindProperty("activatableTileModel");
        colorSwitchModelProp = serializedObject.FindProperty("colorSwitchModel");

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
        redActivatableTileActiveTexturesProp = serializedObject.FindProperty("redActivatableTileActiveTextures");
        redActivatableTileInactiveTexturesProp = serializedObject.FindProperty("redActivatableTileInactiveTextures");
        blueActivatableTileActiveTexturesProp = serializedObject.FindProperty("blueActivatableTileActiveTextures");
        blueActivatableTileInactiveTexturesProp = serializedObject.FindProperty("blueActivatableTileInactiveTextures");
        redColorSwitchTextureProp = serializedObject.FindProperty("redColorSwitchTexture");
        blueColorSwitchTextureProp = serializedObject.FindProperty("blueColorSwitchTexture");

        _modelExporter = (ModelExporterScript)target;
    }

    public override void OnInspectorGUI() {
        serializedObject.Update();

        EditorGUILayout.PropertyField(normalTileModelProp, new GUIContent("Normal Tile Model"));
        EditorGUILayout.PropertyField(destinationTileModelProp, new GUIContent("Destination Tile Model"));
        EditorGUILayout.PropertyField(pressurePlateModelProp, new GUIContent("Pressure Plate Model"));
        EditorGUILayout.PropertyField(activatableTileModelProp, new GUIContent("Activatable Tile Model"));
        EditorGUILayout.PropertyField(colorSwitchModelProp, new GUIContent("Color Switch Model"));

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

        EditorGUILayout.PropertyField(redActivatableTileActiveTexturesProp, new GUIContent("Red Activatable Tile Textures (Active)"));

        for (int i = 0; i < redActivatableTileActiveTexturesProp.arraySize; i++) {
            EditorGUILayout.PropertyField(redActivatableTileActiveTexturesProp.GetArrayElementAtIndex(i), new GUIContent("\tTexture " + (i + 1)));
        }

        EditorGUILayout.PropertyField(redActivatableTileInactiveTexturesProp, new GUIContent("Red Activatable Tile Textures (Inactive)"));

        for (int i = 0; i < redActivatableTileInactiveTexturesProp.arraySize; i++) {
            EditorGUILayout.PropertyField(redActivatableTileInactiveTexturesProp.GetArrayElementAtIndex(i), new GUIContent("\tTexture " + (i + 1)));
        }

        EditorGUILayout.PropertyField(blueActivatableTileActiveTexturesProp, new GUIContent("Blue Activatable Tile Textures (Active)"));

        for (int i = 0; i < blueActivatableTileActiveTexturesProp.arraySize; i++) {
            EditorGUILayout.PropertyField(blueActivatableTileActiveTexturesProp.GetArrayElementAtIndex(i), new GUIContent("\tTexture " + (i + 1)));
        }

        EditorGUILayout.PropertyField(blueActivatableTileInactiveTexturesProp, new GUIContent("Blue Activatable Tile Textures (Inactive)"));

        for (int i = 0; i < blueActivatableTileInactiveTexturesProp.arraySize; i++) {
            EditorGUILayout.PropertyField(blueActivatableTileInactiveTexturesProp.GetArrayElementAtIndex(i), new GUIContent("\tTexture " + (i + 1)));
        }

        EditorGUILayout.PropertyField(redColorSwitchTextureProp, new GUIContent("Red Color Switch Texture"));
        EditorGUILayout.PropertyField(blueColorSwitchTextureProp, new GUIContent("Blue Color Switch Texture"));

        //apply changes
        serializedObject.ApplyModifiedProperties();

        if (GUILayout.Button("Create Model XML File")) {
            _modelExporter.CreateXMLFile();
        }
    }
}
