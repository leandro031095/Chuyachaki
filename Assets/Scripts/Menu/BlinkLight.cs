using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkLight : MonoBehaviour
{
    private GameObject BlinkingLights;
    private GameObject muneco;
    private int counter = 0;

    public GameObject dollContainer;

    void Start()
    {
        int r = Random.Range(0, 4);
        muneco = dollContainer.transform.GetChild(r).gameObject;
        muneco.GetComponent<Image>().enabled = true;
        StartCoroutine(Waiter());
        Saved.triggers.light = false;
    }

    IEnumerator Waiter()
    {
        while (true)
        {
            if (Saved.triggers.light == false)
            {
                ChangeDoll();
                int tiempoEntreParpadeo = Random.Range(3, 4);
                muneco.GetComponent<Image>().enabled = !muneco.GetComponent<Image>().enabled;
                //foreach (Transform child in transform)
                //{
                //    child.GetComponent<Light>().enabled = !child.GetComponent<Light>().enabled;
                    
                //}
                counter++;
                yield return new WaitForSeconds(tiempoEntreParpadeo);
                yield return StartCoroutine(Waiter());
            }
            else { break; }
        }
    }

    private void ChangeDoll()
    {
        if(counter == 3)
        {
            counter = 1;
        }

        if (counter == 1)
        {
            muneco = dollContainer.transform.GetChild(Random.Range(0, 4)).gameObject;
        }
    }
}
