using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : FButton
{
    private void Start()
    {
        ChildText(SavedL.language.Exit);
    }

    public override void OnClick(string scene)
    {
        base.OnClick(Saved.triggers.scene);
    }
}
