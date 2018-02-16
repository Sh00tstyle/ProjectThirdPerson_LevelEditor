using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExporterScript : MonoBehaviour {

    public string fileName;

    public int playfieldHeight;
    public int playfieldWidth;
    public GameObject tilePrefab;
    public float tileDistance;

    public Transform sceneEnvironment;

    public GameObject tileModel; //tile model

    public Texture[] uncoloredTileTextures; //max. 5
    public Texture[] redTileTextures; //max. 5
    public Texture[] blueTileTextures; //max .5
    public Texture redDestinationTileTexture;
    public Texture blueDestinationTileTexture;
    public Texture[] redPressurePlateTextures; //1 or more
    public Texture[] bluePressurePlateTextures; //1 or more
    public Texture[] redActivatableTileTexture; //1 or more
    public Texture[] blueActivatableTileTexture; //1 or more
    public Texture redColorSwitchTexture;
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
                newTile.transform.position = new Vector3((j - playfieldWidth / 2.0f) * tileDistance + 1, 0, (i - playfieldHeight / 2.0f) * tileDistance + 1);
                newTile.transform.parent = transform;

                //storing tile properties
                newTile.AddComponent(typeof(TileScript));
                TileScript tileScript = newTile.GetComponent<TileScript>();
                tileScript.SetTileType(TileType.Uncolored);
                tileScript.SetArrayPos(i, j);
            }
        }

        Debug.Log("Playfield created");
    }

    public void ClearPlayField() {
        Transform[] allChildren = GetComponentsInChildren<Transform>();

        //clear all leftovers
        for (int i = 1; i < allChildren.Length; i++) {
            DestroyImmediate(allChildren[i].gameObject);
        }

        _playfield = null;

        Debug.Log("Playfield cleared");
    }

    public void CreateXMLFile() {
        string filePath = "Assets/XmlLevels/" + fileName + ".xml";

        _sceneObjects = sceneEnvironment.GetComponentsInChildren<Transform>();

        XmlSerializer serializer = new XmlSerializer(typeof(PlayfieldContainer));
        FileStream stream = new FileStream(filePath, FileMode.Create);

        //Creating the container with all relevant level data
        PlayfieldContainer playfieldContainer = CreatePlayfieldContainer();

        //Creating the file
        serializer.Serialize(stream, playfieldContainer);
        stream.Close();

        Debug.Log("Scenefile '" + fileName + ".xml' created in Assets/XmlLevels");
    }

    private PlayfieldContainer CreatePlayfieldContainer() {
        PlayfieldContainer playfieldContainer = new PlayfieldContainer();
        Playfield playfield = new Playfield();

        Transform[] allTiles = GetComponentsInChildren<Transform>();

        //Adding the playfield to the container
        playfield.Height = playfieldHeight;
        playfield.Width = playfieldWidth;

        for (int i = 1; i < allTiles.Length; i++) {
            TileScript currentTile = allTiles[i].gameObject.GetComponent<TileScript>();

            int tileType = (int)currentTile.GetTileType();

            //getting the tile type value and storing it in the playfield list
            playfield.AddContent(tileType);

            switch(tileType) {
                case (int)TileType.PressurePlate:
                    PressurePlate pressurePlate = new PressurePlate();
                    pressurePlate.ColPos = currentTile.GetArrayXPos();
                    pressurePlate.RowPos = currentTile.GetArrayYPos();
                    pressurePlate.ID = currentTile.GetPlateID();
                    pressurePlate.NeededColor = (int)currentTile.GetTileColor();

                    playfieldContainer.AddPressurePlate(pressurePlate);
                    break;

                case (int)TileType.ActivatableTile:
                    ActivatableTile activatableTile = new ActivatableTile();
                    activatableTile.ColPos = currentTile.GetArrayXPos();
                    activatableTile.RowPos = currentTile.GetArrayYPos();
                    activatableTile.ID = currentTile.GetPlateID();
                    activatableTile.DisplayColor = (int)currentTile.GetTileColor();

                    playfieldContainer.AddActivatableTile(activatableTile);
                    break;

                case (int)TileType.PlayerSpawn:
                    SpawnTile spawnTile = new SpawnTile();
                    spawnTile.ColPos = currentTile.GetArrayXPos();
                    spawnTile.RowPos = currentTile.GetArrayYPos();
                    spawnTile.StartingColor = (int)currentTile.GetTileColor();

                    playfieldContainer.AddSpawnTile(spawnTile);
                    break;

                case (int)TileType.Destination:
                    DestinationTile destinationTile = new DestinationTile();
                    destinationTile.ColPos = currentTile.GetArrayXPos();
                    destinationTile.RowPos = currentTile.GetArrayYPos();
                    destinationTile.NeededColor = (int)currentTile.GetTileColor();

                    playfieldContainer.AddDestinationTile(destinationTile);
                    break;

                default:
                    break;
            }

            if(tileType == (int)TileType.PressurePlate) {
                
            } else if(tileType == (int)TileType.ActivatableTile) {
                
            }
        }

        playfieldContainer.AddPlayfield(playfield);

        //Adding the scene environment objects to the XML file
        for (int i = 1; i < _sceneObjects.Length; i++) {
            //adding objects to the container
            Transform currentTransform = _sceneObjects[i];
            SceneObject sceneObject = CreateSceneObject(currentTransform);

            //Adding the newly created object to the list
            playfieldContainer.AddSceneObject(sceneObject);
        }

        return playfieldContainer;
    }

    private SceneObject CreateSceneObject(Transform objTransform) {
        SceneObject sceneObject = new SceneObject(); //blank object

        //name
        sceneObject.Name = objTransform.name;

        //transform properties
        sceneObject.LocalPosition = objTransform.localPosition; //will NOT be the same as in the MGE
        sceneObject.LocalRotation = objTransform.localEulerAngles; //will NOT be the same as in the MGE
        sceneObject.LocalScale = objTransform.localScale;

        //model and texture
        ObjectIdentifier objectIdentifier = objTransform.GetComponent<ObjectIdentifier>();
        sceneObject.Model = objectIdentifier.GetObjFilePath();
        sceneObject.Texture = objectIdentifier.GetTexturePath();

        return sceneObject;
    }
}
