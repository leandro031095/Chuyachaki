using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDisplayer : MonoBehaviour, IInteractable
{
    public GameObject DisplayObject;
    public void Interact(DisplayImage currentDisplay)
    {
        DisplayObject.SetActive(true);
        //DisplayObject.transform.position = new Vector3(GameObject.Find("ZoomCamera").transform.position.x, GameObject.Find("ZoomCamera").transform.position.y, DisplayObject.transform.position.z);
        DisplayObject.transform.position = new Vector3(GameObject.Find("Main Camera").transform.position.x, GameObject.Find("Main Camera").transform.position.y, DisplayObject.transform.position.z);
    }
}
