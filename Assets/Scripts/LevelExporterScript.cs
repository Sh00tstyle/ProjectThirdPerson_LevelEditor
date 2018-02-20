using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class LevelExporterScript : MonoBehaviour {

    public string fileName;

    [Header("Playfield Settings")]
    public int playfieldHeight;
    public int playfieldWidth;
    public GameObject tilePrefab;
    public float tileSize;

    [Header("Scene Objects")]
    public Transform sceneEnvironment;

    [Header("Models")]
    public GameObject tileModel;

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
    public Texture[] redActivatableTileTextures;
    [Space(5)]
    public Texture[] blueActivatableTileTextures;
    [Space(5)]
    public Texture redColorSwitchTexture;
    [Space(5)]
    public Texture blueColorSwitchTexture;

    private int[,] _playfield;

    private Transform[] _sceneObjects;

    public void CreatePlayfield() {
        ClearPlayField();

        _playfield = new int[playfieldHeight, playfieldWidth]; //new playfield with the given size

        for (int i = 0; i < playfieldHeight; i++) {
            for(int j = 0; j < playfieldWidth; j++) {
                _playfield[i, j] = (int)TileType.Uncolored; //default (0)

                GameObject newTile = Instantiate(tilePrefab);
                newTile.transform.position = new Vector3((j - playfieldWidth / 2.0f) * tileSize + 1, 0, (i - playfieldHeight / 2.0f) * tileSize + 1);
                newTile.transform.parent = transform;

                newTile.GetComponent<MeshFilter>().sharedMesh = tileModel.GetComponentInChildren<MeshFilter>().sharedMesh;

                //storing tile properties
                newTile.AddComponent(typeof(TileScript));
                TileScript tileScript = newTile.GetComponent<TileScript>();
                tileScript.SetTileType(TileType.Uncolored);

                tileScript.ApplyType();
            }
        }
    }

    public void ClearPlayField() {
        Transform[] allChildren = GetComponentsInChildren<Transform>();

        //clear all leftovers
        for (int i = 1; i < allChildren.Length; i++) {
            DestroyImmediate(allChildren[i].gameObject);
        }

        _playfield = null;
    }

    public void CreateXMLFile() {
        string filePath = "Assets/XmlLevels/" + fileName + ".xml";

        _sceneObjects = sceneEnvironment.GetComponentsInChildren<Transform>();

        XmlSerializer serializer = new XmlSerializer(typeof(SceneContainer));
        FileStream stream = new FileStream(filePath, FileMode.Create);

        //Creating the container with all relevant level data
        SceneContainer playfieldContainer = CreatePlayfieldContainer();

        //Creating the file
        serializer.Serialize(stream, playfieldContainer);
        stream.Close();

        Debug.Log("Scenefile '" + fileName + ".xml' created in Assets/XmlLevels");
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

    private SceneContainer CreatePlayfieldContainer() {
        SceneContainer sceneContainer = new SceneContainer();
        Playfield playfield = new Playfield();

        Transform[] allTiles = GetComponentsInChildren<Transform>();

        //Adding the playfield to the container
        playfield.Height = playfieldHeight;
        playfield.Width = playfieldWidth;

        for (int i = 1; i < allTiles.Length; i++) {
            TileScript currentTile = allTiles[i].gameObject.GetComponent<TileScript>();

            int tileType = (int)currentTile.GetTileType();
            int listPos = i - 1;

            //getting the tile type value and storing it in the playfield list
            playfield.AddContent(tileType);

            switch(tileType) {
                case (int)TileType.PressurePlate:
                    PressurePlate pressurePlate = new PressurePlate();
                    pressurePlate.ColPos = listPos % playfieldWidth;
                    pressurePlate.RowPos = listPos / playfieldWidth;
                    pressurePlate.ID = currentTile.GetPlateID();
                    pressurePlate.NeededColor = (int)currentTile.GetTileColor();

                    sceneContainer.AddPressurePlate(pressurePlate);
                    break;

                case (int)TileType.ActivatableTile:
                    ActivatableTile activatableTile = new ActivatableTile();
                    activatableTile.ColPos = listPos % playfieldWidth;
                    activatableTile.RowPos = listPos / playfieldWidth;
                    activatableTile.ID = currentTile.GetPlateID();

                    sceneContainer.AddActivatableTile(activatableTile);
                    break;

                case (int)TileType.PlayerSpawn:
                    SpawnTile spawnTile = new SpawnTile();
                    spawnTile.ColPos = listPos % playfieldWidth;
                    spawnTile.RowPos = listPos / playfieldWidth;
                    spawnTile.StartingColor = (int)currentTile.GetTileColor();

                    sceneContainer.AddSpawnTile(spawnTile);
                    break;

                case (int)TileType.Destination:
                    DestinationTile destinationTile = new DestinationTile();
                    destinationTile.ColPos = listPos % playfieldWidth;
                    destinationTile.RowPos = listPos / playfieldWidth;
                    destinationTile.NeededColor = (int)currentTile.GetTileColor();

                    sceneContainer.AddDestinationTile(destinationTile);
                    break;

                default:
                    break;
            }

            if(tileType == (int)TileType.PressurePlate) {
                
            } else if(tileType == (int)TileType.ActivatableTile) {
                
            }
        }

        sceneContainer.AddPlayfield(playfield);

        //Adding the scene environment objects to the XML file
        for (int i = 1; i < _sceneObjects.Length; i++) {
            //adding objects to the container
            Transform currentTransform = _sceneObjects[i];
            SceneObject sceneObject = CreateSceneObject(currentTransform);

            //Adding the newly created object to the list
            sceneContainer.AddSceneObject(sceneObject);
        }

        //adding texture filenames and model filename to the XML file
        sceneContainer.AddTileModel(GetFilenameFromModel(tileModel));
        sceneContainer.AddPlayerModel(GetFilenameFromModel(playerModel));

        sceneContainer.AddRedPlayerTexture(GetFilenameFromTexture(redPlayerTexture));
        sceneContainer.AddBluePlayerTexture(GetFilenameFromTexture(bluePlayerTexture));

        for (int i = 0; i < uncoloredTileTextures.Length; i++) {
            sceneContainer.AddUncoloredTileTexture(GetFilenameFromTexture(uncoloredTileTextures[i]));
        }

        for (int i = 0; i < redTileTextures.Length; i++) {
            sceneContainer.AddRedTileTexture(GetFilenameFromTexture(redTileTextures[i]));
        }

        for (int i = 0; i < blueTileTextures.Length; i++) {
            sceneContainer.AddBlueTileTexture(GetFilenameFromTexture(blueTileTextures[i]));
        }

        sceneContainer.AddRedDestinationTileTexture(GetFilenameFromTexture(redDestinationTileTexture));
        sceneContainer.AddBlueDestinationTileTexture(GetFilenameFromTexture(blueDestinationTileTexture));

        for (int i = 0; i < redPressurePlateTextures.Length; i++) {
            sceneContainer.AddRedPressurePlateTexture(GetFilenameFromTexture(redPressurePlateTextures[i]));
        }

        for (int i = 0; i < bluePressurePlateTextures.Length; i++) {
            sceneContainer.AddBluePressurePlateTexture(GetFilenameFromTexture(bluePressurePlateTextures[i]));
        }

        for (int i = 0; i < redActivatableTileTextures.Length; i++) {
            sceneContainer.AddRedActivatableTileTexture(GetFilenameFromTexture(redActivatableTileTextures[i]));
        }

        for (int i = 0; i < blueActivatableTileTextures.Length; i++) {
            sceneContainer.AddBlueActivatableTileTexture(GetFilenameFromTexture(blueActivatableTileTextures[i]));
        }

        sceneContainer.AddRedColorSwitchTexture(GetFilenameFromTexture(redColorSwitchTexture));
        sceneContainer.AddBlueColorSwitchTexture(GetFilenameFromTexture(blueColorSwitchTexture));

        return sceneContainer;
    }

    private SceneObject CreateSceneObject(Transform objTransform) {
        SceneObject sceneObject = new SceneObject(); //blank object

        //name
        sceneObject.Name = objTransform.name;

        //position (scale and rotation modification wont be allowed)
        sceneObject.xPos = -objTransform.localPosition.x; //invert x for the mge 
        sceneObject.yPos = objTransform.localPosition.y; 
        sceneObject.zPos = objTransform.localPosition.z;

        //rotation
        sceneObject.xRot = objTransform.localRotation.x;
        sceneObject.yRot = -objTransform.localRotation.y;
        sceneObject.zRot = -objTransform.localRotation.z;
        sceneObject.wRot = objTransform.localRotation.w;

        //scale
        sceneObject.xScale = objTransform.localScale.x;
        sceneObject.yScale = objTransform.localScale.y;
        sceneObject.zScale = objTransform.localScale.z;

        //model and texture
        ObjectIdentifier objectIdentifier = objTransform.GetComponent<ObjectIdentifier>();
        sceneObject.Model = objectIdentifier.GetObjFilePath();
        sceneObject.Texture = objectIdentifier.GetTexturePath();

        return sceneObject;
    }
}
