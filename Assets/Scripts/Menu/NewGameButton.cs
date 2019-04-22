using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameButton : FButton
{
    //private AnimationClip duration;
    //public Animator fade;

    private void Start()
    {
        ChildText(SavedL.language.NewGame);
        //duration = Resources.Load<AnimationClip>("AnimationClip/Duration");
    }

    public override void OnClick(string scene)
    {
        base.OnClick(scene);
    }

    //IEnumerator ToPreGame(string scene)
    //{
    //    fade.SetBool("Change", true);
    //    yield return new WaitForSeconds(duration.length);
    //    SceneManager.LoadScene(scene);
    //}

}
