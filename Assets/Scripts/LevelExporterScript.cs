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

    [Header("Models and Textures")]
    public Transform modelsAndTextures;

    private int[,] _playfield;

    private Transform[] _sceneObjects;

    public void CreatePlayfield() {
        ClearPlayField();

        _playfield = new int[playfieldHeight, playfieldWidth]; //new playfield with the given size

        ModelExporterScript modelExporter = modelsAndTextures.GetComponent<ModelExporterScript>();
        GameObject tileModel = modelExporter.normalTileModel;

        for (int i = 0; i < playfieldHeight; i++) {
            for(int j = 0; j < playfieldWidth; j++) {
                _playfield[i, j] = (int)TileType.Uncolored; //default (0)

                GameObject newTile = Instantiate(tilePrefab);
                newTile.transform.position = new Vector3((j - playfieldWidth / 2.0f) * tileSize + 1, 0, (i - playfieldHeight / 2.0f) * tileSize + 1);
                newTile.transform.parent = transform;

                //Apply model mesh
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
