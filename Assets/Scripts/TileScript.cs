using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class that allows designers to further specify tile properties
public class TileScript : MonoBehaviour {

    public TileType tileType;

    //properties for pressure plates and activatable tiles
    public string plateID; //string instead of int to have an empty string by default
    public TileColor color;

    private int _arrayXPos;
    private int _arrayYPos;

    public void SetTileType(TileType pType) {
        tileType = pType;

        if(tileType == TileType.None) gameObject.GetComponent<Renderer>().enabled = false;
        else gameObject.GetComponent<Renderer>().enabled = true;
    }

    public TileType GetTileType() {
        return tileType;
    }

    public void ApplyType() {
        //do something visual with the tile to show different 
        switch(tileType) {
            case TileType.BlueTile:
                GetComponent<Renderer>().material.color = Color.blue;
                break;

            case TileType.RedTile:
                GetComponent<Renderer>().material.color = Color.red;
                break;

            case TileType.Destination:
                GetComponent<Renderer>().material.color = Color.black;
                break;

            case TileType.PressurePlate:
                //TODO
                break;

            case TileType.ActivatableTile:
                //TODO
                break;

            case TileType.RedColorSwitch:
                //TODO
                break;

            case TileType.BlueColorSwitch:
                //TODO
                break;

            default:
                GetComponent<Renderer>().material.color = Color.white;
                break;
        }
    }

    public void SetArrayPos(int x, int y) {
        //store tile position
        _arrayXPos = x;
        _arrayYPos = y;
    }

    public int GetArrayXPos() {
        return _arrayXPos;
    }

    public int GetArrayYPos() {
        return _arrayYPos;
    }

    public string GetPlateID() {
        return plateID;
    }

    public TileColor GetTileColor() {
        return color;
    }
}
