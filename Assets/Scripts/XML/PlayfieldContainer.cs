using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

//containing all relevant data of the scene
[XmlRoot("PlayfieldContainer")]
public class PlayfieldContainer {

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
    public TileModel TileModel;

    [XmlArray("UncoloredTileTextures")]
    [XmlArrayItem("UncoloredTileTexture")]
    public List<TileTexture> UncoloredTileTextures = new List<TileTexture>();

    [XmlArray("RedTileTextures")]
    [XmlArrayItem("RedTileTexture")]
    public List<TileTexture> RedTileTextures = new List<TileTexture>();

    [XmlArray("BlueTileTextures")]
    [XmlArrayItem("BlueTileTextures")]
    public List<TileTexture> BlueTileTextures = new List<TileTexture>();

    [XmlElement("RedDestinationTileTexture")]
    public TileTexture RedDestinationTileTexture;

    [XmlElement("BlueDestinationTileTexture")]
    public TileTexture BlueDestinationTileTexture;

    [XmlArray("RedPressurePlateTextures")]
    [XmlArrayItem("RedPressurePlateTexture")]
    public List<TileTexture> RedPressurePlateTextures = new List<TileTexture>();

    [XmlArray("BluePressurePlateTextures")]
    [XmlArrayItem("BluePressurePlateTexture")]
    public List<TileTexture> BluePressurePlateTextures = new List<TileTexture>();

    [XmlArray("RedActivatableTileTextures")]
    [XmlArrayItem("RedActivatableTileTexture")]
    public List<TileTexture> RedActivatableTileTextures = new List<TileTexture>();

    [XmlArray("BlueActivatableTileTextures")]
    [XmlArrayItem("BlueActivatableTileTexture")]
    public List<TileTexture> BlueActivatableTileTextures = new List<TileTexture>();

    [XmlElement("RedColorSwitchTexture")]
    public TileTexture RedColorSwitchTexture;

    [XmlElement("BlueColorSwitchTexture")]
    public TileTexture BlueColorSwitchTexture;

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

        TileModel tileModel = new TileModel();
        tileModel.ModelFile = filename;

        TileModel = tileModel;
    }

    public void AddUncoloredTileTexture(string filename) {
        if (filename == "") return;

        TileTexture tileTexture = new TileTexture();
        tileTexture.TextureFile = filename;

        UncoloredTileTextures.Add(tileTexture);
    }

    public void AddRedTileTexture(string filename) {
        if (filename == "") return;

        TileTexture tileTexture = new TileTexture();
        tileTexture.TextureFile = filename;

        RedTileTextures.Add(tileTexture);
    }

    public void AddBlueTileTexture(string filename) {
        if (filename == "") return;

        TileTexture tileTexture = new TileTexture();
        tileTexture.TextureFile = filename;

        BlueTileTextures.Add(tileTexture);
    }

    public void AddRedDestinationTileTexture(string filename) {
        if (filename == "") return;

        TileTexture tileTexture = new TileTexture();
        tileTexture.TextureFile = filename;

        RedDestinationTileTexture = tileTexture;
    }

    public void AddBlueDestinationTileTexture(string filename) {
        if (filename == "") return;

        TileTexture tileTexture = new TileTexture();
        tileTexture.TextureFile = filename;

        BlueDestinationTileTexture = tileTexture;
    }

    public void AddRedPressurePlateTexture(string filename) {
        if (filename == "") return;

        TileTexture tileTexture = new TileTexture();
        tileTexture.TextureFile = filename;

        RedPressurePlateTextures.Add(tileTexture);
    }

    public void AddBluePressurePlateTexture(string filename) {
        if (filename == "") return;

        TileTexture tileTexture = new TileTexture();
        tileTexture.TextureFile = filename;

        BluePressurePlateTextures.Add(tileTexture);
    }

    public void AddRedActivatableTileTexture(string filename) {
        if (filename == "") return;

        TileTexture tileTexture = new TileTexture();
        tileTexture.TextureFile = filename;

        RedActivatableTileTextures.Add(tileTexture);
    }

    public void AddBlueActivatableTileTexture(string filename) {
        if (filename == "") return;

        TileTexture tileTexture = new TileTexture();
        tileTexture.TextureFile = filename;

        BlueActivatableTileTextures.Add(tileTexture);
    }

    public void AddRedColorSwitchTexture(string filename) {
        if (filename == "") return;

        TileTexture tileTexture = new TileTexture();
        tileTexture.TextureFile = filename;

        RedColorSwitchTexture = tileTexture;
    }

    public void AddBlueColorSwitchTexture(string filename) {
        if (filename == "") return;

        TileTexture tileTexture = new TileTexture();
        tileTexture.TextureFile = filename;

        BlueColorSwitchTexture = tileTexture;
    }
}
