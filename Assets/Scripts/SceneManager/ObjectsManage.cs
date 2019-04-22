using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectsManage : MonoBehaviour
{
    private  DisplayImage currentDisplay;
    public GameObject[] ObjectsToManage;
    public GameObject[] UiRenderObjects;
    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        //RenderUI();
    }

    public void ManageObjects()
    {
        for (int i = 0; i < ObjectsToManage.Length; i++)
        {
            if (ObjectsToManage[i].name == currentDisplay.GetComponent<SpriteRenderer>().sprite.name)
            {
                ObjectsToManage[i].SetActive(true);
            }
            else
            {
                ObjectsToManage[i].SetActive(false);
            }
        }
    }
    void RenderUI()
    {
        for (int i=0; i<UiRenderObjects.Length;i++)
        {
            UiRenderObjects[i].SetActive(false);
        }
    }
}
