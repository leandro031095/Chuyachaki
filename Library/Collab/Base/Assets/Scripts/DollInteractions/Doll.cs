using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Doll : MonoBehaviour
{
    DesperationBar hpBar;
    //GameObject babyDoll;
    public Camera zommCamera;
    public float dollDamage;
    DisplayImage displayImage;

    void Start()
    {
        hpBar = GameObject.Find("HealthBar").GetComponent<DesperationBar>();
        displayImage = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        //babyDoll = GameObject.Find("doll");
    }

    void DollDamage()
    {
        float distance = Vector2.Distance(gameObject.transform.position, zommCamera.transform.position);
        float damage = dollDamage * 1000 / distance;
        hpBar.ChangeHealth(-damage);
        hpBar.ShowDesperationState();
    }
    public void DeactivateDoll()
    {
        CancelInvoke("DollSpawn");
        CancelInvoke("DollDamage");
        CancelInvoke("ShakeBar");
        //GameObject.Find("BackgroundMusic").GetComponent<AudioSource>().pitch = 0.9F;
        gameObject.SetActive(false);
    }
    public void ActivateDoll()
    {
        Invoke("DollSpawn", 3.0f);
        
        //dollLaugh.Play();
        
    }
    public void DollSpawn()
    {
        gameObject.SetActive(true);
        //GameObject.Find("BackgroundMusic").GetComponent<AudioSource>().pitch = 1.5F;
        

        if (displayImage.currentWall == 1)
        {
            float[] x = { -493, 46, 370, 480 };
            float[] y = { 22, 260, 70, -130 };
            float[] z = { 300, 300, 300, 300 };
            int i = Random.Range(0, 4);
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/dolls/doll" + i);

            gameObject.transform.position = new Vector3(x[i], y[i], z[i]);
        }
        if (displayImage.currentWall == 2)
        {
            float[] x = { -100, -250, 270, 344 };
            float[] y = { -260, 150, 270, -88 };
            float[] z = { 300, 300, 300, 300 };
            int i = Random.Range(0, 4);
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/dolls/doll" + i);
            gameObject.transform.position = new Vector3(x[i], y[i], z[i]);
        }
        if (displayImage.currentWall == 3)
        {
            float[] x = { -392, 563 };
            float[] y = { 30, -55 };
            float[] z = { 534, 300 };
            int[] doll = { 3, 3 };

            int i = Random.Range(0, 2);
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/dolls/doll"+ doll[i]);
            gameObject.transform.position = new Vector3(x[i], y[i], z[i]);
        }

        //Handheld.Vibrate();
        InvokeRepeating("DollDamage", 2.0f, 0.025f);
        InvokeRepeating("ShakeBar", 2.0f, 0.1f);
    }
    void ShakeBar()
    {
        hpBar.ShakeBar();
    }



    /*IEnumerator HealthBar()
    {
        //hpBar.ChangeHealth(-damage);
        int i = 0;
        while (i < 20)
        {
            hpBar.ChangeHealth(-dollDamage / 20);
            i++;
            yield return new WaitForSeconds(0.0025f);
        }
        hpBar.ShowDesperationState();
        StartCoroutine(RedSlider());
    }
    IEnumerator RedSlider()
    {
        int j = 0;
        while (j < 60)
        {
            hpBar.RedSlider(-dollDamage / 60);
            j++;
            //yield return 0; //Wait 1 Frame
            yield return new WaitForSeconds(0.0025f);
        }
    }*/
}
