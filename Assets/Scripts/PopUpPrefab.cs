using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PopUpPrefab : MonoBehaviour
{
    public static PopUpPrefab Instance { get; private set; }

    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private GameObject buttonPrefabContent;

    private void start()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void OnClickClose()
    {
        

    }

    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }

    [System.Serializable]
    public class ListObjectInJsonFile
    {
        public List<ObjectInJsonFile> listObjectInJsonFile = new List<ObjectInJsonFile>();
    }

    [System.Serializable]
    public class ObjectInJsonFile
    {
        public string id;
        public string title;
        public string content;
    }
}
