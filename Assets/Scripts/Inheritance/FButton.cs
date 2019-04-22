using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FButton : MonoBehaviour
{
    public void ChildText(string text)
    {
        GetComponentInChildren<TextMeshProUGUI>().text = text;
    }

    public void ToggleButton(bool condition, GameObject g)
    {
        if (condition)
        {
            g.SetActive(true);
        }
        else
        {
            g.SetActive(false);
        }
    }

    public virtual void OnClick(string scene)
    {
        StartCoroutine(GetComponent<FadeOut>().ChangeScene(scene));
    }

}
