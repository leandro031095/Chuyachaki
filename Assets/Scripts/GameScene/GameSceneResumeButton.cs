using UnityEngine;

public class GameSceneResumeButton : FButton
{
    public GameObject canvas;
    public GameObject doll;

    private void Start()
    {
        ChildText(SavedL.language.Resume);
    }

    public override void OnClick(string scene)
    {
        canvas.SetActive(false);
        doll.GetComponent<Doll>().UnPause();
        //Time.timeScale = 1;
    }
}
