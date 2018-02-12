using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using UnityEngine;

[XmlRoot("SceneObjectContainer")]
public class SceneObjectContainer {

    [XmlArray("SceneObjects")]
    [XmlArrayItem("SceneObject")]
    public List<SceneObject> sceneObjects = new List<SceneObject>();

    public void AddSceneObject(SceneObject sceneObject) {
        sceneObjects.Add(sceneObject);
    }
}
