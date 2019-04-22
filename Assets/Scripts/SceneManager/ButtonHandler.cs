using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public GameObject nightmareManager;

    private DisplayImage currentDisplay;

    //private float initialCameraSize;
    //private Vector3 initialCameraPosition;

    
    // Start is called before the first frame update
    void Start()
    {
        
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
        //initialCameraSize = Camera.main.orthographicSize;
        //initialCameraPosition = Camera.main.transform.position;
    }

    public void OnRightClickArrow()
    {
        currentDisplay.CurrentWall = currentDisplay.CurrentWall + 1;
        Saved.player.wall = currentDisplay.CurrentWall;
        currentDisplay.ChangeWall();
    }
    public void OnLefttClickArrow()
    {
        currentDisplay.CurrentWall = currentDisplay.CurrentWall - 1;
        Saved.player.wall = currentDisplay.CurrentWall;
        currentDisplay.ChangeWall();
    }
    public void OnClickReturn()
    {
        /*if (currentDisplay.CurrentState == DisplayImage.State.zoom)
        {
            GameObject.Find("displayImage").GetComponent<DisplayImage>().CurrentState = DisplayImage.State.normal;
            var zoomInObjects = FindObjectsOfType<ZoomInObject>();
            foreach (var zoomInObject in zoomInObjects)
            {
                zoomInObject.gameObject.layer = 0;
            }
            Camera.main.orthographicSize = initialCameraSize;
            Camera.main.transform.position = initialCameraPosition;
        }else*/
        if(currentDisplay.CurrentState == DisplayImage.State.changedView)
        {
            currentDisplay.CurrentState = DisplayImage.State.normal;
            GameObject.Find("PlayerCanvas").transform.Find("ButtonRight").gameObject.SetActive(true);
            GameObject.Find("PlayerCanvas").transform.Find("ButtonLeft").gameObject.SetActive(true);
            GameObject.Find("PlayerCanvas").transform.Find("ButtonReturn").gameObject.SetActive(false);

            GameObject.Find("PlayerCanvas").transform.Find("Masks").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("MaskBackground").gameObject.SetActive(true);
            currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall" + currentDisplay.CurrentWall);
            
            //StartCoroutine( ButtonObstructor());
            currentDisplay.changeCamera();


            
            
        }
        else if(currentDisplay.CurrentState == DisplayImage.State.changedView1)
        {
            
            currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/wall" + currentDisplay.CurrentWall + "/" + currentDisplay.previousSprite);
            currentDisplay.CurrentState = DisplayImage.State.changedView;
            currentDisplay.changeCamera();
        }
        /*if (Saved.triggers.nightmare && GameObject.Find("displayImage").GetComponent<DisplayImage>().CurrentState == DisplayImage.State.normal)
        {
            nightmareManager.SetActive(true);
        }*/

        //manage buttons



    }
    IEnumerator ButtonObstructor()
    {
        GameObject.Find("PlayerCanvas").transform.Find("ButtonObstructor").gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        GameObject.Find("PlayerCanvas").transform.Find("ButtonObstructor").gameObject.SetActive(false);
    }
}
