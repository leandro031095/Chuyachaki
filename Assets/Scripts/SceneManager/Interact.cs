using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private DisplayImage currentDisplay;

    bool first = true;
    Vector2 firstPosition;
    DisplayImage.State state;

    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();
    }
    private void Update()
    {
        if (Input.touchCount > 0 )
        {
            if (Input.GetTouch(0).phase != TouchPhase.Began && first)
            {
                first = false;
                firstPosition = Input.GetTouch(0).position;
                
                state = currentDisplay.CurrentState;
            }
            if (Input.GetMouseButtonUp(0) )
            {
                //check if there wasn´t a change of display to avoid a undesired interactions
                if (state == currentDisplay.CurrentState)
                {



                    float x = firstPosition.x - Input.GetTouch(0).position.x;
                    float y = firstPosition.y - Input.GetTouch(0).position.y;
                    //float z = firstPosition.z - Input.GetTouch(0).position.z;

                    if (x == 0 && y == 0 /*&& z == 0*/)
                    {
                        Vector2 rayposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        RaycastHit2D hit = Physics2D.Raycast(rayposition, Vector2.zero, 100);
                        if (hit && hit.transform.tag == "Interactable")
                        {
                            hit.transform.GetComponent<IInteractable>().Interact(currentDisplay);
                        }

                    }
                }
                first = true; ;
            }
        }
        else if(Input.GetMouseButtonDown(0))
        {
            Vector2 rayposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayposition, Vector2.zero, 100);
            if (hit && hit.transform.tag == "Interactable")
            {
                hit.transform.GetComponent<IInteractable>().Interact(currentDisplay);
            }
        }
    }
}
