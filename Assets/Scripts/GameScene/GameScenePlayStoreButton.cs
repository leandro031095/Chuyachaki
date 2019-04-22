using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScenePlayStoreButton : FButton
{
    private void Start()
    {
        ChildText(SavedL.language.PlayStore);
    }

    public override void OnClick(string scene)
    {
        Application.OpenURL("market://details?id=" + Application.productName);
    }
}
