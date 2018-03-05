using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class ModelExporterScript : MonoBehaviour {

    [Header("Models")]
    public GameObject normalTileModel;
    public GameObject destinationTileModel;
    public GameObject pressurePlateModel;
    public GameObject activatableTileModel;
    public GameObject colorSwitchModel;

    public GameObject playerModel;

    [Header("Textures")]
    public Texture redPlayerTexture;
    [Space(5)]
    public Texture bluePlayerTexture;

    [Space(10)]
    public Texture[] uncoloredTileTextures;
    [Space(5)]
    public Texture[] redTileTextures;
    [Space(5)]
    public Texture[] blueTileTextures;
    [Space(5)]
    public Texture redDestinationTileTexture;
    [Space(5)]
    public Texture blueDestinationTileTexture;
    [Space(5)]
    public Texture[] redPressurePlateTextures;
    [Space(5)]
    public Texture[] bluePressurePlateTextures;
    [Space(5)]
    public Texture[] redActivatableTileActiveTextures;
    [Space(5)]
    public Texture[] redActivatableTileInactiveTextures;
    [Space(5)]
    public Texture[] blueActivatableTileActiveTextures;
    [Space(5)]
    public Texture[] blueActivatableTileInactiveTextures;
    [Space(5)]
    public Texture redColorSwitchTexture;
    [Space(5)]
    public Texture blueColorSwitchTexture;

    public void CreateXMLFile() {
        string filePath = "Assets/XmlLevels/ModelConfig.xml";

        XmlSerializer serializer = new XmlSerializer(typeof(ModelContainer));
        FileStream stream = new FileStream(filePath, FileMode.Create);

        //Creating the container with all relevant level data
        ModelContainer modelContainer = CreateModelContainer();

        //Creating the file
        serializer.Serialize(stream, modelContainer);
        stream.Close();

        Debug.Log("Scenefile 'ModelConfig.xml' created in Assets/XmlLevels");
    }

    private ModelContainer CreateModelContainer() {
        ModelContainer modelContainer = new ModelContainer();

        //adding texture filenames and model filename to the XML file
        modelContainer.AddNormalTileModel(GetFilenameFromModel(normalTileModel));
        modelContainer.AddDestinationTileModel(GetFilenameFromModel(destinationTileModel));
        modelContainer.AddPressurePlateModel(GetFilenameFromModel(pressurePlateModel));
        modelContainer.AddActivatableTileModel(GetFilenameFromModel(activatableTileModel));
        modelContainer.AddColorSwitchModel(GetFilenameFromModel(colorSwitchModel));

        modelContainer.AddPlayerModel(GetFilenameFromModel(playerModel));

        modelContainer.AddRedPlayerTexture(GetFilenameFromTexture(redPlayerTexture));
        modelContainer.AddBluePlayerTexture(GetFilenameFromTexture(bluePlayerTexture));

        for (int i = 0; i < uncoloredTileTextures.Length; i++) {
            modelContainer.AddUncoloredTileTexture(GetFilenameFromTexture(uncoloredTileTextures[i]));
        }

        for (int i = 0; i < redTileTextures.Length; i++) {
            modelContainer.AddRedTileTexture(GetFilenameFromTexture(redTileTextures[i]));
        }

        for (int i = 0; i < blueTileTextures.Length; i++) {
            modelContainer.AddBlueTileTexture(GetFilenameFromTexture(blueTileTextures[i]));
        }

        modelContainer.AddRedDestinationTileTexture(GetFilenameFromTexture(redDestinationTileTexture));
        modelContainer.AddBlueDestinationTileTexture(GetFilenameFromTexture(blueDestinationTileTexture));

        for (int i = 0; i < redPressurePlateTextures.Length; i++) {
            modelContainer.AddRedPressurePlateTexture(GetFilenameFromTexture(redPressurePlateTextures[i]));
        }

        for (int i = 0; i < bluePressurePlateTextures.Length; i++) {
            modelContainer.AddBluePressurePlateTexture(GetFilenameFromTexture(bluePressurePlateTextures[i]));
        }

        for (int i = 0; i < redActivatableTileActiveTextures.Length; i++) {
            modelContainer.AddRedActivatableTileActiveTexture(GetFilenameFromTexture(redActivatableTileActiveTextures[i]));
        }

        for (int i = 0; i < redActivatableTileInactiveTextures.Length; i++) {
            modelContainer.AddRedActivatableTileInactiveTexture(GetFilenameFromTexture(redActivatableTileInactiveTextures[i]));
        }

        for (int i = 0; i < blueActivatableTileActiveTextures.Length; i++) {
            modelContainer.AddBlueActivatableTileActiveTexture(GetFilenameFromTexture(blueActivatableTileActiveTextures[i]));
        }

        for (int i = 0; i < blueActivatableTileInactiveTextures.Length; i++) {
            modelContainer.AddBlueActivatableTileInactiveTexture(GetFilenameFromTexture(blueActivatableTileInactiveTextures[i]));
        }

        modelContainer.AddRedColorSwitchTexture(GetFilenameFromTexture(redColorSwitchTexture));
        modelContainer.AddBlueColorSwitchTexture(GetFilenameFromTexture(blueColorSwitchTexture));

        return modelContainer;
    }

    private string GetFilenameFromTexture(Texture texture) {
        if (texture == null) return "";

        string path = AssetDatabase.GetAssetPath(texture);
        path = path.Replace("Assets/Textures/", ""); //remove the path to just get the filename
        return path;
    }

    private string GetFilenameFromModel(GameObject gameObj) {
        if (gameObj == null) return "";

        string path = AssetDatabase.GetAssetPath(gameObj);
        path = path.Replace("Assets/Models/", ""); //remove the path to just get the filename
        return path;
    }
}
