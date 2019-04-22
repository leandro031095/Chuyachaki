using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DollDetector : MonoBehaviour
{
    private const float Seconds = 0.5f;
    [Header("Valores de la barra de vida")]
    public float inventoryTime;
    public float damage;
    public float repeatTime;
    [Space(5)]
    public GameObject flashlight;
    public GameObject doll;
    public GameObject zoomCamera;
    public GameObject healthBar;
    public GameObject inventory;
    public Animator pillAnimator;
    public GameObject tutorialDirector;
    [Header("Masks")]
    public GameObject maskBackground;
    public GameObject mask;


    private AudioSource dollLaugh;
    private AnimationClip duration;
    private bool stopDetecting = false;

    private void Start()
    {
        dollLaugh = doll.GetComponent<AudioSource>();
        duration = Resources.Load<AnimationClip>("AnimationClip/Duration");
        
    }

    private void Update()
    {

        
        CheckHealtBar();



        if (!stopDetecting)
        {
            DetectDoll();
        }

        if (Saved.triggers.textCounter == 1)
        {
            StartCoroutine(ActivatingMasks());
        }

        if(Saved.triggers.textCounter == 3)
        {
            StartCoroutine(ActivatingFlashlight());

        }
       
    }

    private void CheckHealtBar()
    {
        if (healthBar.GetComponent<DesperationBar>().healthSlider.value < 0.9f)
        {
            StopInvoke();
        }
    }

    public void DetectDoll()
    {
        Vector3 ray = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(ray, Vector3.up,Mathf.Infinity);

        if (hit && hit.transform.name == "Flashlight")
        {
            tutorialDirector.GetComponent<TutorialDirector>().enabled = false;
            zoomCamera.GetComponent<ZoomCamera>().enabled = false;
            stopDetecting = true;
            DisplayText.TextToDisplay("Me puede servir mas adelante"); 
        }
    }

    public void ChangeHealth()
    {
        healthBar.GetComponent<DesperationBar>().ChangeHealth(-damage);
    }

    public void StopInvoke()
    {
        CancelInvoke("ChangeHealth");
    }

    IEnumerator ActivatingMasks()
    {
        Saved.triggers.textCounter = 2;
        flashlight.SetActive(false);
        yield return new WaitForSeconds(Seconds);
        //Sonido de luces apagados
        maskBackground.SetActive(true);
        yield return new WaitForSeconds(Seconds*2);
        dollLaugh.GetComponent<SpriteRenderer>().enabled = false;
        yield return null;
        dollLaugh.Play();
        yield return new WaitForSeconds(dollLaugh.clip.length);
        //Sonido de linterna prendida
        DisplayText.TextToDisplay("Puedo usar la linterna");
    }

    IEnumerator ActivatingFlashlight()
    {
        Saved.triggers.textCounter = 0;
        yield return new WaitForSeconds(Seconds);
        mask.SetActive(true);
        yield return new WaitForSeconds(Seconds);
        healthBar.SetActive(true);
        yield return new WaitForSeconds(duration.length);
        InvokeRepeating("ChangeHealth", 0, repeatTime);
        yield return new WaitForSeconds(inventoryTime);
        inventory.SetActive(true);
        yield return new WaitForSeconds(duration.length);
        DisplayText.TextToDisplay(SavedL.language.Tutorial2);
        yield return null;
        pillAnimator.SetBool("PillAlert", true);   
        tutorialDirector.GetComponent<TutorialDirector>().enabled = true;
    }
}
