using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreludeSkipTutorialButton : FButton
{
    private void Start()
    {
        ChildText(SavedL.language.SkipTutorial);
        ToggleButton(!Saved.triggers.newgame, gameObject);
    }

    public override void OnClick(string scene)
    {
        Saved.Save(new PlayerData());
        Saved.Save(new TriggersData());

        Saved.player = Saved.Fill(new PlayerData());
        Saved.triggers = Saved.Fill(new TriggersData());
        Saved.triggers.newgame = false;
        base.OnClick(scene);
    }

}
