using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreludeBackButton : FButton
{
    private void Start()
    {
        ChildText(SavedL.language.Back);
        ToggleButton(!Saved.triggers.extraFeatureBack, gameObject);
    }

    public override void OnClick(string scene)
    {
        base.OnClick(scene);
    }
}
