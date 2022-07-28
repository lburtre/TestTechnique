using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public delegate void SelectMenuEventHandler();

public class SelectMenu : MonoBehaviour
{
    public static event SelectMenuEventHandler OnNewButtonToInstanciate;
    public static event SelectMenuEventHandler OnClickNewData;

    [SerializeField] private string json1PathFromApp; // => /Scripts/Json/Json1.json
    [SerializeField] private string json2PathFromApp;

    private JsonFileObjects objectsFromJson;

    public static JsonFileObject ActualJsonFileObject { get; private set; }

    public void OnCLickButtonJson1()
    {
        OnClickNewData?.Invoke();
        UpdateObjectsFromJson(json1PathFromApp);
    }

    public void OnCLickButtonJson2()
    {
        OnClickNewData?.Invoke();
        UpdateObjectsFromJson(json2PathFromApp);
    }

    private void UpdateObjectsFromJson(string path)
    {
        using (StreamReader reader = File.OpenText(Application.dataPath + path))
        {
            string json = reader.ReadToEnd();
            objectsFromJson = JsonUtility.FromJson<JsonFileObjects>("{\"listObject\":" + json + "}");
        }

        InstanciateButton();
    }

    public void InstanciateButton()
    {
        int numberObject = objectsFromJson.listObject.Count;

        for (int i = 0; i < numberObject; i++)
        {
            ActualJsonFileObject = objectsFromJson.listObject[i];
            OnNewButtonToInstanciate?.Invoke();
        }
    }

    [System.Serializable]
    public class JsonFileObjects
    {
        public List<JsonFileObject> listObject = new List<JsonFileObject>();
    }

    [System.Serializable]
    public class JsonFileObject
    {
        public int id;
        public string title;
        public string content;
    }
}
