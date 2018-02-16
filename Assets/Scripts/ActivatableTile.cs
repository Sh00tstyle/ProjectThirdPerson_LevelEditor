using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

public class ActivatableTile {

    [XmlAttribute("ColPos")]
    public int ColPos;

    [XmlAttribute("RowPos")]
    public int RowPos;

    [XmlAttribute("ID")]
    public string ID;

    [XmlAttribute("DisplayColor")]
    public int DisplayColor;
}
