using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;

public class LevelExporterScript : MonoBehaviour {

    [SerializeField]
    private string _fileName;

    private Transform[] _sceneObjects;

	private void Start () {
        _sceneObjects = GetComponentsInChildren<Transform>();

        string filePath = "Assets/XmlScenes/" + _fileName + ".xml";

        XmlSerializer serializer = new XmlSerializer(typeof(SceneObjectContainer));
        FileStream stream = new FileStream(filePath, FileMode.Create);

        //Setting up the container
        SceneObjectContainer sceneObjectContainer = new SceneObjectContainer();

        //starting at i = 1, so that we don't parse the level exporter itself
        for(int i = 1; i < _sceneObjects.Length; i++) {
            //adding objects to the container
            Transform currentTransform = _sceneObjects[i];
            SceneObject sceneObject = CreateSceneObject(currentTransform);
            
            //Adding the newly created object to the list
            sceneObjectContainer.AddSceneObject(sceneObject);
        }

        //Creating the file
        serializer.Serialize(stream, sceneObjectContainer);
        stream.Close();

        Debug.Log("Scenefile '" + _fileName + ".xml' created in Assets/XmlScenes");
	}

    private SceneObject CreateSceneObject(Transform objTransform) {
        SceneObject sceneObject = new SceneObject(); //blank object

        //name
        sceneObject.Name = objTransform.name;

        //transform properties
        sceneObject.LocalPosition = objTransform.localPosition;
        sceneObject.LocalRotation = objTransform.localEulerAngles;
        sceneObject.LocalScale = objTransform.localScale;

        //model and texture
        ObjectIdentifier objectIdentifier = objTransform.GetComponent<ObjectIdentifier>();
        sceneObject.Model = objectIdentifier.GetObjFilePath();
        sceneObject.Texture = objectIdentifier.GetTexturePath();

        //parent
        if (objTransform.parent.GetComponent<LevelExporterScript>()) {
            sceneObject.Parent = ""; //blank, if no parent
        } else {
            sceneObject.Parent = objTransform.parent.name;
        }

        return sceneObject;
    }
}
