using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : FButton
{
    private void Start()
    {
        ChildText(SavedL.language.Exit);
    }

    public override void OnClick(string scene)
    {
        StartCoroutine(ExitAnimation());
    }

    IEnumerator ExitAnimation()
    {
        GetComponent<FadeOut>().fade.SetBool("Change", true);
        yield return new WaitForSeconds(GetComponent<FadeOut>().duration.length);
        Application.Quit();
    }
}
