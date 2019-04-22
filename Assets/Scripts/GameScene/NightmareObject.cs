using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightmareObject : MonoBehaviour, IInteractable
{
    NightmareManager nightmareManager;

    void Start()
    {
        nightmareManager = GameObject.Find("NightmareManager").GetComponent<NightmareManager>();
    }
    void OnEnable()
    {
        nightmareManager = GameObject.Find("NightmareManager").GetComponent<NightmareManager>();
    }

    public void Interact(DisplayImage currentDisplay)
    {
        Saved.triggers.nightmarecounter++;

     


        if (Saved.triggers.nightmarecounter == 1 && Saved.triggers.level == "easy")
        {
            DisplayText.TextToDisplay(SavedL.language.NighmareText1);
            nightmareManager.EndNightmare();
            
        }

        else if (Saved.triggers.nightmarecounter == 1 && Saved.triggers.level != "easy")
        {
            DisplayText.TextToDisplay(SavedL.language.NighmareText2);
        }

        else if (Saved.triggers.nightmarecounter == 2)
        {
            DisplayText.TextToDisplay(SavedL.language.NighmareText1);
            nightmareManager.EndNightmare();
        }
       
        gameObject.SetActive(false);
    }
}
