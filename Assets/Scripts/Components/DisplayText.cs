using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayText : MonoBehaviour
{
    //public GameObject Idoll;
    private static GameSceneText displayer;
    //private static GameObject doll;

    private void Start()
    {
        //doll = Idoll;
        displayer = GetComponent<GameSceneText>();
        Saved.triggers.count = 2;
    }

    public static void TextToDisplay(string textToDisplay)
    {
        Saved.triggers.textFinished = false;

        CheckScene();

        if (Saved.triggers.count == 2)
        {
            Saved.triggers.count = 0;
            displayer.DisplayText(textToDisplay);
        }
    }

    private static void CheckScene()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            //doll.GetComponent<Doll>().StopDamage();
            Time.timeScale = 0;
        }
    }

    private void OnDisable()
    {
        Saved.triggers.count = 2;
    }
}
