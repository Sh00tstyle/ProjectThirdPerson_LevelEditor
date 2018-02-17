using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

//used for the playfield array/list
public class Playfield {

    [XmlAttribute("Height")]
    public int Height;

    [XmlAttribute("Width")]
    public int Width;

    [XmlAttribute("Content")]
    public List<int> Content = new List<int>();

    public void AddContent(int value) {
        Content.Add(value);
    }
	
}
