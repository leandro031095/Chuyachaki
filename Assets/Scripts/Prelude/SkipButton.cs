using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkipButton : FButton
{
    public PreludeText preludeText;
    public GameObject beginButton;

    private void Start()
    {
        ToggleButton(!Saved.triggers.extraFeatureBack, gameObject);
        ChildText(SavedL.language.Skip);

    }

    public override void OnClick(string scene)
    {
        preludeText.stop = true;
        GetComponent<Button>().enabled = false;
        StartCoroutine(ToBegin());
    }

    public IEnumerator ToBegin()
    {
        GetComponent<Animator>().SetBool("ToBegin", true);
        yield return new WaitForSeconds(GetComponent<FadeOut>().duration.length);
        beginButton.GetComponent<Button>().enabled = false;
        beginButton.SetActive(true);
        yield return new WaitForSeconds(GetComponent<FadeOut>().duration.length);
        beginButton.GetComponent<Button>().enabled = true;
    }
}
