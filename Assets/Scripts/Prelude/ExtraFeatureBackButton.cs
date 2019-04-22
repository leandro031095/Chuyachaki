using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExtraFeatureBackButton : FButton
{
    private void Start()
    {
        ChildText(SavedL.language.Back);
        ToggleButton(Saved.triggers.extraFeatureBack, gameObject);
    }

    public override void OnClick(string scene)
    {
        base.OnClick(scene);
    }
}
