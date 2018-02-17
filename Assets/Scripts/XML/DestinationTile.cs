using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

public class DestinationTile {

    [XmlAttribute("ColPos")]
    public int ColPos;

    [XmlAttribute("RowPos")]
    public int RowPos;

    [XmlAttribute("NeededColor")]
    public int NeededColor;
}