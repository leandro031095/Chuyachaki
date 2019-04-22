using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MobileObject : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler

{
    private Vector3 initialTouchPosition;
    //private float directionX;
    //private float directionY;

    public float velocity = 1;
    [HideInInspector]
    public bool respawn;



    public void OnBeginDrag(PointerEventData eventData)
    {
        respawn = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        {
            if (respawn)
            {
                if (Input.touchCount > 0)
                {
                    Vector2 position = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                    GetComponent<RectTransform>().position = new Vector3(position.x, position.y, 0);
                }
            }
        }
    }





    //private void FixedUpdate()
    //{

    //    if (Input.touchCount > 0)
    //    {
    //        Touch touch = Input.GetTouch(0);
    //        switch (touch.phase)
    //        {
    //            case TouchPhase.Began:
    //                initialTouchPosition = touch.position;
    //                print(touch.position.ToString());
    //                break;

    //            case TouchPhase.Moved:
    //                directionX = touch.position.x - initialTouchPosition.x;
    //                directionY = touch.position.y - initialTouchPosition.y;

    //                XAxisMovement();
    //                YaxisMovement();
    //                break;
    //        }
    //    }
    //}

    //private void YaxisMovement()
    //{
    //    if (directionY > 0)
    //    {
    //        transform.position += new Vector3(0, velocity * Time.deltaTime, 0);
    //    }
    //    if (directionY < 0)
    //    {
    //        transform.position += new Vector3(0, -velocity * Time.deltaTime, 0);
    //    }
    //}

    //private void XAxisMovement()
    //{
    //    if (directionX > 0)
    //    {
    //        transform.position += new Vector3(velocity * Time.deltaTime, 0, 0);
    //    }
    //    if (directionX < 0)
    //    {
    //        transform.position += new Vector3(-velocity * Time.deltaTime, 0, 0);
    //    }
    //}

}
