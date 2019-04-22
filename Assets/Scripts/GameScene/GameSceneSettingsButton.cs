using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneSettingsButton : FButton
{
    private void Start()
    {
        ChildText(SavedL.language.Settings);
    }

    public override void OnClick(string scene)
    {
        Saved.triggers.scene = "GameScene";
        base.OnClick(scene);
    }
}
