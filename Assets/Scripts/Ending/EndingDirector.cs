using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndingDirector : MonoBehaviour
{
    public GameObject prologo;

    private void Start()
    {
        StartCoroutine(Prologo());
    }

    IEnumerator Prologo()
    {
        Saved.triggers.prelude = false;
        yield return new WaitForSeconds(2);
        prologo.SetActive(true);
        yield return new WaitForSeconds(3);
        StartCoroutine(GetComponent<FadeOut>().ChangeScene("Menu"));
    }
}
