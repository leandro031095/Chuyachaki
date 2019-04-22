using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : FButton
{

    private void Start()
    {
        ChildText(SavedL.language.Continue);
        ToggleButton(Saved.triggers.prelude , gameObject);
    }

    public override void OnClick(string scene)
    {
        base.OnClick(scene);
    }

}
