using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mural : MonoBehaviour, IInteractable
{
    public void Interact(DisplayImage currentDisplay)
    {
        GetComponent<Animator>().SetBool("Active", true);
    }

}
