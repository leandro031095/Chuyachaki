using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Ending : MonoBehaviour
{
    public GameObject eyesContainer;
    public GameObject desesperationBar;
    public GameObject zoomCamera;
    public GameObject doll;
    public Material opaque;
    public GameObject ending;
    private float duration;

    private void Start()
    {
        doll.SetActive(false);
        zoomCamera.transform.position = new Vector3(14.8f, -56.1f, 0);
        zoomCamera.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 131.8f;
        zoomCamera.GetComponent<ZoomCamera>().enabled = false;
        duration = Resources.Load<AnimationClip>("AnimationClip/Duration").length;
        InitializeEnding();
    }

    private void InitializeEnding()
    {
        StartCoroutine(EndingSequence());
    }

    IEnumerator EndingSequence()
    {
        GameObject.Find("PlayerCanvas").transform.Find("ButtonRight").gameObject.SetActive(false);
        GameObject.Find("PlayerCanvas").transform.Find("ButtonLeft").gameObject.SetActive(false);
        //GameObject.Find("PlayerCanvas").transform.Find("ButtonReturn").gameObject.SetActive(true);
        eyesContainer.SetActive(true);
        yield return new WaitForSeconds(5);
        //TODO Risas de la muñeca
        ending.GetComponent<SpriteRenderer>().material = opaque;
        yield return new WaitForSeconds(5);
        StartCoroutine(desesperationBar.GetComponent<DesperationBar>().GameOverSequence("Ending", true));

    }
}
