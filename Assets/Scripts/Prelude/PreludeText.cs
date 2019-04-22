using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PreludeText : MonoBehaviour
{
    [HideInInspector]
    public bool stop = false;
    private TextMeshProUGUI texto;
    public SkipButton skip;
    public AudioSource typeWritter;
    

    private void Start()
    {
        texto = GetComponent<TextMeshProUGUI>();
        StartCoroutine(TypeSentence());
    }

    IEnumerator TypeSentence()
    {
        string oracion = SavedL.language.PreludeText;
        yield return new WaitForSeconds(1);
        typeWritter.Play();

        //Manda el texto lentamente
        foreach (char letter in oracion.ToCharArray())
        {
            texto.text += letter;
            if (stop == true)
            {
                texto.text = SavedL.language.PreludeText;
                break;
            }
            yield return null;
        }
        if (!Saved.triggers.extraFeatureBack)
        {
            StartCoroutine(skip.ToBegin());
        }
        typeWritter.Stop();
    }
}
