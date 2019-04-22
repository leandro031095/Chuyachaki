using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class MuteToggle : MonoBehaviour
{
    public TextMeshProUGUI childText;

    private void Start()
    {
        childText.text = SavedL.language.Mute;
        GetComponent<Toggle>().isOn = Saved.settings.mute;
    }

    public void ClickOnMuteToggle()
    {
        Saved.settings.mute = this.GetComponent<Toggle>().isOn;
        ListenerVolume();
    }

    public static void ListenerVolume()
    {
        if (Saved.settings.mute)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }
    }
}
