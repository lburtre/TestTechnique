using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUpPrefab : MonoBehaviour
{
    [SerializeField] private GameObject buttonObjectPrefab;
    [SerializeField] private GameObject containerInstanciationButton;
    [SerializeField] private TextMeshProUGUI containerDescriptionText;

    private List<GameObject> listButtonInstanciate = new List<GameObject>();

    public static PopUpPrefab Instance { get; private set; }

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        SelectMenu.OnNewButtonToInstanciate += OnNewButtonToInstanciate;
        SelectMenu.OnClickNewData += OnClickNewData;
        gameObject.SetActive(false);
    }

    private void OnClickNewData()
    {
        ResetPopUpPrefab();
        gameObject.SetActive(true);
    }

    private void OnNewButtonToInstanciate()
    {
        GameObject buttonInstance = Instantiate(buttonObjectPrefab, containerInstanciationButton.transform);
        buttonInstance.GetComponent<ButtonObject>().UpdateButtonInformation();
        listButtonInstanciate.Add(buttonInstance);
    }

    public void OnClickClose()
    {
        ResetPopUpPrefab();
    }

    private void ResetPopUpPrefab()
    {
        int numberObject = listButtonInstanciate.Count;

        if(numberObject > 0)
        {
            for (int i = numberObject - 1; i >= 0; i--)
            {
                Destroy(listButtonInstanciate[i]);
            }
        }

        containerDescriptionText.text = "";
        gameObject.SetActive(false);
    }

    public void UpdateContentText(string contentText)
    {
        containerDescriptionText.text = contentText;
    }

    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }
}
