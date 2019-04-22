using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DesperationBar : MonoBehaviour
{
    public Slider redSlider;
    public Slider healthSlider;
    string state;
    //Transform Mask;
    [Header("Game Over")]
    public GameObject display;
    public Material gameOver;
    public GameObject zoomCamera;
    public GameObject doll;
    public GameObject ending;
    public float velocity;
    public GameObject[] container;
    private float c = 0.15f;
    private bool gameoverFlag;
    private bool flag;

    void Start()
    {
        healthSlider.value = Saved.player.health;
        HealthBarPosition();
        /*if (SceneManager.GetActiveScene().name == "GameScene")
        {
            Mask = GameObject.Find("Masks").transform;
            Mask.localScale = new Vector3(2 - (1 - healthSlider.value), 2 - (1 - healthSlider.value), 1);
        }*/

    }
    void HealthBarPosition()
    {
        RectTransform hpbar = gameObject.GetComponent<RectTransform>();
        if (Saved.settings.leftHand)
        {
            hpbar.localPosition = new Vector3(-hpbar.localPosition.x, hpbar.localPosition.y, hpbar.localPosition.z);
        }
        else
        {
            hpbar.localPosition = new Vector3(hpbar.localPosition.x, hpbar.localPosition.y, hpbar.localPosition.z);
        }
    }

    private void Update()
    {
        if (healthSlider.value <= 0.01f && !gameoverFlag && SceneManager.GetActiveScene().name == "GameScene")
        {
            GameOver("GameOver");
            gameoverFlag = true;
        }
       
    }

    public void ShakeBar()
    {
        if (Up)
        {
            transform.localPosition = new Vector3(transform.localPosition.x + x, transform.localPosition.y + y, transform.localPosition.z);
            Up = false;
        }
        else
        {
            transform.localPosition = new Vector3(transform.localPosition.x - x, transform.localPosition.y - y, transform.localPosition.z);
            Up = true;
        }
    }
    public void ChangeHealth(float amount)
    {
        if (healthSlider.value >= 0)
        {
            healthSlider.value += amount;
            /*if (SceneManager.GetActiveScene().name == "GameScene")
            {
                Mask.localScale = new Vector3(2 - (1 - healthSlider.value), 2 - (1 - healthSlider.value), 1);
                Mask.localScale = new Vector3(2 - (1 - healthSlider.value), 2 - (1 - healthSlider.value), 1);
            }  */   
            Saved.player.health = healthSlider.value;
        }
    }
    /*public void RedSlider(float amount)
    {
        redSlider.value += amount;
    }*/
   /* public void ShowDesperationState()
    {
        //string state = "";
        if (healthSlider.value <= 0.25)
        {
            state = "Nuts";
        }
        else if (healthSlider.value <= 0.5)
        {
            state = "Desperate";
        }
        else if (healthSlider.value <= 0.75)
        {
            state = "Anxious";
        }
        else if (healthSlider.value <= 1)
        {
            state = "Calm";
        }
        Text text = GameObject.Find("DesperationState").GetComponent<Text>();
        text.text = "State: " + state;
    }*/

    public float x = 0.5f; 
    public float y= 0.5f;

    
    bool Up = true;

    public void GameOver(string scene)
    {
        Saved.Save(new PlayerData());
        Saved.Save(new TriggersData());

        Saved.player = Saved.Fill(new PlayerData());
        Saved.triggers = Saved.Fill(new TriggersData());
        Saved.triggers.newgame = false;

        foreach (GameObject g in container)
        {
            g.transform.position = new Vector3(g.transform.position.x,g.transform.position.y,-400);
        }
        display.GetComponent<SpriteRenderer>().material = gameOver;
        doll.GetComponent<SpriteRenderer>().material = gameOver;
        StartCoroutine(GameOverSequence(scene,false));
    }

    public IEnumerator GameOverSequence(string scene,bool ending)
    {
        zoomCamera.GetComponent<ZoomCamera>().enabled = false;
        float f = c + velocity;
        c = f;
        if(f >= 0.5 && !flag)
        {
            StartCoroutine(GetComponent<FadeOut>().ChangeScene(scene));
            flag = true;
        }
        display.GetComponent<SpriteRenderer>().material.SetFloat("_Opaqueness", f);
        doll.GetComponent<SpriteRenderer>().material.SetFloat("_Opaqueness", f);
        if (ending)
        {
            this.ending.GetComponent<SpriteRenderer>().material.SetFloat("_Opaqueness", f);
        }
        yield return null;
        StartCoroutine(GameOverSequence(scene,false));
    }
}
