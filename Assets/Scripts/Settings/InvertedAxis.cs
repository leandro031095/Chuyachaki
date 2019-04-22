using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InvertedAxis : MonoBehaviour
{
    //public GameObject explication;
    public TextMeshProUGUI childText;

    private void Start()
    {
        childText.text = SavedL.language.InvertedAxis;
        GetComponent<Toggle>().isOn = Saved.settings.invertedAxis;
    }

    public void ClickOnInvertedAxis()
    {
        Saved.settings.invertedAxis = this.GetComponent<Toggle>().isOn;
        //explication.SetActive(settingsData.izquierda);
    }
}
