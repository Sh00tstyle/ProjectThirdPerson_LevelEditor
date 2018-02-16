using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

//containing all relevant data of the scene
[XmlRoot("PlayfieldContainer")]
public class PlayfieldContainer {

    [XmlElement("Playfield")]
    public Playfield Playfield;

    [XmlArray("SceneObjects")]
    [XmlArrayItem("SceneObject")]
    public List<SceneObject> SceneObjects = new List<SceneObject>();

    [XmlArray("PressurePlates")]
    [XmlArrayItem("PressurePlate")]
    public List<PressurePlate> PressurePlates = new List<PressurePlate>();

    [XmlArray("ActivatableTiles")]
    [XmlArrayItem("ActivatableTile")]
    public List<ActivatableTile> ActivatableTiles = new List<ActivatableTile>();

    public void AddPlayfield(Playfield playfield) {
        Playfield = playfield;
    }

    public void AddSceneObject(SceneObject sceneObject) {
        SceneObjects.Add(sceneObject);
    }

    public void AddPressurePlate(PressurePlate pressurePlate) {
        PressurePlates.Add(pressurePlate);
    }
    
    public void AddActvatableTile(ActivatableTile activatableTile) {
        ActivatableTiles.Add(activatableTile);
    }
}
