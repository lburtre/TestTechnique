using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public delegate void SelectMenuEventHandler();

public class SelectMenu : MonoBehaviour
{
    public static event SelectMenuEventHandler OnChangeUpdatePopUp;

    [SerializeField] private string json1PathFromApp; // => /Scripts/Json/Json1.json
    [SerializeField] private string json2PathFromApp;

    private ObjectsInJsonFile objectsFromJson;

    public void OnCLickButtonJson1()
    {
        UpdateObjectsInJson(json1PathFromApp);
    }

    public void OnCLickButtonJson2()
    {
        UpdateObjectsInJson(json2PathFromApp);
    }

    private void UpdateObjectsInJson(string path)
    {
        using (StreamReader reader = File.OpenText(Application.dataPath + path))
        {
            string json = reader.ReadToEnd();
            objectsFromJson = JsonUtility.FromJson<ObjectsInJsonFile>("{\"listObject\":" + json + "}");
        }
    }

    [System.Serializable]
    public class ObjectsInJsonFile
    {
        public List<ObjectInJsonFile> listObject = new List<ObjectInJsonFile>();
    }

    [System.Serializable]
    public class ObjectInJsonFile
    {
        public int id;
        public string title;
        public string content;
    }
}
