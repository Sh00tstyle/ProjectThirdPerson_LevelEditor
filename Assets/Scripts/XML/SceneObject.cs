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

    [XmlAttribute("Model")]
    public string Model;

    [XmlAttribute("Texture")]
    public string Texture;
}
