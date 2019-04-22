using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneMenuButton : FButton
{
    public GameObject child;
    private GameSceneText textManager;
    public GameObject doll;

    

    public override void OnClick(string scene)
    {
        Saved.triggers.nightmare = false;
        child.SetActive(true);
        doll.GetComponent<Doll>().Pause();
    }
}
