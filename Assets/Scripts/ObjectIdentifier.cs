using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//class that displays the models and textures and takes care of providing the filenames of them
public class ObjectIdentifier : MonoBehaviour {

    [SerializeField]
    private GameObject _objFile;

    [SerializeField]
    private Texture _texture;

    public void OnValidate() {
        //Assign material and texture to the object
        MeshFilter filter = GetComponent<MeshFilter>();
        MeshRenderer renderer = GetComponent<MeshRenderer>();

        filter.sharedMesh = _objFile.GetComponentInChildren<MeshFilter>().sharedMesh;
        renderer.material.mainTexture = _texture;
    }

    public string GetObjFilePath() {
        if (_objFile == null) return "";

        string path = AssetDatabase.GetAssetPath(_objFile);
        path = path.Replace("Assets/Models/", ""); //remove the path to just get the filename
        return path;
    }

    public string GetTexturePath() {
        if (_texture == null) return "";

        string path = AssetDatabase.GetAssetPath(_texture);
        path = path.Replace("Assets/Textures/", ""); //remove the path to just get the filename
        return path;
    }
}
