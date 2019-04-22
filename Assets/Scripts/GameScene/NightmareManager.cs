using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightmareManager : MonoBehaviour
{
    public Material wave;
    public Material opaque;
    public GameObject displayImage;

    public GameObject wall2;
    public GameObject wall4;

    public GameObject wall2Container;
    public GameObject wall4Container;

    public GameObject[] hidden;

    public GameObject pill;

    private float n;
    private int wallNumber;
    private float initialZ;
    private GameObject musicPlayer;
    private AudioClip clip;
    public GameObject doll;

    void Start()
    {
        
    }

    private void OnEnable()
    {
        ChangeMusic();
        displayImage.GetComponent<SpriteRenderer>().material = wave;
        wallNumber = displayImage.GetComponent<DisplayImage>().currentWall;
        HidePlayerCanvas();
        CheckWall();
        DisplayText.TextToDisplay(SavedL.language.NighmareText0);
    }

    private void ChangeMusic()
    {
        musicPlayer = GameObject.Find("MusicPlayer");
        clip = musicPlayer.GetComponent<AudioSource>().clip;
        var nightmareClip = Resources.Load<AudioClip>("Musica/Modo Pesadilla");
        //var nightmareClip = Resources.Load<AudioClip>("Musica/Bad Encounter");
        //musicPlayer.GetComponent<AudioSource>().pitch = 1.5f;
        musicPlayer.GetComponent<AudioSource>().clip = nightmareClip;
        musicPlayer.GetComponent<AudioSource>().Play();
    }

    /*private void Update()
    {
        //print(Saved.triggers.nightmarecounter.ToString());
           
    }*/

    public void EndNightmare()
    {
        
        switch (wallNumber)
        {
            case 2:
                DeactivateContainer(wall2Container);
                wall2.SetActive(true);
                break;

            case 4:
                DeactivateContainer(wall4Container);
                wall4.SetActive(true);
                break;
        }
        musicPlayer.GetComponent<AudioSource>().clip = clip;
        musicPlayer.GetComponent<AudioSource>().Play();
        pill.GetComponent<Pill>().HealAmount(n);
        ShowPlayerCanvas();
        displayImage.GetComponent<SpriteRenderer>().material = opaque;
        Saved.triggers.nightmare = false;
        Saved.triggers.nightmarecounter = 0;
        Saved.triggers.level = "";
        gameObject.SetActive(false);
        doll.GetComponent<Doll>().DeactivateDoll();
        doll.GetComponent<Doll>().ActivateDoll();
    }

    private void ShowPlayerCanvas()
    {
        foreach (GameObject g in hidden)
        {
            g.transform.position = new Vector3(g.transform.position.x, g.transform.position.y, initialZ);
        }
    }

    private void DeactivateContainer(GameObject container)
    {
        container.SetActive(false);
        //for (int i = 0; i < container.transform.childCount; i++)
        //{
        //    if (container.transform.GetChild(i).gameObject.activeSelf == true)
        //    {
        //        container.transform.GetChild(i).gameObject.SetActive(false);
        //    }
        //}
    }

    private void HidePlayerCanvas()
    {
        foreach (GameObject g in hidden)
        {
            initialZ = g.transform.position.z;
            g.transform.position = new Vector3(g.transform.position.x, g.transform.position.y, -500);
        }
    }


    private void CheckWall()
    {
        if (wallNumber == 2)
        {
            wall2.SetActive(false);
            wall2Container.SetActive(true);
            ActivateNightmare(wall2Container);
        }
        else if (wallNumber == 4)
        {
            wall4.SetActive(false);
            wall4Container.SetActive(true);
            ActivateNightmare(wall4Container);
        }
    }


    public void ActivateNightmare(GameObject container)
    {
        if (Saved.triggers.level == "easy")
        {
            n = 0.3f;
            int r = Random.Range(0, 3);
            container.transform.GetChild(r).GetComponent<SpriteRenderer>().enabled = false;
            container.transform.GetChild(r).transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            n = 0.6f;
            bool limit = true;
            int j = 0;
            while (limit)
            {
                int i = Random.Range(0, 3);
                if (container.transform.GetChild(i).transform.GetChild(0).gameObject.activeSelf == true)
                {

                }
                else
                {
                    container.transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = false;
                    container.transform.GetChild(i).transform.GetChild(0).gameObject.SetActive(true);
                    j++;
                }

                if (j == 2)
                {
                    limit = false;
                }
            }
        }
        doll.GetComponent<Doll>().DeactivateDoll();
        doll.GetComponent<Doll>().ActivateDoll();
    }
}
