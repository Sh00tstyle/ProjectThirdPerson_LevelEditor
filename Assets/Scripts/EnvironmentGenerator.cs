using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentGenerator : MonoBehaviour {

    public GameObject sceneObjectPrefab;

    public string objectName;

    public void GenerateSceneObject() {
        GameObject newSceneObject = Instantiate(sceneObjectPrefab);
        newSceneObject.name = objectName;
        newSceneObject.transform.parent = transform;
    }
}