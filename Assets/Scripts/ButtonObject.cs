using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonObject : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI buttonText;

    private string contentTextAffected;

    public void UpdateButtonInformation()
    {
        buttonText.text = SelectMenu.ActualJsonFileObject.title;
        contentTextAffected = SelectMenu.ActualJsonFileObject.content;
    }

    public void OnClickButton()
    {
        PopUpPrefab.Instance.UpdateContentText(contentTextAffected);
    }
}
