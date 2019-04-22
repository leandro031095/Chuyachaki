using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingsButton : FButton
{

    private void Start()
    {
        ChildText(SavedL.language.Settings);
    }

    public override void OnClick(string scene)
    {
        Saved.triggers.scene = "Menu";
        base.OnClick(scene);
    }



}
