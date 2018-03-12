using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

//containing all relevant data of the scene
[XmlRoot("SceneContainer")]
public class SceneContainer {

    //Playfield
    [XmlElement("Playfield")]
    public Playfield Playfield;

    //Hint playfields
    [XmlArray("HintPlayfields")]
    [XmlArrayItem("HintPlayfield")]
    public List<Playfield> HintPlayfields = new List<Playfield>();

    [XmlElement("HintProps")]
    public HintProps HintProps;

    //Environment
    [XmlArray("SceneObjects")]
    [XmlArrayItem("SceneObject")]
    public List<SceneObject> SceneObjects = new List<SceneObject>();

    //Special Tiles
    [XmlArray("PressurePlates")]
    [XmlArrayItem("PressurePlate")]
    public List<PressurePlate> PressurePlates = new List<PressurePlate>();

    [XmlArray("ActivatableTiles")]
    [XmlArrayItem("ActivatableTile")]
    public List<ActivatableTile> ActivatableTiles = new List<ActivatableTile>();

    [XmlElement("SpawnTile")]
    public SpawnTile SpawnTile;

    [XmlElement("DestinationTile")]
    public DestinationTile DestinationTile;

    public void AddPlayfield(Playfield playfield) {
        Playfield = playfield;
    }

    public void AddHintPlayfield(Playfield playfield) {
        HintPlayfields.Add(playfield);
    }

    public void AddHintProps(HintProps hintProps) {
        HintProps = hintProps;
    }

    public void AddSceneObject(SceneObject sceneObject) {
        SceneObjects.Add(sceneObject);
    }

    public void AddPressurePlate(PressurePlate pressurePlate) {
        PressurePlates.Add(pressurePlate);
    }
    
    public void AddActivatableTile(ActivatableTile activatableTile) {
        ActivatableTiles.Add(activatableTile);
    }

    public void AddSpawnTile(SpawnTile spawnTile) {
        SpawnTile = spawnTile;
    }

    public void AddDestinationTile(DestinationTile destinationTile) {
        DestinationTile = destinationTile;
    }
}
