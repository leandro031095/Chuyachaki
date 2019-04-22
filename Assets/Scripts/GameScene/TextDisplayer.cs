using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TextDisplayer : GameSceneText
{

    //public GameObject doll;

    private void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (Saved.triggers.count == 0)
                {
                    text.text = Saved.triggers.incomingText;
                    Saved.triggers.count++;
                }
                else if (Saved.triggers.count == 1)
                {
                    text.text = "";
                    Saved.triggers.count++;
                    Saved.triggers.textCounter++;
                    gameObject.SetActive(false);
                }
            }
        }else if (Input.GetMouseButtonDown(0))
        {
            if (Saved.triggers.count == 0)
            {
                text.text = Saved.triggers.incomingText;
                Saved.triggers.count++;
            }
            else if (Saved.triggers.count == 1)
            {
                text.text = "";
                Saved.triggers.count++;
                Saved.triggers.textCounter++;
                gameObject.SetActive(false);
            }
        }
    }


    private void OnDisable()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            //doll.GetComponent<Doll>().DoDamage();
            Time.timeScale = 1;
        }
    }

}
