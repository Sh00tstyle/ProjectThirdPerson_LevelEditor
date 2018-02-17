using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

public class SpawnTile {

    [XmlAttribute("ColPos")]
    public int ColPos;

    [XmlAttribute("RowPos")]
    public int RowPos;

    [XmlAttribute("StartingColor")]
    public int StartingColor;
}