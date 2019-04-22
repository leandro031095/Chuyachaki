using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneExitButton : FButton
{
    private void Start()
    {
        ChildText(SavedL.language.Exit);
    }

    public override void OnClick(string scene)
    {
        base.OnClick(scene);
        Time.timeScale = 1;
    }
}
