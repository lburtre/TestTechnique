using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SelectMenu : MonoBehaviour
{
    [SerializeField] private string json1PathFromApp; // => /Scripts/Json/Json1.json
    [SerializeField] private string json2PathFromApp;

    public void OnCLickButtonJson1()
    {
        string jsonText = ReturnJson(json1PathFromApp);
        Debug.Log(jsonText);
    }

    public void OnCLickButtonJson2()
    {
        string jsonText = ReturnJson(json2PathFromApp);
        Debug.Log(jsonText);
    }

    private string ReturnJson(string path)
    {
        using (StreamReader stream = new StreamReader(Application.dataPath + path))
        {
            string json = stream.ReadToEnd();
            return json;
        }
    }
}
