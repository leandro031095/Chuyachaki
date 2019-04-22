using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : FButton
{
    public GameObject buttonsContainer;
    [Header ("Luego del preludio")]
    public GameObject preGame;
    public GameObject fade;
    private AnimationClip duration;

    private void Start()
    {
        ChildText(SavedL.language.Start);
        duration = Resources.Load<AnimationClip>("AnimationClip/Duration");
    }

    public override void OnClick(string scene)
    {
        StartCoroutine(ToPreGame());
    }

    IEnumerator ToPreGame()
    {
        GetComponent<FadeOut>().fade.GetComponent<Animator>().SetBool("Change", true);
        yield return new WaitForSeconds(duration.length);
        preGame.SetActive(true);
        buttonsContainer.SetActive(false);
    }
}
