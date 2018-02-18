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

    //Textures
    [XmlElement("TileModel")]
    public XmlModel TileModel;

    [XmlElement("PlayerModel")]
    public XmlModel PlayerModel;

    [XmlElement("RedPlayerTexture")]
    public XmlTexture RedPlayerTexture;

    [XmlElement("BluePlayerTexture")]
    public XmlTexture BluePlayerTexture;

    [XmlArray("UncoloredTileTextures")]
    [XmlArrayItem("UncoloredTileTexture")]
    public List<XmlTexture> UncoloredTileTextures = new List<XmlTexture>();

    [XmlArray("RedTileTextures")]
    [XmlArrayItem("RedTileTexture")]
    public List<XmlTexture> RedTileTextures = new List<XmlTexture>();

    [XmlArray("BlueTileTextures")]
    [XmlArrayItem("BlueTileTexture")]
    public List<XmlTexture> BlueTileTextures = new List<XmlTexture>();

    [XmlElement("RedDestinationTileTexture")]
    public XmlTexture RedDestinationTileTexture;

    [XmlElement("BlueDestinationTileTexture")]
    public XmlTexture BlueDestinationTileTexture;

    [XmlArray("RedPressurePlateTextures")]
    [XmlArrayItem("RedPressurePlateTexture")]
    public List<XmlTexture> RedPressurePlateTextures = new List<XmlTexture>();

    [XmlArray("BluePressurePlateTextures")]
    [XmlArrayItem("BluePressurePlateTexture")]
    public List<XmlTexture> BluePressurePlateTextures = new List<XmlTexture>();

    [XmlArray("RedActivatableTileTextures")]
    [XmlArrayItem("RedActivatableTileTexture")]
    public List<XmlTexture> RedActivatableTileTextures = new List<XmlTexture>();

    [XmlArray("BlueActivatableTileTextures")]
    [XmlArrayItem("BlueActivatableTileTexture")]
    public List<XmlTexture> BlueActivatableTileTextures = new List<XmlTexture>();

    [XmlElement("RedColorSwitchTexture")]
    public XmlTexture RedColorSwitchTexture;

    [XmlElement("BlueColorSwitchTexture")]
    public XmlTexture BlueColorSwitchTexture;

    public void AddPlayfield(Playfield playfield) {
        Playfield = playfield;
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

    public void AddTileModel(string filename) {
        if (filename == "") return;

        XmlModel tileModel = new XmlModel();
        tileModel.ModelFile = filename;

        TileModel = tileModel;
    }

    public void AddPlayerModel(string filename) {
        if (filename == "") return;

        XmlModel playerModel = new XmlModel();
        playerModel.ModelFile = filename;

        PlayerModel = playerModel;
    }

    public void AddRedPlayerTexture(string filename) {
        if (filename == "") return;

        XmlTexture playerTexture = new XmlTexture();
        playerTexture.TextureFile = filename;

        RedPlayerTexture = playerTexture;
    }

    public void AddBluePlayerTexture(string filename) {
        if (filename == "") return;

        XmlTexture playerTexture = new XmlTexture();
        playerTexture.TextureFile = filename;

        BluePlayerTexture = playerTexture;
    }

    public void AddUncoloredTileTexture(string filename) {
        if (filename == "") return;

        XmlTexture tileTexture = new XmlTexture();
        tileTexture.TextureFile = filename;

        UncoloredTileTextures.Add(tileTexture);
    }

    public void AddRedTileTexture(string filename) {
        if (filename == "") return;

        XmlTexture tileTexture = new XmlTexture();
        tileTexture.TextureFile = filename;

        RedTileTextures.Add(tileTexture);
    }

    public void AddBlueTileTexture(string filename) {
        if (filename == "") return;

        XmlTexture tileTexture = new XmlTexture();
        tileTexture.TextureFile = filename;

        BlueTileTextures.Add(tileTexture);
    }

    public void AddRedDestinationTileTexture(string filename) {
        if (filename == "") return;

        XmlTexture tileTexture = new XmlTexture();
        tileTexture.TextureFile = filename;

        RedDestinationTileTexture = tileTexture;
    }

    public void AddBlueDestinationTileTexture(string filename) {
        if (filename == "") return;

        XmlTexture tileTexture = new XmlTexture();
        tileTexture.TextureFile = filename;

        BlueDestinationTileTexture = tileTexture;
    }

    public void AddRedPressurePlateTexture(string filename) {
        if (filename == "") return;

        XmlTexture tileTexture = new XmlTexture();
        tileTexture.TextureFile = filename;

        RedPressurePlateTextures.Add(tileTexture);
    }

    public void AddBluePressurePlateTexture(string filename) {
        if (filename == "") return;

        XmlTexture tileTexture = new XmlTexture();
        tileTexture.TextureFile = filename;

        BluePressurePlateTextures.Add(tileTexture);
    }

    public void AddRedActivatableTileTexture(string filename) {
        if (filename == "") return;

        XmlTexture tileTexture = new XmlTexture();
        tileTexture.TextureFile = filename;

        RedActivatableTileTextures.Add(tileTexture);
    }

    public void AddBlueActivatableTileTexture(string filename) {
        if (filename == "") return;

        XmlTexture tileTexture = new XmlTexture();
        tileTexture.TextureFile = filename;

        BlueActivatableTileTextures.Add(tileTexture);
    }

    public void AddRedColorSwitchTexture(string filename) {
        if (filename == "") return;

        XmlTexture tileTexture = new XmlTexture();
        tileTexture.TextureFile = filename;

        RedColorSwitchTexture = tileTexture;
    }

    public void AddBlueColorSwitchTexture(string filename) {
        if (filename == "") return;

        XmlTexture tileTexture = new XmlTexture();
        tileTexture.TextureFile = filename;

        BlueColorSwitchTexture = tileTexture;
    }
}
