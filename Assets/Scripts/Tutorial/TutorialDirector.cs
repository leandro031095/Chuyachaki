using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class TutorialDirector : MonoBehaviour
{
    private const float time = 1;
    public CinemachineVirtualCamera zoomCamera;
    public CinemachineVirtualCamera normalCamera;
    public DollDetector dollDetector;
    public DesperationBar healthBar;
    public GameObject dollDetectorObject;
    public GameObject container;
    bool flagPill;

    private void Awake()
    {
        Saved.triggers.textCounter = 0;
        Saved.player.health = 1;
    }

    private void Start()
    {
        StartCoroutine(NormalToZoomCamera());
    }

    private void Update()
    {
        if (!flagPill)
        {

            RecognizeTouch();

        }
        

        if (Saved.triggers.textCounter == 1)
        {
            StartCoroutine(BeginMovement());
        }
    }

    private void RecognizeTouch()
    {
        if(Input.touchCount > 0)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Vector3 ray = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                RaycastHit2D hit = Physics2D.Raycast(ray, Vector3.zero);

                if (hit && hit.transform.name == "pill")
                {
                    flagPill = true;
                    dollDetector.StopInvoke();
                    healthBar.ChangeHealth(0.1f);
                    StartCoroutine(BlinkToGameScene());
                }
            }
        }else if (Input.GetMouseButtonDown(0))
        {
            Vector3 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray, Vector3.zero);

            if (hit && hit.transform.name == "pill")
            {
                flagPill = true;
                dollDetector.StopInvoke();
                healthBar.ChangeHealth(0.1f);
                StartCoroutine(BlinkToGameScene());
            }
        }
    }



    IEnumerator NormalToZoomCamera()
    {
        zoomCamera.GetComponent<ZoomCamera>().enabled = false;
        yield return new WaitForSeconds(time);
        zoomCamera.Priority = 11;
        yield return new WaitForSeconds(time*2.5f);
        DisplayText.TextToDisplay(SavedL.language.Tutorial1);
    }

    IEnumerator BeginMovement()
    {
        zoomCamera.GetComponent<ZoomCamera>().enabled = true;
        StopCoroutine(NormalToZoomCamera());
        Saved.triggers.textCounter = 0;
        dollDetectorObject.GetComponent<DollDetector>().enabled = true;
        yield return null;
        StopAllCoroutines();
    }

    IEnumerator BlinkToGameScene()
    {
        //TODO Respiration sound
        //TODO Wait for the duration
        container.SetActive(false);
        Saved.Save(new PlayerData());
        Saved.Save(new TriggersData());

        Saved.player = Saved.Fill(new PlayerData());
        Saved.triggers = Saved.Fill(new TriggersData());
        yield return new WaitForSeconds(1);
        Saved.triggers.textCounter = 0;
        Saved.triggers.newgame = false;
        StartCoroutine(GetComponent<FadeOut>().ChangeScene("GameScene"));
    }

}
