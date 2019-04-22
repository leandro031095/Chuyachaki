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

        if (displayImage.currentWall == 1)
        {
            //derecha abajo, agarrado del papel, foco1, foco2, mesa
            float[,] position = new float[5, 3] { { 480, -180, 500 }, { 412.2f, 107.5f, 500 }, { 32, 293, 500 }, { -11, 276.2f, 500 }, { -494.7f, -33.7f, 500 } };

            int[] sprite = { 11, 12, 13, 21, 22, 31, 41, 51, 52, 53, 54 };
            int i = Random.Range(0, sprite.Length);
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall" + displayImage.currentWall + "/dolls/" + sprite[i]);
            int randomDoll = int.Parse(sprite[i].ToString().Substring(0, 1)) - 1;
            gameObject.transform.position = new Vector3( position[randomDoll, 0], position[randomDoll, 1], position[randomDoll, 2]);
        }
        if (displayImage.currentWall == 2)
        {
            float[,] position = new float[7, 3] { { 209.9f, 67.1f,500 }, { 264.6f, 237.2f,500 }, { 264.6f, 221.8f,500 }, { 265.4f, 281.7f,500 }, 
                { -480, 25,500 }, { -117, -278,500 }, { -117, -261,500 } };

            int[] sprite = { 11, 12,  21,  31, 41, 51, 52, 61, 71 };
            int i = Random.Range(0, sprite.Length);
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall" + displayImage.currentWall + "/dolls/" + sprite[i]);
            int randomDoll = int.Parse(sprite[i].ToString().Substring(0, 1)) - 1;
            gameObject.transform.position = new Vector3(position[randomDoll, 0], position[randomDoll, 1], position[randomDoll, 2]);
        }
        if (displayImage.currentWall == 3)
        {
            float[,] position = new float[6, 3] { { 591, -93, 500 }, { 571, -19, 500 }, { 94, -151, 500 }, { 41.5f, -214.5f, 500 }, { -544.3f, -177.7f, 500 }, { -574.5f, -172.7f, 500 } };

            int[] sprite = { 11, 21, 31, 41, 51, 61 };
            int i = Random.Range(0, sprite.Length);
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall" + displayImage.currentWall + "/dolls/" + sprite[i]);
            int randomDoll = int.Parse(sprite[i].ToString().Substring(0, 1)) - 1;
            gameObject.transform.position = new Vector3(position[randomDoll, 0], position[randomDoll, 1], position[randomDoll, 2]);
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
