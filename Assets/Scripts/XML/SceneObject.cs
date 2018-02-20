using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

//used for environmental objects
public class SceneObject {

    [XmlAttribute("Name")]
    public string Name;

    [XmlAttribute("xPos")]
    public float xPos;

    [XmlAttribute("yPos")]
    public float yPos;

    [XmlAttribute("zPos")]
    public float zPos;

    [XmlAttribute("xRot")]
    public float xRot;

    [XmlAttribute("yRot")]
    public float yRot;

    [XmlAttribute("zRot")]
    public float zRot;

    [XmlAttribute("wRot")]
    public float wRot;

    [XmlAttribute("xScale")]
    public float xScale;

    [XmlAttribute("yScale")]
    public float yScale;

    [XmlAttribute("zScale")]
    public float zScale;

    [XmlAttribute("Model")]
    public string Model;

    [XmlAttribute("Texture")]
    public string Texture;
}
