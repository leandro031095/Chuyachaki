using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSceneButton : FButton
{
    private void Start()
    {
        ChildText(SavedL.language.IntroScene);
    }

    public override void OnClick(string scene)
    {
        base.OnClick(scene);
    }
}
