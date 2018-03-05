using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

[XmlRoot("ModelContainer")]
public class ModelContainer {

    //Models
    [XmlElement("NormalTileModel")]
    public XmlModel NormalTileModel;

    [XmlElement("DestinationTileModel")]
    public XmlModel DestinationTileModel;

    [XmlElement("PressurePlateModel")]
    public XmlModel PressurePlateModel;

    [XmlElement("ActivatableTileModel")]
    public XmlModel ActivatableTileModel;

    [XmlElement("ColorSwitchModel")]
    public XmlModel ColorSwitchModel;

    [XmlElement("PlayerModel")]
    public XmlModel PlayerModel;

    //Textures
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

    [XmlArray("RedActivatableTileActiveTextures")]
    [XmlArrayItem("RedActivatableTileActiveTexture")]
    public List<XmlTexture> RedActivatableTileActiveTextures = new List<XmlTexture>();

    [XmlArray("RedActivatableTileInactiveTextures")]
    [XmlArrayItem("RedActivatableTileInactiveTexture")]
    public List<XmlTexture> RedActivatableTileInactiveTextures = new List<XmlTexture>();

    [XmlArray("BlueActivatableTileActiveTextures")]
    [XmlArrayItem("BlueActivatableTileActiveTexture")]
    public List<XmlTexture> BlueActivatableTileActiveTextures = new List<XmlTexture>();

    [XmlArray("BlueActivatableTileInactiveTextures")]
    [XmlArrayItem("BlueActivatableTileInactiveTexture")]
    public List<XmlTexture> BlueActivatableTileInactiveTextures = new List<XmlTexture>();

    [XmlElement("RedColorSwitchTexture")]
    public XmlTexture RedColorSwitchTexture;

    [XmlElement("BlueColorSwitchTexture")]
    public XmlTexture BlueColorSwitchTexture;

    public void AddNormalTileModel(string filename) {
        if (filename == "") return;

        XmlModel tileModel = new XmlModel();
        tileModel.ModelFile = filename;

        NormalTileModel = tileModel;
    }

    public void AddDestinationTileModel(string filename) {
        if (filename == "") return;

        XmlModel tileModel = new XmlModel();
        tileModel.ModelFile = filename;

        DestinationTileModel = tileModel;
    }

    public void AddPressurePlateModel(string filename) {
        if (filename == "") return;

        XmlModel tileModel = new XmlModel();
        tileModel.ModelFile = filename;

        PressurePlateModel = tileModel;
    }

    public void AddActivatableTileModel(string filename) {
        if (filename == "") return;

        XmlModel tileModel = new XmlModel();
        tileModel.ModelFile = filename;

        ActivatableTileModel = tileModel;
    }

    public void AddColorSwitchModel(string filename) {
        if (filename == "") return;

        XmlModel tileModel = new XmlModel();
        tileModel.ModelFile = filename;

        ColorSwitchModel = tileModel;
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

    public void AddRedActivatableTileActiveTexture(string filename) {
        if (filename == "") return;

        XmlTexture tileTexture = new XmlTexture();
        tileTexture.TextureFile = filename;

        RedActivatableTileActiveTextures.Add(tileTexture);
    }

    public void AddRedActivatableTileInactiveTexture(string filename) {
        if (filename == "") return;

        XmlTexture tileTexture = new XmlTexture();
        tileTexture.TextureFile = filename;

        RedActivatableTileInactiveTextures.Add(tileTexture);
    }

    public void AddBlueActivatableTileActiveTexture(string filename) {
        if (filename == "") return;

        XmlTexture tileTexture = new XmlTexture();
        tileTexture.TextureFile = filename;

        BlueActivatableTileActiveTextures.Add(tileTexture);
    }

    public void AddBlueActivatableTileInactiveTexture(string filename) {
        if (filename == "") return;

        XmlTexture tileTexture = new XmlTexture();
        tileTexture.TextureFile = filename;

        BlueActivatableTileInactiveTextures.Add(tileTexture);
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
