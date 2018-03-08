using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class that allows designers to further specify tile properties
public class TileScript : MonoBehaviour {

    public TileType tileType;

    //properties for pressure plates and activatable tiles
    public int plateID;
    public TileColor color;

    public void SetTileType(TileType pType) {
        tileType = pType;

        ApplyType();
    }

    public TileType GetTileType() {
        return tileType;
    }

    public void ApplyType() {
        ModelExporterScript modelExporter = GetComponentInParent<LevelExporterScript>().modelsAndTextures.GetComponent<ModelExporterScript>();
        gameObject.GetComponent<Renderer>().enabled = true;
        gameObject.GetComponent<MeshFilter>().sharedMesh = modelExporter.normalTileModel.GetComponentInChildren<MeshFilter>().sharedMesh;

        Texture newTexture = null;
        int rnd;
        int id;

        //do something visual with the tile to show different 
        switch(tileType) {
            case TileType.Uncolored:
                rnd = Random.Range(0, modelExporter.uncoloredTileTextures.Length);

                newTexture = modelExporter.uncoloredTileTextures[rnd];
                break;

            case TileType.PlayerSpawn:
                if (color == TileColor.Blue) {
                    rnd = Random.Range(0, modelExporter.blueTileTextures.Length);
                    newTexture = modelExporter.blueTileTextures[rnd];
                } else if (color == TileColor.Red) {
                    rnd = Random.Range(0, modelExporter.redTileTextures.Length);
                    newTexture = modelExporter.redTileTextures[rnd];
                }
                break;

            case TileType.RedTile:
                rnd = Random.Range(0, modelExporter.redTileTextures.Length);

                newTexture = modelExporter.redTileTextures[rnd];
                break;

            case TileType.BlueTile:
                rnd = Random.Range(0, modelExporter.blueTileTextures.Length);

                newTexture = modelExporter.blueTileTextures[rnd];
                break;


            case TileType.Destination:
                if(color == TileColor.Blue) newTexture = modelExporter.blueDestinationTileTexture;
                else if(color == TileColor.Red) newTexture = modelExporter.redDestinationTileTexture;
                break;

            case TileType.PressurePlate:
                if (color == TileColor.Blue) {
                    if (plateID >= modelExporter.bluePressurePlateTextures.Length) id = 0;
                    else id = plateID;

                    newTexture = modelExporter.bluePressurePlateTextures[id];
                } else if (color == TileColor.Red) {
                    if (plateID >= modelExporter.redPressurePlateTextures.Length) id = 0;
                    else id = plateID;

                    newTexture = modelExporter.redPressurePlateTextures[id];
                }
                break;

            case TileType.ActivatableTile:
                if (color == TileColor.Blue) {
                    if (plateID >= modelExporter.blueActivatableTileActiveTextures.Length) id = 0;
                    else id = plateID;

                    newTexture = modelExporter.blueActivatableTileActiveTextures[id];
                } else if (color == TileColor.Red) {
                    if (plateID >= modelExporter.redActivatableTileActiveTextures.Length) id = 0;
                    else id = plateID;

                    newTexture = modelExporter.redActivatableTileActiveTextures[id];
                }
                break;

            case TileType.RedColorSwitch:
                newTexture = modelExporter.redColorSwitchTexture;
                break;

            case TileType.BlueColorSwitch:
                newTexture = modelExporter.blueColorSwitchTexture;
                break;

            default:
                gameObject.GetComponent<Renderer>().enabled = false;
                break;

        }

        if(newTexture != null) GetComponent<Renderer>().material.mainTexture = newTexture;
    }

    public int GetPlateID() {
        return plateID;
    }

    public TileColor GetTileColor() {
        return color;
    }
}
