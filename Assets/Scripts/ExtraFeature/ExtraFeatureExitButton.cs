using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraFeatureExitButton : FButton
{
    private void Start()
    {
        ChildText(SavedL.language.Back);
    }

    public override void OnClick(string scene)
    {
        Saved.triggers.extraFeatureBack = false;
        base.OnClick(scene);
    }
}
