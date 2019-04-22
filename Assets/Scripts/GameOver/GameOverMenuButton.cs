using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenuButton : FButton
{
    private void Start()
    {
        ChildText(SavedL.language.Menu); 
    }

    public override void OnClick(string scene)
    {
        
        base.OnClick(scene);
    }
}
