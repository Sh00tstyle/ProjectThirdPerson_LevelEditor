using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

//used for environmental objects
public class SceneObject {

    [XmlAttribute("Name")]
    public string Name;

    [XmlAttribute("LocalPosition")]
    public Vector3 LocalPosition;

    [XmlAttribute("LocalRotation")]
    public Vector3 LocalRotation;

    [XmlAttribute("LocalScale")]
    public Vector3 LocalScale;

    [XmlAttribute("Model")]
    public string Model;

    [XmlAttribute("Texture")]
    public string Texture;
}
