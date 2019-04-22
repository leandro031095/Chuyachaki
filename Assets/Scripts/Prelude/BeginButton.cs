using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginButton : FButton
{
    private void Start()
    {
        ChildText(SavedL.language.Begin);
        ToggleButton(false, gameObject);
    }

    public override void OnClick(string scene)
    {
        Saved.Save(new PlayerData());
        Saved.Save(new TriggersData());

        Saved.player = Saved.Fill(new PlayerData());
        Saved.triggers = Saved.Fill(new TriggersData());
        Saved.player.health = 1;
        Saved.triggers.prelude = true;
        base.OnClick(scene);
    }
}
