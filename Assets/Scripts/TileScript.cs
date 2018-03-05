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
        LevelExporterScript levelExporter = GetComponentInParent<LevelExporterScript>();
        gameObject.GetComponent<Renderer>().enabled = true;

        Texture newTexture = null;
        int rnd;
        int id;

        /**

        //do something visual with the tile to show different 
        switch(tileType) {
            case TileType.Uncolored:
                rnd = Random.Range(0, levelExporter.uncoloredTileTextures.Length);

                newTexture = levelExporter.uncoloredTileTextures[rnd];
                break;

            case TileType.PlayerSpawn:
                if (color == TileColor.Blue) {
                    rnd = Random.Range(0, levelExporter.blueTileTextures.Length);
                    newTexture = levelExporter.blueTileTextures[rnd];
                } else if (color == TileColor.Red) {
                    rnd = Random.Range(0, levelExporter.redTileTextures.Length);
                    newTexture = levelExporter.redTileTextures[rnd];
                }
                break;

            case TileType.RedTile:
                rnd = Random.Range(0, levelExporter.redTileTextures.Length);

                newTexture = levelExporter.redTileTextures[rnd];
                break;

            case TileType.BlueTile:
                rnd = Random.Range(0, levelExporter.blueTileTextures.Length);

                newTexture = levelExporter.blueTileTextures[rnd];
                break;


            case TileType.Destination:
                if(color == TileColor.Blue) newTexture = levelExporter.blueDestinationTileTexture;
                else if(color == TileColor.Red) newTexture = levelExporter.redDestinationTileTexture;
                break;

            case TileType.PressurePlate:
                if (color == TileColor.Blue) {
                    if (plateID >= levelExporter.bluePressurePlateTextures.Length) id = 0;
                    else id = plateID;

                    newTexture = levelExporter.bluePressurePlateTextures[id];
                } else if (color == TileColor.Red) {
                    if (plateID >= levelExporter.redPressurePlateTextures.Length) id = 0;
                    else id = plateID;

                    newTexture = levelExporter.redPressurePlateTextures[id];
                }
                break;

            case TileType.ActivatableTile:
                if (color == TileColor.Blue) {
                    if (plateID >= levelExporter.blueActivatableTileTextures.Length) id = 0;
                    else id = plateID;

                    newTexture = levelExporter.blueActivatableTileTextures[id];
                } else if (color == TileColor.Red) {
                    if (plateID >= levelExporter.redActivatableTileTextures.Length) id = 0;
                    else id = plateID;

                    newTexture = levelExporter.redActivatableTileTextures[id];
                }
                break;

            case TileType.RedColorSwitch:
                newTexture = levelExporter.redColorSwitchTexture;
                break;

            case TileType.BlueColorSwitch:
                newTexture = levelExporter.blueColorSwitchTexture;
                break;

            default:
                gameObject.GetComponent<Renderer>().enabled = false;
                break;

        }
        /**/

        if(newTexture != null) GetComponent<Renderer>().material.mainTexture = newTexture;
    }

    public int GetPlateID() {
        return plateID;
    }

    public TileColor GetTileColor() {
        return color;
    }
}
