using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSceneText : MonoBehaviour
{
    [HideInInspector]
    public TextMeshProUGUI text;
    [HideInInspector]
    public string incomingText;


    public void DisplayText(string t)
    {
        incomingText = t;
        Saved.triggers.incomingText = incomingText;
        ActivatingTextBox(true);
        text = transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>();
        StartCoroutine(SlowTypeSentence(incomingText));
    }



    public void ActivatingTextBox(bool c)
    {
        transform.GetChild(0).gameObject.SetActive(c);
    }


    IEnumerator SlowTypeSentence(string t)
    {
        foreach (char letter in t.ToCharArray())
        {
            text.text += letter;
            yield return null;
            if(Saved.triggers.count == 1) break;
        }
        Saved.triggers.textFinished = true;
        Saved.triggers.count = 1;
    }
}
