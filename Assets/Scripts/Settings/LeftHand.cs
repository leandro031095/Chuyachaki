using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LeftHand : MonoBehaviour
{
    public GameObject exp;
    public TextMeshProUGUI childText;
    
    private void Start()
    {
        SetLanguage();
        GetComponent<Toggle>().isOn = Saved.settings.leftHand;
    }

    private void SetLanguage()
    {
        childText.text = SavedL.language.LeftHanded;
        exp.GetComponent<TextMeshProUGUI>().text = SavedL.language.LeftHandedExp;
    }

    public void ClickOnManoIzquierda()
    {
        Saved.settings.leftHand = this.GetComponent<Toggle>().isOn;
        exp.SetActive(this.GetComponent<Toggle>().isOn);
    }
}
