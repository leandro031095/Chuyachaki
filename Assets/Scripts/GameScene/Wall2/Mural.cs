using System.Collections;
using UnityEngine;

public class Mural : MonoBehaviour, IInteractable
{

    
    public void Interact(DisplayImage currentDisplay)
    {
        if (!Saved.triggers.mural)
        {
            StartCoroutine(Animation());
        }
    }

    void Start()
    {
        if (Saved.triggers.mural)
        {
            transform.position = new Vector3(Saved.triggers.muralPosition[0], Saved.triggers.muralPosition[1], Saved.triggers.muralPosition[2]);
            transform.rotation = new Quaternion(Saved.triggers.muralPosition[3], Saved.triggers.muralPosition[4], Saved.triggers.muralPosition[5],transform.rotation.w);
            gameObject.GetComponent<Animator>().enabled = false;
            //transform.position = new Vector3(-449, 159, transform.position.z);
            //transform.rotation = new Quaternion(0, 0, -15, transform.rotation.w);
        }
    }


    IEnumerator Animation()
    {
        GetComponent<Animator>().SetBool("Active", true);
        yield return new WaitForSeconds(1.5f);
        Saved.triggers.muralPosition[0] = transform.position.x;
        Saved.triggers.muralPosition[1] = transform.position.y;
        Saved.triggers.muralPosition[2] = transform.position.z;
        Saved.triggers.muralPosition[3] = transform.rotation.x;
        Saved.triggers.muralPosition[4] = transform.rotation.y;
        Saved.triggers.muralPosition[5] = transform.rotation.z;
        Saved.triggers.mural = true;

        gameObject.GetComponent<Animator>().enabled = false;
    }

}
