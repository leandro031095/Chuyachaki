using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBackButton : FButton
{
    public GameObject buttonsContainer;
    private void Start()
    {
        ChildText(SavedL.language.Back);
    }

    public override void OnClick(string scene)
    {
        buttonsContainer.SetActive(true);
        base.OnClick(scene);
    }

}
